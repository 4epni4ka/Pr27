using DBConnection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Леготкин.Classes.Context
{
    public class MovieContext: Movie, Interfaces.IMovie
    {
        public MovieContext() { }
        public MovieContext(int id, int idTeatr, string Movie, DateTime time, int price): base(id, idTeatr, Movie, time, price) { }
        public List<MovieContext> AllMovie()
        {
            List<MovieContext> allTMovie = new List<MovieContext>();

            MySqlConnection connection = Connection.OpenConnection();
            MySqlDataReader movieQuery = Connection.Query("SELECT * from cinema.movie;", connection);
            while (movieQuery.Read())
            {
                allTMovie.Add(new MovieContext(
                     movieQuery.GetInt32(0),
                     movieQuery.GetInt32(1),
                     movieQuery.GetString(2),
                     movieQuery.GetDateTime(3),
                     movieQuery.GetInt32(4)));
            }
            Connection.CloseConnection(connection);
            return allTMovie;
        }
        public void Save(bool Update = false)
        {
            if (Update)
            {
                MySqlConnection connection = Connection.OpenConnection();
                MySqlDataReader dataReader = Connection.Query("UPDATE 'cinema'.'movie' " + "SET " +
                    $"'idTeatr' = '{this.idTeatr}', " +
                    $"'movie' = '{this.movie}', " +
                    $"'time' = '{this.time}', " +
                    $"'price' = '{this.price}' " +
                    $"WHERE ('id' = '{this.id}');", connection);

                Connection.CloseConnection(connection);
            }
            else
            {
                MySqlConnection connection = Connection.OpenConnection();
                MySqlDataReader dataReader = Connection.Query("INSERT INTO 'cinema'.'movie'" +
                "('idTeatr'," +
                "'movie', " +
                "'time', " +
                "'price') " +
                "VALUES (" +
                $"'{this.idTeatr}', " +
                $"'{this.movie}', " +
                $"'{this.time}', " +
                $"'{this.price}')", connection);

                Connection.CloseConnection(connection);
            }
        }
        public void Delete()
        {
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Query($"DELETE FROM 'cinema'.'movie' WHERE ('id' = '{this.id}')", connection);
            Connection.CloseConnection(connection);
        }
    }
}
