using BDJ.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BDJ.Services.Contracts
{
    public interface ITrainService
    {
        public Train Create(Train train);
        public Train Delete(Train train);
        public Train GetById(Guid id);
        public Train GetByNumber(string number);
        public List<Train> GetAll();
        public Train Update(Train train);
    }
}
