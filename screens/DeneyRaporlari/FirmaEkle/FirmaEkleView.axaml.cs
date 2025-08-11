using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TSE_Automation.ViewModels;

namespace TSE_Automation.Views
{
    public partial class FirmaEkleView : UserControl
    {
        public FirmaEkleView()
        {
            AvaloniaXamlLoader.Load(this);
            DataContext = new FirmaEkleViewModel();
        }
    }
}