using OrcamentoMarcenaria.Services.Contratcs;
using OrcamentoMarcenaria.ViewModel;

namespace OrcamentoMarcenaria.Pages;

public partial class CriarOrcamento : ContentPage
{
    public OrcamentoViewModel OrcamentoVM { get; set; }
    public CriarOrcamento(IOrcamentoService orcamentoService)
    {
        InitializeComponent();
        OrcamentoVM = new(orcamentoService);
        BindingContext = OrcamentoVM;
    }

    private void LimparDados(object sender, EventArgs e)
    {
        OrcamentoVM.Limpar();
        entry_cliente.Text = string.Empty;
        entry_trabalho.Text = string.Empty;
    }

    private void entry_maoObra_TextChanged(object sender, TextChangedEventArgs e)
    {
        OrcamentoVM.CalcularTotais();
    }
}