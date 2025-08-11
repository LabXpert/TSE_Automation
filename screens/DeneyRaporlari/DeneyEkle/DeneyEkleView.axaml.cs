using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TSE_Automation.ViewModels;

namespace TSE_Automation.Views;

public partial class DeneyEkleView : UserControl
{  public DeneyEkleView()
    {
        AvaloniaXamlLoader.Load(this);
        DataContext = new DeneyEkleViewModel();
    }
}