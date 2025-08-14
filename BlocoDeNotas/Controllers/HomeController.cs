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
        
        [HttpPost]
        public JsonResult SalvarNota(int? id, string conteudo)
        {       
            Nota nota;

            if (id.HasValue)
            {
                nota = _context.Notas.Find(id.Value);

                if (nota == null)

                    return Json(new { sucesso = false, mensagem = "Nota não encontrada" });

                nota.Conteudo = conteudo;
                nota.DataAtualizacao = DateTime.Now;

            }
            else
            {
                nota = new Nota
                {
                    Conteudo = conteudo,
                    DataAtualizacao = DateTime.Now
                };

                _context.Notas.Add(nota);
            }

            _context.SaveChanges();

            return Json(new
            {
                sucesso = true,
                id = nota.Id,
                resumo = (conteudo.Length > 20 ? conteudo.Substring(0, 20) + "..." : conteudo)
            });
        }

        [HttpGet]
        public JsonResult ObterNota(int id)
        {
            var nota = _context.Notas.FirstOrDefault(n => n.Id == id);
            return Json(new {conteudo = nota?.Conteudo });
        }

        [HttpDelete]
        [Route("Home/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var nota = _context.Notas.Find(id);
            if (nota == null)
            {
                return NotFound();
            }

            _context.Notas.Remove(nota);
            _context.SaveChanges();

            return Ok();
        }
    }
}
