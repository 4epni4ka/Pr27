using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using DBConnection;

namespace Cinema_Леготкин.Classes.Context
{
    public class TeatrContext:Teatr, Interfaces.ITeatr
    {
        public TeatrContext(int id, string name, int countZal, int countMest) : base(id, name, countZal, countMest) { }
        public List<TeatrContext> AllTeatr()
        {
            List<TeatrContext> allTeatr = new List<TeatrContext>();

            MySqlConnection connection = Connection.OpenConnection();
            MySqlDataReader teatrQuery = Connection.Query("SELECT * from cinema.teatr;", connection);
            while (teatrQuery.Read())
            {
                allTeatr.Add(new TeatrContext(
                    teatrQuery.GetInt32(0),
                    teatrQuery.GetString(1),
                    teatrQuery.GetInt32(2),
                    teatrQuery.GetInt32(3)));
            }
            Connection.CloseConnection(connection);
            return allTeatr;
        }
        public void Save(bool Update = false)
        {
            if (Update)
            {
                MySqlConnection connection = Connection.OpenConnection();
                MySqlDataReader dataReader = Connection.Query("UPDATE 'cinema'.'teatr' " + "SET " +
                    $"'name' = '{this.name}', " +
                    $"'countzal' = '{this.countZal}', " +
                    $"'countmest' = '{this.countMest}' " +
                    $"WHERE ('id' = '{this.id}');", connection);

                Connection.CloseConnection(connection);
            }
            else
            {
                MySqlConnection connection = Connection.OpenConnection();
                MySqlDataReader dataReader = Connection.Query("INSERT INTO 'cinema'.'teatr'" +
                "('name'," +
                "'countzal', " +
                "'countmest') " +
                "VALUES (" +
                $"'{this.name}', " +
                $"'{this.countZal}', " +
                $"'{this.countMest}')", connection);

                Connection.CloseConnection(connection);
            }
        }
        public void Delete()
        {
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Query($"DELETE FROM 'cinema'.'teatr' WHERE ('id' = '{this.id}')", connection);
            Connection.CloseConnection(connection);
        }
    }
}
