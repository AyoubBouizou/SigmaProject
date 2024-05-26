using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unipluss.Sign.ExternalContract.Interfaces;

namespace TestProject1.Mocks
{
    public interface IExternalService
    {
        Task<string> GetDataAsync();
    }
    public class MockExternalService
    {
        public static IExternalService Create()
        {

            var mockService = new Mock<IExternalService>();
            mockService.Setup(s => s.GetDataAsync()).ReturnsAsync(" data fromservice");

            return mockService.Object;
        }
    }
}
