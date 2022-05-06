using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PraceSdatabazi
{
    public class PraceSsql
    {
        //lokalni databaze
        string ConnectionString;
        SqlConnection sqlConnection;
       /// <summary>
       /// Seznam vypracovanych sql dotazu. Pouzije se nasledne v metode VyberSQLcommandText jako argument
       /// </summary>
        public enum VektoroveDotazy 
        {
            /// <summary>
            /// SELECT prezdivka FROM Hraci
            /// </summary>
            seznamHracu,
            /// <summary>
            /// SELECT TOP 10 DatumHry, PocetHracu, PocetKaret FROM Hry 
            /// </summary>
            seznamPoslednichDesetiHer,
            /// <summary>
            /// SELECT TOP 10 Hraci.prezdivka, VysledkyHracu.PocetTahu,  Hry.PocetKaret FROM VysledkyHracu. 
            /// </summary>
            topTenHerJednohoHracePodlePoctuTahuZebricekHracu,
            /// <summary>
            /// SELECT TOP 10 Hraci.prezdivka, VysledkyHracu.PocetTahu,  Hry.PocetKaret FROM VysledkyHracu . Promenna: prezdivka
            /// </summary>
            topTenHerJednohoHracePodlePoctuTahuOsobniZebricek,
            /// <summary>
            /// SELECT Hraci.prezdivka, VysledkyHracu.Skore,  Hry.PocetHracu, Hry.PocetKaret FROM VysledkyHracu. 
            /// </summary>
            VysledkyHryViceHracuPodleSkoreZebricekHracu,
            /// <summary>
            /// SELECT Hraci.prezdivka, VysledkyHracu.Skore,  Hry.PocetHracu, Hry.PocetKaret FROM VysledkyHracu. Promenna: prezdivka
            /// </summary>
            VysledkyHryViceHracuPodleSkoreOsobniZebricek

        }
        
        public PraceSsql(string connectionString)
        {
            this.ConnectionString = connectionString;
            sqlConnection = new SqlConnection(ConnectionString);
        }

        //NONQUERY
        public bool PridejHraceDoTabulkyHraci(string prezdivka)
        {
            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO Hraci (prezdivka) VALUES ('{prezdivka}')", sqlConnection);
                //command.Parameters.AddWithValue("@prezdivka", prezdivka);
                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //pokud se z nejakeho duvodu nepovede ulozit jmeno do databaze vrati se false. Mozne duvody: tabulka neexistuje, databaze neexistuje, jmeno uz v databazi je = neni jedinecne 
                return false;
            }
            return true;
        }

        public bool PridejHruDoTabulkyHry(int pocetHracu, int pocetKaret)
        {
            try
            {
                
                SqlCommand command = new SqlCommand($"INSERT INTO Hry (DatumHry, PocetHracu, PocetKaret) VALUES (@DatumHry, @PocetHracu, @PocetKaret)", sqlConnection);
                command.Parameters.AddWithValue("@DatumHry", DateTime.Now);
                command.Parameters.AddWithValue("@PocetHracu", pocetHracu);
                command.Parameters.AddWithValue("@PocetKaret", pocetKaret);
                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //pokud se z nejakeho duvodu nepovede ulozit jmeno do databaze vrati se false. Mozne duvody: tabulka neexistuje, databaze neexistuje, jmeno uz v databazi je = neni jedinecne 
                return false;
            }
            return true;
        }

        public void PridejVysledekHry()
        { }
        //DOTAZY 
        /// <summary>
        /// Podle vybrane hodnoty z enum VektoroveDotazy vrati textovy retezec s sql dotazem, ktery ma vratit tabulku dat.
        /// </summary>
        /// <param name="dotaz">enum s nazvy preddefinovanymi dotazy</param>
        /// <param name="prezdivka">volitelny string parametr, zadava se pokud ma byt vysledek pro konktretniho hrace. Vychozi hodnota je "".</param>
        /// <param name="pocetKaret">volitelny string parametr, pokud dotaz ma provest vyber podle poctu karet ve hre. Vychozi hodnota je "".</param>
        /// <returns>sql commandText</returns>
        public string VyberSQLcommandText(VektoroveDotazy dotaz)
        {
            string commandText = dotaz switch
            {
                VektoroveDotazy.seznamHracu => "SELECT prezdivka FROM Hraci",
                VektoroveDotazy.seznamPoslednichDesetiHer => "SELECT TOP 10 DatumHry, PocetHracu, PocetKaret FROM Hry ORDER BY DatumHry DESC",
                //10 nejrychleji zahranych her jednoho hrace
                VektoroveDotazy.topTenHerJednohoHracePodlePoctuTahuZebricekHracu => $"SELECT TOP 10 Hraci.prezdivka, VysledkyHracu.PocetTahu, Hry.PocetKaret FROM VysledkyHracu JOIN Hraci ON VysledkyHracu.IdHrac = Hraci.IdHrac FULL OUTER JOIN Hry ON VysledkyHracu.IdHry = Hry.IdHry WHERE Hry.PocetHracu = 1  ORDER BY VysledkyHracu.PocetTahu;",
                VektoroveDotazy.topTenHerJednohoHracePodlePoctuTahuOsobniZebricek => $"SELECT TOP 10 Hraci.prezdivka, VysledkyHracu.PocetTahu,  Hry.PocetKaret FROM VysledkyHracu JOIN Hraci ON VysledkyHracu.IdHrac = Hraci.IdHrac FULL OUTER JOIN Hry ON VysledkyHracu.IdHry = Hry.IdHry WHERE Hry.PocetHracu = 1 AND Hraci.prezdivka = @prezdivka ORDER BY VysledkyHracu.PocetTahu",
                VektoroveDotazy.VysledkyHryViceHracuPodleSkoreZebricekHracu => $"SELECT Hraci.prezdivka, VysledkyHracu.Skore,  Hry.PocetHracu, Hry.PocetKaret FROM VysledkyHracu RIGHT JOIN Hraci ON VysledkyHracu.IdHrac = Hraci.IdHrac FULL OUTER JOIN Hry  ON VysledkyHracu.IdHry = Hry.IdHry WHERE Hry.PocetHracu > 1 ORDER BY VysledkyHracu.Skore DESC", //vrati vsechny hry bez ohledu na pocet karet a pocet hracu - dofiltruje se v C# podle pozadavku uzivatele 
                VektoroveDotazy.VysledkyHryViceHracuPodleSkoreOsobniZebricek => $"SELECT Hraci.prezdivka, VysledkyHracu.Skore,  Hry.PocetHracu, Hry.PocetKaret FROM VysledkyHracu RIGHT JOIN Hraci ON VysledkyHracu.IdHrac = Hraci.IdHrac FULL OUTER JOIN Hry  ON VysledkyHracu.IdHry = Hry.IdHry WHERE Hry.PocetHracu > 1 AND Hraci.prezdivka = @prezdivka ORDER BY VysledkyHracu.Skore DESC", //vrati vsechny hry bez ohledu na pocet karet a pocet hracu - dofiltruje se v C# podle pozadavku uzivatele 
                _ => "", //default
            };
            return commandText;
        }

        public int ZjistiPocetJmenVDatabazi()
        {
                
                SqlCommand command = new ();
                sqlConnection.Open();
                command.Connection = sqlConnection;
                command.CommandText = "SELECT COUNT(*) FROM Hraci"; //sql dotaz
                int pocetJmen = (int)command.ExecuteScalar(); //vrati hodnotu spoctenou dotazem v sql
                Console.WriteLine($"Pocet jmen je {pocetJmen}");
                sqlConnection.Close(); // misto zavreni databaze by slo vse napsat do using a to zavre pripojeni automaticky
                return pocetJmen;
        }
        /// <summary>
        /// Metoda provede vektorovy dotaz. Vysledek vrati pole objektu (radky databaze) v Listu.
        /// </summary>
        /// <param name="dotaz">enum VektoroveDotazy, obsahujici seznam vypracovanych SQL dotazu</param>
        /// <returns>List<object[]></object></returns>
        public List<object[]> ZjistiZdatabazeVektoroveData(VektoroveDotazy dotaz, string prezdivka = "")
        {
            List<object[]> vysledek = new ();
          
                using SqlCommand command = new (VyberSQLcommandText(dotaz), sqlConnection);
                command.Parameters.AddWithValue("@prezdivka", prezdivka);
                sqlConnection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                
                while (dataReader.Read()) //dokud neprojde vsechny zaznamy
                {
                    var sloupce = new object[dataReader.FieldCount];
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        sloupce[i] = dataReader[i];
                    }
                    vysledek.Add(sloupce); //TODO
                }

                return vysledek;
            
        }
       
   
    }
}
