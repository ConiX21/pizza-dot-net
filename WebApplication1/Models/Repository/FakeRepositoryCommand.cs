using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetPizza.Models.Repository
{
    public class FakeRepositoryCommand : IRepository<Command>
    {
        public IQueryable<Command> GetAll => throw new NotImplementedException();

        public Pizza Create(Pizza obj)
        {
            throw new NotImplementedException();
        }

        public Task<Command> CreateAsync(Command obj)
        {
            throw new NotImplementedException();
        }

        //public IQueryable<Command> GetAll => new List<Command> {
        //    new Command {Client  = new Client { },CommandDate =  DateTime.Now.AddDays(-10), CommandID = 1, DetailCommand = new DetailCommand()},
        //    new Command {Client  = new Client { },CommandDate =  DateTime.Now.AddDays(-4), CommandID = 2, DetailCommand = new DetailCommand()},
        //    new Command {Client  = new Client { },CommandDate =  DateTime.Now, CommandID = 3, DetailCommand = new DetailCommand()}
        //}.AsQueryable<Command>();

        public Command GetOne(int id)
        {
            throw new NotImplementedException();
        }
    }
}
