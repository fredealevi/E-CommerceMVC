using CasaDoCodigo.Models;
using EcommerceMVC.Models;
using EcommerceMVC.Repositories;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace EcommerceMVC
{
    class DataService : IDataService
    {
        private readonly ApplicationContext context;
        private readonly IProdutoRepository produtoRepository;

        public DataService(ApplicationContext contexto, IProdutoRepository produtoRepository)
        {
            this.context = contexto;
            this.produtoRepository = produtoRepository;
        }

        public void InicializaDB()
        {
            context.Database.EnsureCreated();
            List<Livro> livros = GetLivros();

            produtoRepository.SaveProdutos(livros);
        }

     

        private static List<Livro> GetLivros()
        {
            // cria uma variavel que vai armazenar os arquivos texto.
            var json = File.ReadAllText("livros.json");

            // deserializer (transforma em objeto) cria uma lista de objetos na clase Livro recebendo a variavel criada na linha de cima.
            var livros = JsonConvert.DeserializeObject<List<Livro>>(json);
            return livros;
        }
    }

  
}
