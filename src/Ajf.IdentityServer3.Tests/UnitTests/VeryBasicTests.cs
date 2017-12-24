using System.Configuration;
using Ajf.IdentityServer3.Models;
using NUnit.Framework;

namespace Ajf.IdentityServer3.Tests.UnitTests
{
    [TestFixture]
    public class VeryBasicTests : BaseUnitTests
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
        }

        [Test]
        public void EnsureDependingProjectGetsBuildPriorToTest()
        {
            //// Arrange
            //var eventRepository = MockRepository.GenerateMock<IEventRepository>();
            //var events = _fixture.CreateMany<Event>().ToArray();
            //eventRepository.Expect(x => x.GetEvents()).Return(events);
            //var eventService = new EventService(eventRepository);

            //// Act
            //var result = eventService.GetEvents();
            new CreateUserAccountModel();
            new Ajf.IdentityServer3.Migrate.Configuration();

            //// Assert
            //Assert.AreEqual(events, result);
        }
    }
}