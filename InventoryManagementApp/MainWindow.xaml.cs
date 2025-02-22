using System.Windows;
using Microsoft.Extensions.DependencyInjection;


namespace InventoryManagementApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           // InitializeComponent();
            DataContext = App.ServiceProvider.GetRequiredService<InventoryViewModel>();
        }
    }
}
