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
            ProduseMgr produse = new ProduseMgr();
            ServiciiMgr servicii = new ServiciiMgr();
            PachetMgr pachete = new PachetMgr();
            produse.AddElement();
            servicii.AddElement();
            //pachete.AddElement();
            //Serviciu serv = servicii.ReadUnServiciu();
            //Produs produs = produse.ReadUnProdus();
            //serv.save2XML("serviciu");
            //produs.save2XML("produs");
            ProdusAbstractMgr.Write2Console();
        }
    }
}