using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignpatternsWithSolid.Data.Contract
{
    public interface IContaRepository
    {
        Conta GetByName(string nomeConta);
    }
}
