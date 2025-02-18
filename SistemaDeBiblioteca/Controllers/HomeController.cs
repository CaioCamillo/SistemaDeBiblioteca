using Microsoft.AspNetCore.Mvc;
using SistemaDeBiblioteca.Models;
using System.Diagnostics;

namespace SistemaDeBiblioteca.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }

}

public class BibliotecaController : Controller
{
    private static List<Livro> livros = new List<Livro>()
    {
        new Livro {Nome = "O Pequeno Príncipe", Autor = "Antoine de Saint-Exupéry", Reservado = false},
        new Livro {Nome = "Romeu E Julieta", Autor = "William Shakespeare", Reservado = false},
        new Livro {Nome = "Dom Quixote De La mancha", Autor = "Miguel de Cervantes", Reservado = true, Reservador = "Joao", DataReserva = new DateTime(2025, 2, 18, 14, 30, 00)},
        new Livro {Nome = "Harry Potter e a Pedra Filosofa", Autor = " J K Rowling", Reservado = true, Reservador = "Gabriel", DataReserva = new DateTime(2025, 1, 20, 10, 20, 20)},
        new Livro {Nome = "Harry Potter e a Câmara Secreta", Autor = " J K Rowling", Reservado = false},
        new Livro {Nome = "Harry Potter e o Prisioneiro de Azkabana", Autor = " J. K. Rowling", Reservado = true, Reservador = "Rafael", DataReserva = new DateTime (2025, 1, 10, 16, 10, 30)},
        new Livro {Nome = "Harry Potter e o Cálice de Fogo", Autor = " J K Rowling", Reservado = false},
        new Livro {Nome = "Harry Potter e a Ordem da Fênix", Autor = " J K Rowling", Reservado = false},
        new Livro {Nome = "Harry Potter e o Enigma do Príncipe", Autor = " J K Rowling", Reservado = false},
        new Livro {Nome = "Harry Potter e as Relíquias da Morte", Autor = " J K Rowling", Reservado = false},
        new Livro {Nome = "Harry Potter e a Criança Amaldiçoada", Autor = " J K Rowling", Reservado = false},
        new Livro {Nome = "Ao Farol", Autor = "Virginia Woolf", Reservado = true, Reservador = "Jorge", DataReserva = new DateTime(2025, 2, 05, 12, 30, 00)},
    };

     public IActionResult Index()
    {
        return View("~/Views/Home/Index.cshtml");
    }

    public IActionResult Adicionar()
    {
        return View("~/Views/Home/Privacy.cshtml");
    }

    [HttpPost]
    public IActionResult Adicionar(Livro novoLivro)
    {
        if (novoLivro != null && !string.IsNullOrEmpty(novoLivro.Nome) && !string.IsNullOrEmpty(novoLivro.Autor))
        {
            livros.Add(novoLivro);

            TempData["MensagemSucesso"] = "Livro adicionado com sucesso!";

            return RedirectToAction("Privacy", "Home");
        }

        TempData["MensagemErro"] = "Erro ao adicionar livro!";
        return RedirectToAction("~/Views/Home/Privacy.cshtml");
    }


    [HttpPost]
    public IActionResult ReservarLivro(string nomeLivro, string nomeUsuario)
    {
        var livro = livros.Find(l => l.Nome == nomeLivro);
        if (livro != null && !livro.Reservado)
        {
            livro.Reservado = true;
            livro.Reservador = nomeUsuario;
            livro.DataReserva = DateTime.Now;
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Pesquisar(string nome)
    {
        List<Livro> resultado;

        if (string.IsNullOrWhiteSpace(nome))
        {
            resultado = livros;
        }
        else
        {
            resultado = livros.FindAll(l =>
                l.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase) ||
                l.Autor.Contains(nome, StringComparison.OrdinalIgnoreCase));
        }

        ViewBag.PesquisaRealizada = true;
        return View("~/Views/Home/Index.cshtml", resultado);
    }
}