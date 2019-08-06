using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Domain.Entities
{
    public class Produto : BaseEntity
    {
        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private string fabricante;
            
        public string Fabricante
        {
            get { return fabricante; }
            set { fabricante = value; }
        }

        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private decimal preco;

        public decimal Preco
        {
            get { var dado =  preco.ToString("0.00");
                return Convert.ToDecimal(dado);
            }
            set { preco = value; }
        }

    }
}
