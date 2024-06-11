using System;
using System.Collections.Generic;

namespace GerenciamentoDeVendas
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Produto> Estoque = new List<Produto>();
            List<Venda> vendas = new List<Venda>();

            while (true)
            {
                Console.WriteLine("\nSelecione uma opção:");
                Console.WriteLine("1. Controle de Estoque");
                Console.WriteLine("2. Cadastro de Cliente");
                Console.WriteLine("3. Gerenciamento de Vendas");
                Console.WriteLine("4. Sair");
                Console.Write("Opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        ControleEstoque(Estoque);
                        break;

                    case "2":
                        CadastroCliente();
                        break;

                    case "3":
                        GerenciamentoVendas(Estoque, vendas);
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Opção Inválida");
                        break;
                }
            }
        }

        static void ControleEstoque(List<Produto> Estoque)
        {
            while (true)
            {
                Console.WriteLine("\nControle de Estoque");
                Console.WriteLine("1. Adicionar Produto");
                Console.WriteLine("2. Remover Produto");
                Console.WriteLine("3. Listar Produtos");
                Console.WriteLine("4. Voltar");
                Console.Write("Escolha uma Opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarProduto(Estoque);
                        break;

                    case "2":
                        RemoverProduto(Estoque);
                        break;

                    case "3":
                        ListarProdutos(Estoque);
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Opção Inválida");
                        break;
                }
            }
        }
        static void CadastroCliente()
        {
            Console.WriteLine("\n=== Cadastro de Cliente ===");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            Console.WriteLine("\nCliente cadastrado com sucesso!");
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Email: {email}");
            Console.WriteLine($"Telefone: {telefone}");
        }

        static void GerenciamentoVendas(List<Produto> Estoque, List<Venda> vendas)
        {
            while (true)
            {
                Console.WriteLine("\nGerenciamento de Vendas");
                Console.WriteLine("1. Registrar Venda");
                Console.WriteLine("2. Listar Vendas");
                Console.WriteLine("3. Voltar");
                Console.Write("Escolha uma Opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        RegistrarVenda(Estoque, vendas);
                        break;

                    case "2":
                        ListarVendas(vendas);
                        break;

                    case "3":
                        return;

                    default:
                        Console.WriteLine("Opção Inválida");
                        break;
                }
            }
        }

        static void AdicionarProduto(List<Produto> Estoque)
        {
            Console.Write("Digite o Id do produto: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do Produto: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a quantidade do Produto: ");
            int quantidade = int.Parse(Console.ReadLine());

            Console.Write("Digite o fornecedor do produto: ");
            string fornecedor = Console.ReadLine();

            Console.Write("Digite para qual setor irá o material: ");
            string setor = Console.ReadLine();

            Estoque.Add(new Produto(id, nome, quantidade, fornecedor, setor));
            Console.WriteLine("Produto Adicionado com êxito");
        }

        static void RemoverProduto(List<Produto> Estoque)
        {
            Console.Write("Digite o Id do produto: ");
            int id = int.Parse(Console.ReadLine());

            Produto produto = Estoque.Find(p => p.Id == id);
            if (produto != null)
            {
                Estoque.Remove(produto);
                Console.WriteLine("Produto removido com êxito.");
            }
            else
            {
                Console.WriteLine("Produto não encontrado");
            }
        }

        static void ListarProdutos(List<Produto> Estoque)
        {
            Console.WriteLine("\nProdutos no estoque:");
            foreach (Produto produto in Estoque)
            {
                Console.WriteLine(produto);
            }
        }

        static void RegistrarVenda(List<Produto> Estoque, List<Venda> vendas)
        {
            Console.Write("Digite o Id da venda: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string nomeCliente = Console.ReadLine();

            Console.Write("Digite o Id do produto vendido: ");
            int produtoId = int.Parse(Console.ReadLine());

            Console.Write("Digite a data da venda (dd/mm/aaaa): ");
            DateTime data = DateTime.Parse(Console.ReadLine());

            Console.Write("Digite a quantidade vendida: ");
            int quantidade = int.Parse(Console.ReadLine());

            Produto produto = Estoque.Find(p => p.Id == produtoId);
            if (produto != null)
            {
                if (produto.Quantidade >= quantidade)
                {
                    produto.Quantidade -= quantidade;
                    vendas.Add(new Venda(id, nomeCliente, produtoId, data, quantidade));
                    Console.WriteLine("Venda registrada com sucesso");
                }
                else
                {
                    Console.WriteLine("Quantidade insuficiente em estoque");
                }
            }
            else
            {
                Console.WriteLine("Produto não encontrado");
            }
        }

        static void ListarVendas(List<Venda> vendas)
        {
            Console.WriteLine("\nVendas registradas:");
            foreach (Venda venda in vendas)
            {
                Console.WriteLine(venda);
            }
        }
    }

    internal class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public string Fornecedor { get; set; }
        public string Setor { get; set; }

        public Produto(int id, string nome, int quantidade, string fornecedor, string setor)
        {
            Id = id;
            Nome = nome;
            Quantidade = quantidade;
            Fornecedor = fornecedor;
            Setor = setor;
        }

        public override string ToString()
        {
            return
                $"\nId: {Id}," +
                $"\nNome: {Nome} " +
                $"\nQuantidade: {Quantidade}" +
                $"\nFornecedor: {Fornecedor} " +
                $"\nSetor: {Setor}";
        }
    }

    internal class Venda
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public int ProdutoId { get; set; }
        public DateTime Data { get; set; }
        public int Quantidade { get; set; }

        public Venda(int id, string nomeCliente, int produtoId, DateTime data, int quantidade)
        {
            Id = id;
            NomeCliente = nomeCliente;
            ProdutoId = produtoId;
            Data = data;
            Quantidade = quantidade;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Cliente: {NomeCliente}, ProdutoId: {ProdutoId}, Data: {Data}, Quantidade: {Quantidade}";
        }
    }
}
