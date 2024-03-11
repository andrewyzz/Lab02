using entitati;
using System.Security.Cryptography.X509Certificates;
 
namespace app1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nr. produse:");
            int nrProduse = int.Parse(Console.ReadLine() ?? string.Empty);
            Console.Write("Nr. servicii:");
            int nrServicii = int.Parse(Console.ReadLine() ?? string.Empty);
            for (int i = 0; i < nrProduse; i++)
            {
                Console.WriteLine($"Introduceti datele pentru produsul "+ (i+1));
                string numeProdus = Console.ReadLine();
                string codInternProdus = Console.ReadLine();
                string producatorProdus = Console.ReadLine();
                ProdusAbstractMgr.AddElement(new Produs(numeProdus, codInternProdus, (i+1), producatorProdus));
            }

            for (int i = 0; i < nrServicii; i++)
            {
                Console.WriteLine("Introduceti datele pentru serviciul "+ (i+1));
                string numeServiciu = Console.ReadLine();
                string codServiciu = Console.ReadLine();
                ProdusAbstractMgr.AddElement(new Serviciu(numeServiciu, codServiciu, (i+1)));
            }
            ProdusAbstractMgr.Write2Console();
        }
        public static bool exist(Object[] a, Object b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != null && a[i].Equals(b))
                {
                    return true;
                }
            }
            return false;
        }
    }
}