using ClubCards.Core.Services;
using ClubCardsProject.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClubCardsProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
         readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public ActionResult<List<CustomerEntity>> Get()
        {
           return  _customerService.GetCustomers();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public ActionResult<CustomerEntity> GetById(int id)
        {
            if (id < 0)
                return BadRequest();
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
                return NotFound();
            return customer;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult Post([FromBody] CustomerEntity value)
        {
            bool isSuccess = _customerService.AddCustomer(value);
            if (isSuccess)
                return Ok(true);
            return BadRequest("ID exists in the system or the file donwt found");
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CustomerEntity value)
        {
            bool isSuccess = _customerService.UpdateCustomer(id, value);
            if (isSuccess)
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool isSuccess = _customerService.DeleteCustomer(id);
            if (isSuccess)
                return Ok(true);
            return NotFound();
        }
    }
}
