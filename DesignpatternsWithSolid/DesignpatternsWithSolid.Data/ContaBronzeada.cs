﻿using DesignpatternsWithSolid.Data.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignpatternsWithSolid.Data
{
    public class ContaBronzeada : Conta
    {
        public ContaBronzeada(ICartaoRecompensa cartao) : base(cartao) { }
    }
}