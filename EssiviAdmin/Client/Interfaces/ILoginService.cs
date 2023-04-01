using EssiviAdmin.Client.Models;

namespace EssiviAdmin.Client.Interfaces
{
    public interface ILoginService
    {
        public Task<string> Login(string username, string password);
        public void Logout();
        public bool Register(Person person);
    }
}
