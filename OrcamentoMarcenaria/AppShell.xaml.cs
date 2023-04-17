using OrcamentoMarcenaria.Pages;

namespace OrcamentoMarcenaria;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
       
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(CriarOrcamento), typeof(CriarOrcamento));
        Routing.RegisterRoute(nameof(EditarOrcamento), typeof(EditarOrcamento));
    }
}
