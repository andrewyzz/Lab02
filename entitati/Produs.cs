using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace entitati
{
    public class Produs : ProdusAbstract
    {
         public string Producator { get; set; }
        public string CodIntern { get; set; }
        public string Nume { get; set; }
        public int Id { get; set; }

        public Produs(string Nume, string CodIntern, int id, string Producator) : base(Nume,CodIntern,id)
        {
            this.Producator = Producator;
        }
        public void Afisare()
        {
            Console.WriteLine("Nume: " + Nume + " Producator: " + Producator + " CodIntern: " + CodIntern + " Id: " + Id);
        }
        public override string Descriere()
        {
            return "Produsul: " + base.AltaDescriere() + this.Producator;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Produs other = (Produs)obj;
            return Producator == other.Producator && CodIntern == other.CodIntern && Nume == other.Nume;
        }
    }
    }
}
