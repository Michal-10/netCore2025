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
    public class CustomerController : ControllerBase
    {
         readonly ICustomerService _customerService;
        readonly IMapper _mapper;
        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public ActionResult<List<CustomerDTO>> Get()
        {
           return  _customerService.GetCustomers().ToList();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{idCustomer}")]
        public ActionResult<CustomerDTO> GetById(int idCustomer)
        {
            //if (tz < 0)
            if (idCustomer <= 0)
                return BadRequest();
            var customer = _customerService.GetCustomerById(idCustomer);
            if (customer == null)
                return NotFound();
            return customer;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult Post([FromBody] CustomerPostModel value)
        {
            var customerDTO = _mapper.Map<CustomerDTO>(value);
            bool isSuccess = _customerService.AddCustomer(customerDTO);
            if (isSuccess)
                return Ok(true);
            return BadRequest("ID exists in the system or the file donwt found");
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{idCustomer}")]
        public ActionResult Put(uint idCustomer, [FromBody] CustomerPostModel value)
        {
            var customerDTO = _mapper.Map<CustomerDTO>(value);
            bool isSuccess = _customerService.UpdateCustomer(idCustomer, customerDTO);
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
