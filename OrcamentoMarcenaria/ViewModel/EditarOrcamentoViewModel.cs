using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OrcamentoMarcenaria.Services.Contratcs;

namespace OrcamentoMarcenaria.ViewModel;

[QueryProperty(nameof(OrcamentoVM), "OrcamentoVM")]
public partial class EditarOrcamentoViewModel : BaseViewModel
{
    [ObservableProperty]
    public OrcamentoViewModel orcamentoVM;

    private readonly IOrcamentoService _orcamentoService;

    public EditarOrcamentoViewModel(IOrcamentoService orcamentoService)
    {
        _orcamentoService = orcamentoService;
    }

    [RelayCommand]
    public async void SalvarOrcamento()
    {
        if (IsBusy)
            return;
        await _orcamentoService.Atualizar(OrcamentoVM);
        await Shell.Current.GoToAsync("..");
    }
    [RelayCommand]
    public async void ExcluirOrcamento()
    {
        if (IsBusy)
            return;
        await _orcamentoService.Excluir(OrcamentoVM);
        await Shell.Current.GoToAsync("..");
    }
}
