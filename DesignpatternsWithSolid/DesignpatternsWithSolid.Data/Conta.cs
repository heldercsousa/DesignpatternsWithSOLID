using DesignpatternsWithSolid.Data.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignpatternsWithSolid.Data
{
    public class Conta
    {
        public Conta(ICartaoRecompensa cartaoRecompensa)
        {
            this._cartaoRecompensa = cartaoRecompensa;
        }
        
        public static Conta CriarConta(TipoConta tipo)
        {
            Conta novaConta = null;
            switch (tipo)
            {
                case TipoConta.Ouro:
                    novaConta = new ContaDourada(new CartaoRecompensaDourado());
                    break;
                case TipoConta.Platina:
                    novaConta = new ContaPlatinada(new CartaoRecompensaPlatinado());
                    break;
                case TipoConta.Prata:
                    novaConta = new ContaPrateada(new CartaoRecompensaPrateado());
                    break;
                case TipoConta.Bronze:
                    novaConta = new ContaBronzeada(new CartaoRecompensaBronze());
                    break;
                case TipoConta.Padrao:
                    novaConta = new ContaPadrao(new CartaoRecompensaNull());
                    break;
                default:
                    break;
            }
            return novaConta;
           /* _factory.CriarConta(tipo);
            _repository.NovaConta(novaConta);*/
        }

        public decimal Saldo { get; private set; }

        public void AdicionarTransacao(decimal montante)
        {
            _cartaoRecompensa.CalcularPontosRecompensa(montante, Saldo);
            Saldo += montante;
        }

        public enum TipoConta
        {
            Padrao,
            Ouro,
            Platina,
            Prata,
            Bronze
        }

        //private readonly IContaFactory _factory;
        //private readonly IContaRepository _repository;
        private ICartaoRecompensa _cartaoRecompensa;
    }
}
