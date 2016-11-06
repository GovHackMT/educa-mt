using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducaMTWebAPI.Models
{
    public class Diario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Faltou { get; set; }
    }
}