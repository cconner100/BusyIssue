namespace BusyIssue;

public partial class MainPage : ContentPage
{
    MainPageViewModel vm;
    public MainPage()
    {
        InitializeComponent();
        if (BindingContext is MainPageViewModel viewModel)
        {
            vm = viewModel;
        }
        else
        {
            throw new NullReferenceException("BindingContext is not MainPageViewModel");
        }
    }

    
    void Stop_Clicked(object sender, EventArgs e)
    {
        if(vm.IsBusy == false)
        {
            vm.IsBusy = true;      
        }
        else
        {
            vm.IsBusy = false;
        }

    }
}

