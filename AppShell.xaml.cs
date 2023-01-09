using ProiectMobileFinal.Views;

namespace ProiectMobileFinal;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(AddUpdateConcert), typeof(AddUpdateConcert));
    }
}
