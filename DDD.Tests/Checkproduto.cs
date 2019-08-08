using DDD.Domain.Entities;
using DDD.Service.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DDD.Tests
{
    public class Checkproduto
    {
        [Theory]
        [InlineData("pdt1", 2, 4, "teste")]
        public void CanCreateAndSave(string name, int codigo,  decimal preco, string fabricante = "")
        {
            TestService<Produto> service = new TestService<Produto>();

            var pdt = new Produto();
            Assert.NotNull(pdt);
            pdt.Nome = name;
            pdt.Codigo = codigo;
            pdt.Preco = preco;
            pdt.Fabricante = fabricante;

            service.Post<ProdutoValidator>(pdt);
            Assert.True(pdt.Id > -1);
            var pdt2 = service.Get(pdt.Id);

            Assert.Equal(pdt2.Nome, pdt.Nome);
            
            Assert.Equal(pdt2.Fabricante, pdt.Fabricante);
        }

        [Theory]
        [InlineData("pdt2", 3, 1, "teste")]
        public void CanDelete(string name, int codigo, decimal preco, string fabricante = "")
        {
            TestService<Produto> service = new TestService<Produto>();

            var pdt = new Produto();
            Assert.NotNull(pdt);
            pdt.Nome = name;
            pdt.Codigo = codigo;
            pdt.Preco = preco;
            pdt.Fabricante = fabricante;

            service.Post<ProdutoValidator>(pdt);
            Assert.True(pdt.Id > -1);
            var pdt2 = service.Get(pdt.Id);

            Assert.Equal(pdt2.Nome, pdt.Nome);

            Assert.Equal(pdt2.Fabricante, pdt.Fabricante);

            var id = pdt.Id;
            service.Delete(pdt.Id);

            // Tentando deletar novamente e verificando se Exception é gerada.
            Assert.Throws<System.ArgumentNullException>(() => service.Delete(id));
        }

        [Theory]
        [InlineData("pdt3", 4, -1, "teste")]
        public void valorNegativo(string name, int codigo, decimal preco, string fabricante = "")
        {
            TestService<Produto> service = new TestService<Produto>();

            var pdt = new Produto();
            Assert.NotNull(pdt);
            pdt.Nome = name;
            pdt.Codigo = codigo;
            pdt.Preco = preco;
            pdt.Fabricante = fabricante;
            Assert.Throws<FluentValidation.ValidationException>(() => service.Post<ProdutoValidator>(pdt));
        }

    }
}
