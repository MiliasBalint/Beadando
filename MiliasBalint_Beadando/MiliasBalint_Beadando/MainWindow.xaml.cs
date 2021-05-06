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

namespace MiliasBalint_Beadando
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// Egy statikus lista, amelyben a 2 számla található
        /// </summary>
        static List<Szamla> szamlak = new List<Szamla>();

        /// <summary>
        /// Ez a MainWindow konstruktora, amely megjeleníti az ablakot
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            Szamla egy = new Szamla("Beta",2500);
            Szamla ketto = new Szamla("Alfa",3500);
            szamlak.Add(egy);
            szamlak.Add(ketto);


            E1.Text = Convert.ToString(szamlak[0].Egyenleg);
            E2.Text = Convert.ToString(szamlak[1].Egyenleg);
            T1.Text = Convert.ToString(szamlak[0].Tulaj);
            T2.Text = Convert.ToString(szamlak[1].Tulaj);
        }
        //Szamla 1

        /// <summary>
        /// Ez a metódus tartozik a bal oldali Feltöltés gombhoz. Ellenőrzés után frissíti a számla (1) egyenlegét a beírt összeggel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void F1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int szam = Convert.ToInt32(B1.Text);
                if (szam<0)
                {
                    Uzenet hiba = new Uzenet("A megadott szám nem lehet negatív!");
                    hiba.Show();
                }
                
                else
                {
                    szamlak[0].Egyenleg = szamlak[0].Egyenleg+szam;
                    E1.Text = Convert.ToString(szamlak[0].Egyenleg);
                }
            }
            catch (FormatException exc)
            {
                Uzenet hiba = new Uzenet(exc.Message);
                hiba.Show();

            }
            catch (OverflowException exc)
            {
                Uzenet hiba = new Uzenet(exc.Message);
                hiba.Show();
            }
        }

        /// <summary>
        /// Ez a metódus tartozik a bal oldali Utalás gombhoz. Ellenőrzés után az 1-es számláról átutalja az adott összeget a 2-esre. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void U1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int szam = Convert.ToInt32(B1.Text);
                if (szam < 0)
                {
                    Uzenet hiba = new Uzenet("A megadott szám nem lehet negatív!");
                    hiba.Show();
                }
                else if (szamlak[0].Egyenleg - szam < 0)
                {
                    Uzenet hiba = new Uzenet("Nincs ennyi pénz a számláján!");
                    hiba.Show();
                }
                else
                {
                    szamlak[0].Egyenleg -=  szam;
                    E1.Text = Convert.ToString(szamlak[0].Egyenleg);
                    szamlak[1].Egyenleg += szam;
                    E2.Text = Convert.ToString(szamlak[1].Egyenleg);
                }
            }
            catch (FormatException exc)
            {
                Uzenet hiba = new Uzenet(exc.Message);
                hiba.Show();

            }
            catch (OverflowException exc)
            {
                Uzenet hiba = new Uzenet(exc.Message);
                hiba.Show();
            }
        }

        /// <summary>
        /// Ez a metódus tartozik a bal oldali Kivétel gombhoz. A bemenet ellenőrzése után az adott összeggel csökkenti az 1-es számla egyenlegét
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void K1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int szam = Convert.ToInt32(B1.Text);
                if (szam < 0)
                {
                    Uzenet hiba = new Uzenet("A megadott szám nem lehet negatív!");
                    hiba.Show();
                }
                else if (szamlak[0].Egyenleg - szam < 0)
                {
                    Uzenet hiba = new Uzenet("Nincs ennyi pénz a számláján!");
                    hiba.Show();
                }
                else
                {
                    szamlak[0].Egyenleg -= szam;
                    E1.Text = Convert.ToString(szamlak[0].Egyenleg);
                    
                }
            }
            catch (FormatException exc)
            {
                Uzenet hiba = new Uzenet(exc.Message);
                hiba.Show();

            }
            catch (OverflowException exc)
            {
                Uzenet hiba = new Uzenet(exc.Message);
                hiba.Show();
            }
        }

        /// <summary>
        /// Ez a metódus tartozik a bal oldali Tulaj név váltás gombhoz. Ellenőrzi, hogy írt-e valamit a felhasználó a bemeneti blokkba és
        /// ha igen akkor beállítja az új nevet az 1-es számlán
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NV1_Click(object sender, RoutedEventArgs e)
        {
            
                if (B1.Text!="")
                {
                    szamlak[0].Tulaj = B1.Text;
                    T1.Text = Convert.ToString(szamlak[0].Tulaj);
                }
                else
                {
                    Uzenet hiba = new Uzenet("Nem adhat meg üres bemenetet!");
                    hiba.Show();
                }


            
        }

        //Szamla 2

        /// <summary>
        /// Ez a metódus tartozik a jobb oldali Feltöltés gombhoz. Ellenőrzés után frissíti a számla (2) egyenlegét a beírt összeggel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void F2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int szam = Convert.ToInt32(B2.Text);
                if (szam < 0)
                {
                    Uzenet hiba = new Uzenet("A megadott szám nem lehet negatív!");
                    hiba.Show();
                }
                else
                {
                    szamlak[1].Egyenleg = szamlak[1].Egyenleg + szam;
                    E2.Text = Convert.ToString(szamlak[1].Egyenleg);
                }
            }
            catch (FormatException exc)
            {
                Uzenet hiba = new Uzenet(exc.Message);
                hiba.Show();

            }
            catch (OverflowException exc)
            {
                Uzenet hiba = new Uzenet(exc.Message);
                hiba.Show();
            }
          
        }

        /// <summary>
        /// Ez a metódus tartozik a jobb oldali Utalás gombhoz. Ellenőrzés után az 1-es számláról átutalja az adott összeget a 2-esre. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void U2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int szam = Convert.ToInt32(B2.Text);
                if (szam < 0)
                {
                    Uzenet hiba = new Uzenet("A megadott szám nem lehet negatív!");
                    hiba.Show();
                }
                else if (szamlak[1].Egyenleg - szam < 0)
                {
                    Uzenet hiba = new Uzenet("Nincs ennyi pénz a számláján!");
                    hiba.Show();
                }
                else
                {
                    szamlak[0].Egyenleg += szam;
                    E1.Text = Convert.ToString(szamlak[0].Egyenleg);
                    szamlak[1].Egyenleg -= szam;
                    E2.Text = Convert.ToString(szamlak[1].Egyenleg);
                }
            }
            catch (FormatException exc)
            {
                Uzenet hiba = new Uzenet(exc.Message);
                hiba.Show();

            }
            catch (OverflowException exc)
            {
                Uzenet hiba = new Uzenet(exc.Message);
                hiba.Show();
            }
        }
        /// <summary>
        /// Ez a metódus tartozik a jobb oldali Kivétel gombhoz. A bemenet ellenőrzése után az adott összeggel csökkenti a 2-es számla egyenlegét
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void K2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int szam = Convert.ToInt32(B2.Text);
                if (szam < 0)
                {
                    Uzenet hiba = new Uzenet("A megadott szám nem lehet negatív!");
                    hiba.Show();
                }
                else if (szamlak[1].Egyenleg - szam < 0)
                {
                    Uzenet hiba = new Uzenet("Nincs ennyi pénz a számláján!");
                    hiba.Show();
                }
                else
                {
                    szamlak[1].Egyenleg -= szam;
                    E2.Text = Convert.ToString(szamlak[1].Egyenleg);
                }
            }
            catch (FormatException exc)
            {
                Uzenet hiba = new Uzenet(exc.Message);
                hiba.Show();

            }
            catch (OverflowException exc)
            {
                Uzenet hiba = new Uzenet(exc.Message);
                hiba.Show();
            }
        }

        /// <summary>
        /// Ez a metódus tartozik a jobb oldali Tulaj név váltás gombhoz. Ellenőrzi, hogy írt-e valamit a felhasználó a bemeneti blokkba és
        /// ha igen akkor beállítja az új nevet a 2-es számlán
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NV2_Click(object sender, RoutedEventArgs e)
        {
            if (B2.Text != "")
            {
                szamlak[1].Tulaj = B2.Text;
                T2.Text = Convert.ToString(szamlak[1].Tulaj);
            }
            else
            {
                Uzenet hiba = new Uzenet("Nem adhat meg üres bemenetet!");
                hiba.Show();
            }
        }
    }
}
