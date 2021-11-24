using IVVUO.INTEGRACIONES.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVVUO.INTEGRACIONES.Core.Interfaces
{
    public interface IInventoryRepository
    {
        Task<List<InventoryEntity>> GetInventory(string emp);
    }
}
