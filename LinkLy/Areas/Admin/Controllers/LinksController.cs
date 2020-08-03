using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LinkLy.Interfaces;
using LinkLy.Models.DataModels;
using Microsoft.AspNetCore.Authorization;
using Linkly.Data.Repositories;
using LinkLy.Models.ViewModels;
using LinkLy.Helpers;
using System.Linq;

namespace LinkLy.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class LinksController : Controller
    {
        private readonly IShortner _shortner;
        private readonly LinkRepository _linkRepository;
        private readonly DomainRepository _domainRepository;
        private readonly Defaults _defaults;

        public LinksController(IShortner shortner, LinkRepository repository, DomainRepository domainRepository, Defaults defaults) {
            _shortner = shortner;
            _linkRepository = repository;
            _domainRepository = domainRepository;
            _defaults = defaults;
        }

        // GET
        public async Task<IActionResult> Index(LinksViewModel model, int? pageNumber, string search, string currentSearch)
        {
            if (search != null)
            {
                pageNumber = 1;
            }
            else {
                search = currentSearch;
            }
            ViewData["CurrentSearch"] = search;

            IQueryable<Link> query = _linkRepository.GetAllQuery(search);
            PaginatedList<Link> paged = await PaginatedList<Link>.CreateAsync(query, pageNumber ?? 1, _defaults.PageSize);

            model.Links = paged.Items;
            model.Paged = paged;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id) {
            LinkDetailsViewModel model = new LinkDetailsViewModel()
            {
                Link = (id == 0 ? new Link() : await _linkRepository.Get(id)),
                Domains = await _domainRepository.GetAllWithDefault()
            };
            model.GenerateStatistics();
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(LinkDetailsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                LinkDetailsViewModel modelState = new LinkDetailsViewModel()
                {
                    Link = model.Link,
                    Domains = await _domainRepository.GetAllWithDefault()
                };
                model.GenerateStatistics();
                return View(modelState);
            }

            if (model.Link.Id != 0)
            {
                Link link = await _linkRepository.Get(model.Link.Id);
                if (link == null)
                {
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
