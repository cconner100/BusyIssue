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

    int click = 0;

    void Stop_Clicked(object sender, EventArgs e)
    {
        click++;
        vm.LoadingMessage = "Loading " + click;
        vm.IsBusy = true;
        Task.Run(UpdateBusy);
    }

    void UpdateBusy()
    {
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await Task.Delay(2000);
            vm.IsBusy = false;
        });
    }

}

