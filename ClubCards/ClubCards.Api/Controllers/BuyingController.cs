using ClubCards.Core.Services;
using ClubCardsProject.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClubCardsProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyingController : ControllerBase
    {
        readonly IBuyingService _buyingService;
        public BuyingController(IBuyingService buyingService)
        {
            _buyingService = buyingService;
        }

        // GET: api/<BuyingController>
        [HttpGet]
        public ActionResult<List<BuyingEntity>> Get()
        {
            return _buyingService.GetBuyings();
        }

        // GET api/<BuyingController>/5
        [HttpGet("{numBuying}")]
        public ActionResult<BuyingEntity> GetById(int numBuying)
        {
            if (numBuying <= 0)
                return BadRequest();
            var buying = _buyingService.GetBuyingById(numBuying);
            if (buying == null)
                return NotFound();
            return buying;
        }

        // POST api/<BuyingController>
        [HttpPost]
        public ActionResult Post([FromBody] BuyingEntity value)
        {
            bool isSuccess = _buyingService.AddBuying(value);
            if (isSuccess)
                return Ok(true);
            return BadRequest("ID exists in the system"); ;
        }

        // PUT api/<BuyingController>/5
        [HttpPut("{numBuying}")]
        public ActionResult Put(uint numBuying, [FromBody] BuyingEntity value)
        {
            bool isSuccess = _buyingService.UpdateBuying(numBuying, value);
            if (isSuccess)
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<BuyingController>/5
        [HttpDelete("{numBuying}")]
        public ActionResult Delete(uint numBuying)
        {
            bool isSuccess = _buyingService.DeleteBuying(numBuying);
            if (isSuccess)
                return Ok(true);
            return NotFound();

        }
    }
}
