using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiliasBalint_Beadando
{
    class Szamla
    {
        /// <summary>
        /// Egyenleget tároló változó
        /// </summary>
        ///<value>
        /// Int változó
        /// </value>
        public int Egyenleg { get; set; }
        /// <summary>
        /// Tulaj nevét tároló változó
        /// </summary>
        /// <value>
        /// String változó
        /// </value>
        /// 
        public string Tulaj { get; set; } = "";

        /// <summary>
        /// Konstruktor, amely beállítja az adatokat példányosításkor
        /// </summary>
        /// <param name=" egyenleg">Egyenleg értéke</param>
        /// <param name=" tulaj">Tulaj neve</param>
        public Szamla(string tulaj, int egyenleg)
        {
            Egyenleg = egyenleg;
            Tulaj = tulaj;
        }

    }
}
