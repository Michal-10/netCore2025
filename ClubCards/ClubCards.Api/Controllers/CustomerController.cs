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
        [HttpGet("{idCustomer}")]
        public ActionResult<CustomerEntity> GetById(int idCustomer)
        {
            //if (tz < 0)
            if (idCustomer < 0)
                return BadRequest();
            var customer = _customerService.GetCustomerById(idCustomer);
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
        [HttpPut("{idCustomer}")]
        public ActionResult Put(uint idCustomer, [FromBody] CustomerEntity value)
        {
            bool isSuccess = _customerService.UpdateCustomer(idCustomer, value);
            if (isSuccess)
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{idCustomer}")]
        public ActionResult Delete(uint idCustomer)
        {
            bool isSuccess = _customerService.DeleteCustomer(idCustomer);
            if (isSuccess)
                return Ok(true);
            return NotFound();
        }
    }
}
