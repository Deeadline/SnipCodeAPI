using NUnit.Framework;
using NSubstitute;
using SnipCodeAPI.Repositories;
using SnipCodeAPI.Repositories.Interfaces;
using SnipCodeAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SnipCodeAPITests
{
    [TestFixture]
    public class UserRepositoryTests
    {
        #region Create

        [Test]
        public void InsertUser_WhenUserToInsert_ShouldInsertOnce()
        {
            IDataGateway gateway = Substitute.For<IDataGateway>();
            var repository = new UserRepository(gateway);
            repository.InsertUser(new User());
            gateway.Received(1).InsertUser(Arg.Any<User>());
        }

        [Test]
        public void InsertUser_WhenNoUserToInsert_ShouldNotInsert()
        {
            IDataGateway gateway = Substitute.For<IDataGateway>();
            gateway.DidNotReceiveWithAnyArgs().InsertUser(Arg.Any<User>());
        }

        #endregion

        #region Read

        [Test]
        public void GetUsers_WhenNoUsers_ReturnsEmptyCollection()
        {
            IDataGateway gateway = Substitute.For<IDataGateway>();

            UserRepository repository = new UserRepository(gateway);
            var users = repository.GetUsers();

            Assert.AreEqual(new List<User>(), users);
        }

        [Test]
        public void GetUsers_WhenUsersAreAvailable_ReturnsUsers()
        {
            IDataGateway gateway = Substitute.For<IDataGateway>();
            gateway.GetAllUsers().Returns(new List<User>
            {
          new User()
            });

            UserRepository repository = new UserRepository(gateway);
            var users = repository.GetUsers();
            Assert.AreEqual(1, users.Count());
        }

        #endregion

        #region Update

        [Test]
        public void UpdateUser_WhenUsersAreAvailable_ReturnsTrue()
        {
            IDataGateway gateway = Substitute.For<IDataGateway>();
            gateway.UpdateUser(Arg.Any<User>()).Returns(true);
            var repository = new UserRepository(gateway);
            Assert.IsTrue(repository.UpdateUser(new User()));
        }

        [Test]
        public void UpdateUser_WhenUsersAreNotAvailable_ReturnsFalse()
        {
            IDataGateway gateway = Substitute.For<IDataGateway>();
            gateway.UpdateUser(Arg.Any<User>()).Returns(false);
            var repository = new UserRepository(gateway);
            Assert.IsFalse(repository.UpdateUser(new User()));
        }

        #endregion

        #region Delete

        [Test]
        public void DeleteUser_WhenUserExists_ShouldDeleteUser()
        {
            IDataGateway gateway = Substitute.For<IDataGateway>();
            var repository = new UserRepository(gateway);
            repository.DeleteUser(2);
            gateway.Received().RemoveUser(Arg.Any<int>());
        }
        #endregion
    }
}