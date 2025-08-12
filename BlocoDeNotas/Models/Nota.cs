namespace BlocoDeNotas.Models
{
    public class Nota
    {
        public int Id { get; set; }
        public string Conteudo { get; set; } = string.Empty;
        public DateTime DataAtualizacao { get; set; }
    }
}
