using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Laminatsia.DTO
{
    public class ServerDateTime
    {
        public DateTime GetDateTimeServer()
        {
            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LaminatsiaEntities"].ConnectionString;
                EntityConnectionStringBuilder builder = new EntityConnectionStringBuilder(connectionString);
                //витягуємо з файла конфіга строку для sql конекта
                connectionString = builder.ProviderConnectionString;

                using (var sql = new SqlConnection(connectionString))
                {
                    sql.Open();
                    string scriptGetDate = "SELECT GETDATE();";
                    SqlCommand sqlCreateDBCreated = new SqlCommand(scriptGetDate, sql);
                    DateTime dateSqlServer = DateTime.Parse(sqlCreateDBCreated.ExecuteScalar().ToString());
                    MessageBox.Show(dateSqlServer.ToString());
                    return dateSqlServer;
                }
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
                return DateTime.Now;
            }
        }
    }
}
