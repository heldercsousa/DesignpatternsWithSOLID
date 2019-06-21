using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DesignpatternsWithSolid.Data.Conta;

namespace DesignpatternsWithSolid.Data.Contract
{
    public interface IContaFactory
    {
        Conta CriarConta(TipoConta tipo);
    }
}
