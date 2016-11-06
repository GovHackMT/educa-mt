using EducaMTWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace EducaMTWebAPI.Controllers
{
    [RoutePrefix("responsavel")]
    public class ResponsavelController:ApiController
    {
        private DAL acesso;

        public ResponsavelController()
        {
            acesso = new DAL();
        }

        [Route("{id}/filhos")]
        [HttpGet]
        public IEnumerable<Filho> GetFilhos(int id)
        {
            return acesso.GetFilhosPorResponsavel(id);
        }

        [Route("{id}/filho/{alunoId}/relatorio")]
        [HttpGet]
        public IEnumerable<RelatorioPresenca> GetRelatorioPresenca(int id, int alunoId)
        {
            return acesso.GetRelatoioPresenca(alunoId);
        }

        [Route("aluno/{id}")]
        [HttpGet]
        public Aluno GetAluno(int id)
        {
            return acesso.GetAluno(id);
        }
    }
}