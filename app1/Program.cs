using entitati;
namespace app1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nr. produse:");
            uint nrProduse = uint.Parse(Console.ReadLine() ?? string.Empty);
            Console.Write("Nr. servicii:");
            uint nrServicii = uint.Parse(Console.ReadLine() ?? string.Empty);
            Produs[] produse = new Produs[nrProduse];
            Serviciu[] servicii = new Serviciu[nrServicii];
            for (int cnt = 0; cnt < nrProduse; cnt++)
            {
                Console.WriteLine("Introdu un produs");
                Console.Write("Numele:");
                string? nume = Console.ReadLine();
                bool exista = false;
                for(int i = 0; i < cnt; i++)
                {
                    if (produse[i] != null && produse[i].Nume == nume)
                    {
                        exista = true;
                        Console.WriteLine("Produsul respectiv exista");
                        break;
                    }
                }
                if (exista)
                {
                    continue;
                }
                Console.Write("Codul intern:");
                string? codintern = Console.ReadLine();
                Console.Write("Producator:");
                string? producator = Console.ReadLine();
                Produs prod = new Produs(producator,codintern,nume,(uint)cnt);
                produse[cnt] = prod;
            }
            for(int cnt = 0; cnt < nrServicii; cnt++)
            {
                Console.Write("Nume serviciului:");
                string nume= Console.ReadLine();
                bool exista = false;
                for (int i = 0; i < cnt; i++)
                {
                    if (servicii[i] != null && servicii[i].Service == nume)
                    {
                        Console.WriteLine("Serviciul exista deja");
                        exista = true;
                        break;
                    }
                }
                if (exista)
                {
                    continue;
                }
                Console.Write("Pret:");
                int pret = int.Parse(Console.ReadLine());
                Console.Write("Cod:");
                int cod = int.Parse(Console.ReadLine());
                Serviciu serv = new Serviciu(nume, pret,cod, cnt);
                servicii[cnt] = serv;
            }
            Console.WriteLine("Produsele sunt:");
            for (int cnt = 0; cnt < nrProduse; cnt++)
            {
                Produs prod = produse[cnt];
                if (prod != null)
                {
                    prod.Afisare();
                }
            }
            for (int cnt = 0; cnt < nrServicii; cnt++)
            {
                Serviciu serv = servicii[cnt];
                if (serv != null)
                {
                    serv.Afisare();
                }
            }
        }
    }
}
