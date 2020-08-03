using System.Collections.Generic;
using LinkLy.Models.DataModels;
using System.Linq;
using System;
using LinkLy.Helpers;

namespace LinkLy.Models.ViewModels
{
    /// <summary>
    /// Viewmodel created for index view of links
    /// PaginatedList class is used for pagination of links
    /// </summary>
    public class LinksViewModel
    {
        public List<Link> Links { get; set; }

        public string Search { get; set; }

        public PaginatedList<Link> Paged { get; set; }

        /// <summary>
        /// Calculates count of clicks within period span from now to x days in the past
        /// </summary>
        /// <param name="days"></param>
        /// <param name="clicks"></param>
        /// <returns></returns>
        public int CalculateClicks(int days, List<Click> clicks)
        {
            if (clicks == null)
            {
                return 0;
            }

            return (from c in clicks
                    where c.CreationDate >= DateTime.Now.AddDays(-days)
                    select c.Id).Count();
        }
    }
}
