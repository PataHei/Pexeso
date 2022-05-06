using System;
using System.Collections.Generic;
using System.Linq;
using PataClassLibraryExtation;

namespace PraceSdatabazi
{
    class Program
    {
        static void Main()
        {
            PraceSsql praceSsql = new (connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrator\source\repos\czechitas\Cis\20211201\Pexeso\Pexeso\DataPexeso.mdf;Integrated Security=True;Connect Timeout=30");
            
            List<object[]> VysledekSQL = praceSsql.ZjistiZdatabazeVektoroveData(PraceSsql.VektoroveDotazy.topTenHerJednohoHracePodlePoctuTahuOsobniZebricek,"Karel");
            foreach (var item in VysledekSQL)
            {
                item.TiskniTo();
            }

            praceSsql.PridejHraceDoTabulkyHraci("Jarmila");
            praceSsql.PridejHruDoTabulkyHry(4, 36);
            Console.Read();
        }
    }

    
}
