using CommunityToolkit.Mvvm.Input;
using Mopups.Services;
using OrcamentoMarcenaria.Pages;
using OrcamentoMarcenaria.Pages.Modal;
using OrcamentoMarcenaria.Services.Contratcs;
using System.Collections.ObjectModel;

namespace OrcamentoMarcenaria.ViewModel
{
    public partial class MainViewModel : BaseViewModel
    {
        private readonly IOrcamentoService _orcamentoService;
        public ObservableCollection<OrcamentoViewModel> Orcamentos { get; set; } = new();

        public MainViewModel(IOrcamentoService orcamentoService)
        {
            _orcamentoService = orcamentoService;
            AtualizarLista();
        }

        [RelayCommand]
        async Task AdicionarOrcamento()
        {
            if (IsBusy)
                return;

            await Shell.Current.GoToAsync(nameof(CriarOrcamento), true);
        }

        [RelayCommand]
        async Task CalculoRapido()
        {
            if (IsBusy)
                return;

            await MopupService.Instance.PushAsync(new AdicaoPeca(null, false));
        }

        [RelayCommand]
        async Task EditarOcamento(OrcamentoViewModel orcamentoViewModel)
        {
            if (IsBusy)
                return;
            await Shell.Current.GoToAsync(nameof(EditarOrcamento), true, new Dictionary<string, object>
            {
                {"OrcamentoVM", orcamentoViewModel }
            });
        }
        public async void AtualizarLista()
        {
            Orcamentos.Clear();
            var orcamentosAtualizados = await _orcamentoService.ObterTodos();

            foreach (var orcamento in orcamentosAtualizados)
            {
                Orcamentos.Add(orcamento);
            }
        }
    }
}
