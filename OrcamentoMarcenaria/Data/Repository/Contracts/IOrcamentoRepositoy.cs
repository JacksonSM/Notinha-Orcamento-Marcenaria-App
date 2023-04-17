using OrcamentoMarcenaria.Domain;

namespace OrcamentoMarcenaria.Data.Repository.Contracts;

public interface IOrcamentoRepositoy
{
    Task Adicionar(Orcamento orcamento);
    Task Atualizar(Orcamento orcamento);
    Task Excluir(Orcamento orcamento);
    Task<List<Orcamento>> ObterTodos();
}
