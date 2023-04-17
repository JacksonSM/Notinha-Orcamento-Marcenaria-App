using MongoDB.Bson;
using Realms;

namespace OrcamentoMarcenaria.Domain;

public class Orcamento : RealmObject
{
    [PrimaryKey]
    [MapTo("_id")]
    public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
    public string Cliente { get; set; }
    public string Trabalho { get; set; }
    public IList<Peca> Pecas { get; }
    public int TotalPecas { get; set; }
    public decimal PrecoFinal { get; set; }
    public decimal MaoObra { get; set; }
    public DateTimeOffset DataCriacao { get; set; } = DateTimeOffset.Now;
}
