using AutoMapper;
using OrcamentoMarcenaria.Domain;
using OrcamentoMarcenaria.Model;
using OrcamentoMarcenaria.ViewModel;

namespace OrcamentoMarcenaria.Config;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<PecaModel, Peca>()
            .ForMember(dest => dest.PrecoUnitario, opt => opt.MapFrom(src => (decimal)src.PrecoUnitario))
            .ForMember(dest => dest.ValorTotal, opt => opt.MapFrom(src => (decimal)src.ValorTotal)).ReverseMap();

        CreateMap<OrcamentoViewModel, Orcamento>()
            .ForMember(dest => dest.Pecas, opt => opt.MapFrom(src => src.Pecas))
            .ForMember(dest => dest.TotalPecas, opt => opt.MapFrom(src => int.Parse(src.TotalPecas)))
            .ForMember(dest => dest.PrecoFinal, opt => opt.MapFrom(src => decimal.Parse(src.PrecoFinal)))
            .ForMember(dest => dest.MaoObra, opt => opt.MapFrom(src => decimal.Parse(src.MaoObra))).ReverseMap();
    }
}

