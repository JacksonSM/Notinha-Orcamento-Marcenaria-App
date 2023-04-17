using Mopups.Pages;
using Mopups.Services;
using OrcamentoMarcenaria.ViewModel;

namespace OrcamentoMarcenaria.Pages.Modal;

public partial class AdicaoPeca : PopupPage
{
    public OrcamentoViewModel OrcamentoVM { get; set; }
    public AdicaoPecaViewModel AdicaoPecaVM { get; set; }

    public AdicaoPeca(OrcamentoViewModel orcamento, bool btnAdicionar)
    {
		InitializeComponent();
        btn_Adicionar.IsVisible = btnAdicionar;
        AdicaoPecaVM = new(orcamento);
        BindingContext = AdicaoPecaVM;
        stp_quantidade.Minimum = 1;
        stp_quantidade.ValueChanged += OnStepperValueChanged;
        stp_quantidade.ValueChanged += Calcular;
        entry_largura.TextChanged += Calcular;
        entry_espessura.TextChanged += Calcular;
        entry_comprimento.TextChanged += Calcular;
        entry_preco.TextChanged += Calcular;
        entry_quantidade.TextChanged += Calcular;
        OrcamentoVM = orcamento;

        foreach (var peca in AdicaoPecaVM.TiposPeca.Keys)
        {
            picker_tipoPeca.Items.Add(peca);
        }
        picker_tipoPeca.SelectedIndex = 0;
        AdicaoPecaVM.TipoPecaAlterada(picker_tipoPeca.SelectedItem.ToString());
    }

    void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
    {
        entry_quantidade.Text = e.NewValue.ToString();
    }
    void Calcular(object sender, ValueChangedEventArgs e)
    {
        AdicaoPecaVM.Calcular();
    }
    void Calcular(object sender, TextChangedEventArgs e)
    {
        AdicaoPecaVM.Calcular();
    }
    private void Fechar_Clicked(object sender, EventArgs e)
    {
        MopupService.Instance.PopAsync();
    }

    private void picker_tipoPeca_SelectedIndexChanged(object sender, EventArgs e)
    {
        var value = picker_tipoPeca.SelectedItem as string;
        AdicaoPecaVM.TipoPecaAlterada(value);
    }
}