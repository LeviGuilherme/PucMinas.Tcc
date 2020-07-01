using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Shared.DbSimulation.DbExternalSystems;

namespace GestaoNormasConsultorias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NormasController : ControllerBase
    {
        private Normas _normas = new Normas();

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _normas.ListaNormas.Values.ToList();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return _normas.ListaNormas[id];
        }
    }
}
