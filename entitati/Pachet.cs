using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace entitati
{
    [XmlType("Pachet")]
    public class Pachet : ProdusAbstract
    {
        [XmlArray("Elemente")]
        public List<ProdusAbstract> elem_pachet = new List<ProdusAbstract>();

        public Pachet(string nume, string codintern, int id, int pret, string categorie) : base(nume, codintern, id, pret, categorie)
        { 
        }
        public Pachet()
        {

        }
        public void PachetDescriere()
        {
            foreach(ProdusAbstract p in elem_pachet)
            {
                p.AltaDescriere();
            }
        }
        public override string Descriere()
        {
            return base.AltaDescriere();
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Console.WriteLine(this.AltaDescriere());
            foreach (var element in elem_pachet)
            {
                sb.AppendLine(element.ToString());
            }

            return sb.ToString();
        }
        public void AddElement (ProdusAbstract e)
        {
            if (canAddToPackage(e))
            {
                elem_pachet.Add(e);
            }
        }
        public  bool canAddToPackage(ProdusAbstract pachet)
        {
            int prodcount = 0;
            foreach(ProdusAbstract pack in elem_pachet)
            {
                if(pack is Produs)
                {
                    prodcount++;
                }
            }
            if (prodcount > 1)
            {
                return false;
            }
            return true;
        }
        public void save2XML(string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Pachet));
            StreamWriter sw = new StreamWriter(fileName + ".xml");
            xs.Serialize(sw, this);
            sw.Close();
        }
        public Pachet loadFromXML(string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Pachet));
            FileStream fs = new FileStream(fileName + ".xml",
            FileMode.Open);
            XmlReader reader = new XmlTextReader(fs);
            //deserializare cu crearea de obiect => constructor fara param
            Pachet pachet = (Pachet)xs.Deserialize(reader);
            fs.Close();
            return pachet;
        }

    }
}
