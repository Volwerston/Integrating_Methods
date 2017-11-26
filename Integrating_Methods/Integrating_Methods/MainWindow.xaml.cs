using Integrating_Methods.Classes;
using Integrating_Methods.Interfaces;
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

namespace Integrating_Methods
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

        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IIntegratingMethod m = IntegratingService.GetIntegratingMethod(method.Text);

                result.Text = m.Count(this.GetMethodContext()).ToString();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private MethodContext GetMethodContext()
        {
            return new MethodContext()
            {
                A = double.Parse(a.Text),
                B = double.Parse(b.Text),
                N = 30,
                Function = new Func(function.Text)
            };
        }
    }
}
