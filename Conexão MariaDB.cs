using System;
using MySql.Data.MySqlClient;


namespace MariaDB
{
    class Conexao
    {
        static void Main(string[] args)
        {
            // Defina a string de conexão com os detalhes do seu banco de dados
            string connectionString = 
            "Server= 192.168.8.10;
            Database= Gerenciador.sql
            ;User ID= Gerenciador.sql;
            Password= password;";

            // Crie a conexão
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    // Abra a conexão
                    conn.Open();
                    Console.WriteLine("Conexão aberta com sucesso!");

                    // Crie o comando para a consulta
                    string sql = "SELECT * FROM sua_tabela";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    // Execute a consulta e obtenha os resultados
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                          
                            string nome = reader["Produto"].ToString();
                            Console.WriteLine($"Produto: {produto}");
                            
                            string nome = reader ["MovimentacaoEstoque"].ToString();
                            Console.WriteLine($"MovimentacaoEstoque: {MovimentacaoEstoque}");
                            
                        string nome = reader ["Fornecedores"].ToString();
                            Console.WriteLine($"Fornecedores: {Fornecedores}");
                          
                        string nome = reader ["Clientes"].ToString();
                            Console.WriteLine($"Clientes: {Clientes}");
                            
                        string nome = reader ["Vendas"].ToString();
                            Console.WriteLine($"Vendas: {Vendas}");
                        
                        string nome = reader ["Compras"].ToString();
                            Console.WriteLine($"Compras: {Compras}");
                            
                       }
                    }
                }
                catch (Exception ex)
                {
                    // Trate possíveis exceções
                    Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                }
                finally
                {
                    // Feche a conexão
                    conn.Close();
                    Console.WriteLine("Conexão fechada.");
                }
            }
        }
    }
}
