using AutoMapper;
using IVVUO.INTEGRACIONES.Core.DTOs;
using IVVUO.INTEGRACIONES.Core.Entities;

namespace IVVUO.INTEGRACIONES.Infraestructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<OrdenesDto, OrdenesEntity>();
            CreateMap<InventoryDto, InventoryEntity>();
        }
    }
}
