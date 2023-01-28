namespace FilmesApi.Data.Dtos
{
    public class ReadFilmeDto
    {
        public string Titulo { get; set; }

        public string Genero { get; set; }

        public string Duracao { get; set; }

        public DateTime HoeraDaConsulta { get; set; } = DateTime.Now;
    }
}
