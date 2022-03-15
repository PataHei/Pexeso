using System;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace pexesoTestovaniTridyLogikaHry
{
    /// <summary>
    /// Trida rozsirujicich metod na serializaci a deserializaci parametru trid, ktere se ulozi do xml souboru.
    /// </summary>
    public static class PraceSxml
    {
        /// <summary>
        /// Vytvori xml soubor s parametry zadane instance tridy
        /// </summary>
        /// <param name="instanceObjektu">objekt urceny k serializaci</param>
        /// <param name="nazevSouboru">string ktery bude pouzit na vygenerovani nazvu xml souboru</param>
        /// <returns>string obsahujici xml</returns>
        public static void UlozInstanciDoXML(this object instanceObjektu, string nazevSouboru) 
        {
            try
            {
                //XmlSerializer serializerHryPexeso = new XmlSerializer(typeof(object)); //vytvori serializator, ktery bere promenene typu LogikaHry. typeof bere parametr, ktery urcuje typ promenne
                XmlSerializer serializerHryPexeso = new XmlSerializer(instanceObjektu.GetType()); //alternativa, ktera typ promenne zjistuje fci GetType()

                using (var sww = new StringWriter()) //StringWriter() metoda s knihovny system IO
                {
                    using (XmlWriter writer = XmlWriter.Create(nazevSouboru)) //Writer zapise xml do souboru xml
                    {
                        serializerHryPexeso.Serialize(writer, instanceObjektu);
                        //xml = sww.ToString(); // Your XML
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
                        instanceObjektu = serializer.Deserialize(sr);//
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
       
    }
}
