using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DotNetPizza.Models.Repository
{
    public class FakeRepositoryClient : IRepository<Client>
    {
        public List<Client> _Clients { get; set; } = new List<Client>{
                new Client {ClientID = 1,Lastname = "GASQUET",Firstname = "Nicolas",Address = "37 immpasse des ...",ZipCode = "83560",City = "Rians", Gender = 0},
                new Client {ClientID = 2,Lastname = "MONIS",Firstname = "Simon",Address = "44 immpasse des ...",ZipCode = "13000",City = "Marseille", Gender = 0},
                new Client { ClientID = 3,Lastname = "LECRAM",Firstname = "Marcele",Address = "789 route des ...",ZipCode = "83000",City = "Toulon", Gender = 1},
                new Client {ClientID = 4,Lastname = "ERREIP",Firstname = "Julie",Address = "563 rue des ...",ZipCode = "84000",City = "Avignons", Gender = 1}
            };

        public IQueryable<Client> GetAll => _Clients.AsQueryable<Client>();

        public Pizza Create(Pizza obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<Client> CreateAsync(Client obj)
        {
            throw new System.NotImplementedException();
        }

        public Client GetOne(int id)
        {
            return _Clients.FirstOrDefault(c => c.ClientID == id);
        }
    }

}
