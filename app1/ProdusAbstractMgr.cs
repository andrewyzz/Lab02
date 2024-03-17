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
        public static ProdusAbstract[] elemente = new ProdusAbstract[100];

        public static int CountElemente { get; set; } = 0;
        public static void AddElement(ProdusAbstract element)
        {
            if (CountElemente < elemente.Length)
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
        //Unused rn.
        public static bool exist(ProdusAbstract[] a, ProdusAbstract b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != null && a[i].Equals(b))
                {
                    Console.WriteLine("EQUALS:" + a[i] + ",B:" + b);
                    return true;
                }
            }
            return false;
        }
    }
}
