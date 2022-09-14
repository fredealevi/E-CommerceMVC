using EcommerceMVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceMVC.Controllers
{
    public class PedidoController : Controller
    {
        // cria o acesso do controller ao ProdutoRepository através do construtor.
        private readonly IProdutoRepository produtoRepository;

        public PedidoController(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public IActionResult Carrossel()
        {
            // retorna a view com o metodo get produtos
            return View(produtoRepository.GetProdutos());
        }

        public IActionResult Carrinho()
        {
            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }
        public IActionResult Resumo()
        {
            return View();
        }
    }
}


