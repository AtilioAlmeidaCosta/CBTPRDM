/*
Autores:
Atilio Almeida Costa
CB3025497
João Victor Crivoi Cesar Sousa
CB3062027
*/
using System.Threading.Tasks;
using PackageTraking.Models;

namespace PackageTraking.Services
{
    public interface ITrackingService
    {
        Task<Package?> GetPackageAsync(string trackingCode);
    }
}