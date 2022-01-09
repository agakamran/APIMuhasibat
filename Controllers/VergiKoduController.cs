using APIMuhasibat.Models;
using APIMuhasibat.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIMuhasibat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VergiKoduController : ControllerBase
    {
        private readonly IRepository<_vergi> _he = null;
        private readonly IRepository<_tip> _ti = null;
        private readonly IRepository<_qrup> _qr = null;
        private readonly IRepository<_aktiv> _bol = null;
        private readonly IRepository<_madde> _mad = null;
        private readonly IRepository<shirket> _shi = null;
        private readonly IRepository<mushteri> _mush = null;
        private readonly IRepository<_vahid> _va = null;
        public VergiKoduController(IRepository<_vergi> he, IRepository<_tip> ti, IRepository<_qrup> qr,
            IRepository<_aktiv> bol, IRepository<_madde> mad, IRepository<shirket> shi, IRepository<mushteri> mush,
            IRepository<_vahid> va)
        {
            _he = he;
            _ti = ti;
            _qr = qr;
            _bol = bol;
            _mad = mad;
            _shi = shi;
            _mush = mush;
            _va = va;
        }
        // GET: api/<VergiKoduController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<VergiKoduController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VergiKoduController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<VergiKoduController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VergiKoduController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
