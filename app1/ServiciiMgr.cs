using entitati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace app1
{
    internal class ServiciiMgr : ProdusAbstractMgr
    {
        //private Serviciu[] servicii = new Serviciu[100];
        public int CountServicii { get; set;} = 0;
        
        public override void AddElement()
        {
            Console.WriteLine("Apasati 1 pentru citire din consola si 2 pentru citire din XML pentru servicii");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        Console.Write("Nume serviciului:");
                        string nume = Console.ReadLine();
                        Console.Write("Cod:");
                        string cod = Console.ReadLine();
                        Console.Write("Categorie:");
                        string? categorie = Console.ReadLine();
                        Console.WriteLine("Pret:");
                        int pret = int.Parse(Console.ReadLine());
                        Serviciu serv = new Serviciu(nume, cod, CountServicii++, pret, categorie);
                        if (!elemente.Contains(serv))
                        {
                            //AddElement(serv);
                            elemente.Add(serv);
                        }
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
        public void AddElement(int count)
        {
            for(int i=0; i < count; i++)
            {
                Console.WriteLine("Datele pentru serviciul:" + (++CountServicii));
                AddElement();
            }
        }
        public Serviciu ReadUnServiciu()
        {
            Console.WriteLine("Datele pentru serviciul:" + (++CountServicii));
            Console.Write("Nume serviciului:");
            string nume = Console.ReadLine();
            Console.Write("Cod:");
            string cod = Console.ReadLine();
            Console.Write("Categorie:");
            string? categorie = Console.ReadLine();
            Console.WriteLine("Pret:");
            int pret = int.Parse(Console.ReadLine());
            return new Serviciu(nume, cod, CountServicii++, pret, categorie);
        }
        public void WriteServiciu() 
        {
            for (int i = 0; i < CountElemente; i++)
            {
                if (elemente[i] is Serviciu)    
                Console.WriteLine(elemente[i].Descriere());
            }
        }
        public void InitListafromXML()
        {
            //initializare lista dintr-un fisier XML
            XmlDocument doc = new XmlDocument();
            //incarca fisierul
            //doc.Load("...");
            doc.Load("C:\\Users\\User\\Desktop\\lab7.3\\app1\\Serviciu.xml"); //calea spre fisier
                                                                               //selecteaza nodurile
            XmlNodeList lista_noduri = doc.SelectNodes("/servicii/Serviciu");
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
                elemente.Add(new Serviciu(nume, codIntern, CountServicii++, pret, categorie));
            }

        }
        public override bool Contains(ProdusAbstract proda)
        {
            for (int i = 0; i < CountElemente; i++)
            {
                ProdusAbstract prod = elemente[i];
                if (proda == prod)
                    return true;
            }
            return false;
        }

    }
}
