using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.ViewModel
{
    public class CommentMessage
    {
        public IEnumerable<Mensagem> Mensagems { get; set; }
        public IEnumerable<Comentario> Comentarios { get; set; }
    }
}
