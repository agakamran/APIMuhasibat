using APIMuhasibat.Models;
using APIMuhasibat.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIMuhasibat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class OperationController : BaseController
    {
        #region
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
        private readonly IRepository<operation> _oper = null;
        private readonly IRepository<Productmaster> _promas = null;
        private readonly IRepository<Productdetal> _prodet = null;
        private readonly IRepository<anbar> _anbar = null;
        private static IWebHostEnvironment _host;
        #endregion
        public OperationController(IWebHostEnvironment host, IRepository<Tipler> ti, IRepository<Qrup> qr,
            IRepository<Activler> act, IRepository<Hesab> he, IRepository<Bolme> bol, IRepository<Madde> mad,
            IRepository<Shirket> shi, IRepository<Mushteri> mush, IRepository<Vahid> va, IRepository<Valyuta> val,
            IRepository<Vergi> ver, IRepository<fealsahe> feal, IRepository<Productmaster> promas,
            IRepository<anbar> anbar, IRepository<Productdetal> prodet, IRepository<operation> oper)
        {
            #region
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
            _oper = oper;
            _promas = promas;
            _prodet= prodet;
            _anbar = anbar;
            #endregion
        }
        [HttpPost]
        [Route("postfile")]
        public async Task<IActionResult> postfile()
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            else
            {
                #region
                string path = "";
                var AnbId=Request.Form["AnbId"];
               // var aId = Request.Form["aId"];
                //var dhesId = Request.Form["dhesId"];
                //var khesId = Request.Form["khesId"];
                var QId = Request.Form["QId"];
                var pars = Request.Form["pars"];
                var ValId = Request.Form["ValId"];
                var Kurs = Request.Form["Kurs"];
                var Serial = Request.Form["Serial"];
                var emeltarixi = Request.Form["emeltarixi"];
                var file = Request.Form.Files["file"];
                DateTime tt = Convert.ToDateTime(emeltarixi);
                #endregion
                if (file != null && file.Length > 0)
                {
                    string _path = _host.ContentRootPath + "\\Uploade\\eqaime\\";
                    if (!(Directory.Exists(_path))) { Directory.CreateDirectory(_path); }
                    try
                    {
                        //var path = Path.Combine(_path, exten);
                        path = Path.Combine(_path, file.FileName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        XmlDocument doc = new XmlDocument();
                        doc.Load(_path + file.FileName);
                        XmlNode rootNode = doc.GetElementsByTagName("root").Item(0);
                        Qaime qaime = new Qaime
                        {
                            // kod = rootNode.Attributes["kod"].Value,
                            qaimeKime = rootNode["qaimeKime"].InnerText,       // (Alan tərəfin VÖENi buraya yazılır.Məcburidir və 10 rəqəmlidir )
                            qaimeKimden = rootNode["qaimeKimden"].InnerText,   // (Satan tərəfin VÖENi buraya yazılır. Məcburidir və 10 rəqəmlidir )
                            vo = rootNode["vo"].InnerText,
                            ds = rootNode["ds"].InnerText,
                            dn = rootNode["dn"].InnerText,
                            des = rootNode["des"].InnerText,                  //(Qaimənin əsas qeydi buraya yazılır. Ən çox 150 simvol ola bilər. Məcburidir)
                            des2 = rootNode["des2"].InnerText,                 //(Qaimənin əlavə qeydi buraya yazılır. Ən çox 150 simvol ola bilər. Məcburidir. Boş ola bilər) 
                            ma = rootNode["ma"].InnerText,                    //(Qaimə təqdim edən filial/obyektin adı buraya yazılır.Məcburi deyil) 
                            mk = rootNode["mk"].InnerText,                   //(Qaimə təqdim edən filial/obyektin kodu buraya yazılır.Məcburi deyil) 
                           // mediator = rootNode["mediator"].InnerText        //(Vasitəçi  Agent və ya Komisyonçu)
                        };
                        
                        #region qaimeKime
                       // Shirket ti = new Shirket();
                        var shir = _shi.GetAll().FirstOrDefault(x => x.Shirvoen == qaime.qaimeKime);
                        if (shir == null)// && shir.Shirvoen != qaime.qaimeKimden
                        {
                            shir = new Shirket()
                            {
                                ShId = Guid.NewGuid().ToString(),
                                Bankadi = "",
                                Bankvoen = "",
                                SWIFT = "",
                                Bankkodu = "",
                                Muxbirhesab = "",
                                Aznhesab = "",
                                Shiricrachi = "",
                                Shirvoen = qaime.qaimeKime,
                                Cavabdehshexs = "",
                                Email = _GetEmail(),
                                Unvan = "",
                                userId = _GeteId(),
                                Shirpercent = decimal.Parse(pars.ToString()),
                            };
                            await _shi.InsertAsync(shir);
                        }
                        #endregion
                        #region qaimeKimden
                       // Mushteri mi = new Mushteri();
                        var mush = _mush.GetAll().FirstOrDefault(x => x.Voen == qaime.qaimeKimden);
                        if (mush == null)//.Voen!=qaime.qaimeKimden
                        {
                            mush = new Mushteri()
                            {
                                MushId = Guid.NewGuid().ToString(),
                                Firma = qaime.des2,
                                Voen = qaime.qaimeKimden,
                                Muqavilenom = "",
                                Muqaviletar = DateTime.Now,
                                Valyuta = "1",
                                Odemesherti = "",
                                Temsilchi = ""
                            };
                            await _mush.InsertAsync(mush);
                        }
                        #endregion
                        foreach (XmlNode row in rootNode["product"]["qaimeTable"].ChildNodes)
                        {                            
                            qaime.qaimeTables.Add(new QaimeTable
                            {
                                c1 = row["c1"].InnerText, //(Mal kodu burada saxlanılır.10 rəqəmlidir. Məcburidir)
                                c2 = row["c2"].InnerText, //(Mal adı burada saxlanılır.Max 150 simvoldur. Məcburidir)
                                c3 = row["c3"].InnerText, //(Ölçü vahidi burada saxlanılır.Max 150 simvoldur. Məcburidir)
                                c4 = row["c4"].InnerText, //(Malın miqdarı burada saxlanılır. Kəsir hissə ən çox 4 rəqəmlidir. Məcburidir)
                                c5 = row["c5"].InnerText, //(Malın buraxılış qiyməti burada saxlanılır. Kəsir hissə ən çox 9 rəqəmlidir. Məcburidir) 
                                c6 = row["c6"].InnerText, //(Cəmi qiyməti burada saxlanılır.Kəsir hissə ən çox 2 rəqəmlidir. Düstur: c4*c5 = c6 . Məcburidir)
                                c7 = row["c7"].InnerText, //(Aksiz dərəcəsi burada saxlanılır. Kəsir hissəsi ən çox 2 rəqəmlidir. Məcburidir )
                                c8 = row["c8"].InnerText, //(Aksiz məbləği burada saxlanılır. Kəsir hissəsi ən çox 2 rəqəmlidir. Məcburidir )
                                c9 = row["c9"].InnerText, //(Cəmi məbləğ burada saxlanılır. Kəsir hissəsi ən çox 2 rəqəmlidir.Düstur : c6+c8 = c9. Şərt: c9= c10+c11+c12. Məcburidir )
                                c10 = row["c10"].InnerText,//(ƏDV - yə cəlb edilən məbləğ burada saxlanılır.Kəsir hissəsi ən çox 2 rəqəmlidir.Məcburidir )
                                c11 = row["c11"].InnerText,//(ƏDV-yə cəlb edilməyən məbləğ burada saxlanılır. Kəsir hissəsi ən çox 2 rəqəmlidir.  Məcburidir )
                                c12 = row["c12"].InnerText,//(ƏDV-dən azad olunan məbləğ burada saxlanılır. Kəsir hissəsi ən çox 2 rəqəmlidir.  Məcburidir )
                                c13 = row["c13"].InnerText,//(ƏDV-yə 0 dərəcə ilə cəlb edilən məbləğ burada saxlanılır. Kəsir hissəsi ən çox 2 rəqəmlidir.  Məcburidir )
                                c14 = row["c14"].InnerText,//(Ödənilməli ƏDV burada saxlanılır.Kəsir hissəsi ən çox 2 rəqəmlidir.  Məcburidir )
                                c15 = row["c15"].InnerText,//(Yol vergisi məbləği burada saxlanılır. Boş ola bilməz.) 
                               // c16 = row["c16"].InnerText,//(Yola salınmış mallara,görülmüş işlərə və göstərilmiş xidmətlər üçün məbləğ burada saxlanılır.Kəsir hissəsi ən çox 2 rəqəmlidir.Məcburidir )
                               // c17 = row["c17"].InnerText,//(Malların Barkod)
                            });                           
                        }
                        foreach (XmlNode row in rootNode["product"]["qaimeYekunTable"].ChildNodes)
                        {
                            qaime.qaimeYekunTables.Add(
                               new QaimeTable
                               {
                                   c1 = row["c1"].InnerText,// (Malların cəmi qiyməti burada saxlanılır.Kəsir hissəsi ən çox 2 rəqəmlidir. Düstur : qaimeYekunTable.c1= sum(qaimeTable.c6) . Məcburidir )  
                                   c2 = row["c2"].InnerText,//(Malların aksiz cəmi məbləği burada saxlanılır.Kəsir hissəsi ən çox 2 rəqəmlidir. Düstur : qaimeYekunTable.c2= sum(qaimeTable.c8) . Məcburidir )
                                   c3 = row["c3"].InnerText,//(Malların cəmi məbləği burada saxlanılır.Kəsir hissəsi ən çox 2 rəqəmlidir. Düstur : qaimeYekunTable.c3= sum(qaimeTable.c9) . Məcburidir )
                                   c4 = row["c4"].InnerText, //(Malların ƏDV - yə cəlb edilən cəmi məbləği burada saxlanılır.Kəsir hissəsi ən çox 2 rəqəmlidir.Düstur : qaimeYekunTable.c4 = sum(qaimeTable.c10).Məcburidir )
                                   c5 = row["c5"].InnerText, //(Malların  ƏDV-yə cəlb edilməyən cəmi məbləği burada saxlanılır.Kəsir hissəsi ən çox 2 rəqəmlidir. Düstur : qaimeYekunTable.c5= sum(qaimeTable.c11) . Məcburidir )
                                   c6 = row["c6"].InnerText, // (Malların  ƏDV-dən azad olunan cəmi məbləği burada saxlanılır.Kəsir hissəsi ən çox 2 rəqəmlidir. Düstur : qaimeYekunTable.c6= sum(qaimeTable.c12) . Məcburidir )
                                   c7 = row["c7"].InnerText, //(Malların  ƏDV-yə 0 dərəcə ilə cəlb edilən cəmi məbləği burada saxlanılır.Kəsir hissəsi ən çox 2 rəqəmlidir. Düstur : qaimeYekunTable.c6= sum(qaimeTable.c12) . Məcburidir )
                                   c8 = row["c8"].InnerText, //(Malların cəmi ödənilməli ƏDV məbləği burada saxlanılır.Kəsir hissəsi ən çox 2 rəqəmlidir. Düstur : qaimeYekunTable.c7= sum(qaimeTable.c13) . Məcburidir )
                                                             // c9 = row["c9"].InnerText, //(Yola salınmış mallara,görülmüş işlərə və göstərilmiş xidmətlər üçün cəmi məbləğ burada saxlanılır.Kəsir hissəsi ən çox 2 rəqəmlidir. Düstur : qaimeYekunTable.c8= sum(qaimeTable.c14) . Məcburidir )
                                                             // c10 = row["c10"].InnerText,//(Yola salınmış mallara,görülmüş işlərə və göstərilmiş xidmətlər üçün yol vergisi )
                               });
                        }
                        #region  masteri hazirla                        
                        decimal _Sum = 0;
                        //yoxlayaq bu qaime evveller daxil edilib
                        shir = _shi.GetAll().FirstOrDefault(x => x.Shirvoen == qaime.qaimeKime);
                        mush = _mush.GetAll().FirstOrDefault(x => x.Voen == qaime.qaimeKimden);
                        var _vvo= _promas.GetAll().FirstOrDefault(k=>k.Vo==qaime.vo.ToString());
                        var vval = _val.GetAll().FirstOrDefault(k => k.Valname == "AZN");
                        if (vval == null) {
                            vval = new Valyuta() { ValId = Guid.NewGuid().ToString(), Valname = "AZN", Valnominal = 1, Tarix = DateTime.Now };
                            await _val.InsertAsync(vval);
                        }
                        var qru = _qr.GetAll().FirstOrDefault(k => k.QId == QId.ToString());
                        if (qru == null) {
                            qru = new Qrup() { QId = Guid.NewGuid().ToString(), Qrupname = QId.ToString() };
                            await _qr.InsertAsync(qru);
                        }
                        var anb = _anbar.GetAll().FirstOrDefault(k => k.AnbId == AnbId.ToString());
                        if (anb == null)
                        {
                            anb = new anbar() { AnbId = Guid.NewGuid().ToString(), Anbarname = AnbId.ToString() };
                            await _anbar.InsertAsync(anb);
                        }
                        if (_vvo == null)
                        {
                            var pmas = new Productmaster()
                            {
                                PmasId = Guid.NewGuid().ToString(),
                                UserId = _GeteId(),
                                Kimden_voen = qaime.qaimeKimden,
                                Kimden_sum = _Sum,
                                Emeltarixi = Convert.ToDateTime(emeltarixi.ToString()),
                                Serial = Serial.ToString(),
                                Vo = qaime.vo,
                                QId = qru.QId,
                                //ActivId = aId.ToString(),
                                //DhesId = dhesId.ToString(),
                                //KhesId = khesId.ToString(),
                                MushId = mush.MushId,
                                ValId = vval.ValId,
                                Kurs = decimal.Parse(Kurs.ToString()),
                               
                                ShId= shir.ShId,
                                AnbId=AnbId.ToString(),
                                Pay = false
                            };

                            await _promas.InsertAsync(pmas);
                            foreach (var xx in qaime.qaimeTables)
                            {
                                var vver = _ver.GetAll().FirstOrDefault(k => k.Vergikodu == xx.c1);
                                var prodet = _prodet.GetAll().FirstOrDefault(k => k.VergiId == vver.VergiId);
                                if (prodet == null)
                                {
                                    var eedv = "0";
                                    if (decimal.Parse(xx.c10) > 0) { eedv = "0,18%"; }
                                    prodet = new Productdetal()
                                    {
                                        PdetId = Guid.NewGuid().ToString(),
                                        PmasId = pmas.PmasId,
                                        Maladi = xx.c2,
                                        Barkod = xx.c17,
                                        VergiId = vver.VergiId,
                                        VId = vver.VId,
                                        Edv = eedv,
                                        Qeyd = ""
                                    };
                                    await _prodet.InsertAsync(prodet);
                                }
                                _Sum += decimal.Parse(xx.c4.ToString()) * decimal.Parse(xx.c5.ToString());
                                #region  ------operation----------
                                shir = _shi.GetAll().FirstOrDefault(x => x.Shirvoen == qaime.qaimeKime);
                                var oper = new operation()
                                {
                                    OpId = Guid.NewGuid().ToString(),
                                    PdetId = prodet.PdetId,
                                    Submiqdar = 1,
                                    Miqdar = decimal.Parse(xx.c4),
                                    Alishqiy = decimal.Parse(xx.c5),
                                    Satishqiy = decimal.Parse(xx.c5) + decimal.Parse(xx.c5) * (shir.Shirpercent / 100),
                                    Aksizderecesi = int.Parse(xx.c7),
                                    Yolvergisi = decimal.Parse(xx.c15),
                                    Qeyd = ""
                                };
                                await _oper.InsertAsync(oper);
                                #endregion
                            }
                            //-------masteri yenileyek---------
                            pmas.Kimden_sum = _Sum;
                            await _promas.EditAsync(pmas);
                            //-------masteri yenileyek---------
                        }
                        else
                        {
                            var fileSavePath = _path.Replace("\\", "/") + "/" + file.FileName;
                            if (System.IO.File.Exists(fileSavePath))
                            {
                                System.IO.File.Delete(fileSavePath);
                            }
                            return BadRequest("Siz bu qaimeni evveller daxil etmisiniz");
                        }
                        #endregion                       
                        var fileSavePath1 = _path.Replace("\\", "/") + "/" + file.FileName;
                        if (System.IO.File.Exists(fileSavePath1))
                        {
                            System.IO.File.Delete(fileSavePath1);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                return Ok();
            }
        }
        // GET: api/<OperationController>
        [HttpGet]
        [Route("getqayimeler")]
        public IEnumerable getqayimeler( string tar)
        {
            
             var res = (from pm in _promas.GetAll().Where(k=>k.UserId== _GeteId()) 
                        join q in _qr.GetAll() on pm.QId equals q.QId
                        join m in _mush.GetAll() on pm.MushId equals m.MushId                        
                        select new
                        {

                            q.Qrupname,
                            pm.PmasId,
                            pm.Serial,                           
                            pm.Kimden_voen,
                            m.Firma,
                            pm.Kimden_sum,
                            edv= (pm.Kimden_sum* 18/100),
                            yekunmeb = pm.Kimden_sum + (pm.Kimden_sum * 18 / 100),
                            pm.Emeltarixi, 
                            Pay = pm.Pay ? "ödenib": "ödenmeli",
                            pm.UserId,
                            pm.Vo
                           
                        }).ToList();
            if (tar!=null && tar != "NaN" && tar !="undefined") {
               res= res.Where(k => k.Emeltarixi >=Convert.ToDateTime(tar) && k.Emeltarixi <= DateTime.Now).ToList();
            }
             int d= res.Count();
             return res.OrderByDescending(c => c.Emeltarixi);            
        }

        [HttpGet]
        [Route("getqayimedetal")]
        public IEnumerable getqayimedetal(string PmasId)
        {
            /*
              select pm.PmasId, pm.UserId,pm.Kimden_voen,pm.Serial,pd.Maladi,op.Miqdar,op.Alishqiy, op.Alishqiy * 0.18 ,pd.Edv,Ve.Vergikodununadi,Va.Vahidadi,pm.Emeltarixi,
              an.Anbarname ,qr.Qrupname      ,* 
              from Productmasters pm
              join Productdetals pd on pm.PmasId=pd.PmasId --where pm.PmasId='1c0191f1-6453-4bdf-bf0d-f8b514f47429'
              join anbars an on pm.AnbId=an.AnbId 
              join Qrups qr on pm.QrupId=qr.QId 
              join operations op on pd.PdetId=op.PdetId
              join Vergis Ve on pd.VergiId=Ve.VergiId
              left join Vahids Va on pd.VId=Va.VId

              where pm.PmasId='1c0191f1-6453-4bdf-bf0d-f8b514f47429'
             */
            var res = (from pm in _promas.GetAll().Where(k => k.PmasId == PmasId)
                       join pd in _prodet.GetAll() on pm.PmasId equals pd.PmasId
                       join an in _anbar.GetAll() on pm.AnbId equals an.AnbId
                       join q in _qr.GetAll()     on pm.QId equals q.QId                       
                       join op in _oper.GetAll() on pd.PdetId equals op.PdetId
                       join Ve in _ver.GetAll() on pd.VergiId equals Ve.VergiId
                       join sh in _shi.GetAll() on pm.ShId equals sh.ShId                       
                       join m in _mush.GetAll() on pm.MushId equals m.MushId
                       //  join Va in _va.GetAll() on pd.VId equals Va.VId

                       select new
                       {
                           q.Qrupname,
                           pm.Kimden_voen,
                           m.Firma,
                           sh.Shirvoen,
                           sh.Shiricrachi,
                           m.Voen,
                           pm.UserId,                          
                           pm.Serial,
                           pd.Maladi,
                           op.Miqdar,
                           op.Alishqiy,
                           cemi= op.Miqdar* op.Alishqiy,
                           edvcəlbedilən= op.Miqdar * op.Alishqiy,
                           Edv = (op.Miqdar * op.Alishqiy * 18/100),
                           yekunmeb= op.Miqdar * op.Alishqiy+ (op.Miqdar * op.Alishqiy * 18 / 100),
                           //pd.Edv,
                           Ve.Vergikodununadi,
                          // Va.Vahidadi,
                           pm.Emeltarixi

                       }).ToList();

            int d = res.Count();
            return res;
        }
        [HttpGet]
        [Route("proddetal")]
        public IEnumerable proddetal()
        {
            /*
              select pm.PmasId, pm.UserId,pm.Kimden_voen,pm.Serial,pd.Maladi,op.Miqdar,op.Alishqiy, op.Alishqiy * 0.18 ,pd.Edv,Ve.Vergikodununadi,Va.Vahidadi,pm.Emeltarixi,
               an.Anbarname ,qr.Qrupname from Productmasters pm
               join Productdetals pd on pm.PmasId=pd.PmasId 
               join anbars an on pm.AnbId=an.AnbId 
               join Qrups qr on pm.QId=qr.QId 
               join operations op on pd.PdetId=op.PdetId
               join Vergis Ve on pd.VergiId=Ve.VergiId
               left join Vahids Va on pd.VId=Va.VId
             */
            var res = (from pm in _promas.GetAll().Where(k => k.UserId == _GeteId())
                       join pd in _prodet.GetAll() on pm.PmasId equals pd.PmasId
                       join an in _anbar.GetAll() on pm.AnbId equals an.AnbId
                       join q in _qr.GetAll() on pm.QId equals q.QId
                       join op in _oper.GetAll() on pd.PdetId equals op.PdetId
                       join Ve in _ver.GetAll() on pd.VergiId equals Ve.VergiId
                       join sh in _shi.GetAll() on pm.ShId equals sh.ShId
                       join m in _mush.GetAll() on pm.MushId equals m.MushId
                       //  join Va in _va.GetAll() on pd.VId equals Va.VId

                       select new
                       {
                           q.Qrupname,
                           pm.Kimden_voen,
                           m.Firma,
                           sh.Shirvoen,
                           sh.Shiricrachi,
                           m.Voen,
                           pm.UserId,
                           pm.Serial,
                           pd.Maladi,
                           op.Miqdar,
                           op.Alishqiy,
                           cemi = op.Miqdar * op.Alishqiy,
                           edvcəlbedilən = op.Miqdar * op.Alishqiy,
                           Edv = (op.Miqdar * op.Alishqiy * 18 / 100),
                           yekunmeb = op.Miqdar * op.Alishqiy + (op.Miqdar * op.Alishqiy * 18 / 100),
                           //pd.Edv,
                           Ve.Vergikodununadi,
                           // Va.Vahidadi,
                           pm.Emeltarixi

                       }).ToList();

            int d = res.Count();
            return res;
        }
        // GET api/<OperationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            /*
            select pm.UserId,pm.Kimden_voen,pm.Kimden_sum,pm.Emeltarixi,pm.Serial,pm.Pay,pd.Maladi,pd.Edv,Ve.Vergikodununadi,Va.Vahidadi,* from Productmasters pm
            join Productdetals pd on pm.PmasId=pd.PmasId
            join operations op on pd.PdetId=op.PdetId
            join Vergis Ve on pd.VergiId=Ve.VergiId
            left join Vahids Va on pd.VId=Va.VId


              select q.Qrupname,pm.Serial,pm.UserId,pm.Kimden_voen,pm.Kimden_sum,pm.Emeltarixi,m.Firma,pm.Vo from Productmasters pm
            join Qrups q on pm.QrupId = q.QId
            join Mushteris m on pm.MushId = m.MushId
            */
            return "value";
        }

        // POST api/<OperationController>
        [HttpPost]
        [Route("postku")]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OperationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OperationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
