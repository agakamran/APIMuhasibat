using APIMuhasibat.Models;
using APIMuhasibat.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIMuhasibat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmeliyyatController : ControllerBase
    {
        private readonly IRepository<Emeliyyatdet> _emel = null;
        private readonly IRepository<Tipler> _ti = null;
        private readonly IRepository<Qrup> _qr = null;
        private readonly IRepository<Activler> _bol = null;
        private readonly IRepository<Hesab> _he = null;
        private readonly IRepository<Madde> _mad = null;
        private readonly IRepository<Shirket> _shi = null;
        private readonly IRepository<Mushteri> _mush = null;
        private readonly IRepository<Vahid> _va = null;
        private readonly IRepository<Valyuta> _val = null;
        private readonly IRepository<Vergi> _ver = null;
        public EmeliyyatController(IRepository<Emeliyyatdet> emel,IRepository<Tipler> ti, IRepository<Qrup> qr, IRepository<Activler> bol, IRepository<Hesab> he,
            IRepository<Madde> mad, IRepository<Shirket> shi, IRepository<Mushteri> mush, IRepository<Vahid> va, IRepository<Valyuta> val, IRepository<Vergi> ver)
        {
            _emel = emel;
            _ti = ti;
            _qr = qr;
            _bol = bol;
            _he = he;
            _mad = mad;
            _shi = shi;
            _mush = mush;
            _va = va;
            _val = val;
            _ver = ver;
        }
        #region Emeliyyat
        // GET: api/hazirla
        [HttpGet]
        [Route("_getEmeliyyat")]
        public IEnumerable _getEmeliyyat(string id)
        {

            if (id != null)
            {
                return _emel.GetAll().Where(c => c.EmdetId == id);
            }
            else
            {
                // int d= _va.GetAll().Count();
                return _emel.GetAll().OrderByDescending(c => c.EmdetId).OrderBy(k => k.EmdetId);
            }

        }
        // POST: api/hazirla/_postmov
        [HttpPost]
        [Route("_postEmeliyyat")]
        public async Task<IActionResult> _postEmeliyyat([FromBody] Emeliyyatdet va)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            try
            {
                if (va.EmdetId == "")
                {
                    // var ff = _val.GetAll().FirstOrDefault(k => k.Valname.Trim().Contains(va.Valname.Trim()));
                    //  if (ff == null)
                    // {                    
                    va.EmdetId = Guid.NewGuid().ToString();
                    va.QId = va.QId;
                    va.UserId = va.UserId;
                    va.MushId = va.MushId;
                    va.VergiId= va.VergiId;
                    va.VId = va.VId;
                    va.Qeyd = va.Qeyd;
                    va.ValId = va.ValId;
                    va.DhesId = va.KhesId;
                    va.KhesId = va.KhesId;
                    va.Submiqdar = va.Submiqdar;                  
                    va.Edvye_celbedilen = va.Edvye_celbedilen;
                    va.Edvye_celbedilmeyen = va.Edvye_celbedilmeyen;
                    va.Miqdar = va.Miqdar;
                    
                    va.Vahidqiymeti_alish = va.Vahidqiymeti_alish;
                    va.Vahidqiymeti_satish = va.Vahidqiymeti_satish;
                    va.Edv = va.Edv;
                    va.Kurs = va.Kurs;
                        await _emel.InsertAsync(va);
                   // }
                    return Ok();
                }
                else
                {
                    var _m = _val.GetAll().FirstOrDefault(x => x.ValId == va.ValId);
                   // _m.ValId = va.ValId;
                  //  _m.Valname = va.Valname;
                    await _val.EditAsync(_m);
                    return Ok();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }
        }
        // DELETE: api/hazirla/5
        [HttpDelete]
        [Route("_deleteEmeliyyat")]
        public async Task<IActionResult> _deleteEmeliyyat(string id)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var va = await _val.GetAll().SingleOrDefaultAsync(m => m.ValId == id);
            if (va == null)
            {
                return NotFound();
            }

            await _val.DeleteAsync(va);
            // await _context.SaveChangesAsync();

            return Ok(va);
        }
        #endregion
        // GET: api/<EmeliyyatController>

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EmeliyyatController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmeliyyatController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EmeliyyatController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmeliyyatController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
