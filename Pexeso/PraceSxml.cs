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
    /// Poznamka1: instance musi mit bezparametricky konstruktor
    /// Poznamka2: vsechny parametry instance, ktere maji byt serializovany musi byt public jinak je neprecte
    /// Poznamka3: metoda neumi zpracovat IEnumerable, protoze to neumi spracovat XmlSerializer
    /// </summary>
    public static class PraceSxml
    {
        /// <summary>
        /// Vytvori xml soubor s parametry zadane instance tridy
        /// </summary>
        /// <param name="instanceObjektu">objekt urceny k serializaci</param>
        /// <param name="nazevSouboru">string ktery bude pouzit na vygenerovani nazvu xml souboru</param>
        /// <param name="adresa">cesta kde ma byt ulozeny soubor xml</param>
        /// <param name="ulozeno">bool hodnota true pokud problehlo ulozeni xml</param>
        /// <returns>string obsahujici xml</returns>
        public static void UlozInstanciDoXMLsouboru(this object instanceObjektu, string nazevSouboru, string adresa, out bool ulozeno) 
        {
            ulozeno = false; //pokud nedojde k ulozeni vraci se false                
            string nazevAcesta = adresa + nazevSouboru; //vygeneruje cestu s nazvem ciloveho souboru
            try
            {
                //XmlSerializer serializerHryPexeso = new XmlSerializer(typeof(object)); //vytvori serializator, ktery bere promenene typu LogikaHry. typeof bere parametr, ktery urcuje typ promenne
                XmlSerializer serializerHryPexeso = new XmlSerializer(instanceObjektu.GetType()); //alternativa, ktera typ promenne zjistuje fci GetType()

               // using (var sw = new StringWriter()) //StringWriter() metoda s knihovny system IO
               // {

                    using (XmlWriter writer = XmlWriter.Create(nazevAcesta)) //Writer zapise xml do souboru xml
                    {                                                       
                        serializerHryPexeso.Serialize(writer, instanceObjektu);
                        //xml = sww.ToString(); // Your XML
                        ulozeno = true;
                    }
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Vytvori xml textovy retezec s parametry zadane instance tridy
        /// </summary>
        /// <param name="instanceObjektu">objekt urceny k serializaci</param>
        /// <returns>string obsahujici xml</returns>
        public static string UlozInstanciDoXMLretezce(this object instanceObjektu)
        {
            string xmlInstance = "";
            try
            {
                XmlSerializer serializerOfInstance = new XmlSerializer(instanceObjektu.GetType()); //alternativa, ktera typ promenne zjistuje fci GetType()

                using (var sw = new StringWriter()) //StringWriter() metoda s knihovny system IO

                {
                    serializerOfInstance.Serialize(sw, instanceObjektu);
                    xmlInstance = sw.ToString(); // Your XML
                    MessageBox.Show(xmlInstance);
                    return xmlInstance;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return xmlInstance;
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
        /// <param name="prefix">textovy retezec, ktery ma byt pred retezcem reprezentujici datum a cas ulozeni</param>
        /// <returns>string s nazvem souboru ve tvaru hraDatum</returns>
        public static string VytvorNazev(this string prefix)
        {
            return $"{prefix}{DateTime.Now:yyMMddHHmmss}.xml";
        }

    }
}
