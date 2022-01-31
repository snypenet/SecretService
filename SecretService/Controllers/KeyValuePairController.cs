using Microsoft.AspNetCore.Mvc;
using SecretService.Persistence.Repositories;
using System.Threading.Tasks;

namespace SecretService.Controllers
{
    [Route("kvp")]
    [ApiController]
    public class KeyValuePairController : ControllerBase
    {
        private readonly IKeyValuePairRepository _keyValuePairRepository;

        public KeyValuePairController(IKeyValuePairRepository keyValuePairRepository)
        {
            _keyValuePairRepository = keyValuePairRepository;
        }

        [HttpGet]
        [Route("{clientId}/all")]
        public async Task<IActionResult> GetAll(string clientId)
        {
            var pairs = await _keyValuePairRepository.GetAll(clientId);
            return Ok(pairs);
        }

        [HttpGet("{clientId}/group/{groupName}")]
        public async Task<IActionResult> GetByGroupName(string clientId, string groupName)
        {
            var pairs = await _keyValuePairRepository.GetByGroupName(clientId, groupName);
            return Ok(pairs);
        }

        [HttpGet("{clientId}/key/{key}")]
        public async Task<IActionResult> GetByKey(string clientId, string key)
        {
            var pairs = await _keyValuePairRepository.GetByKey(clientId, key);
            return Ok(pairs);
        }
    }
}
