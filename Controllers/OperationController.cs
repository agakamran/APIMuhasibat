using APIMuhasibat.Models;
using APIMuhasibat.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
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
        private static IWebHostEnvironment _host;
        #endregion
        public OperationController(IWebHostEnvironment host, IRepository<Tipler> ti, IRepository<Qrup> qr,
            IRepository<Activler> act, IRepository<Hesab> he, IRepository<Bolme> bol, IRepository<Madde> mad,
            IRepository<Shirket> shi, IRepository<Mushteri> mush, IRepository<Vahid> va, IRepository<Valyuta> val,
            IRepository<Vergi> ver, IRepository<fealsahe> feal, IRepository<Productmaster> promas, IRepository<Productdetal> prodet, IRepository<operation> oper)
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

                var aId = Request.Form["aId"];
                var dhesId = Request.Form["dhesId"];
                var khesId = Request.Form["khesId"];
                var QId = Request.Form["QId"];
                var pars = Request.Form["pars"];
                var ValId = Request.Form["ValId"];
                var Kurs = Request.Form["Kurs"];
                var file = Request.Form.Files["file"];
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
                            ds = rootNode["ds"].InnerText,
                            dn = rootNode["vo"].InnerText,
                            des = rootNode["des"].InnerText,                  //(Qaimənin əsas qeydi buraya yazılır. Ən çox 150 simvol ola bilər. Məcburidir)
                            des2 = rootNode["des2"].InnerText,                 //(Qaimənin əlavə qeydi buraya yazılır. Ən çox 150 simvol ola bilər. Məcburidir. Boş ola bilər) 
                            ma = rootNode["ma"].InnerText,                    //(Qaimə təqdim edən filial/obyektin adı buraya yazılır.Məcburi deyil) 
                            mk = rootNode["mk"].InnerText,                   //(Qaimə təqdim edən filial/obyektin kodu buraya yazılır.Məcburi deyil) 
                            mediator = rootNode["mediator"].InnerText        //(Vasitəçi  Agent və ya Komisyonçu)
                        };
                        // if (!_cryp.Cry(qaime.des)) {            }
                        #region qaimeKime
                        Shirket ti = new Shirket();
                        var shir = _shi.GetAll().FirstOrDefault(x => x.Shirvoen == qaime.qaimeKimden);
                        if (shir == null)// && shir.Shirvoen != qaime.qaimeKimden
                        {
                            ti.ShId = Guid.NewGuid().ToString();
                            ti.Bankadi = "";
                            ti.Bankvoen = "";
                            ti.SWIFT = "";
                            ti.Bankkodu = "";
                            ti.Muxbirhesab = "";
                            ti.Aznhesab = "";
                            ti.Shiricrachi = "";
                            ti.Shirvoen = qaime.qaimeKime;
                            ti.Cavabdehshexs = "";
                            ti.Email = _GetEmail();
                            ti.Unvan = ti.Unvan;
                            ti.userId = _GeteId();
                            ti.Shirpercent = 0;
                            await _shi.InsertAsync(ti);
                        }
                        #endregion
                        #region qaimeKimden
                        Mushteri mi = new Mushteri();
                        var mush = _mush.GetAll().FirstOrDefault(x => x.Voen == qaime.qaimeKimden);
                        if (mush == null)//.Voen!=qaime.qaimeKimden
                        {
                            mi.MushId = Guid.NewGuid().ToString();
                            mi.Firma = "";
                            mi.Voen = qaime.qaimeKimden;
                            mi.Muqavilenom = "";
                            mi.Muqaviletar = DateTime.Now;
                            mi.Valyuta = "1";
                            mi.Odemesherti = "";
                            mi.Temsilchi = "";
                            await _mush.InsertAsync(mi);

                        }
                        #endregion
                        foreach (XmlNode row in rootNode["product"]["qaimeTable"].ChildNodes)
                        {
                            var pde=new Productdetal();
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
                                   c16 = row["c16"].InnerText,//(Yola salınmış mallara,görülmüş işlərə və göstərilmiş xidmətlər üçün məbləğ burada saxlanılır.Kəsir hissəsi ən çox 2 rəqəmlidir.Məcburidir )
                                   c17 = row["c17"].InnerText,//(Malların Barkod)
                               });
                            pde.PdetId= Guid.NewGuid().ToString();
                            pde.Maladi = "";
                            //string _pdetId = null,  _maladi = null, _barkod = null, _vergiId = null, _vId = null, _qeyd = null, _edv = null;
                            await _prodet.InsertAsync(pde);
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
                                   c9 = row["c9"].InnerText, //(Yola salınmış mallara,görülmüş işlərə və göstərilmiş xidmətlər üçün cəmi məbləğ burada saxlanılır.Kəsir hissəsi ən çox 2 rəqəmlidir. Düstur : qaimeYekunTable.c8= sum(qaimeTable.c14) . Məcburidir )
                                   c10 = row["c10"].InnerText,//(Yola salınmış mallara,görülmüş işlərə və göstərilmiş xidmətlər üçün yol vergisi )

                               }
                                );
                        }

                        var Em = new Emeliyyatdet();
                        Em.EmdetId = Guid.NewGuid().ToString();
                        Em.UserId = _GeteId();
                        Em.QId = QId.ToString();
                        Em.AId = aId.ToString();
                        Em.DhesId = dhesId.ToString();
                        Em.KhesId = khesId.ToString();
                        Em.MushId = mush.MushId;
                        foreach (var xx in qaime.qaimeTables)
                        {
                            var ver = _ver.GetAll().FirstOrDefault(k => k.Vergikodu == xx.c1);
                            Em.VergiId = ver.VergiId;
                            Em.VId = ver.VId;
                            Em.Maladi = xx.c2.ToString();
                            Em.Barkod = xx.c4.ToString();
                            Em.Miqdar = decimal.Parse(xx.c4);
                            Em.Submiqdar = 1;
                            Em.Vahidqiymeti_alish = decimal.Parse(xx.c5);
                            Em.Vahidqiymeti_satish = Em.Vahidqiymeti_satish + decimal.Parse(xx.c5) * (decimal.Parse(pars.ToString()) / 100);


                            Em.ValId = ValId.ToString();
                            Em.Kurs = decimal.Parse(Kurs.ToString());
                            Em.Emeltarixi = DateTime.Now.Date;
                            if (decimal.Parse(xx.c13) > 0)
                            {
                                Em.Edv = "0,18%";
                                Em.Edvye_celbedilen = 1;
                                Em.Edvye_celbedilmeyen = 0;
                            }
                            else
                            {
                                Em.Edv = "0";
                                Em.Edvye_celbedilen = 0;
                                Em.Edvye_celbedilmeyen = 1;
                            }
                            Em.Qeyd = null;
                            //await _emel.InsertAsync(Em);
                        }


                        var fileSavePath = _path.Replace("\\", "/") + "/" + file.FileName;

                        if (System.IO.File.Exists(fileSavePath))
                        {
                            System.IO.File.Delete(fileSavePath);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                //--------------------------------------                   
                // pp.proId = Request.Form["proId"];
                //  pp.photourl = url;
                // await _photo.InsertAsync(pp);
                return Ok();


            }
        }
        // GET: api/<OperationController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OperationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OperationController>
        [HttpPost]
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
