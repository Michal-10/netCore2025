using ClubCardsProject.Entities;
using ClubCardsProject.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClubCardsProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyingController : ControllerBase
    {
        BuyingService _buyingService=new BuyingService();

        // GET: api/<BuyingController>
        [HttpGet]
        public ActionResult Get()
        {
            var buying = _buyingService.GetBuyings();
            if (buying == null) 
                return NotFound();
            return Ok(buying); 
        }

        // GET api/<BuyingController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var buying = _buyingService.GetBuyingById(id);
            if(buying == null) 
                return NotFound();
            return Ok(buying);
        }

        // POST api/<BuyingController>
        [HttpPost]
        public ActionResult Post([FromBody] BuyingEntity value)
        {
            bool isSuccess = _buyingService.PostBuying(value);
            if(isSuccess)
                return Ok(true);
            return NotFound("ID exists in the system");
        }

        // PUT api/<BuyingController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] BuyingEntity value)
        {
            bool isSuccess = _buyingService.PutBuying(id, value);
            if (isSuccess)
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<BuyingController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool isSuccess = _buyingService.DeleteBuying(id);
            if (isSuccess)
                return Ok(true);
            return NotFound();

        }
    }
}
