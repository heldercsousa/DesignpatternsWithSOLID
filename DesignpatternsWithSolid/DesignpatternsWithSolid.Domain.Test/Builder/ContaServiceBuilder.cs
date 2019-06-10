using DesignpatternsWithSolid.Data;
using DesignpatternsWithSolid.Data.Contract;
using DesignpatternsWithSolid.Domain.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignpatternsWithSolid.Domain.Test.Builder
{
    public class ContaServiceBuilder
    {
        private readonly Mock<IContaRepository> _mockContaRepository;
        private readonly ContaService _contaService;
        public Mock<Conta> ContaMockada { get; private set; }

        public ContaServiceBuilder()
        {
            _mockContaRepository = new Mock<IContaRepository>();
            _contaService = new ContaService(_mockContaRepository.Object);
        }

        public ContaServiceBuilder ComContaChamada(string nomeConta)
        {
            ContaMockada = new Mock<Conta>();
            _mockContaRepository.Setup(r => r.GetByName("ContaComercial")).Returns(ContaMockada.Object);
            return this;
        }

        public ContaServiceBuilder AdicionarTransacaoDeValor(decimal valorTransacao)
        {
            ContaMockada.Setup(a => a.AdicionarTransacao(200m)).Verifiable();
            return this;
        }

        public ContaService Build()
        {
            return _contaService;
        }
    }
}
