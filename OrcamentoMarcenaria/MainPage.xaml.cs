using OrcamentoMarcenaria.ViewModel;

namespace OrcamentoMarcenaria;

public partial class MainPage : ContentPage
{
	private readonly MainViewModel _mainViewModel;
    public MainPage(MainViewModel mainVM)
	{
		InitializeComponent();
		_mainViewModel = mainVM;
		BindingContext = _mainViewModel;
	}

    protected override void OnAppearing()
    {
		_mainViewModel.AtualizarLista();
    }
}

