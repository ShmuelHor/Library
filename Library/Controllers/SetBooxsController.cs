using Library.Service;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class SetBooxsController : Controller
    {
        private readonly IBooxsService _Service;

        public SetBooxsController(IBooxsService Service) => _Service = Service;
        async public Task<IActionResult> Index(long id) =>
            View(await _Service.GetAllBooxs(id));
    }
}
