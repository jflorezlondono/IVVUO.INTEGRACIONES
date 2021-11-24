using IVVUO.INTEGRACIONES.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVVUO.INTEGRACIONES.Core.Interfaces
{
    public interface IOrdenesRepository
    {
        Task<List<OrdenesEntity>> GetSidaTalOrdenes(string emp);
        Task<string> crearOrden(string data);
    }
}
