using ClubCardsProject.Entities;
using ClubCardsProject.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClubCardsProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseCenterController : ControllerBase
    {
        PurchaseCenterService _purchaseCenterService=new PurchaseCenterService();
       // private readonly DataContext _purchaseCenterService = new DataContext();


        // GET: api/<PurchaseCenterController>
        [HttpGet]
        public ActionResult<List<PurchaseCenterEntity>> Get()
        {
            return _purchaseCenterService.GetPurchaseCenters();

        }

        // GET api/<PurchaseCenterController>/5
        [HttpGet("{id}")]
        public ActionResult<PurchaseCenterEntity> GetById(int id)
        {
            if (id < 0)
                return BadRequest();
            var purchaseCenter = _purchaseCenterService.GetPurchaseCenterByID(id);
            if (purchaseCenter == null)
                return NotFound();
            return purchaseCenter;
        }

        // POST api/<PurchaseCenterController>
        [HttpPost]
        public ActionResult Post([FromBody] PurchaseCenterEntity value)
        {
            bool isSuccess = _purchaseCenterService.AddPurchaseCenter(value);
            if (isSuccess)
                return Ok(true);
            return BadRequest("ID exists in the system");
        }

        // PUT api/<PurchaseCenterController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PurchaseCenterEntity value)
        {
            bool isSuccess = _purchaseCenterService.UpdatePurchaseCenter(id, value);
            if (isSuccess)
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<PurchaseCenterController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool isSuccess = _purchaseCenterService.DeletePurchaseCentere(id);
            if (isSuccess)
                return Ok(true);
            return NotFound();
        }
    }
}
