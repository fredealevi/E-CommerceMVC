using EcommerceMVC.Models;
using System.Collections.Generic;

namespace EcommerceMVC.Repositories
{
    public interface IProdutoRepository
    {
        void SaveProdutos(List<Livro> livros);

        IList<Produto> GetProdutos();
    }
}