using DesignpatternsWithSolid.Data.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignpatternsWithSolid.Data
{
    class CartaoRecompensaNull : ICartaoRecompensa
    {
        public int PontosRecompensa { get; private set; }

        public void CalcularPontosRecompensa(decimal montanteTransacao, decimal balancoConta)
        {
        }
    }
}
