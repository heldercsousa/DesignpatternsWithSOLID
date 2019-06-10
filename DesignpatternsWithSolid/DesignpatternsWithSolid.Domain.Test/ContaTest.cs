namespace DesignpatternsWithSolid.Domain.Test
{
    using DesignpatternsWithSolid.Data;
    using DesignpatternsWithSolid.Data.Contract;
    using DesignpatternsWithSolid.Data.Repository;
    using DesignpatternsWithSolid.Domain.Exception;
    using DesignpatternsWithSolid.Domain.Service;
    using DesignpatternsWithSolid.Domain.Test.Builder;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;

    [TestClass]
    public class ContaTest
    {
        private Mock<Conta> contaMockada;
        private Mock<IContaRepository> mockRepository;
        private ContaService sut;

        private ContaServiceBuilder serviceBuilder;

        [TestInitialize]
        public void Setup()
        {
            contaMockada = new Mock<Conta>();
            mockRepository = new Mock<IContaRepository>();
            sut = new ContaService(mockRepository.Object);

            serviceBuilder = new ContaServiceBuilder();
        }

        /// <summary>
        /// MANUAL TEST FAKERY example
        /// </summary>
        [TestMethod]
        public void AdicionarTransacaoManualTestFakery()
        {
            ///AAA - Arrange, Act, Assert
            ///Arrange
            var contaa = new Conta();
            var fakeRepo = new ContaRepository(contaa); //esse repositório foi montado para servir de repositório falso, equanto o oficial não foi desenvolvido
            var sutt = new ContaService(fakeRepo);

            //Act
            sutt.AdicionarTransacao("ContaComercial", 200m);

            //Assert
            Assert.AreEqual(200m, contaa.Saldo);
        }

        /// <summary>
        /// MOQ instead of MANUAL TEST example
        /// </summary>
        [TestMethod]
        public void AdicionarTransacaoMoquada()
        {
            ///AAA - Arrange, Act, Assert
            ///Arrange
            var contaa = new Conta();
           // var mockRepository = new Mock<IContaRepository>();
            mockRepository.Setup(r => r.GetByName("ContaComercial")).Returns(contaa);
           // var sut = new ContaService(mockRepository.Object);

            //Act
            sut.AdicionarTransacao("ContaComercial", 200m);

            //Assert
            Assert.AreEqual(200m, contaa.Saldo);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NaoPodeCriarServicoComRepositorioNull()
        {
            //Arrange
            //Act
            new ContaService(null);
            //Assert;
        }

        /// <summary>
        /// A execção esperada aki é uma ServiceException. Qq coisa diferente dá errado o teste
        /// </summary>
        [TestMethod]
        //[ExpectedException(typeof(ServiceException))]
        public void ExceptionContaEnvelopadaNoServico()
        {
            //Arrange
            contaMockada.Setup(a => a.AdicionarTransacao(100m)).Throws<DomainException>();
            mockRepository.Setup(r => r.GetByName("ContaComercial")).Returns(contaMockada.Object);
            var sut = new ContaService(mockRepository.Object);
            try
            {
                //act
                sut.AdicionarTransacao("ContaComercial", 100m);
            }
            catch (ServiceException serviceException)
            {
                //assert    
                Assert.IsInstanceOfType(serviceException.InnerException, typeof(DomainException));
            }
        }

        /// <summary>
        /// A seção Arrange deste test ficou mais clara graças ao padrão Builder;
        /// Another advantage of the Builder pattern is that it leads to more declarative tests. 
        /// No test should ever have a cyclomatic complexity greater than 1, meaning that tests should be completely linear 
        /// with no branching. An if statement or a for, foreach, or while loop will cause the cyclomatic complexity of a test 
        /// to exceed 1. The Builder pattern helps with this by converting imperative construction and initialization to declarative.
        /// </summary>
        [TestMethod]
        public void UsandoUmBuilderParaMelhorarLeitura()
        {
            //arrange
            var sutt = serviceBuilder.ComContaChamada("ContaComercial").AdicionarTransacaoDeValor(200m).Build();

            //act
            sutt.AdicionarTransacao("ContaComercial", 200m);

            //assert
            serviceBuilder.ContaMockada.Verify();
        }
    }
}
