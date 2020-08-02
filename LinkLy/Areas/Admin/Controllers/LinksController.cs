using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LinkLy.Interfaces;
using LinkLy.Models;
using Microsoft.AspNetCore.Authorization;
using Linkly.Data.Repositories;
using LinkLy.Models.ViewModels;

namespace LinkLy.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class LinksController : Controller
    {
        private readonly IShortner _shortner;
        private readonly LinkRepository _linkRepository;
        private readonly DomainRepository _domainRepository;

        public LinksController(IShortner shortner, LinkRepository repository, DomainRepository domainRepository) {
            _shortner = shortner;
            _linkRepository = repository;
            _domainRepository = domainRepository;
        }

        public async Task<IActionResult> Index(LinksViewModel model)
        {
            model.Links = await _linkRepository.GetPaged(model.Search);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id) {
            LinkDetailsViewModel model = new LinkDetailsViewModel()
            {
                Link = (id == 0 ? new Link() : await _linkRepository.Get(id)),
                Domains = await _domainRepository.GetAllWithDefault()
            };
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(LinkDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Link.Id != 0) {
                    Link link = await _linkRepository.Get(model.Link.Id);
                    if (link == null) {
                        return NotFound();
                    }
                    link.Domain = model.Link.Domain;
                    link.Name = model.Link.Name;
                    link.Uri = model.Link.Uri;
                    await _linkRepository.Update(link);
                    return RedirectToAction("Index");
                }

                await _linkRepository.Add(model.Link);
                return RedirectToAction("Index");
            }
            else
            {
                LinkDetailsViewModel modelState = new LinkDetailsViewModel()
                {
                    Link = model.Link,
                    Domains = await _domainRepository.GetAllWithDefault()
                };
                return View(modelState);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            Link link = await _linkRepository.Get(id);
            if (link == null) {
                return NotFound();
            }
            return View(link);
        }

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _linkRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
