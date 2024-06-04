using System;
using System.Collections.Generic;

namespace ControleEstoque
{ 

    class Estoque

    {
        static List<Produto> estoque = new List<Produto>();
        static List<Fornecedor> fornecedores = new List<Fornecedor>();
        static List<Cliente> clientes = new List<Cliente>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("=== Controle de Estoque ===");
                Console.WriteLine("1 - Adicionar Produto");
                Console.WriteLine("2 - Visualizar Estoque");
                Console.WriteLine("3 - Entrada de Produto");
                Console.WriteLine("4 - Saída de Produto");
                Console.WriteLine("5 - Cadastrar Fornecedor");
                Console.WriteLine("6 - Visualizar Fornecedores");
                Console.WriteLine("7 - Cadastrar Cliente");
                Console.WriteLine("8 - Visualizar Clientes");
                Console.WriteLine("9 - Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarProduto();
                        break;
                    case "2":
                        VisualizarEstoque();
                        break;
                    case "3":
                        MovimentarEstoque(TipoMovimentacao.Entrada);
                        break;
                    case "4":
                        MovimentarEstoque(TipoMovimentacao.Saida);
                        break;
                    case "5":
                        CadastrarFornecedor();
                        break;
                    case "6":
                        VisualizarFornecedores();
                        break;
                    case "7":
                        CadastrarCliente();
                        break;
                    case "8":
                        VisualizarClientes();
                        break;
                    case "9":
                        Console.WriteLine("Saindo...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AdicionarProduto()
        {
            Console.WriteLine("Digite o codigo do Produto:");
            int Codigo = int.Parse(Console.ReadLine());
            Console.Write("Nome do Produto: ");
            string nome = Console.ReadLine();
            Console.Write("Quantidade: ");
            int quantidade = int.Parse(Console.ReadLine());
            Console.WriteLine("Nome do Forncedor:");
            string fornecedor = Console.ReadLine();
            Console.WriteLine("digite o setor que o material será destinado:");
            string setor = Console.ReadLine();

            Produto produto = new Produto(nome, quantidade, setor, fornecedor, Codigo);
            estoque.Add(produto);

            Console.WriteLine("Produto adicionado com sucesso.");
        }

        static void VisualizarEstoque()
        {
            Console.WriteLine("=== Estoque ===");
            foreach (var produto in estoque)
            {
                Console.WriteLine($"Nome: {produto.Nome}, Quantidade: {produto.Quantidade}");
            }
        }

        static void MovimentarEstoque(TipoMovimentacao tipoMovimentacao)
        {
            Console.Write("Nome do Produto: ");
            string nome = Console.ReadLine();
            Console.Write("Quantidade: ");
            int quantidade = int.Parse(Console.ReadLine());

            Produto produto = estoque.Find(p => p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado.");
                return;
            }

            if (tipoMovimentacao == TipoMovimentacao.Entrada)
            {
                produto.AdicionarQuantidade(quantidade);
                Console.WriteLine("Entrada de produto realizada com sucesso.");
            }
            else if (tipoMovimentacao == TipoMovimentacao.Saida)
            {
                if (produto.Quantidade < quantidade)
                {
                    Console.WriteLine("Quantidade insuficiente em estoque.");
                    return;
                }
                produto.RemoverQuantidade(quantidade);
                Console.WriteLine("Saída de produto realizada com sucesso.");
            }
        }

        static void CadastrarFornecedor()
        {
            Console.Write("Nome do Fornecedor: ");
            string nome = Console.ReadLine();
            Console.Write("E-mail do Fornecedor: ");
            string email = Console.ReadLine();

            Fornecedor fornecedor = new Fornecedor(nome, email);
            fornecedores.Add(fornecedor);

            Console.WriteLine("Fornecedor cadastrado com sucesso.");
        }

        static void VisualizarFornecedores()
        {
            Console.WriteLine("=== Fornecedores ===");
            foreach (var fornecedor in fornecedores)
            {
                Console.WriteLine($"Nome: {fornecedor.Nome}, Email: {fornecedor.Email}");
            }
        }

        static void CadastrarCliente()
        {
            Console.Write("Nome do Cliente: ");
            string nome = Console.ReadLine();
            Console.Write("E-mail do Cliente: ");
            string email = Console.ReadLine();

            Cliente cliente = new Cliente(nome, email);
            clientes.Add(cliente);

            Console.WriteLine("Cliente cadastrado com sucesso.");
        }

        static void VisualizarClientes()
        {
            Console.WriteLine("=== Clientes ===");
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"Nome: {cliente.Nome}, Email: {cliente.Email}");
            }
        }
    }

    enum TipoMovimentacao
    {
        Entrada,
        Saida
    }

    class Produto
    {
        public int Codigo {  get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public string Fornecedor { get; set; }

        public string setor { get; set; }



        public Produto(string nome, int quantidade, string setor, string Fornecedor, int Codigo )
        {
            Nome = nome;
            Quantidade = quantidade;
            this.setor = setor;
            this.Fornecedor = Fornecedor;
            int Código = Codigo;
        }

        public void AdicionarQuantidade(int quantidade)
        {
            Quantidade += quantidade;
        }

        public void RemoverQuantidade(int quantidade)
        {
            Quantidade -= quantidade;
        }
    }

    class Fornecedor
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public Fornecedor(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }
    }

    class Cliente
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public Cliente(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }
    }
}


























