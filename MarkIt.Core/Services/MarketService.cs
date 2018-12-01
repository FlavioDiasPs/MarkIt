using MarkIt.Core.Entities;
using MarkIt.Core.Interfaces.Repositories;
using MarkIt.Core.Interfaces.Services;
using System.Collections.Generic;

namespace MarkIt.Core.Services
{
    public class MarketService : IMarketService
    {
        private readonly IMarketRepository _repository;

        public MarketService(IMarketRepository repository)
        {
            _repository = repository;
        }


        public void Add(Market obj)
        {
            _repository.Add(obj);
        }

        public IEnumerable<Market> GetAll()
        {
            return _repository.GetAll();
        }

        public Market GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(Market obj)
        {
            _repository.Remove(obj);
        }

        public void Update(Market obj)
        {
            _repository.Update(obj);
        }
    }
}
