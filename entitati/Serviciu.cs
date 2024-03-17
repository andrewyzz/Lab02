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
        public string CodIntern { get; set; }

        public Serviciu(string Nume, string CodIntern, int Id) : base(Nume, CodIntern, Id) {
            this.Nume = Nume;
            this.CodIntern = CodIntern;
            this.Id = Id;
        }
        public void Afisare()
        {
            Console.WriteLine("Serviciu: " + Nume + " CodIntern:"+CodIntern+ "Id:" + Id);
        }
        public override string Descriere()
        {
            return "Serviciul: " + base.AltaDescriere() + ", ID:"+ base.Id;
        }
        public override bool Equals(object obj)
        {
            if(obj == null || GetType() != obj.GetType()) return false;
            Serviciu srv = obj as Serviciu;
            return base.Nume == srv.Nume && base.CodIntern == srv.CodIntern;
        }
    }
}
