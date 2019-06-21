using DesignpatternsWithSolid.Data.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignpatternsWithSolid.Data
{
    class CartaoRecompensaDourado : ICartaoRecompensa
    {
        public int PontosRecompensa { get; private set; }

        public void CalcularPontosRecompensa(decimal montanteTransacao, decimal balancoConta)
        {
            PontosRecompensa += Math.Max((int)decimal.Floor((montanteTransacao / GoldBalanceCostPerPoint) + (montanteTransacao / GoldTransactionCostPerPoint)), 0);
        }

        private const int GoldTransactionCostPerPoint = 5;
        private const int GoldBalanceCostPerPoint = 2000;
    }
}