using GoalPtApp.APIBaseURLs;
using GoalPtApp.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using GoalPtApp.Pages;
using CommunityToolkit.Maui;

namespace GoalPtApp;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        }).UseMauiCommunityToolkit();
        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream("GoalPtApp.appsettings.json");
        var jsonConfig = new ConfigurationBuilder().AddJsonStream(stream).Build();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<MainPageViewModel>();
        builder.Configuration.AddConfiguration(jsonConfig);
        builder.Services.AddSingleton<GoalPtConnection>();
        return builder.Build();
    }
}