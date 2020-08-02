using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace LinkLy.Extensions
{
    public static class IEnumerableExtension
    {
        public static IEnumerable<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> items, string selectedValue) {
            if (string.IsNullOrEmpty(selectedValue)) selectedValue = "";
            return from item in items
                   select new SelectListItem
                   {
                       Text = item.GetPropertyValue("Name"),
                       Value = item.GetPropertyValue("Name"),
                       Selected = item.GetPropertyValue("Name").Equals(selectedValue.ToString())
                   };
        }
    }
}
