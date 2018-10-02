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
    public class SnippetRepositoryTests
    {
        #region Create

        [Test]
        public void InsertSnippet_WhenSnippetToInsert_ShouldInsertOnce()
        {
            IDataGateway gateway = Substitute.For<IDataGateway>();
            var repository = new SnippetRepository(gateway);
            repository.InsertSnippet(new Snippet());
            gateway.Received(1).InsertSnippet(Arg.Any<Snippet>());
        }

        [Test]
        public void InsertSnippet_WhenNoSnippetToInsert_ShouldNotInsert()
        {
            IDataGateway gateway = Substitute.For<IDataGateway>();
            gateway.DidNotReceiveWithAnyArgs().InsertSnippet(Arg.Any<Snippet>());
        }

        #endregion

        #region Read

        [Test]
        public void GetSnippets_WhenNoSnippets_ReturnsEmptyCollection()
        {
            IDataGateway gateway = Substitute.For<IDataGateway>();

            var repository = new SnippetRepository(gateway);
            var snippets = repository.GetSnippets();

            Assert.AreEqual(new List<Snippet>(), snippets);
        }

        [Test]
        public void GetSnippets_WhenSnippetsAreAvailable_ReturnsSnippets()
        {
            IDataGateway gateway = Substitute.For<IDataGateway>();
            gateway.GetAllSnippets().Returns(new List<Snippet>
            {
          new Snippet()
            });

            var repository = new SnippetRepository(gateway);
            var snippets = repository.GetSnippets();
            Assert.AreEqual(1, snippets.Count());
        }

        #endregion

        #region Update

        [Test]
        public void UpdateSnippet_WhenSnippetsAreAvailable_ReturnsTrue()
        {
            IDataGateway gateway = Substitute.For<IDataGateway>();
            gateway.UpdateSnippet(Arg.Any<Snippet>()).Returns(true);
            var repository = new SnippetRepository(gateway);
            Assert.IsTrue(repository.UpdateSnippet(new Snippet()));
        }

        [Test]
        public void UpdateSnippet_WhenSnippetAreNotAvailable_ReturnsFalse()
        {
            IDataGateway gateway = Substitute.For<IDataGateway>();
            gateway.UpdateSnippet(Arg.Any<Snippet>()).Returns(false);
            var repository = new SnippetRepository(gateway);
            Assert.IsFalse(repository.UpdateSnippet(new Snippet()));
        }

        #endregion

        #region Delete

        [Test]
        public void DeleteSnippet_WhenSnippetExists_ShouldDeleteSnippet()
        {
            IDataGateway gateway = Substitute.For<IDataGateway>();

            var repository = new SnippetRepository(gateway);
            repository.DeleteSnippet(2);
            gateway.Received().RemoveSnippet(Arg.Any<int>());
        }
        #endregion

    }
}