using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;

namespace Зоомагазин.Database
{
    public class Connection
    {
        private static string connectionString =
            "Host=localhost;Port=5432;Database=Зоомагазин;Username=postgres;Password=222111mapa;";

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }

        public static bool TestConnection()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    MessageBox.Show("Подключение к базе данных успешно!");
                    return true;
                }
            }

            catch (Exception error)
            {
                MessageBox.Show("Ошибка подключения!" + error.Message);
                return false;
            }
        }
    }

}
