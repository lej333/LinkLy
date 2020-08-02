using System.Collections.Generic;

namespace LinkLy.Models.ViewModels
{
    public class LinkDetailsViewModel
    {
        public Link Link { get; set; }
        public List<Domain> Domains { get; set; }
    }
}
