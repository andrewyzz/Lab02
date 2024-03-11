using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entitati
{
    public class Serviciu : ProdusAbstract
    {
        public string Nume { get; set; }
        public int Id { get; set; }
        public string Cod { get; set; }

        public Serviciu(string nume, string cod, int id) : base(nume, cod, id) { 
            this.Nume = nume;
            this.Id = id;
            this.Cod = cod;
        }
        public void Afisare()
        {
            Console.WriteLine("Serviciu: " + Nume + " CodIntern:"+Cod+ "Id:" + Id);
        }
        public override string Descriere()
        {
            return "Serviciul: " + base.AltaDescriere() + ", ID:"+ this.Id;
        }
        public override bool Equals(object obj)
        {
            if(obj== null || GetType() != obj.GetType()) return false;
            Serviciu srv = (Serviciu)obj;
            return Nume == srv.Nume && Id==srv.Id;
        }
    }
}
