using SecretService.Persistence.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecretService.Persistence.Repositories
{
    public interface IKeyValuePairRepository
    {
        Task<IEnumerable<SecretKeyValuePair>> GetAll(string paritionKey);
        Task<IEnumerable<SecretKeyValuePair>> GetByGroupName(string partitionKey, string name);
        Task<SecretKeyValuePair> GetByKey(string partitionKey, string key);
    }
}
