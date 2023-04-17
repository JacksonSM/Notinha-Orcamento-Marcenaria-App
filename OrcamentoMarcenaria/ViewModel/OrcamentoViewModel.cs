using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MongoDB.Bson;
using Mopups.Services;
using OrcamentoMarcenaria.Model;
using OrcamentoMarcenaria.Pages.Modal;
using OrcamentoMarcenaria.Services.Contratcs;
using System.Collections.ObjectModel;
using System.Globalization;

namespace OrcamentoMarcenaria.ViewModel
{
    public partial class OrcamentoViewModel : BaseViewModel
    {
        private readonly IOrcamentoService _orcamentoService;

        public ObjectId Id { get; set; }
        public string Cliente { get; set; }
        public string Trabalho { get; set; }
        public string MaoObra { get; set; }
        public ObservableCollection<PecaModel> Pecas { get; } = new();

        [ObservableProperty]
        public string totalPecas = "0";
        [ObservableProperty]
        public string precoFinal = "0,00";

        public DateTimeOffset DataCriacao { get; set; } = DateTimeOffset.Now;

        public OrcamentoViewModel(IOrcamentoService orcamentoService)
        {
            _orcamentoService = orcamentoService;
        }

        public OrcamentoViewModel()
        {
            
        }

        public void AdicionarPeca(PecaModel pecaModel)
        {
            Pecas.Add(pecaModel);
            CalcularTotais();
        }

        public void CalcularTotais()
        {
            float maoObraCon = 0;
            if(MaoObra != null)
                float.TryParse(MaoObra.Trim(), out maoObraCon);
            TotalPecas = Pecas.Select(c => c.Quantidade).Sum().ToString();
            var total = Pecas.Select(c => c.ValorTotal).Sum();
            PrecoFinal = (total + maoObraCon).ToString("F2",CultureInfo.CurrentCulture);
        }

        [RelayCommand]
        async Task AdicionarPeca()
        {
            if (IsBusy)
                return;

            await MopupService.Instance.PushAsync(new AdicaoPeca(this,true));
        }

        [RelayCommand]
        async Task SalvarOrcamento()
        {
            if (IsBusy)
                return;
            await _orcamentoService.Adicionar(this);
            await Shell.Current.GoToAsync("..");
        }

        public void Limpar()
        {
            Cliente = string.Empty;
            Trabalho = string.Empty;
            TotalPecas = "0";
            PrecoFinal = "0";
            Pecas.Clear();
        }
    }
}
