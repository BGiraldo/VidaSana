using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VidaSana.API.Application.Models;
using VidaSana.API.Infrastructure.IRepository;

namespace VidaSana.API.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {

        private readonly VidaSanaContext _context;

        public ClientRepository(VidaSanaContext context)
        {
            _context = context;
        }


        public void Add(ClientData clientToInsert)
        {
            _context.Clients.Add(clientToInsert);
            _context.SaveChanges();
        }

        public void Delete(string clientId)
        {
            _context.Remove(FindAsync(clientId).Result);
            _context.SaveChanges();
        }

        public async Task<ClientData> FindAsync(string clientId)
        {
            return await _context.Clients
           .FirstOrDefaultAsync(c => c.Document == clientId);
        }

        public void Update(ClientData clientToUpdate)
        {
            _context.Clients.Update(clientToUpdate);
            _context.SaveChanges();
        }
    }
}
