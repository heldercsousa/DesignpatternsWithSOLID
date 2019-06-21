﻿using DesignpatternsWithSolid.Data.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignpatternsWithSolid.Data
{
    class CartaoRecompensaPrateado : ICartaoRecompensa
    {
        public int PontosRecompensa { get; private set; }

        public void CalcularPontosRecompensa(decimal montanteTransacao, decimal balancoConta)
        {
            PontosRecompensa += Math.Max((int)decimal.Floor(montanteTransacao / SilverTransactionCostPerPoint), 0);
        }

        private const int SilverTransactionCostPerPoint = 10;
    }
}