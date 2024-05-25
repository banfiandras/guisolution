using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace realestate
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //isntall newtonsoft.Json nuget pakage, import it

            List<Ad> hirdetesek = Ad.LoadFromJson("realestates.json").ToList();

            Console.WriteLine("Földszintes ingatlanok átlagos alapterülete: {0:F2} m2",
                hirdetesek.Where(x => x.Floors == 0).Average(x => x.Area));

            var adat = hirdetesek.Where((x) => x.FreeOfCharge).OrderBy(x => x.DistanceTo(47.4164220114032, 19.066342425796986)).First();

            Console.WriteLine("Légvonal távolság:");
            Console.WriteLine("\tEladó neve: {0}", adat.Seller.Name);
            Console.WriteLine("\tEladó telefonszám: {0}", adat.Seller.Phone);
            Console.WriteLine("\talapterület: {0}", adat.Area);
            Console.WriteLine("\tszobák száma: {0}", adat.Rooms);

            Console.ReadLine();
        }
    }
}
