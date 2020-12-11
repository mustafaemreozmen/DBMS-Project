using Npgsql;
using RTSSoln.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTSSoln.Infrastructure.IoC
{
    public class FloorTypeHandler : IDbHandler<FloorType>
    {
        public void Delete(Guid entity)
        {
            using (var conn = new NpgsqlConnection(@"User ID=postgres;Password=master;Host=localhost;Port=5432;Database=vtProjeG171210046;"))
            {
                conn.Open();
                using (var command = new NpgsqlCommand($"DELETE FROM \"FloorType\" WHERE \"Id\" = @p1", conn))
                {
                    command.Parameters.AddWithValue("p1", entity);
                    int nRows = command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public void Insert(FloorType entity)
        {
            using (var conn = new NpgsqlConnection(@"User ID=postgres;Password=master;Host=localhost;Port=5432;Database=vtProjeG171210046;"))
            {
                conn.Open();
                using (var command = new NpgsqlCommand($"INSERT INTO \"FloorType\"(\"Id\", \"Name\", \"Description\", \"Created\", \"Creator\", \"Modified\", \"Modifier\") VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7); ", conn))
                {
                    command.Parameters.AddWithValue("p1", entity.Id);
                    command.Parameters.AddWithValue("p2", entity.Name);
                    command.Parameters.AddWithValue("p3", entity.Description);
                    command.Parameters.AddWithValue("p4", entity.Created);
                    command.Parameters.AddWithValue("p5", entity.Creator);
                    command.Parameters.AddWithValue("p6", entity.Modified);
                    command.Parameters.AddWithValue("p7", entity.Modifier);

                    int nRows = command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public List<FloorType> Select()
        {
            using (var conn = new NpgsqlConnection(@"User ID=postgres;Password=master;Host=localhost;Port=5432;Database=vtProjeG171210046;"))
            {
                conn.Open();
                List<FloorType> readerData = new List<FloorType>();
                using (var command = new NpgsqlCommand("SELECT* FROM \"FloorType\"", conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        readerData.Add(new FloorType
                        {
                            Id = reader.IsDBNull(0)? Guid.Empty : reader.GetGuid(0),
                            Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                            Description = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                            Created = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3),
                            Creator =  reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                            Modified = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5),
                            Modifier = reader.IsDBNull(6) ? string.Empty : reader.GetString(4)
                        });
                    }
                }
                conn.Close();
                return readerData;
            }
        }

        public void Update(FloorType entity)
        {
            using (var conn = new NpgsqlConnection(@"User ID=postgres;Password=master;Host=localhost;Port=5432;Database=vtProjeG171210046;"))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("UPDATE \"FloorType\" SET quantity = @q WHERE \"Id\" = @n", conn))
                {
                    int nRows = command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
}
