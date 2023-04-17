using Realms;

namespace OrcamentoMarcenaria.Domain;

public class Peca : RealmObject
{
    public string Nome { get; set; }
    public float Largura { get; set; }
    public float Espessura { get; set; }
    public float Comprimento { get; set; }
    public float Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }
    public decimal ValorTotal { get; set; }
}
