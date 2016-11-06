using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducaMTWebAPI.Models
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Turma { get; set; }
        public string Periodo { get; set; }        
    }
}