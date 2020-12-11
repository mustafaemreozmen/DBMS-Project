using Npgsql;
using RTSSoln.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTSSoln.Infrastructure.IoC
{
    public class MenuHandler : IDbHandler<Menu>
    {
        public void Delete(Guid entity)
        {
            using (var conn = new NpgsqlConnection(@"User ID=postgres;Password=master;Host=localhost;Port=5432;Database=vtProjeG171210046;"))
            {
                conn.Open();
                using (var command = new NpgsqlCommand($"DELETE FROM \"Menu\" WHERE \"Id\" = @p1", conn))
                {
                    command.Parameters.AddWithValue("p1", entity);
                    int nRows = command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public void Insert(Menu entity)
        {
            using (var conn = new NpgsqlConnection(@"User ID=postgres;Password=master;Host=localhost;Port=5432;Database=vtProjeG171210046;"))
            {
                conn.Open();
                using (var command = new NpgsqlCommand($"INSERT INTO \"Menu\"(\"Id\", \"Title\", \"Description\", \"Created\", \"Creator\") VALUES (@p1,@p2,@p3,@p4,@p5); ", conn))
                {
                    command.Parameters.AddWithValue("p1", entity.Id);
                    command.Parameters.AddWithValue("p2", entity.Title);
                    command.Parameters.AddWithValue("p3", entity.Description);
                    command.Parameters.AddWithValue("p4", DateTime.Now);
                    command.Parameters.AddWithValue("p5", entity.Creator);

                    int nRows = command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public List<Menu> Select()
        {
            using (var conn = new NpgsqlConnection(@"User ID=postgres;Password=master;Host=localhost;Port=5432;Database=vtProjeG171210046;"))
            {
                conn.Open();
                List<Menu> readerData = new List<Menu>();
                using (var command = new NpgsqlCommand("SELECT* FROM \"Menu\"", conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        readerData.Add(new Menu
                        {
                            Id = reader.IsDBNull(0) ? Guid.Empty : reader.GetGuid(0),
                            Title = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                            Description = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                            Created = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3),
                            Creator = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                            Modified = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5),
                            Modifier = reader.IsDBNull(6) ? string.Empty : reader.GetString(6)
                        });
                    }
                }
                conn.Close();
                return readerData;
            }
        }

        public Menu SelectOne(Guid entity)
        {
            using (var conn = new NpgsqlConnection(@"User ID=postgres;Password=master;Host=localhost;Port=5432;Database=vtProjeG171210046;"))
            {
                conn.Open();
                Menu readerData = new Menu();
                using (var command = new NpgsqlCommand("SELECT* FROM \"Menu\" WHERE \"Id\" = @p1", conn))
                {
                    command.Parameters.AddWithValue("p1", entity);

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        readerData = new Menu
                        {
                            Id = reader.IsDBNull(0) ? Guid.Empty : reader.GetGuid(0),
                            Title = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                            Description = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                            Created = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3),
                            Creator = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                            Modified = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5),
                            Modifier = reader.IsDBNull(6) ? string.Empty : reader.GetString(6)
                        };
                    }
                }
                conn.Close();
                return readerData;
            }
        }

        public void Update(Menu entity)
        {
            using (var conn = new NpgsqlConnection(@"User ID=postgres;Password=master;Host=localhost;Port=5432;Database=vtProjeG171210046;"))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("UPDATE \"Menu\" SET \"Title\"=@p2, \"Description\"=@p3, \"Modified\"=@p6, \"Modifier\"=@p7 WHERE \"Id\" = @p1", conn))
                {
                    command.Parameters.AddWithValue("p1", entity.Id);
                    command.Parameters.AddWithValue("p2", entity.Title);
                    command.Parameters.AddWithValue("p3", entity.Description);
                    command.Parameters.AddWithValue("p6", DateTime.Now);
                    command.Parameters.AddWithValue("p7", entity.Modifier);

                    int nRows = command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
}
