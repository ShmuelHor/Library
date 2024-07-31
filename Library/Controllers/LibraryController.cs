using Library.Data;
using Library.Models;
using Library.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace Library.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ILibraryService _Service;

        public LibraryController(ILibraryService Service)
        {
            _Service = Service;
        }
        async public Task<IActionResult> Index() =>
            View(await _Service.GetAllLibrary());
        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(LibraryModel libraryModel)
        {
             await _Service.InsertLibrary(libraryModel.NameGenre);
            return View("Index", await _Service.GetAllLibrary());
        }

        public async Task<IActionResult> Delete(long id)
        {
            await _Service.DeletetLibrary(id);
            return View("Index", await _Service.GetAllLibrary());
        }






    }
}
