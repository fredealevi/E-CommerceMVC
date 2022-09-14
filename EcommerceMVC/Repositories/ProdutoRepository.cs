using EcommerceMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceMVC.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationContext context;

        public ProdutoRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public IList<Produto> GetProdutos()
        {
            // metodo Get Produtos retorna uma lista de produtos
            return context.Set<Produto>().ToList();
        }

        public void SaveProdutos(List<Livro> livros)
        {
            // cria na classe produto um novo objeto para cada item da lista de livros (livros = <List<Livro>)..
            foreach (var livro in livros)
            {
                context.Set<Produto>().Add(new Produto(livro.Codigo, livro.Nome, livro.Preco));
            }
            //Salva tudo no banco
            context.SaveChanges();
        }
    }
}
