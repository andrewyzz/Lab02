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
            ProduseMgr produs = new ProduseMgr();
            ServiciiMgr servicii = new ServiciiMgr();
            produs.ReadProdus(nrProduse);
            servicii.ReadServiciu(nrServicii);
            Console.Write("Nr. produse:");
            int nrProduse2 = int.Parse(Console.ReadLine() ?? string.Empty);
            Console.Write("Nr. servicii:");
            int nrServicii2 = int.Parse(Console.ReadLine() ?? string.Empty);
            for(int i= 0; i < nrProduse2; i++) {
                ProdusAbstractMgr.elemente[ProdusAbstractMgr.CountElemente++] = produs.ReadUnProdus();
            }
            for (int i = 0; i < nrProduse2; i++)
            {
                ProdusAbstractMgr.elemente[ProdusAbstractMgr.CountElemente++] = servicii.ReadUnServiciu();
            }
            ProdusAbstractMgr.Write2Console();
        }
    }
}