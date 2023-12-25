using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Cinema_Леготкин.Classes.Context
{
    public class TeatrContext:Teatr
    {
        public TeatrContext(int id, string name, int countZal, int countMest) : base(id, name, countZal, countMest) { }
        public static List<TeatrContext> AllTeatr()
        {
            List<TeatrContext> allTeatr = new List<TeatrContext>();

            MySqlConnection connection = DBConnection.Connection.OpenConnection();
            MySqlDataReader teatrQuery = DBConnection.Connection.Query("SELECT * from cinema.teatr;", connection);
            while (teatrQuery.Read())
            {
                allTeatr.Add(new TeatrContext(
                    teatrQuery.GetInt32(0),
                    teatrQuery.GetString(1),
                    teatrQuery.GetInt32(2),
                    teatrQuery.GetInt32(3)));
            }
            DBConnection.Connection.CloseConnection(connection);
            return allTeatr;
        }
    }
}
