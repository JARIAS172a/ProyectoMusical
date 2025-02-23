using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Models.Data;
using Models.ViewModels;
using System.Security.Claims;

namespace ProyectoVentaMusical.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ComprarController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ComprarController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string objBuscar)
        {

            var canciones = from c in _context.Canciones select c;
            if (!string.IsNullOrEmpty(objBuscar))
            {
                canciones = canciones.Where(c => c.NombreCancion.Contains(objBuscar));
            }

            var lstFiltrada = await canciones.ToListAsync();
            CarritoVM viewModel = new CarritoVM
            {
                ListaCanciones = lstFiltrada,
                CarritoCompras = new CarritoCompras()
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> anadirACarrito(CarritoVM carritoVM)
        {
            CarritoCompras _carrito = new CarritoCompras();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var usuario = await _userManager.FindByIdAsync(userId);
            if (usuario != null)
            {
                _carrito.IdUsuario = usuario.Id;
                _carrito.NombreUsuario = usuario.UserName;
            }

            _carrito.FechaCompra = DateTime.Now;
            decimal cantidad = carritoVM.Cancion.CantidadDisponible;
            decimal precio = carritoVM.Cancion.Precio;
            decimal _subtotal = cantidad * precio;
            _carrito.Subtotal = _subtotal;
            _carrito.Total = _subtotal;
            _carrito.TipoPago = carritoVM.CarritoCompras.TipoPago;

            _context.CarritoCompras.Add(_carrito);
            _context.SaveChanges();

            DetalleCarrito detalleCarrito = new DetalleCarrito();
            int ultimoIdCarrito = _carrito.IdCarrito;

            detalleCarrito.IdCarrito = ultimoIdCarrito;
            detalleCarrito.CodigoCancion = carritoVM.Cancion.CodigoCancion;
            detalleCarrito.Cantidad = carritoVM.Cancion.CantidadDisponible;
            detalleCarrito.PrecioUnitario = carritoVM.Cancion.Precio;
            detalleCarrito.Total = _subtotal;
            _context.DetalleCarrito.Add(detalleCarrito);
            _context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }

    }
}
