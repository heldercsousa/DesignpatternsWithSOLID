using DesignpatternsWithSolid.Data.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignpatternsWithSolid.Data.Repository
{
    public class ContaRepository : IContaRepository
    {
        private Conta conta;
        public ContaRepository(Conta _conta)
        {
            this.conta = _conta;
        }
        public Conta GetByName(string nomeConta)
        {
            return conta;
        }
    }
}
