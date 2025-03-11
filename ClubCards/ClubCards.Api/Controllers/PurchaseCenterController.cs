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
    public class PurchaseCenterController : ControllerBase
    {
        readonly IPurchaseCenterService _purchaseCenterService;
        readonly IMapper _mapper;
        public PurchaseCenterController(IPurchaseCenterService purchaseCenterService, IMapper mapper)
        {
            _purchaseCenterService = purchaseCenterService;
            _mapper = mapper;
        }

        // GET: api/<PurchaseCenterController>
        [HttpGet]
        public ActionResult<List<PurchaseCenterDTO>> Get()
        {
            return _purchaseCenterService.GetPurchaseCenters().ToList();

        }

        // GET api/<PurchaseCenterController>/5
        [HttpGet("{numPurchaseCenter}")]
        public ActionResult<PurchaseCenterDTO> GetById(int numPurchaseCenter)
        {
            if (numPurchaseCenter <= 0)
                return BadRequest();
            var purchaseCenter = _purchaseCenterService.GetPurchaseCenterByID(numPurchaseCenter);
            if (purchaseCenter == null)
                return NotFound();
            return purchaseCenter;
        }

        // POST api/<PurchaseCenterController>
        [HttpPost]
        public ActionResult Post([FromBody] PurchaseCenterPostModel value)
        {
            var purchaseCenterDTO = _mapper.Map<PurchaseCenterDTO>(value);
            bool isSuccess = _purchaseCenterService.AddPurchaseCenter(purchaseCenterDTO);
            if (isSuccess)
                return Ok(true);
            return BadRequest("ID exists in the system");
        }

        // PUT api/<PurchaseCenterController>/5
        [HttpPut("{numPurchaseCenter}")]
        public ActionResult Put(uint numPurchaseCenter, [FromBody] PurchaseCenterPostModel value)
        {
            var purchaseCenterDTO = _mapper.Map<PurchaseCenterDTO>(value);
            bool isSuccess = _purchaseCenterService.UpdatePurchaseCenter(numPurchaseCenter, purchaseCenterDTO);
            if (isSuccess)
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<PurchaseCenterController>/5
        [HttpDelete("{numPurchaseCenter}")]
        public ActionResult Delete(uint numPurchaseCenter)
        {
            bool isSuccess = _purchaseCenterService.DeletePurchaseCentere(numPurchaseCenter);
            if (isSuccess)
                return Ok(true);
            return NotFound();
        }
    }
}
