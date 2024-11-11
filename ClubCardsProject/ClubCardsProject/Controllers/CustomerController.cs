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
        //private readonly DataContext _customerService=new DataContext();

        // GET: api/<CustomerController>
        [HttpGet]
        public ActionResult<List<CustomerEntity>> Get()
        {
           //return  _customerService.GetCustomers();
           return  _customerService.GetCustomers();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public ActionResult<CustomerEntity> GetById(int id)
        {
            if (id < 0)
                return BadRequest();
            //var customer = _customerService.GetCustomerById(id);
            var customer = _customerService.GetCustomerById(id);
            //var customer = _customerService.GetCustomers().Find(x => x.Id == id);
            if (customer == null)
                return NotFound();
            return customer;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult Post([FromBody] CustomerEntity value)
        {
            //bool isSuccess = _customerService.AddCustomer(value);
            bool isSuccess = _customerService.AddCustomer(value);
            if (isSuccess)
                return Ok(true);
            return BadRequest("ID exists in the system");
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
