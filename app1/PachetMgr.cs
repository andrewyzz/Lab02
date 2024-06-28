using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            Console.WriteLine("Apasati 1 pentru citire din consola si 2 pentru citire din XML pentru Pachete");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
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

                        Pachet p = new Pachet(nume_pachet, codIntern_pachet, CountPachete++, pret, categorie);


                        ProduseMgr mgrProduse = new ProduseMgr();
                        Console.WriteLine("Introduceti nr. de produse: ");
                        int nr_prod = int.Parse(Console.ReadLine());
                        for (int i = 0; i < nr_prod; i++)
                            p.AddElement(mgrProduse.ReadUnProdus());


                        ServiciiMgr mgrServicii = new ServiciiMgr();
                        Console.WriteLine("Introduceti nr. de servicii: ");
                        int nr_serv = int.Parse(Console.ReadLine());
                        for (int i = 0; i < nr_serv; i++)
                            p.AddElement(mgrServicii.ReadUnServiciu());

                        elemente.Add(p);
                        this.save2XML("pachete");
                        break;
                    }
                case 2:
                    InitListafromXML();
                    break;
                default:
                    InitListafromXML();
                    break;
            }
        }
        public void AddElement(int nr)
        {
            for(int i=0;i<nr; i++)
            {
                this.AddElement();
            }
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
        public void InitListafromXML()
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load("C:\\Users\\User\\Desktop\\lab7.5\\app1\\Pachet.xml");

                XmlNodeList lista_noduri = doc.SelectNodes("/pachete/Pachet");
                foreach (XmlNode nodPachet in lista_noduri)
                {
                    string nume = nodPachet["Nume"].InnerText;
                    string codIntern = nodPachet["CodIntern"].InnerText;
                    string producator = nodPachet["Producator"].InnerText;
                    int pret = int.Parse(nodPachet["Pret"].InnerText);
                    string categorie = nodPachet["Categorie"].InnerText;

                    Pachet pachet = new Pachet(nume, codIntern, CountPachete++, pret, categorie);

                    XmlNodeList listaNoduriProduse = nodPachet.SelectNodes("Produse/Produs");
                    foreach (XmlNode nodProdus in listaNoduriProduse)
                    {
                        string numeProdus = nodProdus["Nume"].InnerText;
                        string codInternProdus = nodProdus["CodIntern"].InnerText;
                        string producatorProdus = nodProdus["Producator"].InnerText;
                        int pretProdus = int.Parse(nodProdus["Pret"].InnerText);
                        string categorieProdus = nodProdus["Categorie"].InnerText;

                        Produs produs = new Produs(numeProdus, codInternProdus, CountElemente++, pretProdus, categorieProdus, producatorProdus);
                        pachet.AddElement(produs);
                    }

                    XmlNodeList listaNoduriServicii = nodPachet.SelectNodes("Servicii/Serviciu");
                    foreach (XmlNode nodServiciu in listaNoduriServicii)
                    {
                        string numeServiciu = nodServiciu["Nume"].InnerText;
                        string codInternServiciu = nodServiciu["CodIntern"].InnerText;
                        string furnizorServiciu = nodServiciu["Furnizor"].InnerText;
                        int pretServiciu = int.Parse(nodServiciu["Pret"].InnerText);
                        string categorieServiciu = nodServiciu["Categorie"].InnerText;

                        Serviciu serviciu = new Serviciu(numeServiciu, codInternServiciu, CountElemente++, pretServiciu, categorieServiciu);
                        pachet.AddElement(serviciu);
                    }

                    elemente.Add(pachet);
                }
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                Console.WriteLine("Wrong directory in path file.");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
