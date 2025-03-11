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
    public class BuyingController : ControllerBase
    {
        readonly IBuyingService _buyingService;
        readonly IMapper _mapper;
        public BuyingController(IBuyingService buyingService, IMapper mapper)
        {
            _buyingService = buyingService;
            _mapper = mapper;
        }

        // GET: api/<BuyingController>
        [HttpGet]
        public ActionResult<List<BuyingDTO>> Get()
        {
            return _buyingService.GetBuyings().ToList();
        }

        // GET api/<BuyingController>/5
        [HttpGet("{numBuying}")]
        public ActionResult<BuyingDTO> GetById(int numBuying)
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
        public ActionResult Post([FromBody] BuyingPostModel value)
        {
            var buyingDTO = _mapper.Map<BuyingDTO>(value);
            bool isSuccess = _buyingService.AddBuying(buyingDTO);
            //bool isSuccess = _buyingService.AddBuying(value);
            if (isSuccess)
                return Ok(true);
            return BadRequest("ID exists in the system"); ;
        }

        // PUT api/<BuyingController>/5
        [HttpPut("{numBuying}")]
        public ActionResult Put(uint numBuying, [FromBody] BuyingPostModel value)
        {
            var buyingDTO = _mapper.Map<BuyingDTO>(value);
            bool isSuccess = _buyingService.UpdateBuying(numBuying, buyingDTO);
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
