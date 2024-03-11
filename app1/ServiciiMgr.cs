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
        private Serviciu[] servicii = new Serviciu[100];
        public int CountServicii { get; set;} = 0;
        public void ReadServiciu()
        {
            Console.Write("Nume serviciului:");
            string nume = Console.ReadLine();
            Console.Write("Cod:");
            string cod = Console.ReadLine();
            Serviciu serv = new Serviciu(nume, cod, CountServicii);
            if (Program.exist(servicii, serv))
            {
                Console.WriteLine("Serviciul respectiv exista");
            }
            else
            {
                servicii[CountServicii++] = serv;
            }
        }
        public void ReadServiciu(int count)
        {
            for(int i=0; i < count; i++)
            {
                Console.WriteLine("Datele pentru serviciul:" + i + 1); ;
            }
        }
        public void WriteServiciu() 
        {
        for(int i=0;i<CountServicii;i++)
            {
                servicii[i].Descriere();
            }
        }
    }
}
