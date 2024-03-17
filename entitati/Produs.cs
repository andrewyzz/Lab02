using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace entitati
{
    public class Produs : ProdusAbstract, IComparable<Produs>
    {
         public string Producator { get; set; }
        public string CodIntern { get; set; }
        public string Nume { get; set; }
        public int Id { get; set; }

        public Produs(string Nume, string CodIntern, int id, string Producator) : base(Nume,CodIntern,id)
        {
            this.Producator = Producator;
            this.Nume= Nume;
            this.CodIntern=CodIntern;
            this.Id= id;
        }
        public void Afisare()
        {
            Console.WriteLine("Nume: " + Nume + " Producator: " + Producator + " CodIntern: " + CodIntern + " Id: " + Id);
        }
        public override string Descriere()
        {
            return "Produsul: " + base.AltaDescriere() + ", Producător: " + this.Producator + ", ID: " + base.Id;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Produs other = obj as Produs;
            return this.Producator == other.Producator && base.CodIntern == other.CodIntern && base.Nume == other.Nume;
        }
        public int CompareTo(Produs obj)
        {
            if (obj == null) return 1;

            Produs otherProdus = obj as Produs;
            if (otherProdus != null)
                return this.Nume.CompareTo(otherProdus.Nume);
            else
                throw new ArgumentException("Object is not a Produs.");
        }
        public static bool operator ==(Produs p1, Produs p2)
            => ((p1.Nume == p2.Nume) && (p1.CodIntern == p2.CodIntern) && (p1.Producator == p2.Producator));
        public static bool operator !=(Produs p1, Produs p2)
            => !((p1.Nume == p2.Nume) && (p1.CodIntern == p2.CodIntern) && (p1.Producator == p2.Producator));
    }
    
}
