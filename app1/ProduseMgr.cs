using entitati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace app1
{
    internal class ProduseMgr : ProdusAbstractMgr
    {
        public int CountProduse { get; set; } = 0;
        
        public override void AddElement()
        {
            Console.WriteLine("Apasati 1 pentru citire din consola si 2 pentru citire din XML pentru Produse");
            int choice= int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
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
                        Produs prod = new Produs(nume, codintern, CountProduse, pret, categorie,producator);
                        if (!elemente.Contains(prod))
                        {
                            //AddElement(prod);
                            elemente.Add(prod);
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
        public void ReadProdus(int count)
        {
            for(int i = 0; i < count; i++)
            {
                Console.WriteLine("Datele pentru produsul:" + (++CountProduse));
                AddElement();
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
            Console.Write("Categorie:");
            string? categorie = Console.ReadLine();
            Console.Write("Pret:");
            int pret = int.Parse(Console.ReadLine());
            return new Produs(nume, codintern, CountProduse, pret, categorie, producator);
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

        public void InitListafromXML()
        {
            //initializare lista dintr-un fisier XML
            XmlDocument doc = new XmlDocument();
            //incarca fisierul
            //doc.Load("...");
            doc.Load("C:\\Users\\User\\Desktop\\lab7.3\\app1\\Produs.xml"); //calea spre fisier
                                        //selecteaza nodurile
            XmlNodeList lista_noduri = doc.SelectNodes("/produse/Produs");
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
                elemente.Add(new Produs(nume, codIntern, CountProduse, pret, categorie, producator));
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

        /*public Produs[] Contains(string? nume)
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
        }*/

    }
}
