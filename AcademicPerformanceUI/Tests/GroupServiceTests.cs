using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.MockRepositories;
using WcfRestService;
using WcfRestService.DTOModels;
using WcfRestService.ServiceInterfaces;

namespace Tests
{
    [TestClass]
    public class GroupServiceTests
    {
        private readonly ICartService _cartService;
        private GroupRepositoryMock repositoryMock = new GroupRepositoryMock();
        private readonly GroupDto testGroup = new GroupDto() { Id = Guid.NewGuid(), GroupName = "Test", StudyYear = 3, MaxStudents = 30 };
        public GroupServiceTests()
        {
            _cartService = new CartService(repositoryMock);
        }

        [TestMethod]
        public void Get_group_collection_returns_according_type()
        {
            _cartService.CreateEntity(testGroup);
            var list = _cartService.GetEntities();
            Assert.IsInstanceOfType(list, typeof(List<GroupDto>));
        }

        [TestMethod]
        public void Add_group_to_collection_not_empty()
        {
            _cartService.CreateEntity(testGroup);
            var list = _cartService.GetEntities();
            Assert.IsTrue(list.Count > 0);
            repositoryMock.Clear();
        }

        [TestMethod]
        public void Collection_returns_empty_if_nothing_added()
        {
            var list = _cartService.GetEntities();
            Assert.IsTrue(list.Count == 0);
            repositoryMock.Clear();
        }

        [TestMethod]
        public void Clear_collection_returns_empty()
        {
            repositoryMock.Clear();
            var list = _cartService.GetEntities();
            Assert.IsTrue(list.Count == 0);
        }

        [TestMethod]
        public void Add_group_to_collection_returns_equal()
        {
            _cartService.CreateEntity(testGroup);
            var list = _cartService.GetEntities();
            var firstOrDefault = _cartService.GetEntities().FirstOrDefault();
            Assert.IsTrue(testGroup.Id == firstOrDefault.Id);
            Assert.IsTrue(testGroup.GroupName == firstOrDefault.GroupName);
            Assert.IsTrue(testGroup.StudyYear == firstOrDefault.StudyYear);
            Assert.IsTrue(testGroup.MaxStudents == firstOrDefault.MaxStudents);
            repositoryMock.Clear();
        }

        [TestMethod]
        public void Remove_group_count_less()
        {
            _cartService.CreateEntity(testGroup);
            _cartService.CreateEntity(new GroupDto() { Id = Guid.NewGuid(), GroupName ="123", MaxStudents = 1, StudyYear = 2});
            _cartService.CreateEntity(new GroupDto() { Id = Guid.NewGuid(), GroupName = "123", MaxStudents = 1, StudyYear = 2 });
            var newId = Guid.NewGuid();
            _cartService.CreateEntity(new GroupDto() { Id = newId, GroupName = "123", MaxStudents = 1, StudyYear = 2 });
            var previousCount = _cartService.GetEntities().Count;
            _cartService.DeleteEntity(newId.ToString());
            Assert.AreEqual(previousCount-1, _cartService.GetEntities().Count);
            repositoryMock.Clear();
        }

        [TestMethod]
        public void Remove_group_item_removed()
        {
            _cartService.CreateEntity(testGroup);
            _cartService.CreateEntity(new GroupDto() { Id = Guid.NewGuid(), GroupName = "123", MaxStudents = 1, StudyYear = 2 });
            _cartService.CreateEntity(new GroupDto() { Id = Guid.NewGuid(), GroupName = "123", MaxStudents = 1, StudyYear = 2 });
            var newId = Guid.NewGuid();
            _cartService.CreateEntity(new GroupDto() { Id = newId, GroupName = "123", MaxStudents = 1, StudyYear = 2 });
            var previousCount = _cartService.GetEntities().Count;
            _cartService.DeleteEntity(newId.ToString());
            Assert.IsNull(_cartService.GetEntities().FirstOrDefault(item => item.Id == newId));
            repositoryMock.Clear();
        }


        [TestMethod]
        public void Update_group_collection_count_save()
        {
            _cartService.CreateEntity(testGroup);
            _cartService.CreateEntity(new GroupDto() { Id = Guid.NewGuid(), GroupName = "123", MaxStudents = 1, StudyYear = 2 });
            _cartService.CreateEntity(new GroupDto() { Id = Guid.NewGuid(), GroupName = "123", MaxStudents = 1, StudyYear = 2 });
            var newId = Guid.NewGuid();
            var entity = _cartService.CreateEntity(new GroupDto() { Id = newId, GroupName = "123", MaxStudents = 1, StudyYear = 2 });
            var previousCount = _cartService.GetEntities().Count;
            entity.GroupName = "12321321";
            var countOld = _cartService.GetEntities().Count;
            _cartService.UpdateEntity(entity);
            var countNew = _cartService.GetEntities().Count;
            Assert.AreEqual(countNew, countOld);
            repositoryMock.Clear();
        }

        [TestMethod]
        public void Update_group_in_collection_name_changed()
        {
            _cartService.CreateEntity(testGroup);
            _cartService.CreateEntity(new GroupDto() { Id = Guid.NewGuid(), GroupName = "123", MaxStudents = 1, StudyYear = 2 });
            _cartService.CreateEntity(new GroupDto() { Id = Guid.NewGuid(), GroupName = "123", MaxStudents = 1, StudyYear = 2 });
            var newId = Guid.NewGuid();
            var entity = _cartService.CreateEntity(new GroupDto() { Id = newId, GroupName = "123", MaxStudents = 1, StudyYear = 2 });
            entity.GroupName = "12321321";
            _cartService.UpdateEntity(entity);

            Assert.AreEqual(entity.GroupName, _cartService.GetEntities().FirstOrDefault(item => item.Id == newId).GroupName);

            repositoryMock.Clear();
        }
    }
}
