using entitati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app1
{
    internal class ServiciiMgr : ProdusAbstractMgr
    {
        //private Serviciu[] servicii = new Serviciu[100];
        public int CountServicii { get; set;} = 0;
        public void ReadServiciu()
        {
            Console.Write("Nume serviciului:");
            string nume = Console.ReadLine();
            Console.Write("Cod:");
            string cod = Console.ReadLine();
            Serviciu serv = new Serviciu(nume, cod, CountServicii);
            if(!Contains(serv)) { 
                AddElement(serv);
            }
        }
        public void ReadServiciu(int count)
        {
            for(int i=0; i < count; i++)
            {
                Console.WriteLine("Datele pentru serviciul:" + (++CountServicii));
                ReadServiciu();
            }
        }
        public Serviciu ReadUnServiciu()
        {
            Console.WriteLine("Datele pentru serviciul:" + (++CountServicii));
            Console.Write("Nume serviciului:");
            string nume = Console.ReadLine();
            Console.Write("Cod:");
            string cod = Console.ReadLine();
            return new Serviciu(nume, cod, CountServicii);
        }
        public void WriteServiciu() 
        {
            for (int i = 0; i < CountElemente; i++)
            {
                if (elemente[i] is Serviciu)    
                Console.WriteLine(elemente[i].Descriere());
            }
        }
        public bool Contains(Serviciu serv)
        {
            for(int i = 0; i < CountElemente; i++)
            {
                if (elemente[i] is Serviciu)
                {
                    Serviciu serviciu = (Serviciu)elemente[i];
                    if(serviciu==serv)
                        return true;
                }
            }
            return false;
        }
        public Serviciu[] Contains(string? serv)
        {
            Serviciu[] servNume = new Serviciu[100];
            int numeCnt = 0;
            for(int i = 0; i < CountElemente; i++)
            {
                if (elemente[i] is Serviciu)
                {
                    Serviciu serviciu = (Serviciu)elemente[i];
                    if(serviciu.Nume == serv)
                        servNume[numeCnt++] = serviciu;
                }
            }
            return servNume;
        }

    }
}
