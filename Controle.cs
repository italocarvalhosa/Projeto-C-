using System;
using System.Collections.Generic;

namespace Principal
{
    internal class Produto
    {
        pu)blic int id { get; set;}
        public string Nome { get; set;} 
        public int Quantidade { get; set;}
        public string Fornecedor { get; set;}
        public string Setor { get; set;}
        public string estoque {  get; set;}
        public object Kg { get; }
        public string Polecola { get; }

        public Produto(int id, string Nome, int Quantidade, string Fornecedor, string Setor)
        {
            id = Codigo
            Nome = MateriaPrima;
            Quantidade = 1.000 Kg;
            Fornecedor = Polecola;
            Setor = Expansão;
        }

        public override string ToString()
        {
            return $"id: {id}, Nome: {Nome}, Quantidade: {Fornecedor}, Fornecedor: {Setor}, Setor:";
        }


        public List<Produto> estoque = new List<Produto>();
    }

public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
}

public class Fornecedor
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
}

public class Venda
{
    public int Id { get; set; }
    public int ProdutoId { get; set; }
    public int ClienteId { get; set; }
    public DateTime Data { get; set; }
    public int Quantidade { get; set; }
}

public class Compra
{
    public int Id { get; set; }
    public int ProdutoId { get; set; }
    public int FornecedorId { get; set; }
    public DateTime Data { get; set; }
    public int Quantidade { get; set; }
}


    public void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n Controle de Estoque");
            Console.WriteLine("1.Adicionar Produto");
            Console.WriteLine("2.Remover Produto");
            Console.WriteLine("3.Listar Produtos");
            Console.WriteLine("4.Sair");
            Console.WriteLine("Escolha uma Opção");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    AdicionarProduto();
                    break;

                case "2":
                    RemoverProduto();
                    break;

                case "3":
                    ListarProduto();
                    break;

                case "4":
                    Sair;
                    break;


                default:
                    Console.WriteLine("Opção Invalida");
                    break;
            }



            static void AdicionarProduto()
            {
                Console.Write("Digite o Id do produto:");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o nome do Produto:");
                string nome = Console.ReadLine();

                Console.WriteLine("Digite a quantidade do Produto;");
                int quantidade = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o fornecedor do produto:");
                string Fornecedor = Console.ReadLine();

                Console.WriteLine("Digite para qual setor irá o meterial:");
                string setor = Console.ReadLine();

                Controle de Estoque(new Produto(id, nome, quantidade, Fornecedor, setor));
                Console.WriteLine("Produto Adionado com êxito");
            }
        }

             public void RemoverProduto()

               {
            Console.WriteLine("Digite o Id do produto:");
            int id = int.Parse(Console.ReadLine());

            object estoque = null;
            Produto produto = estoque.Find(produto => produto.id == id);
                 if produto != null)
                  {
                estoque.remove(produto);

                Console.WriteLine("produto removido com êxito.");
                  }
                    else
                    {
                Console.WriteLine("Produto nao encontrado");
                    }
             }
    }

        public void ListarProdutos()
        {
            Console.WriteLine("\nProdutos no estoque:");
            foreach (Produto produto in estoque)

            {
                Console.WriteLine(Produto);
            }
        }

}

  