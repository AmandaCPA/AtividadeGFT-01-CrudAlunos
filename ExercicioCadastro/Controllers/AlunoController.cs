using System;
using System.Linq;
using ExercicioCadastro.Database;
using ExercicioCadastro.Models;
using Microsoft.AspNetCore.Mvc;


namespace ExercicioCadastro.Controllers
{

    public class AlunoController : Controller
    {

    private readonly ApplicationDbContext database;    

    public AlunoController(ApplicationDbContext database)
    {
        this.database = database;
    }

        public IActionResult Index()
        {
            var aluno = database.Alunos.ToList();
            return View(aluno);
        }


        public IActionResult Cadastrar()
        {
            return View();
        }

       public IActionResult Editar(int id)
        {
        	Aluno aluno = database.Alunos.First(register => register.MatriculaId == id);
	        return View("Cadastrar", aluno); 
        }

        public IActionResult Deletar(int id){
        Aluno aluno = database.Alunos.First(register => register.MatriculaId == id);
        database.Alunos.Remove(aluno);
        database.SaveChanges();
        return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Salvar(Aluno aluno){
        if(aluno.MatriculaId == 0)
        {
            database.Alunos.Add(aluno);
        }
        else
        {
            Aluno alunoDoBanco = database.Alunos.First(register => register.MatriculaId == aluno.MatriculaId);

            alunoDoBanco.Nome = aluno.Nome;
            alunoDoBanco.Sobrenome = aluno.Sobrenome;
            alunoDoBanco.Cpf = aluno.Cpf;
            alunoDoBanco.Curso = aluno.Curso;
            }
        
            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
