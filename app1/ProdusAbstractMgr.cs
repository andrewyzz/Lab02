using entitati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app1
{
    abstract class ProdusAbstractMgr
    {
        protected static ProdusAbstract[] elemente = new ProdusAbstract[100];

        protected static int CountElemente { get; set; } = 0;
        public static void AddElement(ProdusAbstract element)
        {
            if (CountElemente < elemente.Length && !exist(elemente,element))
            {
                elemente[CountElemente++] = element;
                
            }
            else
            {
                Console.WriteLine("Produsul/serviciul exista deja.");
            }
        }
        public static void Write2Console()
        {
            Console.WriteLine("elementele din tablou:");

            for (int i = 0; i < CountElemente; i++)
            {
                Console.WriteLine(elemente[i].Descriere());
            }
        }
        public static bool exist(Object[] a, Object b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != null && a[i].Equals(b))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
