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
        //private readonly DataContext _buyingService=new DataContext();
        
        
        // GET: api/<BuyingController>
         [HttpGet]
        public ActionResult<List<BuyingEntity>> Get()
        {
            return _buyingService.GetBuyings();
        }

        // GET api/<BuyingController>/5
        [HttpGet("{id}")]
        public ActionResult<BuyingEntity> GetById(int id)
        {
            if (id<0)
                return BadRequest();
            var buying = _buyingService.GetBuyingById(id);
            if(buying == null) 
                return NotFound();
            return buying;
        }

        // POST api/<BuyingController>
        [HttpPost]
        public ActionResult Post([FromBody] BuyingEntity value)
        {
            bool isSuccess = _buyingService.AddBuying(value);
            if(isSuccess)
                return Ok(true);
            return BadRequest("ID exists in the system"); ;
        }

        // PUT api/<BuyingController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] BuyingEntity value)
        {
            bool isSuccess = _buyingService.UpdateBuying(id, value);
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
