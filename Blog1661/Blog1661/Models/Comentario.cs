using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Comentario
    {
    
        public int ComentarioId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataDoComentario { get; set; }
        public string Autor { get; set; }
        public List <Mensagem> Mensagem { get; set; }
    }
}
