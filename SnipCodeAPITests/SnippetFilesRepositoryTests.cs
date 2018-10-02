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
    public class SnippetFilesRepositoryTests
    {
        #region Create

        [Test]
        public void InsertSnippetFile_WhenSnippetFileToInsert_ShouldInsertOnce()
        {
            IDataGateway gateway = Substitute.For<IDataGateway>();
            var repository = new SnippetFileRepository(gateway);
            repository.InsertSnippetFile(new SnippetFile());
            gateway.Received(1).InsertSnippetFile(Arg.Any<SnippetFile>());
        }

        [Test]
        public void InsertUser_WhenNoUserToInsert_ShouldNotInsert()
        {
            IDataGateway gateway = Substitute.For<IDataGateway>();
            gateway.DidNotReceiveWithAnyArgs().InsertSnippetFile(Arg.Any<SnippetFile>());
        }

        #endregion

        #region Read

        [Test]
        public void GetSnippetFiles_WhenNoSnippetFiles_ReturnsEmptyCollection()
        {
            IDataGateway gateway = Substitute.For<IDataGateway>();

            var repository = new SnippetFileRepository(gateway);
            var snippetFiles = repository.GetSnippetFiles();

            Assert.AreEqual(new List<SnippetFile>(), snippetFiles);
        }

        [Test]
        public void GetSnippetFiles_WhenSnippetFilesAreAvailable_ReturnsSnippetFiles()
        {
            IDataGateway gateway = Substitute.For<IDataGateway>();
            gateway.GetAllSnippetFiles().Returns(new List<SnippetFile>
            {
                new SnippetFile()
            });

            var repository = new SnippetFileRepository(gateway);
            var snippetFiles = repository.GetSnippetFiles();
            Assert.AreEqual(1, snippetFiles.Count());
        }

        #endregion

        #region Update

        [Test]
        public void UpdateSnippetFile_WhenSnippetFilesAreAvailable_ReturnsTrue()
        {
            IDataGateway gateway = Substitute.For<IDataGateway>();

            gateway.UpdateSnippetFile(Arg.Any<SnippetFile>()).Returns(true);
            var repository = new SnippetFileRepository(gateway);
            Assert.IsTrue(repository.UpdateSnippetFile(new SnippetFile()));
        }

        [Test]
        public void UpdateSnippetFile_WhenSnippetFilesAreNotAvailable_ReturnsFalse()
        {
            IDataGateway gateway = Substitute.For<IDataGateway>();
            gateway.UpdateSnippetFile(Arg.Any<SnippetFile>()).Returns(false);
            var repository = new SnippetFileRepository(gateway);
            Assert.IsFalse(repository.UpdateSnippetFile(new SnippetFile()));
        }

        #endregion

        #region Delete

        [Test]
        public void DeleteSnippetFile_WhenSnippetFileExists_ShouldDeleteSnippetFile()
        {
            IDataGateway gateway = Substitute.For<IDataGateway>();

            var repository = new SnippetFileRepository(gateway);
            repository.DeleteSnippetFile(1);
            gateway.Received().RemoveSnippetFile(Arg.Any<int>());
        }
        #endregion

    }
}