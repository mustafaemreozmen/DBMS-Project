using Npgsql;
using RTSSoln.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTSSoln.Infrastructure.IoC
{
    public class OrderHandler
    {
        public void Delete(Guid entity)
        {
            using (var conn = new NpgsqlConnection(@"User ID=postgres;Password=master;Host=localhost;Port=5432;Database=vtProjeG171210046;"))
            {
                conn.Open();
                using (var command = new NpgsqlCommand($@"CALL DML_ORDER('D','{entity}','{Guid.Empty}','{Guid.Empty}','{Guid.Empty}','mozmen6')", conn))
                {
                    int nRows = command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public void Insert(Order entity)
        {
            using (var conn = new NpgsqlConnection(@"User ID=postgres;Password=master;Host=localhost;Port=5432;Database=vtProjeG171210046;"))
            {
                conn.Open();
                using (var command = new NpgsqlCommand($@"CALL DML_ORDER('I','{entity.Id}','{entity.TableId}','{entity.EmployeeId}','{entity.OrderStatusId}','{entity.Creator}')", conn))
                {
                    int nRows = command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public List<Order> Select()
        {
            using (var conn = new NpgsqlConnection(@"User ID=postgres;Password=master;Host=localhost;Port=5432;Database=vtProjeG171210046;"))
            {
                conn.Open();
                List<Order> readerData = new List<Order>();
                using (var command = new NpgsqlCommand("SELECT* FROM \"Order\"", conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        readerData.Add(new Order
                        {
                            Id = reader.IsDBNull(0) ? Guid.Empty : reader.GetGuid(0),
                            TableId = reader.IsDBNull(1) ? Guid.Empty : reader.GetGuid(1),
                            OrderStatusId = reader.IsDBNull(2) ? Guid.Empty : reader.GetGuid(2),
                            Created = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3),
                            Creator = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                            Modified = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5),
                            Modifier = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                            EmployeeId = reader.IsDBNull(7) ? Guid.Empty : reader.GetGuid(7)
                        });
                    }
                }
                conn.Close();
                return readerData;
            }
        }

        public void Update(Order entity)
        {
            using (var conn = new NpgsqlConnection(@"User ID=postgres;Password=master;Host=localhost;Port=5432;Database=vtProjeG171210046;"))
            {
                conn.Open();
                using (var command = new NpgsqlCommand($@"CALL DML_ORDER('U','{entity.Id}','{entity.TableId}','{entity.EmployeeId}','{entity.OrderStatusId}','{entity.Modifier}')", conn))
                {
                    int nRows = command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public Order SelectOne(Guid entity)
        {
            using (var conn = new NpgsqlConnection(@"User ID=postgres;Password=master;Host=localhost;Port=5432;Database=vtProjeG171210046;"))
            {
                conn.Open();
                Order readerData = new Order();
                using (var command = new NpgsqlCommand("SELECT* FROM \"Order\" WHERE \"Id\" = @p1", conn))
                {
                    command.Parameters.AddWithValue("p1", entity);

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        readerData = new Order
                        {
                            Id = reader.IsDBNull(0) ? Guid.Empty : reader.GetGuid(0),
                            TableId = reader.IsDBNull(1) ? Guid.Empty : reader.GetGuid(1),
                            OrderStatusId = reader.IsDBNull(2) ? Guid.Empty : reader.GetGuid(2),
                            Created = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3),
                            Creator = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                            Modified = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5),
                            Modifier = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                            EmployeeId = reader.IsDBNull(7) ? Guid.Empty : reader.GetGuid(7)
                        };
                    }
                }
                conn.Close();
                return readerData;
            }
        }
    }
}
