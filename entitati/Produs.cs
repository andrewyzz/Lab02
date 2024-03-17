using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace entitati
{
    public class Produs : ProdusAbstract
    {
        public string Producator { get; set; }
        

        public Produs(string Nume, string CodIntern, int id, int pret, string categorie, string Producator) : base(Nume,CodIntern,id,pret,categorie)
        {
            this.Producator = Producator;
            
        }
        public Produs() { }
        public void Afisare()
        {
            Console.WriteLine("Nume: " + Nume + " Producator: " + Producator + " CodIntern: " + CodIntern + " Id: " + Id);
        }
        public override string Descriere()
        {
            return "Produsul: " + base.AltaDescriere() + ", Producător: " + this.Producator + ", ID: " + base.Id;
        }
        public override bool Equals(ProdusAbstract obj)
        {
            if (obj == null)
            {
                return false;
            }

            return (base.Nume == obj.Nume) && (base.CodIntern == obj.CodIntern);
        }
        public int CompareTo(Produs obj)
        {
            if (obj == null) return 1;

            Produs otherProdus = obj as Produs;
            if (otherProdus != null)
                return this.Nume.CompareTo(otherProdus.Nume);
            else
                throw new ArgumentException("Object is not Produs.");
        }
        public void save2XML(string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Produs));
            StreamWriter sw = new StreamWriter(fileName + ".xml");
            xs.Serialize(sw, this);
            sw.Close();
        }
        public Produs loadFromXML(string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Produs));
            FileStream fs = new FileStream(fileName + ".xml",
            FileMode.Open);
            XmlReader reader = new XmlTextReader(fs);
            //deserializare cu crearea de obiect => constructor fara param
            Produs produs = (Produs)xs.Deserialize(reader);
            fs.Close();
            return produs;
        }
        public static bool operator ==(Produs p1, Produs p2)
            => ((p1.Nume == p2.Nume) && (p1.CodIntern == p2.CodIntern) && (p1.Producator == p2.Producator));
        public static bool operator !=(Produs p1, Produs p2)
            => !((p1.Nume == p2.Nume) && (p1.CodIntern == p2.CodIntern) && (p1.Producator == p2.Producator));
    }
    
}
