using Npgsql;
using RTSSoln.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTSSoln.Infrastructure.IoC
{
    public class OrderItemHandler
    {
        public void Delete(Guid entity)
        {
            using (var conn = new NpgsqlConnection(@"User ID=postgres;Password=master;Host=localhost;Port=5432;Database=vtProjeG171210046;"))
            {
                conn.Open();
                using (var command = new NpgsqlCommand($@"CALL DML_ORDERITEM('D','{entity}','{Guid.Empty}','{Guid.Empty}','{String.Empty}','meozmen')", conn))
                {
                    int nRows = command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
        public void Update(OrderItem entity)
        {
            using (var conn = new NpgsqlConnection(@"User ID=postgres;Password=master;Host=localhost;Port=5432;Database=vtProjeG171210046;"))
            {
                conn.Open();
                using (var command = new NpgsqlCommand($@"CALL DML_ORDERITEM('U','{entity.Id}','{entity.ProductId}','{entity.OrderId}','{entity.Notes}','{entity.Modifier}')", conn))
                {
                    int nRows = command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
        public void Insert(OrderItem entity)
        {
            using (var conn = new NpgsqlConnection(@"User ID=postgres;Password=master;Host=localhost;Port=5432;Database=vtProjeG171210046;"))
            {
                conn.Open();
                using (var command = new NpgsqlCommand($@"CALL DML_ORDERITEM('I','{entity.Id}','{entity.ProductId}','{entity.OrderId}','{entity.Notes}','{entity.Creator}')", conn))
                {
                    int nRows = command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public List<OrderItem> Select()
        {
            using (var conn = new NpgsqlConnection(@"User ID=postgres;Password=master;Host=localhost;Port=5432;Database=vtProjeG171210046;"))
            {
                conn.Open();
                List<OrderItem> readerData = new List<OrderItem>();
                using (var command = new NpgsqlCommand("SELECT* FROM \"OrderItem\"", conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        readerData.Add(new OrderItem
                        {
                            Id = reader.IsDBNull(0) ? Guid.Empty : reader.GetGuid(0),
                            ProductId = reader.IsDBNull(1) ? Guid.Empty : reader.GetGuid(1),
                            OrderId = reader.IsDBNull(2) ? Guid.Empty : reader.GetGuid(2),
                            Notes = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
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

        public OrderItem SelectOne(Guid entity)
        {
            using (var conn = new NpgsqlConnection(@"User ID=postgres;Password=master;Host=localhost;Port=5432;Database=vtProjeG171210046;"))
            {
                conn.Open();
                OrderItem readerData = new OrderItem();
                using (var command = new NpgsqlCommand("SELECT* FROM \"OrderItem\" WHERE \"Id\" = @p1", conn))
                {
                    command.Parameters.AddWithValue("p1", entity);

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        readerData = new OrderItem
                        {
                            Id = reader.IsDBNull(0) ? Guid.Empty : reader.GetGuid(0),
                            ProductId = reader.IsDBNull(1) ? Guid.Empty : reader.GetGuid(1),
                            OrderId = reader.IsDBNull(2) ? Guid.Empty : reader.GetGuid(2),
                            Notes = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
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
