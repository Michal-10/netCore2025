using ClubCards.Core.DTOs;
using ClubCards.Core.Services;
using ClubCardsProject.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClubCardsProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        readonly IStoreService _storeService;
        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        // GET: api/<StoreController>
        [HttpGet]
        public ActionResult<List<StoreDTO>> Get()
        {
            return _storeService.GetStores().ToList();
        }

        // GET api/<StoreController>/5
        [HttpGet("{id}")]
        public ActionResult<StoreDTO> GetById(int id)
        {
            if (id <= 0)
                return BadRequest();
            var store = _storeService.GetStoreById(id);
            if (store == null)
                return NotFound();
            return store;
        }

        // POST api/<StoreController>
        [HttpPost]
        public ActionResult Post([FromBody] StoreEntity value)
        {
            bool isSuccess = _storeService.AddStore(value);
            if (isSuccess)
                return Ok(true);
            return BadRequest("ID exists in the system");
        }

        // PUT api/<StoreController>/5
        [HttpPut("{id}")]
        public ActionResult Put(uint id, [FromBody] StoreEntity value)
        {
            bool isSuccess = _storeService.UpdateStore(id, value);
            if (isSuccess)
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<StoreController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(uint id)
        {
            bool isSuccess = _storeService.DeleteStore(id);
            if (isSuccess)
                return Ok(true);
            return NotFound(); ;
        }
    }
}
