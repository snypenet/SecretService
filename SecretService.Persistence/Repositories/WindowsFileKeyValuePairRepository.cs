using Newtonsoft.Json;
using SecretService.Persistence.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretService.Persistence.Repositories
{
    public class WindowsFileKeyValuePairRepository : IKeyValuePairRepository
    {
        private readonly string _directoryLocation;

        public WindowsFileKeyValuePairRepository(string directoryLocation)
        {
            _directoryLocation = directoryLocation;
        }
        
        public async Task<IEnumerable<SecretKeyValuePair>> GetAll(string paritionKey)
        {
            paritionKey = paritionKey.Trim();
            var secretsFile = await GetSecretsFile(paritionKey);
            return secretsFile.Pairs;
        }

        private async Task<SecretsFile> GetSecretsFile(string paritionKey)
        {
            string secretsFilePath = Path.Combine(_directoryLocation, $"{paritionKey}_secrets.json");
            if (!File.Exists(secretsFilePath))
            {
                await File.WriteAllTextAsync(secretsFilePath, JsonConvert.SerializeObject(new SecretsFile()));
            }

            return JsonConvert.DeserializeObject<SecretsFile>(await File.ReadAllTextAsync(secretsFilePath));
        }

        public async Task<IEnumerable<SecretKeyValuePair>> GetByGroupName(string paritionKey, string name)
        {
            name = name.Trim();
            paritionKey = paritionKey.Trim();
            var secretFile = await GetSecretsFile(paritionKey);
            var secrets = secretFile.Pairs.Where(p => p.Group.Any(g => g.Equals(name, StringComparison.InvariantCultureIgnoreCase) || g == "All"));
            return secrets;
        }

        public async Task<SecretKeyValuePair> GetByKey(string paritionKey, string key)
        {
            key = key.Trim();
            paritionKey = paritionKey.Trim();
            var secretFile = await GetSecretsFile(paritionKey);
            var secret = secretFile.Pairs.SingleOrDefault(p => p.Key == key);
            return secret;
        }

        
    }
}
