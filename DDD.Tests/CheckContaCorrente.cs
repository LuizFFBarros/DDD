using DDD.Domain.Entities;
using DDD.Service.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DDD.Tests
{
    public class CheckContaCorrente
    {

        [Theory]
        [InlineData(12345678901, "luiz", "bh", 3144446666, 0d, 500d, 0d)]
        public void insereContaCorrente(long cpf, string nome, string endereco, long telefone, decimal saldo, decimal limiteCredito, decimal saldoLimiteCredito)
        {
            TestService<ContaCorrente> service = new TestService<ContaCorrente>();

            var cc = new ContaCorrente
            {
                CPF = cpf,
                Endereco = endereco,
                LimiteCredito = limiteCredito,
                Nome = nome,
                Saldo = saldo,
                SaldoLimiteCredito = saldoLimiteCredito,
                Telefone = telefone
            };

            service.Post<ContaCorrenteValidator>(cc);
            Assert.True(cc.Id > -1);

            var cc_get = service.Get(cc.Id);
            Assert.Equal(cc.Nome, cc_get.Nome);
            Assert.Equal(cc.CPF, cc_get.CPF);
        }

        [Theory]
        [InlineData(123456789, "luiz",     "bh", 3144446666, 0, 500, 0)]
        public void GeraExcecao_CPF_diferente_11_digitos(long cpf, string nome, string endereco, long telefone, decimal saldo, decimal limiteCredito, decimal saldoLimiteCredito)
        {
            TestService<ContaCorrente> service = new TestService<ContaCorrente>();
            try
            {
                var cc = new ContaCorrente
                {
                    CPF = cpf,
                    Endereco = endereco,
                    LimiteCredito = limiteCredito,
                    Nome = nome,
                    Saldo = saldo,
                    SaldoLimiteCredito = saldoLimiteCredito,
                    Telefone = telefone
                };
            }
            catch (ArgumentException ArgEx)
            {
                Assert.True(ArgEx.GetType().Equals(typeof(ArgumentException)));
            }

        }

        [Theory]
        [InlineData(12345678902, "luiz", "bh", 3144446666, 1000, 500, 500, 1300)]
        public void debitaValor(long cpf, string nome, string endereco, long telefone, decimal saldo, decimal limiteCredito, decimal saldoLimiteCredito, decimal valorDebitar)
        {
            TestService<ContaCorrente> service = new TestService<ContaCorrente>();

            var cc = new ContaCorrente
            {
                CPF = cpf,
                Endereco = endereco,
                LimiteCredito = limiteCredito,
                Nome = nome,
                Saldo = saldo,
                SaldoLimiteCredito = saldoLimiteCredito,
                Telefone = telefone
            };

            service.Post<ContaCorrenteValidator>(cc);
            Assert.True(cc.Id > -1);

            var cc_get = service.Get(cc.Id);

          Assert.Equal(cc_get.Debitar(valorDebitar), valorDebitar);
        }

        [Theory]
        [InlineData(12345678903, "luiz", "bh", 3144446666, 1000, 500, 500, 2000)]
        public void GeraExcecaoDebitoMaiorQueLimiteConta(long cpf, string nome, string endereco, long telefone, decimal saldo, decimal limiteCredito, decimal saldoLimiteCredito, decimal valorDebitar)
        {
            TestService<ContaCorrente> service = new TestService<ContaCorrente>();

            var cc = new ContaCorrente
            {
                CPF = cpf,
                Endereco = endereco,
                LimiteCredito = limiteCredito,
                Nome = nome,
                Saldo = saldo,
                SaldoLimiteCredito = saldoLimiteCredito,
                Telefone = telefone
            };

            service.Post<ContaCorrenteValidator>(cc);
            Assert.True(cc.Id > -1);

            var cc_get = service.Get(cc.Id);

            Assert.Throws<ArgumentException>(()=> cc_get.Debitar(valorDebitar));
        }
    }
}
