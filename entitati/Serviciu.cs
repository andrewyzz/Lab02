using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entitati
{
    public class Serviciu
    {
        public string Service { get; set; }
        public int Pret { get; set; }
        public int Id { get; set; }
        public int Cod { get; set; }

        public Serviciu()
        {
        }
        public Serviciu(string service, int pret,int cod,int id) { 
            this.Service = service;
            this.Pret = pret;
            this.Id = id;
            this.Cod = cod;
        }
        public void Afisare()
        {
            Console.WriteLine("Serviciu: " + Service + " Pret: " + Pret + " CodIntern:"+Cod+ "Id:" + Id);
        }
    }
}
