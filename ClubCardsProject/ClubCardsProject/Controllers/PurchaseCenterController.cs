﻿using ClubCardsProject.Entities;
using ClubCardsProject.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClubCardsProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseCenterController : ControllerBase
    {
        PurchaseCenterService _purchaseCenterService=new PurchaseCenterService();
        // GET: api/<PurchaseCenterController>
        [HttpGet]
        public ActionResult Get()
        {
            var purchaseCenters = _purchaseCenterService.GetPurchaseCenters();
            if (purchaseCenters == null)
                return NotFound();
            return Ok(purchaseCenters);
        }

        // GET api/<PurchaseCenterController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var purchaseCenter = _purchaseCenterService.GetPurchaseCenterByID(id);
            if (purchaseCenter == null)
                return NotFound();
            return Ok(purchaseCenter);
        }

        // POST api/<PurchaseCenterController>
        [HttpPost]
        public ActionResult Post([FromBody] PurchaseCenterEntity value)
        {
            bool isSuccess = _purchaseCenterService.PostPurchaseCenter(value);
            if (isSuccess)
                return Ok(true);
            return NotFound("ID exists in the system"); 
        }

        // PUT api/<PurchaseCenterController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PurchaseCenterEntity value)
        {
            bool isSuccess = _purchaseCenterService.PutPurchaseCenter(id, value);
            if (isSuccess)
                return Ok(true);
            return NotFound();
        }

        // DELETE api/<PurchaseCenterController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool isSuccess = _purchaseCenterService.DeletePurchaseCentere(id);
            if (isSuccess)
                return Ok(true);
            return NotFound();
        }
    }
}