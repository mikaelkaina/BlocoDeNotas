using System.Diagnostics;
using BlocoDeNotas.Data;
using BlocoDeNotas.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlocoDeNotas.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var notas = _context.Notas.
                OrderByDescending(n => n.DataAtualizacao)
                .ToList();
            return View(notas);
        }
    }

}
