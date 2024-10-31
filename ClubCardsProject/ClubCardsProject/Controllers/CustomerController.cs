using ClubCardsProject.Entities;
using ClubCardsProject.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClubCardsProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        CustomerService _customerService=new CustomerService();
        // GET: api/<CustomerController>
        [HttpGet]
        public ActionResult Get()
        {
           var customers = _customerService.GetCustomers();
            if (customers == null)
                return NotFound();
            return Ok(customers);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult Post([FromBody] CustomerEntity value)
        {
            bool isSuccess = _customerService.PostCustomer(value);
            if (isSuccess)
                return Ok(true);
            return NotFound("ID exists in the system");
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CustomerEntity value)
        {
            bool isSuccess = _customerService.PutCustomer(id, value);
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
