using System;
using System.Collections.Generic
using GetConnection;
using MySqlCommand;


namespace Gericiamento de vendas 

 Class Vendas : Principal 

public class Venda
{
    public int Id { get; set; }
    public int ProdutoId { get; set; }
    public int ClienteId { get; set; }
    public DateTime Data { get; set; }
    public int Quantidade { get; set; }
}

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }
}

public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
}

public class Vendas
{
    private Database db = new Database();

    public void Adicionar(Venda venda)
    {
        using (var conn = db.GetConnection())
        {
            conn.Open();
            string sql = "INSERT INTO Vendas (ProdutoId, ClienteId, Data, Quantidade) VALUES (@ProdutoId, @ClienteId, @Data, @Quantidade)";
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ProdutoId", venda.ProdutoId);
                cmd.Parameters.AddWithValue("@ClienteId", venda.ClienteId);
                cmd.Parameters.AddWithValue("@Data", venda.Data);
                cmd.Parameters.AddWithValue("@Quantidade", venda.Quantidade);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public Venda ObterPorId(int id)
    {
        using (var conn = db.GetConnection())
        {
            conn.Open();
            string sql = "SELECT * FROM Vendas WHERE Id = @Id";
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Venda
                        {
                            Id = reader.GetInt32("Id"),
                            ProdutoId = reader.GetInt32("ProdutoId"),
                            ClienteId = reader.GetInt32("ClienteId"),
                            Data = reader.GetDateTime("Data"),
                            Quantidade = reader.GetInt32("Quantidade")
                        };
                    }
                }
            }
        }
        return null;
    }

    public void Atualizar(Venda venda)
    {
        using (var conn = db.GetConnection())
        {
            conn.Open();
            string sql = "UPDATE Vendas SET ProdutoId = @ProdutoId, ClienteId = @ClienteId, Data = @Data, Quantidade = @Quantidade WHERE Id = @Id";
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ProdutoId", venda.ProdutoId);
                cmd.Parameters.AddWithValue("@ClienteId", venda.ClienteId);
                cmd.Parameters.AddWithValue("@Data", venda.Data);
                cmd.Parameters.AddWithValue("@Quantidade", venda.Quantidade);
                cmd.Parameters.AddWithValue("@Id", venda.Id);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void Excluir(int id)
    {
        using (var conn = db.GetConnection())
        {
            conn.Open();
            string sql = "DELETE FROM Vendas WHERE Id = @Id";
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
