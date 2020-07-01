using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Compliance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NormasExternasController : ControllerBase
    {
        private INormaService _service;

        public NormasExternasController(INormaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            return await _service.GetNormas();
        }

        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            return await _service.GetNorma(id);
        }
    }
}
