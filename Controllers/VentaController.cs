using Microsoft.AspNetCore.Mvc;
using RegistroDeVentas.Models;
using RegistroDeVentas.Services;

namespace RegistroDeVentas.Controllers;
public class VentaController : Controller
{
    private readonly IVentaService _ventasService;

    public VentaController(IVentaService ventasService)
    {
        _ventasService = ventasService;
    }

    public IActionResult RegistrarVenta()
    {
        return View();
    }

    [HttpPost]
    public IActionResult RegistrarVenta(VentaModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        _ventasService.RegistrarVenta(model.MapearAEntidad());

        return RedirectToAction("Resultados");
    }

    public IActionResult Resultados()
    {
        var ventas = _ventasService.ObtenerVentas();

         var VentasModelLista = VentaModel.MapearAListaModel(ventas);

        return View(VentasModelLista);
    }
}