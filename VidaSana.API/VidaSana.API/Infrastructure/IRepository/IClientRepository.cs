using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidaSana.API.Application.Models;
using VidaSana.API.Application.SeedWork;

namespace VidaSana.API.Infrastructure.IRepository
{
   public interface IClientRepository : IRepository<ClientData>{ }
}
