using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Models;
using Models.Data;
using Models.ViewModels;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoVentaMusical.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ComprarController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ComprarController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment, UserManager<ApplicationUser> userManager)
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var usuario = await _userManager.FindByIdAsync(userId);

            if (usuario == null)
            {
                return NotFound("Usuario no encontrado.");
            }

            // Verifica si ya existe un carrito para este usuario
            var carritoExistente = _context.CarritoCompras
                                           .FirstOrDefault(c => c.IdUsuario == usuario.Id);

            if (carritoExistente == null)
            {
                // Crea un nuevo carrito si no existe
                CarritoCompras nuevoCarrito = new CarritoCompras
                {
                    IdUsuario = usuario.Id,
                    NombreUsuario = usuario.UserName,
                    FechaCompra = DateTime.Now,
                    TipoPago = carritoVM.CarritoCompras.TipoPago,
                    Subtotal = 0,
                    Total = 0
                };

                _context.CarritoCompras.Add(nuevoCarrito);
                await _context.SaveChangesAsync();
                carritoExistente = nuevoCarrito;
            }

            // Agrega un nuevo detalle de carrito
            DetalleCarrito nuevoDetalle = new DetalleCarrito
            {
                IdCarrito = carritoExistente.IdCarrito,
                CodigoCancion = carritoVM.Cancion.CodigoCancion,
                Cantidad = carritoVM.Cancion.CantidadDisponible,
                PrecioUnitario = carritoVM.Cancion.Precio,
                Total = carritoVM.Cancion.CantidadDisponible * carritoVM.Cancion.Precio
            };

            _context.DetalleCarrito.Add(nuevoDetalle);

            // Actualiza los totales del carrito
            carritoExistente.Subtotal += nuevoDetalle.Total;
            carritoExistente.Total += nuevoDetalle.Total; 

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public async Task<IActionResult> CarritoCompras()
        {
            var userId = _userManager.GetUserId(User);

            // Encontrar el carrito de compras para el usuario logueado

            var carrito = _context.CarritoCompras.FirstOrDefault(c => c.IdUsuario == userId);

            if (carrito == null)
            {
                ViewBag.Message = "Debes ingresar canciones a tu carrito de compras.";
                return View();
            }

            var detalles = _context.DetalleCarrito
                .Include(dc => dc.CodigoCancionNavigation)
                .Where(dc => dc.IdCarrito == carrito.IdCarrito)
                .ToList();

            var canciones = detalles.Select(dc => dc.CodigoCancionNavigation).Distinct().ToList();

            var viewModel = new CarritoMostrarVM
            {
                CarritoCompras = carrito,
                DetalleCarrito = detalles,
                ListaCanciones = canciones
            };


            return View(viewModel);

        }


        [HttpPost]
        public async Task<IActionResult> CarritoCompras(int opcion)
        {
            //switch (payment)
            //{
            //    case "Tarjeta de Crédito":
            //        // Lógica para procesar el pago con tarjeta
            //        break;
            //    case "Transferencia Bancaria":
            //        // Lógica para procesar la transferencia
            //        break;
            //    case "Dinero Disponible":
            //        // Lógica para verificar y usar el dinero disponible
            //        break;
            //}
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Pagar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Pagar(int opcion)
        {
            return View();
        }


    }
}
