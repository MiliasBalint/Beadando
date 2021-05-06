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

namespace MiliasBalint_Beadando
{
    /// <summary>
    /// Interaction logic for Uzenet.xaml
    /// </summary>
    public partial class Uzenet : Window
    {
        /// <summary>
        /// Ez a hiba üzenetet megjelenító Uzenet ablak konstruktora, amely megjeleníti az ablakot
        /// </summary>
        public Uzenet(string szoveg)
        {
            InitializeComponent();
            Kimenet.Text = szoveg;
        }
    }
}
