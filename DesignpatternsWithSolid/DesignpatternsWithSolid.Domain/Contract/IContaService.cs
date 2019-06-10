using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignpatternsWithSolid.Domain.Contract
{
    public interface IContaService
    {
        void AdicionarTransacao(string uid, decimal montante);

    }
}
