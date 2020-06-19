using BDJ.Data;
using BDJ.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BDJ.Services
{
    public class LineService : ILineService
    {
        private readonly BdjDbContext dbContext;

        public LineService(BdjDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Line Create(Line line)
        {
            dbContext.Lines.Add(line);
            dbContext.SaveChanges();
            return line;
        }

        public Line Delete(Line line)
        {
            dbContext.Lines.Remove(line);
            dbContext.SaveChanges();
            return line;
        }

        public List<Line> GetAll()
        {
            return dbContext.Lines.ToList();
        }

        public Line GetById(Guid id)
        {
            return dbContext.Lines.First(l => l.Id == id);
        }

        public Line Update(Line line)
        {
            Line oldLine = GetById(line.Id);
            oldLine.ArrivalTime = line.ArrivalTime;
            oldLine.Departure = line.Departure;
            oldLine.DepartureTime = line.DepartureTime;
            oldLine.Destination = line.Destination;
            oldLine.Train = line.Train;
            dbContext.Lines.Update(oldLine);
            dbContext.SaveChanges();

            return line;
        }
    }
}
