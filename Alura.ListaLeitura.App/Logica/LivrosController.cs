using Alura.ListaLeitura.App.HTML;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
    public class LivrosController : Controller
    {
        
        private static string CarregaLista(IEnumerable<Livro> livros)
        {
            var conteudoArquivo = HtmlUtils.CarregaArquivoHTML("para-ler");

            foreach (var livro in livros)
            {
                conteudoArquivo = conteudoArquivo.Replace("#NOVO-ITEM#", $"<li>{livro.Titulo} - {livro.Autor}</li>#NOVO-ITEM#");
            }
            return conteudoArquivo.Replace("#NOVO-ITEM#", "");
        }
        public IActionResult ParaLer()
        {
            var _repo = new LivroRepositorioCSV();
            ViewBag.Livros = _repo.ParaLer.Livros; 
            return View("lista");
            
        }
        public IActionResult Lendo()
        {
            var _repo = new LivroRepositorioCSV();

            ViewBag.Livros = _repo.Lendo.Livros;
            return View("lista");

        }
        public IActionResult Lidos()
        {
            var _repo = new LivroRepositorioCSV();
            ViewBag.Livros = _repo.Lidos.Livros;
            return View("lista");

        }
        public string Detalhes(int id)
        {           
            var repo = new LivroRepositorioCSV();
            var livro = repo.Todos.First(l => l.Id == id);
            return livro.Detalhes();
        }

        public string Teste()
        {
            return "Resposta teste";
        }

    }
}
