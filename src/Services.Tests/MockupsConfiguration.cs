using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Repositories.interfaces;
using Moq;

namespace Services.Tests
{
    public class MockupsConfiguration
    {
         public static IRoutesRepository MockRoutesRepository()
        {
            var mockRoutesRepository = new Mock<IRoutesRepository>();

            Customer customer = new Customer();
            List<Route> routes = new List<Route>();
            routes.Add(new Route { Comments="", Created = DateTime.Now, CreatedBy = "cvazquez", ID = 1, Name = "NOMBRE", IsDeleted = false, Distance = 1000, Customer = customer});
            routes.Add(new Route { Comments="", Created = DateTime.Now, CreatedBy = "cvazquez2", ID = 2, Name = "NOMBRE2", IsDeleted = false, Distance = 1001, Customer = customer});

            mockRoutesRepository.Setup(x=>x.GetByID(1)).Returns(routes[0]);
            //TODO: Throw Exception
            //mockRoutesRepository.Setup(x=>x.GetByID(2)).Returns();
            mockRoutesRepository.Setup(x=>x.GetAll()).Returns(routes);

            return mockRoutesRepository.Object;
        }

        public static IUnitOfWork MockUnitOfWork()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
             
            mockUnitOfWork.Setup(x=>x.RoutesRepository).Returns(MockRoutesRepository);

            return mockUnitOfWork.Object;
        }
    }
}
