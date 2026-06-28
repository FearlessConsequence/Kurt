using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace bilet1;

public partial class FirstWindow : Window
{
    public FirstWindow()
    {
        InitializeComponent();
    }

    private void OnOpenWindow(object? sender, RoutedEventArgs e)
    {
        var mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();
    }
}