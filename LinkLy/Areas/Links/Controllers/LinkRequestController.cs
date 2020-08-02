using System.Threading.Tasks;
using LinkLy.Data;
using LinkLy.Interfaces;
using LinkLy.Models;
using Microsoft.AspNetCore.Mvc;
using Shyjus.BrowserDetection;
using Shyjus.BrowserDetection.Browsers;
using System;

namespace LinkLy.Controllers
{
    [Area("Links")]
    public class LinkRequestController : Controller
    {
        private readonly IBrowserDetector _browserDetector;
        private readonly ApplicationDbContext _db;
        private readonly IShortner _shortner;
        private readonly IVisitor _visitor;

        public LinkRequestController(IBrowserDetector browserDetector, ApplicationDbContext db, IShortner shortner, IVisitor visitor) {
            _browserDetector = browserDetector;
            _db = db;
            _shortner = shortner;
            _visitor = visitor;
        }

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

                await _db.Clicks.AddAsync(click);

                link.TotalClicks++;
                link.LastClick = DateTime.Now;

                await _db.SaveChangesAsync();
            }

            return Redirect(link.Uri);
        }
    }
}
