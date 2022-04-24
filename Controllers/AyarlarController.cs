using APIMuhasibat.Models;
using APIMuhasibat.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIMuhasibat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AyarlarController : BaseController
    {
        private readonly IRepository<Tipler> _ti = null;
        private readonly IRepository<Qrup> _qr = null;
        private readonly IRepository<Activler> _act = null;
        private readonly IRepository<Hesab> _he = null;
        private readonly IRepository<Bolme> _bol = null;
        private readonly IRepository<Madde> _mad = null;
        private readonly IRepository<Shirket> _shi = null;
        private readonly IRepository<Mushteri> _mush = null;
        private readonly IRepository<Vahid> _va = null;
        private readonly IRepository<Valyuta> _val = null;
        private readonly IRepository<Vergi> _ver = null;
        private readonly IRepository<fealsahe> _feal = null;
        private readonly IRepository<Emeliyyatdet> _emel = null;
        private readonly IRepository<anbar> _anbar = null;
        private static IWebHostEnvironment _host;
        public AyarlarController(IWebHostEnvironment host, IRepository<Tipler> ti, IRepository<Qrup> qr, IRepository<Activler> act, IRepository<Hesab> he, IRepository<Bolme> bol,
        IRepository<Madde> mad, IRepository<Shirket> shi, IRepository<Mushteri> mush, IRepository<Vahid> va, IRepository<Valyuta> val,
         IRepository<anbar> anbar, IRepository<Vergi> ver, IRepository<fealsahe> feal, IRepository<Emeliyyatdet> emel)
        {
            _host = host;
            _ti = ti;
            _qr = qr;
            _act = act;
            _he = he;
            _mad = mad;
            _shi = shi;
            _mush = mush;
            _va = va;
            _val = val;
            _ver = ver;
            _bol = bol;
            _feal = feal;
            _emel = emel;
            _anbar = anbar;
        }
        /*
   select *from Tiplers
   select *from Aktivs
   select *from Maddes
   select *from Bolmes
    select *from Hesabs
    select * from Mushteris
    select * from Shirkets
    select * from Vahids
    select count(*) from Vergis
*/
        /*
          delete from Tiplers
          delete from Aktivs
          delete from Maddes
          delete from Bolmes        
          delete from Hesabs
          delete from Mushteris
          delete from Shirkets
          delete from Vahids
          delete from Vergis
        */



        #region tip
        // GET: api/hazirla
        [HttpGet]
        [Route("_gettip")]
        public IEnumerable<Tipler> _gettip(string id)
        {
            if (id != null)
            {
                return _ti.GetAll().Where(g => g.TipId == id);
            }
            else
            {
                return _ti.GetAll().OrderByDescending(c => c.TipId).OrderBy(k => k.TipId);
            }
        }
        // POST: api/hazirla/_postmov
        [HttpPost]
        [Route("_postip")]
        public async Task<IActionResult> _postip([FromBody] Tipler ti)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            try
            {
                if (ti.TipId == "")
                {
                    ti.TipId = Guid.NewGuid().ToString();
                    ti.TipName = ti.TipName;

                    await _ti.InsertAsync(ti);
                    return Ok();
                }
                else
                {
                    var _m = _ti.GetAll().FirstOrDefault(x => x.TipId == ti.TipId);
                    _m.TipId = ti.TipId;
                    _m.TipName = ti.TipName;
                    await _ti.EditAsync(_m);
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
        [Route("_deletetip")]
        public async Task<IActionResult> _deletetip(string id)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var ti = await _ti.GetAll().SingleOrDefaultAsync(m => m.TipId == id);
            if (ti == null)
            {
                return NotFound();
            }

            await _ti.DeleteAsync(ti);
            // await _context.SaveChangesAsync();

            return Ok(ti);
        }
        #endregion
        #region qrup
        // GET: api/hazirla
        [HttpGet]
        [Route("_getqrup")]
        public IEnumerable _getqrup(string id)
        {
            // int vv = _mov.GetAll().OrderByDescending(c => c.mnom).Count()if (id != null)
            //  select QId, Qrupname, dh.Hesnom, kh.Hesnom from Qrups q join Hesabs dh on q.DhesId = dh.HesId
            //            join Hesabs kh on q.KhesId = kh.HesId
           // select QId, Qrupname, dh.HesId dhid, dh.Hesnom dhnom, dh.Hesname dhname, kh.HesId khid, kh.Hesnom khnom, kh.Hesname khname from Qrups q
           //join Hesabs dh on q.DhesId = dh.HesId
           // join Hesabs kh on q.KhesId = kh.HesId
       
                   var res = (from q in _qr.GetAll().ToList()
                        join dh in _he.GetAll().ToList() on q.DhesId equals dh.HesId
                        join kh in _he.GetAll().ToList() on q.KhesId equals kh.HesId
                        select new
                        {
                            q.QId,
                            q.Qrupname,
                            dhesId = dh.Hesnom,
                            khesId = kh.Hesnom
                        }).ToList();
            if (id != null)
            {
                
                return res.ToList().Where(g => g.QId == id);
            }
            return res.ToList();
        }
        // POST: api/hazirla/_postmov
        [HttpPost]
        [Route("_postqrup")]
        public async Task<IActionResult> _postqrup([FromBody] Qrup qr)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            try
            {
                if (qr.QId == "")
                {
                    qr.QId = Guid.NewGuid().ToString();
                    qr.Qrupname = qr.Qrupname;
                    qr.DhesId = qr.DhesId;
                    qr.KhesId=qr.KhesId;
                   // qr.Description = qr.Description;
                    await _qr.InsertAsync(qr);
                    return Ok();
                }
                else
                {
                    var _m = _qr.GetAll().FirstOrDefault(x => x.QId == qr.QId);
                    _m.Qrupname = qr.Qrupname;
                    _m.DhesId = qr.DhesId;
                    _m.KhesId = qr.KhesId;
                    // _m.Description = qr.Description;
                    await _qr.EditAsync(_m);
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
        [Route("_deleteqrup")]
        public async Task<IActionResult> _deleteqrup(Qrup qrr)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var qr = await _qr.GetAll().SingleOrDefaultAsync(m => m.QId == qrr.QId);
            if (qr == null)
            {
                return NotFound();
            }

            await _qr.DeleteAsync(qr);
            // await _context.SaveChangesAsync();
            return Ok(qr);
        }
        #endregion
        #region bol aktiv
        // GET: api/hazirla
        [HttpGet]
        [Route("getaktiv")]
        public IEnumerable<Activler> getaktiv(string id)
        {
            if (id != null)
            {
                return _act.GetAll().Where(g => g.ActivId == id);
            }
            else
            {
                return _act.GetAll().OrderByDescending(c => c.ActivId).OrderBy(k => k.ActivId);
            }


        }
        // POST: api/hazirla/_postmov
        [HttpPost]
        [Route("_postaktivler")]
        public async Task<IActionResult> _postaktivler([FromBody] Activler ti)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            try
            {
                if (ti.ActivId == "")
                {
                    ti.ActivId = Guid.NewGuid().ToString();
                    ti.ActivName = ti.ActivName;
                    ti.Description = ti.Description;
                    await _act.InsertAsync(ti);
                    return Ok();
                }
                else
                {
                    var _m = _act.GetAll().FirstOrDefault(x => x.ActivId == ti.ActivId);
                    _m.ActivId = ti.ActivId;
                    _m.ActivName = ti.ActivName;
                    _m.Description = ti.Description;
                    await _act.EditAsync(_m);
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
        [Route("_delaktiv")]
        public async Task<IActionResult> _delaktiv(string id)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var ti = await _act.GetAll().SingleOrDefaultAsync(m => m.ActivId == id);
            if (ti == null)
            {
                return NotFound();
            }

            await _act.DeleteAsync(ti);
            // await _context.SaveChangesAsync();

            return Ok(ti);
        }
        #endregion
        #region hesab
        // GET: api/hazirla
        [HttpGet]
        [Route("_gethesab")]
        public IEnumerable _gethesab(string id)
        {
            /*
             select he.HesId,he.Hesnom,he.Hesname,he.BId,m.MId,m.MaddeName,t.TipId,t.TipName from Hesabs he left
            join Maddes m on he.MId=m.MId  
            join Tiplers t on he.TipId=t.TipId order by he.Hesnom,m.MaddeName
             */
            var res = (from he in _he.GetAll().ToList()
                       join b in _bol.GetAll().ToList() on he.BId equals b.bId
                       join m in _mad.GetAll().ToList() on he.MId equals m.MId //into mad
                       join t in _ti.GetAll().ToList() on he.TipId equals t.TipId
                       join a in _act.GetAll().ToList() on he.ActivId equals a.ActivId
                       // from _mmad in mad.DefaultIfEmpty()
                       select new
                       {
                           he.HesId, he.Hesnom, he.Hesname, he.BId,b.bolmeName, m.MId,
                           m.MaddeName, t.TipId, t.TipName,he.ActivId,a.ActivName
                       });
            if (id != null)
            {
               // return _he.GetAll();
                return (from x in res
                       orderby x.Hesnom, x.MaddeName descending
                        select x).Where(k=>k.Hesnom==id).ToList();
            }
            else
            {
                //return _he.GetAll();
                return (from x in res
                        orderby x.Hesnom, x.MaddeName descending
                        select x).ToList();
            }
        }
        // POST: api/hazirla/_postmov
        [HttpPost]
        [Route("_posthesab")]
        public async Task<IActionResult> _posthesab([FromBody] Hesab ti)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            try
            {
                if (ti.HesId == "")
                {
                    ti.HesId = Guid.NewGuid().ToString();
                    ti.Hesname = ti.Hesname;
                    ti.Hesnom = ti.Hesnom;
                    if (ti.Hesnom == "")
                    {
                        ti.Hesnom = ti.MId;
                    }
                    
                    var tt = _ti.GetAll().FirstOrDefault(x => x.TipName == ti.TipId);
                    if (tt != null) { ti.TipId = tt.TipId; }
                    else { ti.TipId = null; }                  
                    var res = _act.GetAll().FirstOrDefault(x => x.ActivName == ti.ActivId);
                    if (res!=null) { ti.ActivId = res.ActivId; }
                    else { ti.ActivId = null; }
                    var mad = _mad.GetAll().FirstOrDefault(x => x.MaddeName == ti.MId);
                    if (mad!=null) { ti.MId =mad.MId; }
                    else { ti.MId = null; }
                    var bo = _bol.GetAll().FirstOrDefault(x => x.bolmeName == ti.BId);
                    if (bo!=null) { ti.BId = bo.bId; }
                    else { ti.MId = null; }                   
                    await _he.InsertAsync(ti);
                    return Ok();
                }
                else
                {
                    var _m = _he.GetAll().FirstOrDefault(x => x.HesId == ti.HesId);
                    _m.HesId = ti.HesId;
                    _m.TipId = ti.TipId;
                    _m.Hesname = ti.Hesname;
                    _m.Hesnom = ti.Hesnom;
                    _m.MId = ti.MId;
                    _m.BId = ti.BId;
                    await _he.EditAsync(_m);
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
        [Route("_deletehesab")]
        public async Task<IActionResult> _deletehesab(string id)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var ti = await _he.GetAll().SingleOrDefaultAsync(m => m.HesId == id);
            if (ti == null)
            {
                return NotFound();
            }

            await _he.DeleteAsync(ti);
            // await _context.SaveChangesAsync();

            return Ok(ti);
        }
        #endregion
        #region bolme
        // GET: api/hazirla
        [HttpGet]
        [Route("_getbolme")]
        public IEnumerable<Bolme> _getbolme(string id)
        {
            if (id != null)
            {
                return _bol.GetAll().Where(g => g.bId == id);
            }
            else
            {
                return _bol.GetAll().OrderBy(k => k.bId);
            }
        }
        // POST: api/hazirla/_postmov
        /*
   select *from Tiplers
   select *from Aktivs
   select *from Maddes
   select *from Bolmes
    select *from Hesabs
    select * from Mushteris
    select * from Shirkets
    select * from Vahids
    select * from Vergis
*/
        /*
          delete from Tiplers
          delete from Aktivs
          delete from Maddes
          delete from Bolmes        
          delete from Hesabs
          delete from Mushteris
          delete from Shirkets
          delete from Vahids
          delete from Vergis
        */

        [HttpPost]
        [Route("_postbolme")]
        public async Task<IActionResult> _postbolme([FromBody] Bolme ti)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            try
            {
               
                if (ti.bId == "")
                {
                    ti.bId = Guid.NewGuid().ToString();
                    ti.bolmeName = ti.bolmeName;
                    await _bol.InsertAsync(ti);
                    return Ok();
                }
                else
                {
                    var _m = _bol.GetAll().FirstOrDefault(x => x.bId == ti.bId);
                    _m.bId = ti.bId;
                    _m.bolmeName = ti.bolmeName;
                    await _bol.EditAsync(_m);
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
        [Route("_delbolme")]
        public async Task<IActionResult> _delbolme(string id)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var ti = await _bol.GetAll().SingleOrDefaultAsync(m => m.bId == id);
            if (ti == null)
            {
                return NotFound();
            }

            await _bol.DeleteAsync(ti);
            // await _context.SaveChangesAsync();

            return Ok(ti);
        }
        #endregion
        #region madde
        // GET: api/hazirla
        [HttpGet]
        [Route("_getmad")]
        public IEnumerable<Madde> _getmad(string id)
        {
            if (id != null)
            {
                return _mad.GetAll().Where(g => g.MId == id);
            }
            else
            {
                return _mad.GetAll().OrderByDescending(c => c.MId).OrderBy(k => k.MId);
            }
        }
        // POST: api/hazirla/_postmov
        [HttpPost]
        [Route("_postmad")]
        public async Task<IActionResult> _postmad([FromBody] Madde ti)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            try
            {
                if (ti.MId == "")
                {
                    ti.MId = Guid.NewGuid().ToString();
                    ti.MaddeName = ti.MaddeName;
                    await _mad.InsertAsync(ti);
                    return Ok();
                }
                else
                {
                    var _m = _mad.GetAll().FirstOrDefault(x => x.MId == ti.MId);
                    _m.MId = ti.MId;
                    _m.MaddeName = ti.MaddeName;
                    await _mad.EditAsync(_m);
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
        [Route("_deletemad")]
        public async Task<IActionResult> _deletemad(string id)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var ti = await _mad.GetAll().SingleOrDefaultAsync(m => m.MId == id);
            if (ti == null)
            {
                return NotFound();
            }

            await _mad.DeleteAsync(ti);
            // await _context.SaveChangesAsync();

            return Ok(ti);
        }
        #endregion
        #region shirket
        // GET: api/hazirla
        [HttpGet]
        [Route("_getshirket")]
        public IEnumerable<Shirket> _getshirket(string id)
        {
            if (id != null && id != "undefined")
            {
                return _shi.GetAll().Where(c => c.ShId == id);
            }
            else
            {
                // int d = _shi.GetAll().Count();
                return _shi.GetAll().OrderByDescending(c => c.ShId).OrderBy(k => k.ShId);
            }


        }
        // POST: api/hazirla/_postmov
        [HttpPost]
        [Route("_postshirket")]
        public async Task<IActionResult> _postshirket([FromBody] Shirket ti)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            try
            {
                if (ti.ShId == "")
                {
                    ti.ShId = Guid.NewGuid().ToString();
                    ti.Bankadi = ti.Bankadi;
                    ti.Bankvoen = ti.Bankvoen;
                    ti.SWIFT = ti.SWIFT;
                    ti.Bankkodu = ti.Bankkodu;
                    ti.Muxbirhesab = ti.Muxbirhesab;
                    ti.Aznhesab = ti.Aznhesab;
                    ti.Shiricrachi = ti.Shiricrachi;
                    ti.Shirvoen = ti.Shirvoen;
                    ti.Cavabdehshexs = ti.Cavabdehshexs;
                    ti.Email = _GetEmail();
                    ti.Unvan = ti.Unvan;
                    ti.userId = _GeteId();
                    ti.Shirpercent = ti.Shirpercent;
                    await _shi.InsertAsync(ti);
                    return Ok();
                }
                else
                {
                    var _m = _shi.GetAll().FirstOrDefault(x => x.ShId == ti.ShId);
                    _m.Bankadi = ti.Bankadi;
                    _m.Bankvoen = ti.Bankvoen;
                    _m.SWIFT = ti.SWIFT;
                    _m.Bankkodu = ti.Bankkodu;
                    _m.Muxbirhesab = ti.Muxbirhesab;
                    _m.Aznhesab = ti.Aznhesab;
                    _m.Shiricrachi = ti.Shiricrachi;
                    _m.Shirvoen = ti.Shirvoen;
                    _m.Cavabdehshexs = ti.Cavabdehshexs;
                    _m.Email = _GetEmail();
                    _m.Unvan = ti.Unvan;
                    _m.userId = _GeteId();
                    _m.Shirpercent = ti.Shirpercent;
                    await _shi.EditAsync(_m);
                    return Ok();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }
        }
        // DELETE: api/hazirla/5
        [HttpGet]
        [Route("_deleteshirket")]
        public async Task<IActionResult> _deleteshirket(string id)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var ti = await _shi.GetAll().SingleOrDefaultAsync(m => m.ShId == id);
            if (ti == null)
            {
                return NotFound();
            }

            await _shi.DeleteAsync(ti);
            // await _context.SaveChangesAsync();

            return Ok(ti);
        }
        #endregion
        #region mushteri
        // GET: api/hazirla
        [HttpGet]
        [Route("_getmushteri")]
        public IEnumerable<Mushteri> _getmushteri(string id)
        {
            if (id != null)
            {
                return _mush.GetAll().Where(c => c.MushId == id);
            }
            else
            {
                // int d= _va.GetAll().Count();
                return _mush.GetAll().OrderByDescending(c => c.MushId).OrderBy(k => k.MushId);
            }


        }
        // POST: api/hazirla/_postmov
        [HttpPost]
        [Route("_postmushteri")]
        public async Task<IActionResult> _postmushteri([FromBody] Mushteri ti)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            try
            {
                if (ti.MushId == "")
                {
                    ti.MushId = Guid.NewGuid().ToString();
                    ti.Firma = ti.Firma;
                    ti.Voen = ti.Voen;
                    ti.Muqavilenom = ti.Muqavilenom;
                    ti.Muqaviletar = DateTime.Now;
                    ti.Valyuta = ti.Valyuta;
                    ti.Odemesherti = ti.Odemesherti;
                    ti.Temsilchi = ti.Temsilchi;
                    await _mush.InsertAsync(ti);
                    return Ok();
                }
                else
                {
                    var _m = _mush.GetAll().FirstOrDefault(x => x.MushId == ti.MushId);
                    _m.Firma = ti.Firma;
                    _m.Voen = ti.Voen;
                    _m.Muqavilenom = ti.Muqavilenom;
                    _m.Muqaviletar = ti.Muqaviletar;
                    _m.Valyuta = ti.Valyuta;
                    _m.Odemesherti = ti.Odemesherti;
                    _m.Temsilchi = ti.Temsilchi;
                    await _mush.EditAsync(_m);
                    return Ok();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }
        }
        // DELETE: api/hazirla/5
        [HttpGet]
        [Route("_deletemushteri")]
        public async Task<IActionResult> _deletemushteri(string id)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var ti = await _mush.GetAll().SingleOrDefaultAsync(m => m.MushId == id);
            if (ti == null)
            {
                return NotFound();
            }

            await _mush.DeleteAsync(ti);
            // await _context.SaveChangesAsync();

            return Ok(ti);
        }
        #endregion
        #region Vahid
        // GET: api/hazirla
        [HttpGet]
        [Route("_getvahid")]
        public IEnumerable _getvahid()
        {

            //if (id != null)
            //{
            //    return _va.GetAll().Where(c => c.Vahidadi == id);
            //}
            //else
            //{
                // int d= _va.GetAll().Count();
                return _va.GetAll().OrderByDescending(c => c.VId).OrderBy(k => k.VId);
           // }

        }
        // POST: api/hazirla/_postmov
        [HttpPost]
        [Route("_postvahid")]
        public async Task<IActionResult> _postvahid([FromBody] Vahid va)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            try
            {
                if (va.VId == "")
                {
                   
                    if (_va.GetAll().FirstOrDefault(k => k.Vahidadi.Trim() == va.Vahidadi.Trim()) == null)
                    {
                        va.VId = Guid.NewGuid().ToString();
                        va.Vahidadi = va.Vahidadi.Trim();
                        await _va.InsertAsync(va);
                    }                    
                    return Ok();
                }
                else
                {
                    var _m = _va.GetAll().FirstOrDefault(x => x.VId == va.VId);
                    _m.VId = va.VId;
                    _m.Vahidadi = va.Vahidadi;
                    await _va.EditAsync(_m);
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
        [Route("_deletevahid")]
        public async Task<IActionResult> _deletevahid(string id)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var va = await _va.GetAll().SingleOrDefaultAsync(m => m.VId == id);
            if (va == null)
            {
                return NotFound();
            }

            await _va.DeleteAsync(va);
            // await _context.SaveChangesAsync();

            return Ok(va);
        }
        #endregion
        #region Vergi kodu
        // GET: api/hazirla
        [HttpGet]
        [Route("_getvergi")]
        public IEnumerable _getvergi()
        {
            //if(emel == "ALIŞ")
            //{
                var res = (from a in _ver.GetAll()
                           join b in _va.GetAll() on a.VId equals b.VId
                           select new
                           {
                               a.VergiId,
                               a.Vergikodu,
                               a.Vergikodununadi,
                               a.VId,
                               a.Edv_tar,
                               a.State,
                               b.Vahidadi
                           });

                int dd = res.Count();
                return res.OrderBy(o => o.VergiId).ToList();
            //}
            //else if (emel == "SATIŞ")
            //{
            //    var res = (from e in _emel.GetAll()
            //               join a in _ver.GetAll() on e.VergiId equals a.VergiId
            //               join b in _va.GetAll() on e.VId equals b.VId
            //             //  join e in _emel.GetAll()
            //               select new
            //               {
            //                   a.VergiId,
            //                   a.Vergikodu,
            //                   a.Vergikodununadi,
            //                   e.VId,
            //                   a.Edv_tar,
            //                   a.State,
            //                   b.Vahidadi
            //               });

            //    int dd = res.Count();
            //    return res.OrderBy(o => o.VergiId).ToList();
            //}
            //return null;
        }
        // POST: api/hazirla/_postmov
       
        [HttpPost]
        [Route("postvergi")]
        public async Task<IActionResult> postvergi([FromBody] Vergi ver)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            try
            {
                if (ver.VergiId == "")
                {

                    ver.VergiId = Guid.NewGuid().ToString();
                    ver.Vergikodu = ver.Vergikodu;
                    if (ver.Vergikodununadi != null)
                    {
                        ver.Vergikodununadi = ver.Vergikodununadi.ToUpper().TrimEnd();
                    }
                    if (ver.VId != null)
                    {
                        ver.VId = _va.GetAll().FirstOrDefault(c => c.Vahidadi == ver.VId).VId;
                    }
                    ver.Edv_tar = null;// Convert.ToDateTime("0001-01-01 01:01:01");
                    ver.State = ver.State;
                    await _ver.InsertAsync(ver);

                    return Ok();
                }
                else
                {
                    var _m = _ver.GetAll().FirstOrDefault(x => x.VergiId == ver.VergiId);
                    _m.VergiId = ver.VergiId;
                    _m.Vergikodu = ver.Vergikodu;
                    if (ver.Vergikodununadi != null)
                    {
                        _m.Vergikodununadi = ver.Vergikodununadi.ToUpper().TrimEnd();
                    }
                    //_m.Vergikodununadi = ver.Vergikodununadi;
                    _m.VId = _va.GetAll().FirstOrDefault(c => c.Vahidadi == ver.VId).VId;
                    _m.State = ver.State;
                    await _ver.EditAsync(_m);
                    return Ok();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }
        }
        // DELETE: api/hazirla/5
        [HttpGet]
        [Route("_deletevergi")]
        public async Task<IActionResult> _deletevergi(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var vergi = await _ver.GetAll().SingleOrDefaultAsync(m => m.VergiId == id);
            if (vergi == null)
            {
                return NotFound();
            }

            await _ver.DeleteAsync(vergi);
            // await _context.SaveChangesAsync();

            return Ok(vergi);
        }
        #endregion
        #region fealiyyet sahesi
        // GET: api/hazirla
        [HttpGet]
        [Route("_getfeal")]
        public IEnumerable<fealsahe> _getfeal(string id)
        {
            // int vv = _mov.GetAll().OrderByDescending(c => c.mnom).Count()if (id != null)
            if (id != null)
            {
                return _feal.GetAll().Where(g => g.fsId == id);
            }
            else
            {
                return _feal.GetAll().OrderByDescending(c => c.fsId).OrderBy(k => k.fsId);
            }


        }
        // POST: api/hazirla/_postmov
        [HttpPost]
        [Route("_postfeal")]
        public async Task<IActionResult> _postfeal([FromBody] fealsahe qr)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            try
            {
                if (qr.fsId == "")
                {
                    qr.fsId = Guid.NewGuid().ToString();
                    qr.fsADI = qr.fsADI;
                    qr.fs_CODE = qr.fs_CODE;
                    await _feal.InsertAsync(qr);
                    return Ok();
                }
                else
                {
                    var _m = _feal.GetAll().FirstOrDefault(x => x.fsId == qr.fsId);
                    _m.fsADI = qr.fsADI;
                    _m.fs_CODE = qr.fs_CODE;
                    await _feal.EditAsync(_m);
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
        [Route("_deletefeal")]
        public async Task<IActionResult> _deletefeal(fealsahe qrr)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var qr = await _feal.GetAll().SingleOrDefaultAsync(m => m.fsId == qrr.fsId);
            if (qr == null)
            {
                return NotFound();
            }

            await _feal.DeleteAsync(qr);
            // await _context.SaveChangesAsync();
            return Ok(qr);
        }
        #endregion
        #region Valyuta
        // GET: api/hazirla
        [HttpGet]
        [Route("_getvalyuta")]
        public IEnumerable _getvalyuta(string id)
        {

            if (id != null)
            {
                return _val.GetAll().Where(c => c.ValId == id);
            }
            else
            {
                // int d= _va.GetAll().Count();
                return _val.GetAll().OrderByDescending(c => c.ValId).OrderBy(k => k.ValId);
            }

        }
        // POST: api/hazirla/_postmov
        [HttpPost]
        [Route("_postvalyuta")]
        public async Task<IActionResult> _postvalyuta([FromBody] Valyuta va)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            try
            {
                if (va.ValId == "")
                {
                    var ff = _val.GetAll().FirstOrDefault(k => k.Valname.Trim().Contains(va.Valname.Trim()));
                    if (ff == null)
                    {
                        va.ValId = Guid.NewGuid().ToString();
                        va.Valname = va.Valname.Trim();
                        va.Valnominal = va.Valnominal;
                        va.Tarix =null;
                        await _val.InsertAsync(va);
                    }
                    return Ok();
                }
                else
                {
                    var _m = _val.GetAll().FirstOrDefault(x => x.ValId == va.ValId);
                    _m.ValId = va.ValId;
                    _m.Valname = va.Valname;
                    _m.Valnominal = va.Valnominal;
                    _m.Tarix =va.Tarix;
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
        [Route("_deletevalyuta")]
        public async Task<IActionResult> _deletevalyuta(string id)
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
        #region anbar
        // GET: api/hazirla
        [HttpGet]
        [Route("getanbar")]
        public IEnumerable<anbar> getanbar(string id)
        {
            if (id != null)
            {
                return _anbar.GetAll().Where(g => g.AnbId == id).ToList();
            }
            else
            {
                return _anbar.GetAll().OrderByDescending(c => c.AnbId).OrderBy(k => k.AnbId);
            }


        }
        // POST: api/hazirla/_postmov
        [HttpPost]
        [Route("_postanbar")]
        public async Task<IActionResult> _postanbar([FromBody] anbar ti)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            try
            {
                if (ti.AnbId == "")
                {
                    ti.AnbId = Guid.NewGuid().ToString();
                    ti.Anbarname = ti.Anbarname;                   
                    await _anbar.InsertAsync(ti);
                    return Ok();
                }
                else
                {
                    var _m = _anbar.GetAll().FirstOrDefault(x => x.AnbId == ti.AnbId);
                    _m.AnbId = ti.AnbId;
                    _m.Anbarname = ti.Anbarname;
                    await _anbar.EditAsync(_m);
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
        [Route("_delanbar")]
        public async Task<IActionResult> _delanbar(string id)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var ti = await _anbar.GetAll().FirstOrDefaultAsync(m => m.AnbId == id);
            if (ti == null)
            {
                return NotFound();
            }
            await _anbar.DeleteAsync(ti);
            // await _context.SaveChangesAsync();

            return Ok(ti);
        }
        #endregion
        // GET: api/<AyarlarController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AyarlarController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AyarlarController>
        [HttpPost]
        [Route("posthazirla")]
        public async Task<IActionResult> posthazirla([FromBody] string value)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            else
            {
                if (value.Length > 0)
                {
                    string fullPath = "", jsonData = "";
                    var rootPath = _host.ContentRootPath; //get the root path
                    string path = "Uploade//ayarlar";
                    switch (value)
                    {
                        case "aktiv":
                            fullPath = Path.Combine(rootPath, path+"//aktiv.json");
                            jsonData = System.IO.File.ReadAllText(fullPath);
                            if (string.IsNullOrWhiteSpace(jsonData)) return null;
                            var acti = JsonConvert.DeserializeObject<List<Activler>>(jsonData);
                            #region aktiv
                            if (_act.GetAll().Count() == 0)
                            {
                                foreach (var k in acti)
                                {
                                    var p = new Activler() { ActivId = "", ActivName = k.ActivName.ToString(), Description = "" };
                                    await _postaktivler(p);                                    
                                }
                                Console.WriteLine("Yazilan aktiv sayi=" + _act.GetAll().Count());
                            }
                            #endregion
                            break;
                        case "tip":
                            fullPath = Path.Combine(rootPath, path + "//tip.json");
                            jsonData = System.IO.File.ReadAllText(fullPath);
                            if (string.IsNullOrWhiteSpace(jsonData)) return null;
                            var tip = JsonConvert.DeserializeObject<List<Tipler>>(jsonData);
                            #region tip
                            if (_ti.GetAll().Count() == 0)
                            {                               
                                foreach (var k in tip)
                                {
                                    var p = new Tipler() { TipId = "", TipName = k.TipName.ToString() };
                                    await _postip(p);
                                }
                                Console.WriteLine("Yazilan tip sayi=" + _ti.GetAll().Count());
                            }
                            #endregion
                            break;
                        case "vergi":
                            #region
                            fullPath = Path.Combine(rootPath, path + "//eqm_mal_kodlari-v1.json"); //combine the root path with that of our json file inside mydata directory
                            jsonData = System.IO.File.ReadAllText(fullPath); //read all the content inside the file
                            if (string.IsNullOrWhiteSpace(jsonData)) return null; //if no data is present then return null or error if you wish
                            if (_ver.GetAll().Count() == 0)
                            {
                                var verg = JsonConvert.DeserializeObject<List<verg>>(jsonData); //deserialize object as a list of users in accordance with your json file

                                IEnumerable<string> a = verg.Select(x => x.VAHID);
                                var aa=a.Distinct().ToList();
                                foreach (var k in aa)
                                {
                                    if (k != null)
                                    {
                                        var p = new Vahid() { VId = "", Vahidadi = k };
                                        await _postvahid(p);
                                    }
                                    Console.WriteLine("Yazilan vahid sayi=" + aa.Count());
                                }

                                foreach (var item in verg)
                                {
                                    var ve = new Vergi();
                                    ve.VergiId = "";
                                    ve.Edv_tar = null;
                                    ve.VId = item.VAHID;
                                    ve.Vergikodu = item.CODE;
                                    if (item.ADI != null) { ve.Vergikodununadi = item.ADI; }
                                    if (item.STATE != null) { ve.State = int.Parse(item.STATE); }
                                    await postvergi(ve);
                                }
                                Console.WriteLine("Yazilan vergi sayi=" + _ver.GetAll().Count());
                            }
                            #endregion
                            break;
                        case "hesab":
                            fullPath = Path.Combine(rootPath, path + "//hesablar.json");
                            jsonData = System.IO.File.ReadAllText(fullPath);
                            if (string.IsNullOrWhiteSpace(jsonData)) return null;
                            var hes = JsonConvert.DeserializeObject<List<hesb>>(jsonData);
                            #region bolme
                            if (_bol.GetAll().Count() == 0)
                            {
                                IEnumerable<int> b = hes.Select(x => x.bId);
                                var bb = b.Distinct().ToList();
                                foreach (var k in bb)
                                {
                                    if (k != 0)
                                    {
                                        var p = new Bolme() { bId = "", bolmeName = k.ToString() };
                                        await _postbolme(p);
                                    }
                                }
                                Console.WriteLine("Yazilan bolme sayi=" + bb.Count());
                            }
                            #endregion
                            #region madd
                            if (_mad.GetAll().Count() == 0)
                            {
                                IEnumerable<string> m = hes.Select(x => x.mId);
                                var mm = m.Distinct().ToList();
                                foreach (var k in mm)
                                {
                                    if (k != "")
                                    {
                                        var p = new Madde() { MId = "", MaddeName = k };
                                        await _postmad(p);
                                    }
                                }
                                Console.WriteLine("Yazilan madde sayi=" + mm.Count());
                            }
                            #endregion                          
                            #region hesab
                            if (_he.GetAll().Count() == 0)
                            {
                                foreach (var item in hes)
                                {
                                    var ve = new Hesab()
                                    {
                                        HesId = "",
                                        BId = item.bId.ToString(),
                                        MId = item.mId,
                                        Hesnom = item.hesnom,
                                        Hesname = item.hesname,
                                        TipId = item.tipId,
                                        ActivId = item.activId
                                        //if (item.ADI != null) { ve.Vergikodununadi = item.ADI; }
                                        //if (item.STATE != null) { ve.State = int.Parse(item.STATE); }
                                    };
                                    await _posthesab(ve);
                                }
                                Console.WriteLine("Yazilan hesab sayi=" + _he.GetAll().Count());
                            }
                            #endregion                           
                            break;
                        case "Mushteri":
                            #region
                            fullPath = Path.Combine(rootPath, path + "//mushteri.json");
                            jsonData = System.IO.File.ReadAllText(fullPath);
                            if (string.IsNullOrWhiteSpace(jsonData)) return null;
                            var mush = JsonConvert.DeserializeObject<List<Mushteri>>(jsonData);
                            if (_mush.GetAll().Count() == 0)
                            {
                                foreach (var mm in mush)
                                {
                                    var p = new Mushteri()
                                    {
                                        MushId = "",
                                        Firma = mm.Firma,
                                        Voen = mm.Voen,
                                        Muqavilenom = mm.Muqavilenom,
                                        Valyuta = mm.Valyuta,
                                        Odemesherti = mm.Odemesherti,
                                        Temsilchi = mm.Temsilchi
                                    };

                                    await _postmushteri(p);
                                }
                                Console.WriteLine("Yazilan mushteri sayi=" + _mush.GetAll().Count());
                            }
                            #endregion
                            break;
                        case "shirket":
                            #region
                            fullPath = Path.Combine(rootPath, path + "//shirket.json");
                            jsonData = System.IO.File.ReadAllText(fullPath);
                            if (string.IsNullOrWhiteSpace(jsonData)) return null;
                            var shir = JsonConvert.DeserializeObject<List<Shirket>>(jsonData);
                            if (_shi.GetAll().Count() == 0)
                            {
                                foreach (var s in shir)
                                {
                                    var p = new Shirket()
                                    {
                                        ShId = "",
                                        Bankadi = s.Bankadi,
                                        Bankvoen = s.Bankvoen,
                                        SWIFT = s.SWIFT,
                                        Muxbirhesab = s.Muxbirhesab,
                                        Bankkodu = s.Bankkodu,
                                        Aznhesab = s.Aznhesab,
                                        Shiricrachi = s.Shiricrachi,
                                        Shirvoen = s.Shirvoen,
                                        Cavabdehshexs = s.Cavabdehshexs,
                                        Email = "",
                                        Unvan = s.Unvan,
                                        userId = "",
                                        Shirpercent = 0
                                    };
                                    await _postshirket(p);
                                }
                                Console.WriteLine("Yazilan shirket sayi=" + _shi.GetAll().Count());
                            }
                            #endregion
                            break;
                        case "fealiyet":
                            #region
                            fullPath = Path.Combine(rootPath, path + "//fk-v1.json");
                            jsonData = System.IO.File.ReadAllText(fullPath);
                            if (string.IsNullOrWhiteSpace(jsonData)) return null;
                            var feal = JsonConvert.DeserializeObject<List<fealsahe>>(jsonData);
                            if (_feal.GetAll().Count() == 0)
                            {
                                int f = feal.Count;
                                foreach (var k in feal)
                                {
                                    try
                                    {
                                        var p = new fealsahe() { fsId = "", fs_CODE = k.fs_CODE, fsADI = k.fsADI };
                                        await _postfeal(p);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex);
                                    }
                                }
                                Console.WriteLine("Yazilan fealiyyet sayi=" + _feal.GetAll().Count());
                            }
                            #endregion
                            break;
                    }

                }
                else { return BadRequest("Failed"); }
                return Ok();
            }
        }

        // PUT api/<AyarlarController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AyarlarController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
