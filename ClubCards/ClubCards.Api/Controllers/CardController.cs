using ClubCards.Core.Services;
using ClubCardsProject.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClubCardsProject.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        readonly ICardService _cardService;
        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        // GET: api/<CardController>
        [HttpGet]
        public ActionResult<List<CardEntity>> Get()
        {
            return _cardService.GetCards();
        }


        // GET api/<CardController>/5
        [HttpGet("{numCard}")]
        public ActionResult GetById(int numCard)
        {
            if (numCard < 0)
                return BadRequest();
            var card = _cardService.GetCardByID(numCard);
            if (card == null)
                return NotFound();
            return Ok(card);
        }

        // POST api/<CardController>
        [HttpPost]
        public ActionResult Post([FromBody] CardEntity value)
        {
            bool isSuccess = _cardService.AddCard(value);
            if (isSuccess)
                return Ok(true);
            return BadRequest("ID exists in the system");
        }

        // PUT api/<CardController>/5
        [HttpPut("{numCard}")]
        public ActionResult Put(uint numCard, [FromBody] CardEntity value)
        {
            bool isSuccess = _cardService.UpdateCard(numCard, value);
            if (isSuccess)
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<CardController>/5
        [HttpDelete("{numCard}")]
        public ActionResult Delete(uint numCard)
        {
            bool isSuccess = _cardService.DeleteCard(numCard);
            if (isSuccess)
                return Ok(true);
            return NotFound();
        }
    }
}
