using System;
using System.Collections.Generic
using GetConnection;
using MySqlCommand;

public class Fornecedores
{
    private Database db = new Database();

    public void Adicionar(Fornecedor fornecedor)
    {
        using (var conn = db.GetConnection())
        {
            conn.Open();
            string sql = "INSERT INTO Fornecedores (Nome, Telefone) VALUES (@Nome, @Telefone)";
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Nome", fornecedor.Nome);
                cmd.Parameters.AddWithValue("@Telefone", fornecedor.Telefone);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public Fornecedor ObterPorId(int id)
    {
        using (var conn = db.GetConnection())
        {
            conn.Open();
            string sql = "SELECT * FROM Fornecedores WHERE Id = @Id";
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Fornecedor
                        {
                            Id = reader.GetInt32("Id"),
                            Nome = reader.GetString("Nome"),
                            Telefone = reader.GetString("Telefone")
                        };
                    }
                }
            }
        }
        return null;
    }

    public void Atualizar(Fornecedor fornecedor)
    {
        using (var conn = db.GetConnection())
        {
            conn.Open();
            string sql = "UPDATE Fornecedores SET Nome = @Nome, Telefone = @Telefone WHERE Id = @Id";
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Nome", fornecedor.Nome);
                cmd.Parameters.AddWithValue("@Telefone", fornecedor.Telefone);
                cmd.Parameters.AddWithValue("@Id", fornecedor.Id);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void Excluir(int id)
    {
        using (var conn = db.GetConnection())
        {
            conn.Open();
            string sql = "DELETE FROM Fornecedores WHERE Id = @Id";
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
