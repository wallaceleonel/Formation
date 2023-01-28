using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos
{
    public class UpdateFilmeDto
    {
        [Required(ErrorMessage = "titulo do fime e obrigatorio")]
        [MaxLength(500, ErrorMessage = "O titulo não pode ter mais do que 500 caracteres")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O gênero do filme é obrigatorio")]
        [StringLength(50, ErrorMessage = "O gênero não pode ter mais do que 50 caracteres")]
        public string Genero { get; set; }
        [Required]
        [Range(70, 600, ErrorMessage = "duração deve ter entre 70 e 600 minutos")]
        public int Duracao { get; set; }
    }
}
