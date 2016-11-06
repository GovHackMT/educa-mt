using EducaMTWebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TeleSharp.TL;
using TLSharp.Core;

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

        [Route("autenticar-telegram")]
        [HttpPost]
        public async Task<string> AutenticarTelegram()
        {
            var apiId = 92426;
            var apiHash = "77135e73f47f49813618b53e8c51ee89";
            var client = new TelegramClient(apiId, apiHash);
            await client.ConnectAsync();
            var hash = await client.SendCodeRequestAsync("+5565992291443");
            return hash;
        }

        [Route("enviar-telegram")]
        [HttpPost]
        public async Task Enviartelegram(EnviarTelegramDto dto)
        {
            var apiId = 92426;
            var apiHash = "77135e73f47f49813618b53e8c51ee89";
            var client = new TelegramClient(apiId, apiHash);
            await client.ConnectAsync();
            var user = await client.MakeAuthAsync("+5565992291443", dto.Hash, dto.Code);
            var result = await client.GetContactsAsync();

            //find recipient in contacts
            var userR = result.users.lists
                .Where(x => x.GetType() == typeof(TLUser))
                .Cast<TLUser>()
                .FirstOrDefault(x => x.phone == "5565981250768");

            //send message
            await client.SendMessageAsync(new TLInputPeerUser() { user_id = userR.id }, dto.Mensagem);
        }

        [Route("enviar-sms")]
        [HttpPost]
        public async Task<string> EnviarSMS(envioSmsDto dto)
        {
            dto.Mensagem = HttpUtility.UrlEncode(dto.Mensagem);
            var senha = "148754";
            var login = "65981250768";

            string page = $"http://54.173.24.177/painel/api.ashx?action=sendsms&lgn={login}&pwd={senha}&msg={dto.Mensagem}&numbers={dto.Numero}";
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(page))
            using (HttpContent content = response.Content)
            {                
                return await content.ReadAsStringAsync();                
            }
        }        
    }
}