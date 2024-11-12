using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DolgozatTóthZsófia
{
    internal class Nagyvaros
    {

        public string Nev { get; set; }
        public string Orszag { get; set; }
        public double Nepesseg { get; set; }

        public Nagyvaros(string sor)
        {
            var s = sor.Split(";");
            Nev = s[0];
            Orszag = s[1];
            Nepesseg = Convert.ToDouble(s[2]); ;
        }

        public override string ToString()
        {
            return $"{Nev}, {Orszag}, Lakosság: {Nepesseg:F2} millió fő";
        }
    }
   }

