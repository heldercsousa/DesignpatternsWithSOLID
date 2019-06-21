using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignpatternsWithSolid.Data.Contract
{
    public interface ICartaoRecompensa
    {
        int PontosRecompensa { get; }
        void CalcularPontosRecompensa(decimal montanteTransacao, decimal balancoConta);
    }
}
