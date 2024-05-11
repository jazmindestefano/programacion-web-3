using Microsoft.AspNetCore.Mvc;

namespace RegistroDeVentas.Controllers;
public class Presentacion : Controller
{
    public IActionResult Bienvenido()
    {
        return View();
    }
}