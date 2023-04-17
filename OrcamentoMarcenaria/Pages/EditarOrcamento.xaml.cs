using OrcamentoMarcenaria.ViewModel;

namespace OrcamentoMarcenaria.Pages;

public partial class EditarOrcamento : ContentPage
{
    private readonly EditarOrcamentoViewModel _editarOrcamentoViewModel;
    public EditarOrcamento(EditarOrcamentoViewModel editarOrcamentoViewModel)
    {
        InitializeComponent();
        _editarOrcamentoViewModel = editarOrcamentoViewModel;
        BindingContext = _editarOrcamentoViewModel;

    }

    private void LimparDados(object sender, EventArgs e)
    {
        _editarOrcamentoViewModel.OrcamentoVM.Limpar();
        entry_cliente.Text = string.Empty;
        entry_trabalho.Text = string.Empty;

    }

    private void entry_maoObra_TextChanged(object sender, TextChangedEventArgs e)
    {
        _editarOrcamentoViewModel.OrcamentoVM.CalcularTotais();
    }

}