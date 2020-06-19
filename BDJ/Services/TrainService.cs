using BDJ.Data;
using BDJ.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BDJ.Services
{
    public class TrainService : ITrainService
    {
        private readonly BdjDbContext dbContext;

        public TrainService(BdjDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Train Create(Train train)
        {
            dbContext.Trains.Add(train);
            dbContext.SaveChanges();
            return train;
        }

        public Train Delete(Train train)
        {
            dbContext.Trains.Remove(train);
            dbContext.SaveChanges();
            return train;
        }

        public List<Train> GetAll()
        {
            return dbContext.Trains.ToList();
        }

        public Train GetById(Guid id)
        {
            return dbContext.Trains.First(t => t.Id == id);
        }

        public Train GetByNumber(string number)
        {
            return dbContext.Trains.First(t => t.Number == number);
        }

        public Train Update(Train train)
        {
            Train oldTrain = GetById(train.Id);
            oldTrain.Capacity = train.Capacity;
            oldTrain.Number = train.Number;
            oldTrain.Type = train.Type;
            dbContext.Trains.Update(oldTrain);
            dbContext.SaveChanges();

            return train;
        }
    }
}
