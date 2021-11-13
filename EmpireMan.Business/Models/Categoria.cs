using System.Collections.Generic;

namespace EmpireMan.Business.Models
{
    public class Categoria : Entity
    {
        public string Descricao { get; set; }

        public virtual IEnumerable<Produto> Produtos { get; set; }
    }
}