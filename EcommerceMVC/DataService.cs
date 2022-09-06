using CasaDoCodigo.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace EcommerceMVC
{
    class DataService : IDataService
    {
        private readonly ApplicationContext contexto;

        public DataService(ApplicationContext contexto)
        {
            this.contexto = contexto;
        }

        public void InicializaDB()
        {
            contexto.Database.EnsureCreated();

            // cria uma variavel que vai armazenar os arquivos texto.
            var json = File.ReadAllText("livros.json");

            // deserializer (transforma em objeto) cria uma lista de objetos na clase Livro recebendo a variavel criada na linha de cima.
            var livros = JsonConvert.DeserializeObject<List<Livro>>(json);


            // cria na classe produto um novo objeto para cada item da lista de livros (livros = <List<Livro>)..
            foreach (var livro in livros)
            {
                contexto.Set<Produto>().Add(new Produto(livro.Codigo, livro.Nome, livro.Preco));
            }
            //Salva tudo no banco
            contexto.SaveChanges();
        }
    }

    class Livro
    {
        public string Codigo { get; set; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }
    }
}
