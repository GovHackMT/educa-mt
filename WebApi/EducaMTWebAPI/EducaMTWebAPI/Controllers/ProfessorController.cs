using EducaMTWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace EducaMTWebAPI.Controllers
{
    [RoutePrefix("professor")]
    public class ProfessorController: ApiController
    {
        private DAL acesso;

        public ProfessorController()
        {
            acesso = new DAL();

        }

        [Route("alunos")]
        [HttpGet]
        public IEnumerable<Aluno> GetAlunos()
        {
            return acesso.GetTodosAlunos();
        }

        [Route("{id}/disciplinas")]
        [HttpGet]
        public IEnumerable<Disciplina> GetDisciplinasPorProfessor(int id)
        {
            return acesso.GetDisciplinasPorProfessor(id);
        }

        [Route("{id}/disciplina/{disciplinaId}/diario-inicial")]
        [HttpGet]
        public IEnumerable<Diario> GetDiarioInicial(int id, int disciplinaId)
        {
            return acesso.GetDiarioInicial(id, disciplinaId);
        }

        [Route("{id}/disciplina/{disciplinaId}/diario")]
        [HttpPost]
        public string EnviarDiario(IEnumerable<Diario> dto, int id, int disciplinaId)
        {
            acesso.EnviarDiario(dto, disciplinaId);
            return "ok";
        }
    }
}