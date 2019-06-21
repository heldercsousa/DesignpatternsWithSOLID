using DesignpatternsWithSolid.Data.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignpatternsWithSolid.Data
{
    class CartaoRecompensaPlatinado : ICartaoRecompensa
    {
        public int PontosRecompensa { get; private set; }

        public void CalcularPontosRecompensa(decimal montanteTransacao, decimal balancoConta)
        {
            PontosRecompensa += Math.Max((int)decimal.Ceiling((balancoConta / PlatinumBalanceCostPerPoint) + (montanteTransacao / PlatinumTransactionCostPerPoint)), 0);
        }

        private const int PlatinumTransactionCostPerPoint = 2;
        private const int PlatinumBalanceCostPerPoint = 1000;
    }
}
