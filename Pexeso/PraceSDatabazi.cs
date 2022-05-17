using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Pexeso
{
    public class PraceSDatabazi
    {
        
        //lokalni databaze
        readonly string connectionString;
        readonly SqlConnection sqlConnection;
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
            /// SELECT TOP 10 Hraci.prezdivka, VysledkyHracu.PocetTahu,  Hry.PocetKaret FROM VysledkyHracu. Promenna: prezdivka
            /// </summary>
            topTenHerJednohoHracePodlePoctuTahuOsobniZebricek,
            /// <summary>
            /// SELECT Hraci.prezdivka, VysledkyHracu.Skore,  Hry.PocetHracu, Hry.PocetKaret FROM VysledkyHracu. 
            /// Vrati vsechny hry bez ohledu na pocet karet a pocet hracu - dofiltruje se v C# podle pozadavku uzivatele
            /// </summary>
            VysledkyHryViceHracuPodleSkoreZebricekHracu,
            /// <summary>
            /// SELECT Hraci.prezdivka, VysledkyHracu.Skore,  Hry.PocetHracu, Hry.PocetKaret FROM VysledkyHracu. Promenna: prezdivka.
            /// Vrati vsechny hry bez ohledu na pocet karet a pocet hracu - dofiltruje se v C# podle pozadavku uzivatele 
            /// </summary>
            VysledkyHryViceHracuPodleSkoreOsobniZebricek,
            /// <summary>
            /// SELECT IdHrace FROM Hraci. Promenna: prezdivka.
            /// Vrati IdHrace podle prezdivky
            /// </summary>
            IDHrace

        }

        public PraceSDatabazi()
        {
            this.connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Administrator\source\repos\czechitas\Cis\20211201\Pexeso\Pexeso\DataPexeso.mdf;Integrated Security = True; Connect Timeout = 30";
            sqlConnection = new SqlConnection(this.connectionString);
        }


        //NONQUERY INSERTS
       
        /// <summary>
        /// Prida informace o hraci pexesa do sql databaze do tabulky Hraci. Pokud jmeno jiz v databazi je do tabulky se neulozi
        /// </summary>
        ///<param name="prezdivka">string se jmenem. Limit poctu znaku je dan nastavenim tabulky v databazi</param>
        /// <returns>true pokud ulozeni probehlo v poradku </returns>
        public bool PridejHraceDoTabulkyHraci(string prezdivka)
        {

            SqlCommand command = new SqlCommand($"INSERT INTO Hraci (prezdivka) VALUES (@prezdivka)", sqlConnection);
            command.Parameters.AddWithValue("@prezdivka", prezdivka);
            sqlConnection.Open();
            try
            {
                command.ExecuteNonQuery();
            }
            catch 
            {
                sqlConnection.Close();
                return false;
            }
            
            sqlConnection.Close();
            return true;
        }

        /// <summary>
        /// Prida informace o zalozene hre pexeso do sql databaze do tabulky Hry
        /// </summary>
        /// <param name="pocetHracu">int pocet hracu </param>
        /// <param name="pocetKaret">int pocet karticek pexesa</param>
        /// <returns>true pokud ulozeni probehlo v poradku </returns>
        public bool PridejHruDoTabulkyHry(int pocetHracu, int pocetKaret)
        {

            SqlCommand command = new SqlCommand($"INSERT INTO Hry (DatumHry, PocetHracu, PocetKaret) VALUES (@DatumHry, @PocetHracu, @PocetKaret)", sqlConnection);
            command.Parameters.AddWithValue("@DatumHry", DateTime.Now);
            command.Parameters.AddWithValue("@PocetHracu", pocetHracu);
            command.Parameters.AddWithValue("@PocetKaret", pocetKaret);
            sqlConnection.Open();
            command.ExecuteNonQuery();
            sqlConnection.Close();

            return true;

        }
        /// <summary>
        /// Fce zjisti z databaze id hry s nejvyssi hodnotou a toto IdHry s tabulky Hry vrati jako int.
        /// </summary>
        /// <returns>int maximalni IdHry s tabulky Hry</returns>
        public int ZjistiZdatabazeIdHry()
        {
            SqlCommand command = new SqlCommand($"SELECT TOP 1 IdHry FROM Hry ORDER BY IdHry DESC", sqlConnection);
            sqlConnection.Open();
            SqlDataReader idHry = command.ExecuteReader();
            idHry.Read();
            int idHryInt = (int)idHry[0];
            sqlConnection.Close();
            return idHryInt;

        }

        public int ZjistiZdatabazeIdHrace(string prezdivka)
        {
            SqlCommand command = new SqlCommand(VyberSQLcommandText(VektoroveDotazy.IDHrace), sqlConnection);
            command.Parameters.AddWithValue("@prezdivka", prezdivka);
            sqlConnection.Open();
            SqlDataReader idHrac = command.ExecuteReader();
            idHrac.Read();
            int idHracInt = (int)idHrac[0];
            sqlConnection.Close();
            return idHracInt;
        }

        /// <summary>
        /// Prida vysledek hry do SQL databaze
        /// </summary>
        /// <param name="values">string s hodnotama ve tvaru: IdHry, IdHrac, Skore, PocetTahu </param>
        /// <returns></returns>
        public bool PridejVysledekHry(int IdHry, int IdHrac, int Skore, int PocetTahu)
        {

            SqlCommand command = new SqlCommand($"INSERT INTO VysledkyHracu (IdHry, IdHrac, Skore, PocetTahu ) VALUES (@idHry, @idHrac, @Skore, @PocetTahu)", sqlConnection);
            command.Parameters.AddWithValue("@idHry", IdHry);
            command.Parameters.AddWithValue("@idHrac", IdHrac);
            command.Parameters.AddWithValue("@Skore", Skore);
            command.Parameters.AddWithValue("@PocetTahu", PocetTahu);
            sqlConnection.Open();
            command.ExecuteNonQuery();
            sqlConnection.Close();
            return true;
        }

        //DOTAZY 
        /// <summary>
        /// Podle vybrane hodnoty z enum VektoroveDotazy vrati textovy retezec s sql dotazem, ktery ma vratit tabulku dat.
        /// </summary>
        /// <param name="dotaz">enum s nazvy preddefinovanymi dotazy</param>
        /// <param name="prezdivka">volitelny string parametr, zadava se pokud ma byt vysledek pro konktretniho hrace. Vychozi hodnota je "".</param>
        /// <param name="pocetKaret">volitelny string parametr, pokud dotaz ma provest vyber podle poctu karet ve hre. Vychozi hodnota je "".</param>
        /// <returns>sql commandText</returns>
        string VyberSQLcommandText(VektoroveDotazy dotaz)
        {
            string commandText;

            switch (dotaz)
            {
                case VektoroveDotazy.seznamHracu:
                    commandText = "SELECT prezdivka FROM Hraci";
                    break;
                case VektoroveDotazy.seznamPoslednichDesetiHer:
                    commandText = "SELECT TOP 10 DatumHry, PocetHracu, PocetKaret FROM Hry ORDER BY DatumHry DESC";
                    break;
                case VektoroveDotazy.topTenHerJednohoHracePodlePoctuTahuZebricekHracu:
                    commandText = $"SELECT TOP 10 Hraci.prezdivka, VysledkyHracu.PocetTahu, Hry.PocetKaret FROM VysledkyHracu JOIN Hraci ON VysledkyHracu.IdHrac = Hraci.IdHrac FULL OUTER JOIN Hry ON VysledkyHracu.IdHry = Hry.IdHry WHERE Hry.PocetHracu = 1  ORDER BY VysledkyHracu.PocetTahu;";
                    break;
                case VektoroveDotazy.topTenHerJednohoHracePodlePoctuTahuOsobniZebricek:
                    commandText = $"SELECT TOP 10 Hraci.prezdivka, VysledkyHracu.PocetTahu,  Hry.PocetKaret FROM VysledkyHracu JOIN Hraci ON VysledkyHracu.IdHrac = Hraci.IdHrac FULL OUTER JOIN Hry ON VysledkyHracu.IdHry = Hry.IdHry WHERE Hry.PocetHracu = 1 AND Hraci.prezdivka = @prezdivka ORDER BY VysledkyHracu.PocetTahu";

                    break;
                case VektoroveDotazy.VysledkyHryViceHracuPodleSkoreZebricekHracu:
                    commandText = $"SELECT Hraci.prezdivka, VysledkyHracu.Skore,  Hry.PocetHracu, Hry.PocetKaret FROM VysledkyHracu RIGHT JOIN Hraci ON VysledkyHracu.IdHrac = Hraci.IdHrac FULL OUTER JOIN Hry  ON VysledkyHracu.IdHry = Hry.IdHry WHERE Hry.PocetHracu > 1 ORDER BY VysledkyHracu.Skore DESC"; //vrati vsechny hry bez ohledu na pocet karet a pocet hracu - dofiltruje se v C# podle pozadavku uzivatele 
                    break;
                case VektoroveDotazy.VysledkyHryViceHracuPodleSkoreOsobniZebricek:
                    commandText = $"SELECT Hraci.prezdivka, VysledkyHracu.Skore,  Hry.PocetHracu, Hry.PocetKaret FROM VysledkyHracu RIGHT JOIN Hraci ON VysledkyHracu.IdHrac = Hraci.IdHrac FULL OUTER JOIN Hry  ON VysledkyHracu.IdHry = Hry.IdHry WHERE Hry.PocetHracu > 1 AND Hraci.prezdivka = @prezdivka ORDER BY VysledkyHracu.Skore DESC"; //vrati vsechny hry bez ohledu na pocet karet a pocet hracu - dofiltruje se v C# podle pozadavku uzivatele 
                    break;
                case VektoroveDotazy.IDHrace:
                    commandText = $"SELECT Hraci.IdHrac FROM Hraci WHERE Hraci.prezdivka = @prezdivka";
                    break;
                default:
                    throw new ArgumentException(message: "invalid enum value", paramName: nameof(dotaz));
                    
            }

            return commandText;
        }
        /// <summary>
        /// Vrati pocet ulozenych prezdivek v databazi
        /// </summary>
        /// <returns>int pocet prezdivek</returns>
        public int ZjistiPocetJmenVDatabazi()
        {

            SqlCommand command = new SqlCommand();
            sqlConnection.Open();
            command.Connection = sqlConnection;
            command.CommandText = "SELECT COUNT(*) FROM Hraci"; //sql dotaz
            int pocetJmen = (int)command.ExecuteScalar(); //vrati hodnotu spoctenou dotazem v sql
            Console.WriteLine($"Pocet jmen je {pocetJmen}");
            sqlConnection.Close(); // misto zavreni databaze by slo vse napsat do using a to zavre pripojeni automaticky
            return pocetJmen;
 
        }

        /// <summary>
        /// Fce provede vektorovy dotaz. Vysledek vrati pole objektu (radky databaze) v Listu.
        /// </summary>
        /// <param name="dotaz">enum VektoroveDotazy, obsahujici seznam vypracovanych SQL dotazu</param>
        /// <param name="prezdivka">volitelny string, zadava se pokud ma byt vysledkem osobni statistika pro jednoho hrace</param>
        /// <returns>List<object[]></object></returns>
        public List<object[]> ZjistiZdatabazeVektoroveData(VektoroveDotazy dotaz, string prezdivka = "")
        {
            List<object[]> vysledek = new List<object[]>();   

            SqlCommand command = new SqlCommand(VyberSQLcommandText(dotaz), sqlConnection);
            command.Parameters.AddWithValue("@prezdivka", prezdivka); //ohlida aby nekdo se nesnazil sabotovat databazi injekci napr. prikazu DROP nebo neco jineho
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
            sqlConnection.Close();
            return vysledek;

        }

        /// <summary>
        /// Fce provede dotaz v tabulce Hraci a vrati vsechny ulozene prezdivky
        /// </summary>
        /// <returns>pole stringu s prezdivkama</returns>
        public string[] VratSeznamHracu()
        {
            List<string> vysledek = new List<string>();

            SqlCommand command = new SqlCommand(VyberSQLcommandText(VektoroveDotazy.seznamHracu), sqlConnection);
            
            sqlConnection.Open();
            
            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read()) //dokud neprojde vsechny zaznamy
            {
                vysledek.Add(dataReader["Prezdivka"].ToString()); //TODO
            }
            sqlConnection.Close();
            return vysledek.ToArray();
        }

    }
}
