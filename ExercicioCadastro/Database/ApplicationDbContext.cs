using ExercicioCadastro.Models;
using Microsoft.EntityFrameworkCore;


namespace ExercicioCadastro.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Aluno> Alunos {get; set;}


        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base (options){}

    }
}