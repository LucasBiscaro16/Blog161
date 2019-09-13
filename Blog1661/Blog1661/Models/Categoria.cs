using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Categoria
    {
       
        public int CategoriaId { get; set; }
        public string Descriacao { get; set; }

        public List<Mensagem> Mensagens { get; set; }
    }
}
