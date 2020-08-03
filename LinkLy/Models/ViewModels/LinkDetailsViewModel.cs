using System.Collections.Generic;
using LinkLy.Models.DataModels;
using System.Linq;
using Newtonsoft.Json;
using System;

namespace LinkLy.Models.ViewModels
{
    public class LinkDetailsViewModel
    {
        public Link Link { get; set; }
        public List<Domain> Domains { get; set; }

        /// <summary>
        /// Statistics properties
        /// </summary>
        public string CountriesLabels { get; set; }
        public string CountriesValues { get; set; }
        public string DeviceTypesLabels { get; set; }
        public string DeviceTypesValues { get; set; }
        public string BrowsersLabels { get; set; }
        public string BrowsersValues { get; set; }
        public string ClicksLabels { get; set; }
        public string ClicksValues { get; set; }

        /// <summary>
        /// Generates statistics based on Clicks list object
        /// </summary>
        /// TODO: Test and optimize queries with big count of data, for this version its ok. 
        public void GenerateStatistics()
        {
            if (Link == null || Link.Clicks == null) {
                return;
            }

            List<StatisticsItem> countries = Link.Clicks.GroupBy(l => l.Country).Select(l => new StatisticsItem { Name = l.Key, Count = l.Count()}).OrderBy(l => l.Name).ToList();
            CountriesLabels = JsonConvert.SerializeObject(countries.Select(c => c.Name).ToList());
            CountriesValues = JsonConvert.SerializeObject(countries.Select(c => c.Count).ToList());

            List<StatisticsItem> deviceTypes = Link.Clicks.GroupBy(l => l.DeviceType).Select(l => new StatisticsItem { Name = l.Key, Count = l.Count() }).OrderBy(l => l.Name).ToList();
            DeviceTypesLabels = JsonConvert.SerializeObject(deviceTypes.Select(c => c.Name).ToList());
            DeviceTypesValues = JsonConvert.SerializeObject(deviceTypes.Select(c => c.Count).ToList());

            List<StatisticsItem> browsers = Link.Clicks.GroupBy(l => l.BrowserName).Select(l => new StatisticsItem { Name = l.Key, Count = l.Count() }).OrderBy(l => l.Name).ToList();
            BrowsersLabels = JsonConvert.SerializeObject(browsers.Select(c => c.Name).ToList());
            BrowsersValues = JsonConvert.SerializeObject(browsers.Select(c => c.Count).ToList());

            var clicks = from month in Enumerable.Range(0, 12)
                let key = new { DateTime.Now.AddMonths(-month).Year, DateTime.Now.AddMonths(-month).Month }
                join click in Link.Clicks on key
                        equals new
                        {
                            click.CreationDate.Year,
                            click.CreationDate.Month
                        } into g
                orderby key.Year, key.Month
                select new DateStatisticsItem { Year = key.Year, Month = key.Month, Count = g.Count() };

            ClicksLabels = JsonConvert.SerializeObject(clicks.Select(c => c.Year.ToString() + '-' + c.Month.ToString()).ToList());
            ClicksValues = JsonConvert.SerializeObject(clicks.Select(c => c.Count).ToList());
        }
    }
}
