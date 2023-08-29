namespace BusyIssue;
using System.Diagnostics;
using System.Runtime.CompilerServices;

using Telerik.Maui.Controls;

public class ZtLoading : RadBusyIndicator
{
    Label _busyMessage = new Label();


    public ZtLoading()
    {
        _busyMessage.FontAttributes = FontAttributes.Bold;
        IsBusy = false;
        //IsVisible = false;
        _busyMessage.HorizontalOptions = LayoutOptions.Center;
        BusyContent = _busyMessage;
        ContentUnderOpacity = 0.4;
        VerticalOptions = LayoutOptions.Fill;
        HorizontalOptions = LayoutOptions.Fill;
        AnimationType = AnimationType.Animation3;

        if (Application.Current is null)
        {
            Debug.WriteLine("Application.Current is null");
            return;
        }
        // Get the os theme and set the background color
        switch (Application.Current.RequestedTheme)
        {
            case AppTheme.Light:
                BackgroundColor = Colors.Transparent;
                break;
            case AppTheme.Dark:
                BackgroundColor = Colors.Transparent;
                break;
            case AppTheme.Unspecified:
                break;
            default:
                break;

        }
    }

    protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        //if (propertyName == nameof(IsBusy))
        //{
        //    IsVisible = IsBusy;
        //}

        base.OnPropertyChanged(propertyName);
    }


    public static readonly BindableProperty MessageProperty = BindableProperty.Create(nameof(Message), typeof(string), typeof(ZtLoading), propertyChanged: OnMessageChanged);
    public string Message
    {
        get => (string)GetValue(MessageProperty);
        set => SetValue(MessageProperty, value);
    }

    static void OnMessageChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is ZtLoading loading)
        {
            loading._busyMessage.Text = (string)newValue;
        }
    }
}

