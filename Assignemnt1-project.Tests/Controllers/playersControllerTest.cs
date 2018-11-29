using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignemnt1_project.Controllers;
using System.Web.Mvc;
using Moq;
using Assignemnt1_project.Models;
using System.Collections.Generic;
using System.Linq;

namespace Assignemnt1_project.Tests.Controllers
{   
    
    [TestClass]
    public class playersControllerTest 
    {
        // gloal variable need for multiple tests in this class
        playersController controller;
        Mock<IPlayersMock> mock;
        List<player> players;

        [TestInitialize]

        public void TestInitialize()
        {
            //this will run before each individual test
            //create a new mock data oject to hold a fale list of players
            mock = new Mock<IPlayersMock>();
            //populate mock list
            players = new List<player>
            {
                new player{player_id=100,first_name="Rudy",last_name="Gay",
                           salary=8000000,position="Forward",points_per_game=13,
                           rebonds_per_game =10,injury="no",team_id=1},
                 new player{player_id=200,first_name="Patty",last_name="Mills",
                           salary=9000000,position="Guard",points_per_game=10,
                           rebonds_per_game =3,injury="no",team_id=1},
                 new player{player_id=300,first_name="Bryn",last_name="Forbes",
                           salary=2000000,position="Guard",points_per_game=11,
                           rebonds_per_game =4,injury="no",team_id=1}
            };
            //put the list to mock object and pass it to player controller
            mock.Setup(m => m.players).Returns(players.AsQueryable());
            controller = new playersController(mock.Object);
        }

        [TestMethod]
        public void IndexLoadView()
        {
            //arange  move to testinitialize for code re-use
            //playersController controller = new playersController();
            //act
            ViewResult result = controller.Index() as ViewResult;
            //assert
            Assert.AreEqual("Index",result.ViewName);

        }
        [TestMethod]
        public void IndexReturnPlayers()
        {
            //act 
            var result = (List<player>)((ViewResult)controller.Index()).Model;
            //assert
            CollectionAssert.AreEqual(players, result);
        }
    }
}
