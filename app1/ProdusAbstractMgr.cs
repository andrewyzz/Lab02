using entitati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace app1
{
    abstract class ProdusAbstractMgr
    {
        //public static ProdusAbstract[] elemente = new ProdusAbstract[100];
        public static List<ProdusAbstract> elemente = new List<ProdusAbstract>();
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

        public static void Write2Console()
        {
            Console.WriteLine("elementele din tablou:");

            foreach(ProdusAbstract elem in elemente)
            {
                Console.WriteLine(elem.ToString());
            }
        }
        public abstract bool Contains(ProdusAbstract proda);

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
        //Unused rn.
        /*public static bool exist(ProdusAbstract[] a, ProdusAbstract b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != null && a[i].Equals(b))
                {
                    return true;
                }
            }
            return false;
        }*/
    }
}
