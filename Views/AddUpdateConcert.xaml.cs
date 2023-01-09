using ProiectMobileFinal.ViewModels;

namespace ProiectMobileFinal.Views;

public partial class AddUpdateConcert : ContentPage
{
	public AddUpdateConcert(AddUpdateConcertViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
    }
}