using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Domain.Entities
{
    public class ContaCorrente : BaseEntity
    {
        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private long cpf;

        public long CPF
        {
            set
            {
                if (value.ToString().Length != 11)
                    throw new ArgumentException("CPF deve ter 11 digitos");
                cpf = value;
            }
            get { return cpf; }
        }

        private string endereco;

        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        private long telefone;

        public long Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }


        private decimal saldo;

        public decimal Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }

        private decimal saldoLimiteCredito;

        public decimal SaldoLimiteCredito
        {
            get { return saldoLimiteCredito; }
            set { saldoLimiteCredito = value; }
        }

        private decimal limiteCredito;        

        public decimal LimiteCredito
        {
            get { return limiteCredito; }
            set
            {
                limiteCredito = value;
                SaldoLimiteCredito += limiteCredito;
            }
        }


        public decimal Debitar(decimal valor)
        {
            // 1300     1000        500
            if (valor > Saldo + SaldoLimiteCredito)
                throw new ArgumentException("Saldo insuficiente");

            var x = Math.Abs(Saldo - valor);
            if (x < 0)
            {
                Saldo = 0;
                saldoLimiteCredito = saldoLimiteCredito - x;

            }

            return valor;
        }

        public void Creditar(decimal valorCredito)
        {
            if (valorCredito > 50000)
                Console.WriteLine("Notificando COAF");

            if(LimiteCredito - SaldoLimiteCredito != 0)
            {
                var valorFaltanteLimiteCredito = LimiteCredito - SaldoLimiteCredito;
                saldo += (valorCredito -= valorFaltanteLimiteCredito);
            }


        }

    }
}
