using WhereToEat.Services.IServices;
using WhereToEat.Services.Implementation;
using WhereToEat.Services.Models;

namespace WhereToEat.Tests
{
    public class CompanyTest
    {
        private ICompanyService companyService;
        [SetUp]
        public void Setup()
        {
            companyService = new CompanyService();
        }

        [Test]
        public void TestAddUser()
        {
            CompanyViewModel viewModel = new CompanyViewModel
            {
                CompanyName = "Comapny 1",
                RegisteredDate = DateTime.Now
            };
            viewModel = companyService.Add(viewModel);
            Assert.IsNotNull(viewModel.Id);
        }

        [Test]
        public void TestGetUserIsNotNull()
        {
            var id = Guid.NewGuid();
            var res = companyService.Get(id);
            Assert.IsNotNull(res);
        }

        [Test]
        public void TestGetAllUserIsNotNull()
        {
            var res = companyService.GetAll();
            Assert.IsNotNull(res);
        }

        [Test]
        public void TestGetAllUserCountIsGreaterThanZero()
        {
            var res = companyService.GetAll();
            Assert.IsTrue(res.Count > 0);
        }

        [Test]
        public void TestDeleteUserByUser()
        {
            CompanyViewModel viewModel = new CompanyViewModel
            {
                Id = Guid.Parse("efbd4589-6bb4-4693-8106-67f1968327d5"),
                CompanyName = "Comapny 1",
                RegisteredDate = DateTime.Now
            };
            bool res = companyService.Delete(viewModel);
            Assert.IsTrue(res);
        }

        [Test]
        public void TestDeleteUserByUserId()
        {
            Guid userId = Guid.Parse("efbd4589-6bb4-4693-8106-67f1968327d6");
            bool res = companyService.Delete(userId);
            Assert.IsTrue(res);
        }
    }
}