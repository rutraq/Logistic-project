using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace LogisticProgram
{
    class Sql
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=rajje.db.elephantsql.com;Port=5432;User Id=slihduor;Password=Z3kDd9k-Hzri0TsNeXOEKYkb7jo9wClC;Database=slihduor;");
        public List<int[]> GetTotalShipping()
        {
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("select sum(\"Truck count\") as trucks, sum(shipping.\"Weight\") as weight, sum(\"Pipes count\") as pipes from Shipping", conn);
            NpgsqlDataReader reader = command.ExecuteReader();

            List<int[]> query = new List<int[]>();
            if (reader.HasRows)
            {
                foreach (DbDataRecord record in reader)
                {
                    int[] read = {
                        Convert.ToInt32(record["trucks"]),
                        Convert.ToInt32(record["weight"]),
                        Convert.ToInt32(record["pipes"])
                    };
                    query.Add(read);
                }
            }
            conn.Close();
            return query;
        }
        public List<int[]> GetTotalRegistry()
        {
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("select sum(Length) as length, sum(registry.weight) as weight, avg(Length) as averagelength, avg(Thickness) as averagethickness from registry", conn);
            NpgsqlDataReader reader = command.ExecuteReader();

            List<int[]> query = new List<int[]>();
            if (reader.HasRows)
            {
                foreach (DbDataRecord record in reader)
                {
                    int[] read = {
                        Convert.ToInt32(record["length"]),
                        Convert.ToInt32(record["weight"]),
                        Convert.ToInt32(record["averagelength"]),
                        Convert.ToInt32(record["averagethickness"])
                    };
                    query.Add(read);
                }
            }
            conn.Close();
            return query;
        }
    }
}
