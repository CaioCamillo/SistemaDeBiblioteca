namespace SistemaDeBiblioteca.Models
{
    public class Livro
    {
        public string Nome { get; set; }
        public string Autor { get; set; }
        public bool Reservado { get; set; }
        public string Reservador { get; set; }
        public DateTime? DataReserva { get; set; }
    }
}
