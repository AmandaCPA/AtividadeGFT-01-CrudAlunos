using System.ComponentModel.DataAnnotations;

namespace ExercicioCadastro.Models
{
    public class Aluno
    {
        [Key]
        public int MatriculaId {get; set;}
        public string Nome {get; set;}
        public string Sobrenome {get; set;}
        public string Cpf {get; set;}
        public string Curso {get; set;}
    }
}