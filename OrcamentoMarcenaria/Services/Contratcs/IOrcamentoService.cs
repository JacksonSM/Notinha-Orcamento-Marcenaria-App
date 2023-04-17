using OrcamentoMarcenaria.ViewModel;

namespace OrcamentoMarcenaria.Services.Contratcs;

public interface IOrcamentoService
{
    Task Adicionar(OrcamentoViewModel orcamentoViewModel);
    Task Atualizar(OrcamentoViewModel orcamentoViewModel);
    Task Excluir(OrcamentoViewModel orcamentoViewModel);
    Task<List<OrcamentoViewModel>> ObterTodos();
}
