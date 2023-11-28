using GoalPtApp.Pages;

namespace GoalPtApp;

public partial class App : Application
{
    public App(MainPage page)
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}
