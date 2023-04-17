using OrcamentoMarcenaria.Data.Repository.Contracts;
using OrcamentoMarcenaria.Domain;
using Realms;

namespace OrcamentoMarcenaria.Data.Repository;

public class OrcamentoRepository : IOrcamentoRepositoy
{
    private readonly Realm realm;
    public OrcamentoRepository()
    {
        realm = Realm.GetInstance();
    }
    public async Task Adicionar(Orcamento orcamento)
    {
        await realm.WriteAsync(() =>
        {
            realm.Add(orcamento);
        });
    }

    public async Task Atualizar(Orcamento orcamento)
    {
        await realm.WriteAsync(() =>
        {
            realm.Add(orcamento,true);
        });
    }

    public async Task Excluir(Orcamento orcamento)
    {
        var obj = realm.Find<Orcamento>(orcamento.Id);
        await realm.WriteAsync(() =>
        {
            realm.Remove(obj);
        });
    }

    public async Task<List<Orcamento>> ObterTodos()
    {
        await realm.RefreshAsync();
        return realm.All<Orcamento>().ToList();
    }
}
