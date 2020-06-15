using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Valuta2;

namespace ValutaRestService.Controllers
{   
    [Route("api/valuta")]
    [ApiController]
    public class ValutaCalcController : ControllerBase
    {
        
        // GET: api/<ValutaController>
        [HttpGet("svensk/{value1}", Name = "TilSvenskeKroner")]
        public double TilSvenskeKroner(int value1)
        {
            return ValutaCalc.TilSvenskeKroner(value1);
        }
       
        // GET: api/<ValutaController>
        [HttpGet("dansk/{value2}")]
        public double TilDanskeKroner(int value2)
        {
            return ValutaCalc.TilDanskeKroner(value2);
        }
    }
}
