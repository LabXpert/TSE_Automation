using Avalonia.Controls;
using Avalonia.Interactivity;

namespace TSE_Automation.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void MenuToggleButton_Click(object? sender, RoutedEventArgs e)
    {
        MainSplitView.IsPaneOpen = !MainSplitView.IsPaneOpen;
    }

    private void DeneyEkleButton_Click(object? sender, RoutedEventArgs e)
    {
        var deneyEkleView = new DeneyEkleView();
        MainContentControl.Content = deneyEkleView;
    }

    private void DeneyRaporlaButton_Click(object? sender, RoutedEventArgs e)
    {
        var deneyRaporlaView = new DeneyRaporlaView();
        MainContentControl.Content = deneyRaporlaView;
    }

    private void DeneySilDuzenleButton_Click(object? sender, RoutedEventArgs e)
    {
        var deneySilDuzenleView = new DeneySilDuzenleView();
        MainContentControl.Content = deneySilDuzenleView;
    }
}