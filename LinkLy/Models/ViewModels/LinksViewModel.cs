using System.Collections.Generic;
using LinkLy.Models.DataModels;
using System.Linq;
using System;
using LinkLy.Helpers;

namespace LinkLy.Models.ViewModels
{
    public class LinksViewModel
    {
        public List<Link> Links { get; set; }

        public string Search { get; set; }

        public PaginatedList<Link> Paged { get; set; }

        public int CalculateClicks(int days, List<Click> clicks)
        {
            if (clicks == null)
            {
                return 0;
            }

            return (from c in clicks where c.CreationDate >= DateTime.Now.AddDays(-days) select c.Id).Count();
        }
    }
}
