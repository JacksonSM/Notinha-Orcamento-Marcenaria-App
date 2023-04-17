using AutoMapper;
using OrcamentoMarcenaria.Data.Repository.Contracts;
using OrcamentoMarcenaria.Domain;
using OrcamentoMarcenaria.Services.Contratcs;
using OrcamentoMarcenaria.ViewModel;

namespace OrcamentoMarcenaria.Services
{
    public class OrcamentoService : IOrcamentoService
    {
        private readonly IOrcamentoRepositoy _orcamentoRepositoy;
        private readonly IMapper _mapper;

        public OrcamentoService(IOrcamentoRepositoy orcamentoRepositoy, IMapper mapper)
        {
            _orcamentoRepositoy = orcamentoRepositoy;
            _mapper = mapper;
        }

        public async Task Adicionar(OrcamentoViewModel orcamentoViewModel)
        {
            var entity = _mapper.Map<Orcamento>(orcamentoViewModel);
            await _orcamentoRepositoy.Adicionar(entity);
        }

        public async Task Atualizar(OrcamentoViewModel orcamentoViewModel)
        {
            var entity = _mapper.Map<Orcamento>(orcamentoViewModel);
            await _orcamentoRepositoy.Atualizar(entity);
        }

        public async Task Excluir(OrcamentoViewModel orcamentoViewModel)
        {
            var entity = _mapper.Map<Orcamento>(orcamentoViewModel);
            await _orcamentoRepositoy.Excluir(entity);
        }

        public async Task<List<OrcamentoViewModel>> ObterTodos()
        {
            var entities = await _orcamentoRepositoy.ObterTodos();
            return _mapper.Map<List<OrcamentoViewModel>>(entities);
        }
    }
}
