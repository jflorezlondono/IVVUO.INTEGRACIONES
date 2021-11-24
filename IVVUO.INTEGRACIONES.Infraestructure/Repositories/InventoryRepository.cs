using IVVUO.INTEGRACIONES.Core.Entities;
using IVVUO.INTEGRACIONES.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVVUO.INTEGRACIONES.Infraestructure.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        public Task<List<InventoryEntity>> GetInventory(string emp)
        {
            throw new NotImplementedException();
        }
    }
}
