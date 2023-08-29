namespace BusyIssue;

using CommunityToolkit.Mvvm.ComponentModel;

public partial class MainPageViewModel : ObservableObject
{
    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    string loadingMessage = "Loading Something";
}
