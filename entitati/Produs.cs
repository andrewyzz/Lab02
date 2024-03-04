using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entitati
{
    public class Produs
    {
        public string Producator { get; set; }
        public string CodIntern { get; set; }
        public string Nume { get; set; }
        public uint Id { get; set; }

        public Produs(string Producator, string CodIntern, string Nume, uint id)
        {
            this.Producator = Producator;
            this.CodIntern = CodIntern;
            this.Nume = Nume;
            this.Id = id;
        }
        public Produs()
        {

        }
        public void Afisare()
        {
            Console.WriteLine("Nume: "+Nume+" Producator: "+Producator+" CodIntern: "+CodIntern+" Id: "+Id);
        }
    }
}
