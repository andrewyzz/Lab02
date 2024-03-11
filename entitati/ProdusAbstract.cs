using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entitati
{
    public abstract class ProdusAbstract
    {
        public string Nume { get; set; }
        public string CodIntern {  get; set; }
        public int Id { get; set; }
        public ProdusAbstract(string nume,string codintern, int id)
        {
            Nume = nume;
            CodIntern = codintern;
            Id = id;
        }
        public abstract string Descriere();
        public virtual string AltaDescriere()
        {
            return "[" + this.CodIntern + "] " +this.Nume;
        }
        public override string ToString()
        {
            return "Nume:"+this.Nume +", CodIntern:"+this.CodIntern+", Id:"+this.Id;
        }

    }
}
