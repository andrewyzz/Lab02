using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace entitati
{
    [XmlInclude(typeof(Produs)), XmlInclude(typeof(Serviciu)), XmlInclude(typeof(Pachet))]
    public abstract class ProdusAbstract : IPackageable
    {
        [XmlElement("ID")]
        public int Id { get; set; }
        [XmlElement("Numele")]
        public string Nume { get; set; }
        [XmlElement("CodulIntern")]
        public string CodIntern { get; set; }
        [XmlElement("Pretul")]
        public int Pret { get; set; }
        [XmlElement("Categoria")]
        public string Categorie { get; set; }
        protected ProdusAbstract(string nume,string codintern, int id, int pret,string categorie)
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
