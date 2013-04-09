using System;
using System.Collections.Generic;
using Model;
using Model.Repositories.interfaces;
using Moq;
using NUnit.Framework;
using Services.Routes.impl;

namespace Services.Tests
{
    [TestFixture]
    public class RouteServiceTest
    {
        private IUnitOfWork unitOfWork;

        [TestFixtureSetUp]
        public void Setup()
        {
            unitOfWork = MockupsConfiguration.MockUnitOfWork();
        }


        [Test]
        public void Get_Route_By_Id()
        {
           var routesService = new DefaultRoutesService(unitOfWork);
           var route = routesService.GetById(1);
           
            Assert.AreEqual(route.CreatedBy, "cvazquez" );
            Assert.IsInstanceOf(typeof(Route), route);
        }

        [Test]
        public void Get_Route_By_Id_Fail()
        {
           var routesService = new DefaultRoutesService(unitOfWork);

           var route = routesService.GetById(2);
           
            // Assert
            Assert.AreEqual(route.CreatedBy, "cvazquez" );
        }

        [Test]
        public void Get_Routes_Count()
        {
           var routesService = new DefaultRoutesService(unitOfWork);

           Assert.AreEqual(routesService.GetAll().Count, 2);
        }
    }
}
