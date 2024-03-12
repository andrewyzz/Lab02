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
            ProdusAbstractMgr.Write2Console();
        }
    }
}