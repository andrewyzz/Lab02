using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entitati
{
    public class Pachet : ProdusAbstract
    {
        private  List<IPackageable> elem_pachet = new List<IPackageable>();

        public Pachet(string nume, string codintern, int id, int pret, string categorie) : base(nume, codintern, id, pret, categorie)
        { 
          
        }
        public void PachetDescriere()
        {
            foreach(ProdusAbstract p in elem_pachet)
            {
                p.AltaDescriere();
            }
        }
        public override string Descriere()
        {
            return base.AltaDescriere();
        }
        public override string AltaDescriere()
        {
            return base.AltaDescriere();
        }
        public void AddElement (ProdusAbstract e)
        {
            if (canAddToPackage((Pachet)e))
            {
                elem_pachet.Add(e);
            }
        }
        public  bool canAddToPackage(Pachet pachet)
        {
            int prodcount = 0;
            foreach(Pachet pack in elem_pachet)
            {
                if(pack is Produs)
                {
                    prodcount++;
                }
            }
            if (prodcount > 1)
            {
                return false;
            }
            return true;
        }
        
    }
}
