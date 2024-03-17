using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using entitati;

namespace app1
{
    internal class PachetMgr : ProdusAbstractMgr
    {
        public int CountPachete { get; set; } = 0;

        public override void AddElement()
        {
            Console.WriteLine("Introdu un pachet");
            Console.Write("Numele:");
            string? nume_pachet = Console.ReadLine();
            Console.Write("Codul intern:");
            string? codIntern_pachet = Console.ReadLine();
            Console.Write("Pret:");
            int pret = int.Parse(Console.ReadLine() ?? string.Empty);
            Console.Write("Categorie:");
            string? categorie = Console.ReadLine();

            Pachet p = new Pachet(nume_pachet,codIntern_pachet,CountPachete++,pret,categorie);


            ProduseMgr mgrProduse = new ProduseMgr();
            Console.WriteLine("Introduceti nr. de produse: ");
            uint nr_prod = uint.Parse(Console.ReadLine());
            for (int i = 0; i < nr_prod; i++)
                p.AddElement(mgrProduse.ReadUnProdus());


            ServiciiMgr mgrServicii = new ServiciiMgr();
            Console.WriteLine("Introduceti nr. de servicii: ");
            uint nr_serv = uint.Parse(Console.ReadLine());
            for (int i = 0; i < nr_serv; i++)
                p.AddElement(mgrServicii.ReadUnServiciu());

            elemente.Add(p);

        }
        public Pachet ReadUnPachet()
        {
            Console.WriteLine("Datele pentru pachetul:" + (++CountPachete));
            Console.Write("Numele:");
            string? nume = Console.ReadLine();
            Console.Write("Codul intern:");
            string? codintern = Console.ReadLine();
            Console.Write("Producator:");
            string? producator = Console.ReadLine();
            Console.Write("Categorie:");
            string? categorie = Console.ReadLine();
            Console.Write("Pret:");
            int pret = int.Parse(Console.ReadLine());
            return new Pachet(nume, codintern, CountPachete++, pret, categorie);
        }
        public override bool Contains(ProdusAbstract proda)
        {
            throw new NotImplementedException();
        }
        public void InitListafromXML()
        {
            //initializare lista dintr-un fisier XML
            XmlDocument doc = new XmlDocument();
            //incarca fisierul
            //doc.Load("...");
            doc.Load("C:\\Users\\cti22d113\\Desktop\\lab7.2\\app1\\Pachet.xml"); //calea spre fisier
                                                                               //selecteaza nodurile
            XmlNodeList lista_noduri = doc.SelectNodes("/pachete/Pachet");
            foreach (XmlNode nod in lista_noduri)
            {
                //itereaza si selecteaza simpurile fiecarui nod si
                //informatia continuta in cadrul proprietatii InnerText
                string nume = nod["Nume"].InnerText;
                string codIntern = nod["CodIntern"].InnerText;
                string producator = nod["Producator"].InnerText;
                int pret = int.Parse(nod["Pret"].InnerText);
                string categorie = nod["Categorie"].InnerText;

                //adauga in lista produse
                Pachet p = new Pachet(nume, codIntern, CountPachete++, pret, categorie);
                p.AddElement(p);
            }
        }
    }
}
