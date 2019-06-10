using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignpatternsWithSolid.Data
{
    public class Conta
    {
        public virtual void AdicionarTransacao(decimal montante)
        {
            Saldo += montante;  
        }
        public decimal Saldo { get; private set; }
    }
}
