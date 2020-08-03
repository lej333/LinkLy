using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LinkLy.Models;

namespace LinkLy.Areas.Admin.Controllers
{
    /// <summary>
    /// Temporary controller for modules which are not built yet (placeholder)
    /// </summary>
    [Authorize]
    [Area("Admin")]
    public class TodoController : Controller
    {
        public TodoController() {
        }

        public async Task<IActionResult> Index(string title)
        {
            Todo todo = new Todo()
            {
                Title = title
            };
            return View(todo);
        }
    }
}
