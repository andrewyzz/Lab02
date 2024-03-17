using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entitati
{
    public abstract class ProdusAbstract : IPackageable
    {
        public string Nume { get; set; }
        public string CodIntern {  get; set; }
        public int Id { get; set; }
        public int Pret { get; set; }
        public string Categorie { get; set; }
        public ProdusAbstract(string nume,string codintern, int id, int pret,string categorie)
        {
            this.Nume = nume;
            this.CodIntern = codintern;
            this.Id = id;
            this.Pret= pret;
            this.Categorie= categorie;
        }
        public ProdusAbstract() { }
        public abstract string Descriere();
        public virtual string AltaDescriere()
        {
            return "[" + this.CodIntern + "] " +this.Nume + " " + this.Categorie + " " + this.Pret ;
        }
        

        public override string ToString()
        {
            return "Nume:"+this.Nume +", CodIntern:"+this.CodIntern+", Id:"+this.Id + ",Categorie:"+this.Categorie+", Pret:"+ this.Pret;
        }
        public virtual bool Equals(Object o) { return base.Equals(o); }
        
        public virtual bool Equals(ProdusAbstract other)
        {
            return false;
        }

        public bool canAddToPackage(Pachet pachet)
        {
            return false;
        }
    }
}
