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
        readonly static string connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrator\source\repos\czechitas\Cis\20211201\Pexeso\Pexeso\DataPexeso.mdf;Integrated Security=True;Connect Timeout=30";
        SqlConnection sqlConnection = new SqlConnection(connetionString);

        public PraceSDatabazi()
        {
            
        }

        public string[] NactiPresdivky()
        {
            string[] prezdivky;
            using (sqlConnection)
            {
                SqlCommand nactiHrace = new SqlCommand("SELECT Jmeno FROM Table", sqlConnection);
                sqlConnection.Open();
                
                return prezdivky;
            }

            return prezdivky;

        }
    }
}
