using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Mopups.Hosting;
using OrcamentoMarcenaria.Config;
using OrcamentoMarcenaria.Data.Repository;
using OrcamentoMarcenaria.Data.Repository.Contracts;
using OrcamentoMarcenaria.Pages;
using OrcamentoMarcenaria.Services;
using OrcamentoMarcenaria.Services.Contratcs;
using OrcamentoMarcenaria.ViewModel;

namespace OrcamentoMarcenaria;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureMopups()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddAutoMapper(typeof(MapperConfig));

        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<MainPage>();

        builder.Services.AddTransient<EditarOrcamento>();
        builder.Services.AddTransient<EditarOrcamentoViewModel>();

        builder.Services.AddTransient<CriarOrcamento>();
        builder.Services.AddTransient<OrcamentoViewModel>();
        builder.Services.AddTransient<AdicaoPecaViewModel>();

        builder.Services.AddSingleton<IOrcamentoRepositoy, OrcamentoRepository>();
        builder.Services.AddSingleton<IOrcamentoService, OrcamentoService>();



#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
	}
}
