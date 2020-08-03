using System.Threading.Tasks;
using LinkLy.Data;
using LinkLy.Interfaces;
using LinkLy.Models.DataModels;
using LinkLy.Models;
using Microsoft.AspNetCore.Mvc;
using Shyjus.BrowserDetection;
using Shyjus.BrowserDetection.Browsers;
using System;
using Linkly.Data.Repositories;

namespace LinkLy.Controllers
{
    [Area("Links")]
    public class LinkRequestController : Controller
    {
        private readonly IBrowserDetector _browserDetector;
        private readonly ApplicationDbContext _db;
        private readonly IShortner _shortner;
        private readonly IVisitor _visitor;
        private readonly ClickRepository _clickRepository;

        public LinkRequestController(IBrowserDetector browserDetector, ApplicationDbContext db, IShortner shortner, IVisitor visitor, ClickRepository clickRepository) {
            _browserDetector = browserDetector;
            _db = db;
            _shortner = shortner;
            _visitor = visitor;
            _clickRepository = clickRepository;
        }

        /// <summary>
        /// Process link request
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="register"></param>
        /// <returns></returns>
        /// TODO: use LinkRepository instead of _db (needs a new function without ownership check)
        public async Task<IActionResult> Index(string guid, bool register = true)
        {
            if (guid == null) {
                return NotFound();
            }

            int id = _shortner.RestoreGuid(guid);
            Link link = await _db.Links.FindAsync(id);
            if (link == null) {
                return NotFound();
            }

            if (register) { 
                string ipNumber = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                IpInfo ipInfo = _visitor.GetIpInfo(ipNumber);
                IBrowser browser = _browserDetector.Browser;
                Click click = new Click();
                click.LinkId = link.Id;

                click.BrowserName = browser.Name;
                click.BrowserVersion = browser.Version;
                click.OSName = browser.OS;
                click.DeviceType = browser.DeviceType;

                click.CreationIpNumber = ipInfo.IpNumber;
                click.City = ipInfo.City;
                click.Country = ipInfo.Country;
                click.HostName = ipInfo.HostName;
                click.Location = ipInfo.Location;
                click.Organisation = ipInfo.Organisation;
                click.Postal = ipInfo.Postal;
                click.Region = ipInfo.Region;

                await _clickRepository.Add(click);

                link.TotalClicks++;
                link.LastClick = DateTime.Now;

                await _db.SaveChangesAsync();
            }

            return Redirect(link.Uri);
        }
    }
}
