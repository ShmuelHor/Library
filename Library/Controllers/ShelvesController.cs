using Library.Service;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class ShelvesController : Controller
    {
        private readonly IShelvesService _Service;

        public ShelvesController(IShelvesService Service)
        {
            _Service = Service;
        }
        async public Task<IActionResult> Index(long id) =>
            View(await _Service.GetAllShelves(id));

        public async Task<IActionResult> Delete(long id)
        {
            await _Service.DeletetShelves(id);
            return View("Index", await _Service.GetAllShelves(id));
        }
    }
}
