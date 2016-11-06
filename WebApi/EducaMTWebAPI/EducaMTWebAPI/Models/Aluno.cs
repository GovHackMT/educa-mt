using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducaMTWebAPI.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

    }
}