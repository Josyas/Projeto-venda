using AutoMapper;
using Venda_BackEnd.DTO;
using Venda_BackEnd.Entites;

namespace Venda_BackEnd.Mappings
{
    public class EntitiesToDTOProfile : Profile
    {
        public EntitiesToDTOProfile()
        {
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
        }
    }
}
