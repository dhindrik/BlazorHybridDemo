
namespace CatchLoggerDemo.Apps;

public partial class AppShell
{
	public AppShell()
	{
		InitializeComponent();

        RegisterComponent.Parameters = new Dictionary<string, object>()
       {
           { "Url", "/register" }
       };
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        
    }
}
