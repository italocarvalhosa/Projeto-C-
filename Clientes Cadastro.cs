
using GetConnection;
using MySqlCommand;
using System;
using System.Collections.Generic

namespace cliente

public class Clientes
{
    private Database db = new Database();

    public void Adicionar(Cliente cliente)
    {
        using (var conn = db.GetConnection())
        {
            conn.Open();
            string sql = "INSERT INTO Clientes (Nome, Email) VALUES (@Nome, @Email)";
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@Email", cliente.Email);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public Cliente ObterPorId(int id)
    {
        using (var conn = db.GetConnection())
        {
            conn.Open();
            string sql = "SELECT * FROM Clientes WHERE Id = @Id";
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Cliente
                        {
                            Id = reader.GetInt32("Id"),
                            Nome = reader.GetString("Nome"),
                            Email = reader.GetString("Email")
                        };
                    }
                }
            }
        }
        return null;
    }

    public void Atualizar(Cliente cliente)
    {
        using (var conn = db.GetConnection())
        {
            conn.Open();
            string sql = "UPDATE Clientes SET Nome = @Nome, Email = @Email WHERE Id = @Id";
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@Email", cliente.Email);
                cmd.Parameters.AddWithValue("@Id", cliente.Id);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void Excluir(int id)
    {
        using (var conn = db.GetConnection())
        {
            conn.Open();
            string sql = "DELETE FROM Clientes WHERE Id = @Id";
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
