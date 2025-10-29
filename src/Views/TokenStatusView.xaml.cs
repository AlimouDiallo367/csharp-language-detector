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
using System.Windows.Shapes;
using LanguageDetector.ViewModels;

namespace LanguageDetector.Views
{
    /// <summary>
    /// Logique d'interaction pour TokenStatusView.xaml
    /// </summary>
    public partial class TokenStatusView : Window
    {
        public TokenStatusView()
        {
            InitializeComponent();

            if (this.DataContext is TokenStatusViewModel vm)
            {
                
                vm.LoadTokenStatusAsync();
            }
        }
    }
}
