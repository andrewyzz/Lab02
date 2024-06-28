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
            Console.WriteLine("Nr. Pachete:");
            int nrPachete = int.Parse(Console.ReadLine() ?? string.Empty);
            ProduseMgr produse = new ProduseMgr();
            ServiciiMgr servicii = new ServiciiMgr();
            PachetMgr pachete = new PachetMgr();
            produse.AddElement(nrProduse);
            servicii.AddElement(nrServicii);
            pachete.AddElement(nrPachete);
            ProdusAbstractMgr.Write2Console();
        }
    }
}