using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace Pexeso
{
    /// <summary>
    /// Trida rozsirujicich metod na serializaci a deserializaci parametru trid, ktere se ulozi do xml souboru.
    /// </summary>
    public static class PraceSxml
    {
        /// <summary>
        /// Vytvori xml soubor s parametry zadane instance tridy
        /// Poznamka: metoda neumi zpracovat IEnumerable, protoze to neumi spracovat XmlSerializer
        /// </summary>
        /// <param name="instanceObjektu">objekt urceny k serializaci</param>
        /// <param name="nazevSouboru">string ktery bude pouzit na vygenerovani nazvu xml souboru</param>
        /// <returns>string obsahujici xml</returns>
        public static void UlozInstanciDoXML(this object instanceObjektu, string nazevSouboru, string adresa, out bool ulozeno) 
        {
            ulozeno = false; //pokud nedojde k ulozeni vraci se false                
            string nazevAcesta = adresa + nazevSouboru; //vygeneruje cestu s nazvem ciloveho souboru
            try
            {
                //XmlSerializer serializerHryPexeso = new XmlSerializer(typeof(object)); //vytvori serializator, ktery bere promenene typu LogikaHry. typeof bere parametr, ktery urcuje typ promenne
                XmlSerializer serializerHryPexeso = new XmlSerializer(instanceObjektu.GetType()); //alternativa, ktera typ promenne zjistuje fci GetType()

                using (var sw = new StringWriter()) //StringWriter() metoda s knihovny system IO
                {

                    using (XmlWriter writer = XmlWriter.Create(nazevAcesta)) //Writer zapise xml do souboru xml
                    {                                                       
                        serializerHryPexeso.Serialize(sw, instanceObjektu);
                        //xml = sww.ToString(); // Your XML
                        ulozeno = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Naplni parametry objektu dane tridy. Pr. pouziti: LogikaHry pexeso = (LogikaHry)pexeso.Deserializuj("pexeso");
        /// </summary>
        /// <param name="instanceObjektu">objekt jehoz parametry se maji vyplnit</param>
        /// <param name="nazevSouboru">nazev souboru xml (string)</param>
        public static object Deserializuj(this object instanceObjektu, string nazevSouboru)
        {
            try
            {
                if (File.Exists(nazevSouboru)) //otestuje zda zadany soubor existuje
                {

                    XmlSerializer serializer = new XmlSerializer(instanceObjektu.GetType()); //vytvori serializer
                    using (StreamReader sr = new StreamReader(nazevSouboru)) //vytvori objek na precteni xml
                    {
                        //TODO
                        //instanceObjektu.Deserialize(instanceObjektu);
                        instanceObjektu = serializer.Deserialize(sr);
                    }  
                }
                else throw new FileNotFoundException("Soubor nebyl nalezen");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
            return instanceObjektu;
        }
        /// <summary>
        /// Vygeneruje automaticky nazev pro soubor. ten se sklada se zadaneho prefixu a data ulozeni (format: yyMMddHHmmss)
        /// </summary>
        /// <param name="nazev">promena, ktera ma obsahovat vygenerovany nazev pro soubor</param>
        /// <param name="prefix">textovy retezec, ktery ma byt pred retezcem reprezentujici datum a cas ulozeni</param>
        /// <returns>string s nazvem souboru ve tvaru hraDatum</returns>
        public static string VytvorNazev(this string nazev, string prefix = "soubor")
        {
            return $"{prefix}{DateTime.Now:yyMMddHHmmss}.xml";
        }


    }
}
