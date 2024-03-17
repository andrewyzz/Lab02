using entitati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app1
{
    internal class ProduseMgr : ProdusAbstractMgr
    {
        //private Produs[] produse = new Produs[100];
        public int CountProduse { get; set; } = 0;
        
        public void ReadProdus()
        {
            //Console.WriteLine("Introdu un produs");
            Console.Write("Numele:");
            string? nume = Console.ReadLine();
            Console.Write("Codul intern:");
            string? codintern = Console.ReadLine();
            Console.Write("Producator:");
            string? producator = Console.ReadLine();
            Produs prod = new Produs(nume, codintern, CountProduse, producator);
            if (!Contains(prod))
            {
                AddElement(prod);
            }
        }
        public void ReadProdus(int count)
        {
            for(int i = 0; i < count; i++)
            {
                Console.WriteLine("Datele pentru produsul:" + (++CountProduse));
                ReadProdus();
            }
        }
        public Produs ReadUnProdus()
        {
            Console.WriteLine("Datele pentru produsul:" + (++CountProduse));
            Console.Write("Numele:");
            string? nume = Console.ReadLine();
            Console.Write("Codul intern:");
            string? codintern = Console.ReadLine();
            Console.Write("Producator:");
            string? producator = Console.ReadLine();
            return new Produs(nume, codintern, CountProduse, producator);
        }
        public void WriteProdus()
        {
            for(int i=0;i< CountElemente;i++)
            {
                if (elemente[i] is Produs)
                {
                    Console.WriteLine(elemente[i].Descriere());
                }
            }
        }
        public bool Contains(Produs prod)
        {
            for(int i=0;i< CountElemente;i++)
            {
                if (elemente[i] is Produs)
                {
                    Produs produs = (Produs)elemente[i];
                    if (produs == prod)
                        return true;
                }
            }
            return false;
        }
        public Produs[] Contains(string? nume)
        {
            Produs[] prodNume = new Produs[100];
            int numeCnt = 0;
            for (int i = 0; i < CountElemente; i++)
            {
                if (elemente[i] is Serviciu)
                {
                    Produs produs = (Produs)elemente[i];
                    if (produs.Nume == nume)
                        prodNume[numeCnt++] = produs;
                }
            }
            return prodNume;
        }

    }
}
