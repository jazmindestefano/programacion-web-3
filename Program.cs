using RegistroDeVentas.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IVentaService, VentaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Presentacion}/{action=Bienvenido}/{id?}");

app.Run();

//app.MapControllerRoute(
//    name: "diaMes",
//    pattern: "{controller}/{action}/{dia}/{mes}");

//si solo quiero que la regla re routing aplique a un controlador en particular
//app.MapControllerRoute(
//    name: "esFeriado",
//    pattern: "Feriados/{action=EsFeriado}/{dia}/{mes}",
//    defaults: new { controller = "Feriados" });
