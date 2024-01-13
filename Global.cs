using System.Data.SqlClient;
using System.Web.Configuration;

namespace AdvisingSystem
{
    public class Global
    {
        public static readonly string ConnectionString = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

    }
}