using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace entitati
{
    public class Serviciu : ProdusAbstract
    {

        public Serviciu(string Nume, string CodIntern, int id, int pret, string categorie) : base(Nume, CodIntern, id, pret, categorie)
        {
            
        }
        public Serviciu() {}
        public void Afisare()
        {
            Console.WriteLine("Serviciu: " + Nume + " CodIntern:"+CodIntern+ "Id:" + Id);
        }
        public override string Descriere()
        {
            return "Serviciul: " + base.AltaDescriere() + ", ID:"+ base.Id;
        }
        public void save2XML(string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Serviciu));
            StreamWriter sw = new StreamWriter(fileName + ".xml");
            xs.Serialize(sw, this);
            sw.Close();
        }
        public Serviciu loadFromXML(string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Serviciu));
            FileStream fs = new FileStream(fileName + ".xml",
            FileMode.Open);
            XmlReader reader = new XmlTextReader(fs);
            //deserializare cu crearea de obiect => constructor fara param
            Serviciu serviciu = (Serviciu)xs.Deserialize(reader);
            fs.Close();
            return serviciu;
        }
        /*public override bool Equals(object obj)
        {
            if(obj == null || GetType() != obj.GetType()) return false;
            Serviciu srv = obj as Serviciu;
            return base.Nume == srv.Nume && base.CodIntern == srv.CodIntern;
        }*/
        public override bool Equals(ProdusAbstract obj)
        {
            if (obj == null)
            {
                return false;
            }
            return (base.Nume == obj.Nume) && (base.CodIntern == obj.CodIntern);
        }
    }
}
