using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Леготкин.Classes.Context
{
    public class MovieContext: Movie
    {
        public MovieContext(int id, int idTeatr, string Movie, DateTime time, int price): base(id, idTeatr, Movie, time, price) { }
        public static List<MovieContext> AllTeatr()
        {
            List<MovieContext> allTMovie = new List<MovieContext>();

            MySqlConnection connection = DBConnection.Connection.OpenConnection();
            MySqlDataReader movieQuery = DBConnection.Connection.Query("SELECT * from cinema.movie;", connection);
            while (movieQuery.Read())
            {
                allTMovie.Add(new MovieContext(
                     movieQuery.GetInt32(0),
                     movieQuery.GetInt32(1),
                     movieQuery.GetString(2),
                     movieQuery.GetDateTime(3),
                     movieQuery.GetInt32(4)));
            }
            DBConnection.Connection.CloseConnection(connection);
            return allTMovie;
        }
    }
}
