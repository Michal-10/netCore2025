using ClubCardsProject.Entities;
using ClubCardsProject.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClubCardsProject.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        CardService _cardService = new CardService();
        // GET: api/<CardController>
        [HttpGet]
        public ActionResult Get()
        {
           var cards = _cardService.GetCards();
            if (cards == null)
                return NotFound();
            return Ok(cards);
        }
    

        // GET api/<CardController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var card = _cardService.GetCardByID(id);
            if (card == null)
                return NotFound();
            return Ok(card);
        }

        // POST api/<CardController>
        [HttpPost]
        public ActionResult Post([FromBody] CardEntity value)
        {
           bool isSuccess = _cardService.PostCard(value);
            if (isSuccess)
                return Ok(true);
            return NotFound("ID exists in the system");
        }

        // PUT api/<CardController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CardEntity value)
        {
            bool isSuccess = _cardService.PutCard(id, value);
            if (isSuccess)
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<CardController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool isSuccess = _cardService.DeleteCard(id);
            if (isSuccess)
                return Ok(true);
            return NotFound();
        }
    }
}
