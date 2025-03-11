using AutoMapper;
using ClubCards.Api.Models;
using ClubCards.Core.DTOs;
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
        readonly IMapper _mapper;
        public CardController(ICardService cardService, IMapper mapper)
        {
            _cardService = cardService;
            _mapper = mapper;
        }

        // GET: api/<CardController>
        [HttpGet]
        public ActionResult<List<CardDTO>> Get()
        {
            return _cardService.GetCards().ToList();
        }


        // GET api/<CardController>/5
        [HttpGet("{numCard}")]
        public ActionResult<CardDTO> GetById(int numCard)
        {
            if (numCard <= 0)
                return BadRequest();
            var card = _cardService.GetCardByID(numCard);
            if (card == null)
                return NotFound();
            return card;
        }

        // POST api/<CardController>
        [HttpPost]
        public ActionResult Post([FromBody] CardPostModel value)
        {
            var cardDTO = _mapper.Map<CardDTO>(value);
            bool isSuccess = _cardService.AddCard(cardDTO);
            if (isSuccess)
                return Ok(true);
            return BadRequest("ID exists in the system");
        }

        // PUT api/<CardController>/5
        [HttpPut("{numCard}")]
        public ActionResult Put(uint numCard, [FromBody] CardPostModel value)
        {
            var cardDTO = _mapper.Map<CardDTO>(value);
            bool isSuccess = _cardService.UpdateCard(numCard, cardDTO);
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
