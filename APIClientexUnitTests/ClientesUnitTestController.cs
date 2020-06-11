using APICliente.Context;
using APICliente.Controllers;
using APICliente.Models;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Xunit;

namespace APIClientexUnitTests
{
    public class ClientesUnitTestController
    {

        private readonly AppDbContext context;

        [Fact]
        public void GetClientes_Return_OkResult()
        {

        //Arrange
        var controller = new ClientesController(context);

        //Act
        var data = controller.Get();

        //Assert
        Assert.IsType<List<Cliente>>(data.Value);

        }

}
}
