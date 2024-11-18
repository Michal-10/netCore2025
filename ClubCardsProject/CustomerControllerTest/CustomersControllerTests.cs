using ClubCardsProject.Controllers;
using ClubCardsProject.Entities;
using ClubCardsProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerControllerTest
{
    public class CustomersControllerTests
    {

        [Fact]
        public void GetAll_ReturnsOKResult()
        {
            //Arrange

            //Act
            var test = (new CustomerController(new CustomerService(new DataContextCustomerFake()))).Get();
            //Assert
            Assert.IsType<ActionResult<List<CustomerEntity>>>(test);
        }
       
        [Fact]
        public void GetById_ReturnsBadRequest()
        {
            //Arrange
            var id = -1;
            //Act
            var test = (new CustomerController(new CustomerService(new DataContextCustomerFake()))).GetById(id);
            //Assert
            Assert.IsType<BadRequestResult>(test.Result);
        }
        [Fact]
        public void GetById_ReturnsNotFound()
        {
            //Arrange
            var id = 3;
            //Act
            var test = (new CustomerController(new CustomerService(new DataContextCustomerFake()))).GetById(id);
            //Assert
            Assert.IsType<NotFoundResult>(test.Result);
        }
       
        [Fact]
        public void GetById_ReturnsOKResult()
        {
            //Arrange
            var id = 1;
            //Act
            var test = (new CustomerController(new CustomerService(new DataContextCustomerFake()))).GetById(id);
            //Assert
            Assert.IsType<ActionResult<CustomerEntity>>(test);
            //Assert.IsType<OkObjectResult>(test);
        }
        //public void Post_ReturnsOKResult(ActionResult test)
        [Fact]
        public void Post_ReturnsOKResult()
        {
            //Arrange
            //מניחה כרגע שאובייקט 100 לא קיים 
            var obj = new CustomerEntity( 150, "215112608", "mi", "iz", "054", "d@" +
                "d.v", new DateTime(10, 10, 10), new DateTime(11, 11, 11) );
            //Act
            var test = (new CustomerController(new CustomerService(new DataContextCustomerFake()))).Post(obj);
            //Assert
            Assert.IsType<OkObjectResult>(test);
        }
        [Fact]
        public void Post_ReturnsBadRequest()
        {
            //Arrange
            //מניחה כרגע שאובייקט 1 קיים כבר
            var obj = new CustomerEntity(1, "111111111", "mi", "iz", "054", "hh", new DateTime(10, 10, 10), new DateTime(11, 11, 11));
            //Act
            var test = (new CustomerController(new CustomerService(new DataContextCustomerFake()))).Post(obj);
            //Assert
            Assert.IsType<BadRequestObjectResult>(test);
        }

        [Fact]
        public void Put_ReturnsOKResult()
        {
            //Arrange
            //מניחה כרגע שאובייקט 1 קיים כבר
            var obj = new CustomerEntity(1, "214823064", "mi", "iz", "054", "hh@d.d", new DateTime(10, 10, 10), new DateTime(11, 11, 11));
            var id = 1;
            //Act
            var test = (new CustomerController(new CustomerService(new DataContextCustomerFake()))).Put(id,obj);
            //Assert
            Assert.IsType<OkObjectResult>(test);
        }

        [Fact]
        public void Put_ReturnsNotFound()
        {
            //Arrange
            //מניחה כרגע שאובייקט 100 לא קיים 
            var obj = new CustomerEntity(100, "111111111", "mi", "iz", "054", "hh", new DateTime(10, 10, 10), new DateTime(11, 11, 11));
            var id = 100;
            //Act
            var test= (new CustomerController(new CustomerService(new DataContextCustomerFake()))).Put(id, obj);
            //Assert
            Assert.IsType<NotFoundResult>(test);
        }

        [Fact]
        public void Delete_ReturnsOKResult()
        {
            //Arrange
            //מניחה כרגע שאובייקט 1 קיים כבר
            //var id = 5;
            var id = 1;
            //Act
            var test= new CustomerController(new CustomerService(new DataContextCustomerFake())).Delete(id);
            //Assert
            Assert.IsType<OkObjectResult>(test);
        }

        [Fact]
        public void Delete_ReturnsNotFound()
        {
            //Arrange
            //מניחה כרגע שאובייקט לא קיים 
            var id = 500;
            //Act
            var test = new CustomerController(new CustomerService(new DataContextCustomerFake())).Delete(id);
            //Assert
            Assert.IsType<NotFoundResult>(test);
        }
    }
}
