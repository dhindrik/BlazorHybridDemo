

namespace CatchLoggerDemo.Apps;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        Component.Parameters = new Dictionary<string, object>()
       {
           { "Url", "/" }
       };

    }
}

