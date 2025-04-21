using Avalonia.Controls;
using labVII.ViewModels;

namespace labVII.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}
