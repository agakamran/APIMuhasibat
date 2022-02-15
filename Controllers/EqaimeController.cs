using APIMuhasibat.Models;
using APIMuhasibat.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIMuhasibat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EqaimeController : ControllerBase
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
        private readonly IRepository<Emeliyyatdet> _emel = null;
        private static IWebHostEnvironment _host;
        #endregion
        public EqaimeController(IWebHostEnvironment host, IRepository<Tipler> ti, IRepository<Qrup> qr,
            IRepository<Activler> act, IRepository<Hesab> he, IRepository<Bolme> bol,IRepository<Madde> mad,
            IRepository<Shirket> shi, IRepository<Mushteri> mush, IRepository<Vahid> va, IRepository<Valyuta> val,
            IRepository<Vergi> ver, IRepository<fealsahe> feal, IRepository<Emeliyyatdet> emel)
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
            _emel = emel;
            #endregion           
        }
        // GET: api/<VergiKoduController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }       
        [HttpPost]
        [Route("postfile")]
        public async Task<IActionResult> postfile()
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            else
            {
                string path = "";
                var file = Request.Form.Files["file"];
                #region
                // var pp = new prodphoto();
                // pp.photoId = Guid.NewGuid().ToString();               
                // var ft = Request.Form["genId"];
                // string exten = Path.GetExtension(file.FileName);
                // string url = "Images/" + fi + "/" + gen + "/" + pp.photoId + exten;
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
                            kod = rootNode.Attributes["kod"].Value,
                            qaimeKime = rootNode["qaimeKime"].InnerText,
                            qaimeKimden = rootNode["qaimeKimden"].InnerText,
                            sn = rootNode["sn"].InnerText,
                            vo = rootNode["vo"].InnerText,
                            des = rootNode["des"].InnerText,
                            des2 = rootNode["des2"].InnerText
                        };
                        foreach (XmlNode row in rootNode["product"]["qaimeTable"].ChildNodes)
                        {
                            string c1 = row["c1"].InnerText;
                            Console.WriteLine("Hello World!");
                            qaime.qaimeTables.Add(
                               new QaimeTable
                               {
                                   c1 = row["c1"].InnerText,
                                   c2 = row["c2"].InnerText,
                                   c3 = row["c3"].InnerText,
                                   c4 = row["c4"].InnerText,
                                   c5 = row["c5"].InnerText,
                                   c6 = row["c6"].InnerText,
                                   c7 = row["c7"].InnerText,
                                   c8 = row["c8"].InnerText,
                                   c9 = row["c9"].InnerText,
                                   c10 = row["c10"].InnerText,
                                   c11 = row["c11"].InnerText,
                                   c12 = row["c12"].InnerText,
                                   c13 = row["c13"].InnerText,
                                   c14 = row["c14"].InnerText,
                               });
                        }
                        foreach (XmlNode row in rootNode["product"]["qaimeYekunTable"].ChildNodes)
                        {
                            qaime.qaimeYekunTables.Add(
                               new QaimeTable
                               {
                                   c1 = row["c1"].InnerText,
                                   c2 = row["c2"].InnerText,
                                   c3 = row["c3"].InnerText,
                                   c4 = row["c4"].InnerText,
                                   c5 = row["c5"].InnerText,
                                   c6 = row["c6"].InnerText,
                                   c7 = row["c7"].InnerText,
                                   c8 = row["c8"].InnerText
                                  
                               }
                                );
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
