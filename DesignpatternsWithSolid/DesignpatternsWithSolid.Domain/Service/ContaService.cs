namespace DesignpatternsWithSolid.Domain.Service
{
    using DesignpatternsWithSolid.Data.Contract;
    using DesignpatternsWithSolid.Domain.Contract;
    using DesignpatternsWithSolid.Domain.Exception;
    using System;

    public class ContaService : IContaService
    {
        private readonly IContaRepository repository;
        public ContaService(IContaRepository _repository)
        {
            if (_repository == null)
                throw new ArgumentNullException("repository", "Um repositório válido deve ser fornecido");
            this.repository = _repository;
        }
        public void AdicionarTransacao(string uid, decimal montante)
        {
            var conta = repository.GetByName(uid);
            if (conta != null)
            {
                try
                {
                    conta.AdicionarTransacao(montante);
                }
                catch (DomainException domainException)
                {
                    //The original exception is now wrapped properly by the new exception.
                    throw new ServiceException("Repository.AdicionarTransacao para conta falhou", domainException);
                }
            }
           
        }
    }
}
