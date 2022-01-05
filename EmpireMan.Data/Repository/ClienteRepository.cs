using EmpireMan.Business.Interfaces;
using EmpireMan.Business.Models;
using EmpireMan.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace EmpireMan.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(EmpireDbContext context) : base(context) {}

        public override async Task Remover(int id)
        {
            var cliente = DbSet.Find(id);
            var endereco = Db?.ClienteEnderecos.Where(x => x.Id == cliente.ClienteEndereco.Id).FirstOrDefault();

            if (endereco != null)
                Db?.ClienteEnderecos.Remove(endereco);

            DbSet.Remove(cliente);
            await SaveChanges();
        }
    }
}
