using DesignpatternsWithSolid.Data.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignpatternsWithSolid.Data
{
    class CartaoRecompensaBronze : ICartaoRecompensa
    {
        public int PontosRecompensa { get; private set; }

        public void CalcularPontosRecompensa(decimal montanteTransacao, decimal balancoConta)
        {
            PontosRecompensa += Math.Max((int)decimal.Floor(montanteTransacao / BronzeTransactionCostPerPoint), 0);
        }

        private const int BronzeTransactionCostPerPoint = 20;
    }
}
