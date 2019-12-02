using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JKX
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Water(object sender, RoutedEventArgs e)
        {
            Service service = new Service("Вода");
            service.Show();
        }

        public void Light(object sender, RoutedEventArgs e)
        {
            Service service = new Service("Свет");
            service.Show();
        }

        public void Trash(object sender, RoutedEventArgs e)
        {
            Service service = new Service("Мусор");
            service.Show();
        }
    }
}
