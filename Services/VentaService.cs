﻿using RegistroDeVentas.Entidades;

namespace RegistroDeVentas.Services;

public interface IVentaService
{
    void RegistrarVenta(Venta venta);
    List<Venta> ObtenerVentas();
    List<Venta> ObtenerVentasOrdenadasAscendente();
    List<Venta> ObtenerVentasOrdenadasDescendente();
}


public class VentaService : IVentaService
{
    private static List<Venta> _ventas = new List<Venta>();

    public void RegistrarVenta(Venta venta)
    {
        venta.TotalVenta = venta.CantidadVendida * venta.PrecioUnitario;
        venta.IdVenta = _ventas.Count == 0
                        ? 1 :
                        _ventas.Max(v => v.IdVenta) + 1;

        _ventas.Add(venta);
    }

    public List<Venta> ObtenerVentas()
    {
        return _ventas
            .OrderBy(v => v.IdVenta)
            .ToList();
    }

    public List<Venta> ObtenerVentasOrdenadasAscendente()
    {
        return _ventas.OrderBy(v => v.TotalVenta).ToList();
    }

    public List<Venta> ObtenerVentasOrdenadasDescendente()
    {
        return _ventas.OrderByDescending(v => v.TotalVenta).ToList();
    }
}
