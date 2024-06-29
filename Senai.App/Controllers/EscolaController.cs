using Microsoft.AspNetCore.Mvc;
using Senai.Domain.DTos;
using Senai.Service.Interfaces;


namespace Senai.App.Controllers
{
    public class EscolaController : Controller
    {

        private readonly IEstadoService _estadoService;

        public EscolaController(IEstadoService estadoService)
        {
            _estadoService = estadoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Form()
        {
            var model = new EscolaDto();
            //ViewBag.Estado = await _estadoService.BuscarEstados();
            return View();
        }

        [HttpPost]
        public IActionResult Form(EscolaDto model)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }
    }
}
