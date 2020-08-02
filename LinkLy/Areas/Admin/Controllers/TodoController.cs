using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LinkLy.Models;

namespace LinkLy.Areas.Admin.Controllers
{
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
