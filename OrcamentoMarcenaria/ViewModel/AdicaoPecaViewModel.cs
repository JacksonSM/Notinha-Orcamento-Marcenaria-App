using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mopups.Services;
using OrcamentoMarcenaria.Domain.Enum;
using OrcamentoMarcenaria.Model;
using System.Globalization;

namespace OrcamentoMarcenaria.ViewModel;

public partial class AdicaoPecaViewModel : BaseViewModel
{
    [ObservableProperty]
    public bool isComprimento = true;
    [ObservableProperty]
    public bool isLargura = true;
    [ObservableProperty]
    public bool isEspessura = true;
    [ObservableProperty]
    public bool isPreco = true;
    [ObservableProperty]
    public bool isMetro = true;

    [ObservableProperty]
    public string valorUnitario = "0.00";
    [ObservableProperty]
    public string valorTotal = "0.00";

    public string Comprimento { get; set; }
    public string Largura { get; set; }
    public string Espessura { get; set; }
    public string Metro { get; set; }
    public string Preco { get; set; }
    public string Quantidade { get; set; }

    float _comprimentoCon;
    float _larguraCon;
    float _espessuraCon;
    float _metroCon;
    float _precoCon;
    int _quantidadeCon;

    float _valorUnitarioCon;
    float _valorTotalCon;


    private TipoPeca tipoAtual;

    public Dictionary<string, TipoPeca> TiposPeca = new()
    {
        { "TABUA", TipoPeca.TABUA }, 
        { "RIPA", TipoPeca.RIPA },
        { "LINHA", TipoPeca.LINHA }, 
        { "BARROTE", TipoPeca.BARROTE }, 
        { "CAIBRO", TipoPeca.CAIBRO }
    };

    public AdicaoPecaViewModel(OrcamentoViewModel orcamentoVM)
    {
        _orcamentoVM = orcamentoVM;
    }


    public void TipoPecaAlterada(string peca)
    {
        var tipo = TiposPeca.FirstOrDefault(c => c.Key.Equals(peca));
        tipoAtual = tipo.Value;
        switch (tipo.Value)
        {
            case TipoPeca.RIPA:
                IsLargura = false; 
                IsComprimento = false; 
                IsEspessura = false; 
                IsMetro = true; 
                break;
            case TipoPeca.BARROTE:
                IsLargura = false;
                IsComprimento = false;
                IsEspessura = false;
                IsMetro = true;
                break;
            case TipoPeca.CAIBRO:
                IsLargura = false;
                IsComprimento = false;
                IsEspessura = false;
                IsMetro = true;
                break;
            case TipoPeca.LINHA:
                IsLargura = false;
                IsComprimento = false;
                IsEspessura = false;
                IsMetro = true;
                break;
            case TipoPeca.TABUA:
                IsLargura = true;
                IsComprimento = true;
                IsEspessura = true;
                IsMetro = false;
                break;
        }
    }

    public void Calcular()
    {
        if (tipoAtual == TipoPeca.TABUA)
            CalcularPorMetroCubico();
        else
            CalcularPorMetro();
    }

    private void CalcularPorMetro()
    {
        if (Metro?.Length > 0)
            float.TryParse(Metro.Trim(), CultureInfo.InvariantCulture, out _metroCon);
        else
            _metroCon = 0;

        if (Preco?.Length > 0)
            float.TryParse(Preco.Trim(), CultureInfo.InvariantCulture, out _precoCon);
        else
            _precoCon = 0;

        _quantidadeCon = int.Parse(Quantidade);

        var totalMetro = _metroCon * _quantidadeCon;
        _valorTotalCon = _precoCon * totalMetro;

        _valorUnitarioCon = _precoCon;
        ValorUnitario = _precoCon.ToString("F2", CultureInfo.InvariantCulture);
        ValorTotal = _valorTotalCon.ToString("F2", CultureInfo.InvariantCulture);
    }

    private void CalcularPorMetroCubico()
    {
        if (Largura?.Length > 0)
            float.TryParse(Largura.Trim(), CultureInfo.InvariantCulture, out _larguraCon);
        else
            _larguraCon = 0;

        if (Espessura?.Length > 0)
            float.TryParse(Espessura.Trim(), CultureInfo.InvariantCulture, out _espessuraCon);
        else
            _espessuraCon = 0;

        if (Comprimento?.Length > 0)
            float.TryParse(Comprimento.Trim(), CultureInfo.InvariantCulture, out _comprimentoCon);
        else
            _comprimentoCon = 0;

        var metroCubico = _comprimentoCon * _larguraCon * _espessuraCon;

        if (Preco?.Length > 0)
            float.TryParse(Preco.Trim(), CultureInfo.InvariantCulture, out _precoCon);
        else
            _precoCon = 0;

        _quantidadeCon = Quantidade != null ? int.Parse(Quantidade): 0;

        _valorUnitarioCon = _precoCon * metroCubico;
        _valorTotalCon = _valorUnitarioCon * _quantidadeCon;

        ValorUnitario = _valorUnitarioCon.ToString("F2", CultureInfo.CurrentCulture); 
        ValorTotal = _valorTotalCon.ToString("F2", CultureInfo.CurrentCulture);
    }

    private readonly OrcamentoViewModel _orcamentoVM;

    [RelayCommand]
    public void Adicionar()
    {
        var tipo = TiposPeca.FirstOrDefault(c => c.Value.Equals(tipoAtual));

        var novaPeca = new PecaModel
        {
            Nome = tipo.Key,
            Largura = _larguraCon,
            Comprimento = _comprimentoCon,
            Espessura = _espessuraCon,
            PrecoUnitario = _valorUnitarioCon,
            ValorTotal = _valorTotalCon,
            Quantidade = _quantidadeCon
        };
        _orcamentoVM.AdicionarPeca(novaPeca);

        MopupService.Instance.PopAsync();
    }
}
