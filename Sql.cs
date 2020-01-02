using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
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

        public void UpdateTransport(List<Transport> transport)
        {
            conn.Open();

            foreach(var el in transport)
            {
                DateTime date = DateTime.ParseExact(el.DateShipping, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                int days = date.Day;
                int month = date.Month;
                int year = date.Year;

                DateTime date2 = DateTime.ParseExact(el.DateShipped, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                int days2 = date2.Day;
                int month2 = date2.Month;
                int year2 = date2.Year;

                NpgsqlCommand command = new NpgsqlCommand($"update transport set \"State number\" = '{el.StateNubmer}', \"Date shipping\" = '{year}-{month}-{days}', \"Date shipped\" = '{year2}-{month2}-{days2}', \"Weight\" = {el.Weight}, \"price\" = {el.Price}, \"currency\" = '{el.Currency}' where \"number\" = {el.Number}", conn);
                command.ExecuteNonQuery();
            }

            conn.Close();
        }
        public void UpdateShipping(List<Shipping> shipping)
        {
            conn.Open();

            foreach (var el in shipping)
            {
                DateTime date = DateTime.ParseExact(el.Date, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                int days = date.Day;
                int month = date.Month;
                int year = date.Year;

                NpgsqlCommand command = new NpgsqlCommand($"update shipping set \"Date\" = '{year}-{month}-{days}', \"Truck count\" = {el.Trucks}, \"Weight\" = {el.Weight}, \"Pipes count\" = {el.Pipes} where \"number\" = {el.Number}", conn);
                command.ExecuteNonQuery();
            }

            conn.Close();
        }
        public void UpdateRegistry(List<Registry> registry)
        {
            conn.Open();

            foreach (var el in registry)
            {
                NpgsqlCommand command = new NpgsqlCommand($"update registry set \"number\" = {Convert.ToInt32(el.Date)}, \"diameter\" = {el.Diameter}, \"Pipe number\" = {el.PipeNumber}, \"length\" = {el.Length}, \"thickness\" = {el.Thickness}, \"weight\" = {el.Weight} where \"Personal\" = {el.Number}", conn);
                command.ExecuteNonQuery();
            }

            conn.Close();
        }
    }
}
