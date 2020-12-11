using Npgsql;
using RTSSoln.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTSSoln.Infrastructure.IoC
{
    public class ReservationHandler
    {
        public void Delete(Guid entity)
        {
            using (var conn = new NpgsqlConnection(@"User ID=postgres;Password=master;Host=localhost;Port=5432;Database=vtProjeG171210046;"))
            {
                conn.Open();
                using (var command = new NpgsqlCommand($@"CALL DML_RESERVATION('D','{entity}','{Guid.Empty}','{Guid.Empty}','{DateTime.MinValue}','meozmen')", conn))
                {
                    int nRows = command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public void Insert(Reservation entity)
        {
            using (var conn = new NpgsqlConnection(@"User ID=postgres;Password=master;Host=localhost;Port=5432;Database=vtProjeG171210046;"))
            {
                conn.Open();
                using (var command = new NpgsqlCommand($@"CALL DML_RESERVATION('I','{entity.Id}','{entity.TableId}','{entity.CustomerId}','{entity.ReservationTime}','{entity.Creator}')", conn))
                {
                    int nRows = command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public List<Reservation> Select()
        {
            using (var conn = new NpgsqlConnection(@"User ID=postgres;Password=master;Host=localhost;Port=5432;Database=vtProjeG171210046;"))
            {
                conn.Open();
                List<Reservation> readerData = new List<Reservation>();
                using (var command = new NpgsqlCommand("SELECT* FROM \"Reservation\"", conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        readerData.Add(new Reservation
                        {
                            Id = reader.IsDBNull(0) ? Guid.Empty : reader.GetGuid(0),
                            TableId = reader.IsDBNull(1) ? Guid.Empty : reader.GetGuid(1),
                            CustomerId = reader.IsDBNull(2) ? Guid.Empty : reader.GetGuid(2),
                            ReservationTime = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3),
                            Created = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4),
                            Creator = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                            Modified = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6),
                            Modifier = reader.IsDBNull(7) ? string.Empty : reader.GetString(7)
                        });
                    }
                }
                conn.Close();
                return readerData;
            }
        }

        public void Update(Reservation entity)
        {
            using (var conn = new NpgsqlConnection(@"User ID=postgres;Password=master;Host=localhost;Port=5432;Database=vtProjeG171210046;"))
            {
                conn.Open();
                using (var command = new NpgsqlCommand($@"CALL DML_RESERVATION('U','{entity.Id}','{entity.TableId}','{entity.CustomerId}','{entity.ReservationTime}','{entity.Modifier}')", conn))
                {
                    int nRows = command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public Reservation SelectOne(Guid entity)
        {
            using (var conn = new NpgsqlConnection(@"User ID=postgres;Password=master;Host=localhost;Port=5432;Database=vtProjeG171210046;"))
            {
                conn.Open();
                Reservation readerData = new Reservation();
                using (var command = new NpgsqlCommand("SELECT* FROM \"Reservation\" WHERE \"Id\" = @p1", conn))
                {
                    command.Parameters.AddWithValue("p1", entity);

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        readerData = new Reservation
                        {
                            Id = reader.IsDBNull(0) ? Guid.Empty : reader.GetGuid(0),
                            TableId = reader.IsDBNull(1) ? Guid.Empty : reader.GetGuid(1),
                            CustomerId = reader.IsDBNull(2) ? Guid.Empty : reader.GetGuid(2),
                            ReservationTime = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3),
                            Created = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4),
                            Creator = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                            Modified = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6),
                            Modifier = reader.IsDBNull(7) ? string.Empty : reader.GetString(7)
                        };
                    }
                }
                conn.Close();
                return readerData;
            }
        }

    }
}
