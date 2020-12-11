using Npgsql;
using RTSSoln.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTSSoln.Infrastructure.IoC
{
    public class PaymentHandler
    {
        public void Delete(Guid entity)
        {
            using (var conn = new NpgsqlConnection(@"User ID=postgres;Password=master;Host=localhost;Port=5432;Database=vtProjeG171210046;"))
            {
                conn.Open();
                using (var command = new NpgsqlCommand($@"CALL DML_PAYMENT('D','{entity}','{Guid.Empty}','{Guid.Empty}','{Decimal.Zero}','meozmen')", conn))
                {
                    int nRows = command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public void Insert(Payment entity)
        {
            using (var conn = new NpgsqlConnection(@"User ID=postgres;Password=master;Host=localhost;Port=5432;Database=vtProjeG171210046;"))
            {
                conn.Open();
                using (var command = new NpgsqlCommand($@"CALL DML_PAYMENT('I','{entity.Id}','{entity.CashRegisterId}','{entity.TableId}','{entity.Price}','{entity.Creator}')", conn))
                {
                    int nRows = command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
        public void Update(Payment entity)
        {
            using (var conn = new NpgsqlConnection(@"User ID=postgres;Password=master;Host=localhost;Port=5432;Database=vtProjeG171210046;"))
            {
                conn.Open();
                using (var command = new NpgsqlCommand($@"CALL DML_PAYMENT('U','{entity.Id}','{entity.CashRegisterId}','{entity.TableId}','{entity.Price}','{entity.Modifier}')", conn))
                {
                    int nRows = command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
        public List<Payment> Select()
        {
            using (var conn = new NpgsqlConnection(@"User ID=postgres;Password=master;Host=localhost;Port=5432;Database=vtProjeG171210046;"))
            {
                conn.Open();
                List<Payment> readerData = new List<Payment>();
                using (var command = new NpgsqlCommand("SELECT* FROM \"Payment\"", conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        readerData.Add(new Payment
                        {
                            Id = reader.IsDBNull(0) ? Guid.Empty : reader.GetGuid(0),
                            CashRegisterId = reader.IsDBNull(1) ? Guid.Empty : reader.GetGuid(1),
                            TableId = reader.IsDBNull(2) ? Guid.Empty : reader.GetGuid(2),
                            Price = reader.IsDBNull(3) ? Decimal.Zero : reader.GetDecimal(3),
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

        public Payment SelectOne(Guid entity)
        {
            using (var conn = new NpgsqlConnection(@"User ID=postgres;Password=master;Host=localhost;Port=5432;Database=vtProjeG171210046;"))
            {
                conn.Open();
                Payment readerData = new Payment();
                using (var command = new NpgsqlCommand("SELECT* FROM \"Payment\" WHERE \"Id\" = @p1", conn))
                {
                    command.Parameters.AddWithValue("p1", entity);

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        readerData = new Payment
                        {
                            Id = reader.IsDBNull(0) ? Guid.Empty : reader.GetGuid(0),
                            CashRegisterId = reader.IsDBNull(1) ? Guid.Empty : reader.GetGuid(1),
                            TableId = reader.IsDBNull(2) ? Guid.Empty : reader.GetGuid(2),
                            Price = reader.IsDBNull(3) ? Decimal.Zero : reader.GetDecimal(2),
                            Created = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(3),
                            Creator = reader.IsDBNull(5) ? string.Empty : reader.GetString(4),
                            Modified = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(5),
                            Modifier = reader.IsDBNull(7) ? string.Empty : reader.GetString(4)
                        };
                    }
                }
                conn.Close();
                return readerData;
            }
        }

    }
}
