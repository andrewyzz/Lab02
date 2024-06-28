using entitati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace app1
{
    abstract class ProdusAbstractMgr
    {
        //public static ProdusAbstract[] elemente = new ProdusAbstract[100];
        protected static List<ProdusAbstract> elemente = new List<ProdusAbstract>();
        public static int CountElemente { get; set; } = 0;
        public abstract void AddElement();
        
            /*if (!Contains(element))
            {
                //elemente[CountElemente++] = element;
                elemente.Add(element);
            }*/
        public List<ProdusAbstract> getList()
        {
            return elemente;
        }
        public bool canAddToPackage(ProdusAbstract prod)
        {
            return false;
        }
        public void save2XML(string fileName)
        {
            Type[] prodAbstractTypes = new Type[3];
            prodAbstractTypes[0] = typeof(Serviciu);
            prodAbstractTypes[1] = typeof(Produs);
            prodAbstractTypes[2] = typeof(Pachet);
            XmlSerializer xs = new XmlSerializer(typeof(List<ProdusAbstract>), prodAbstractTypes);
            StreamWriter sw = new StreamWriter(fileName + ".xml");
            xs.Serialize(sw, elemente);
            sw.Close();
        }

        public static void Write2Console()
        {
            Console.WriteLine("elementele din tablou:");

            foreach(ProdusAbstract elem in elemente)
            {
                Console.WriteLine(elem.ToString());
            }
        }

        public ProdusAbstract[] Contains(string? cautat)
        {
            ProdusAbstract[] absNume = new ProdusAbstract[100];
            int numeCnt = 0;
            for (int i = 0; i < CountElemente; i++)
            {
                    ProdusAbstract prod = elemente[i];
                    if (prod.Nume == cautat)
                        absNume[numeCnt++] = prod;
            }
            return absNume;
        }
    }
}
