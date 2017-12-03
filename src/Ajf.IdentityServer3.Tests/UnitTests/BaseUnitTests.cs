using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Ajf.IdentityServer3.Tests.UnitTests
{
    public class BaseUnitTests
    {
        protected Fixture _fixture;

        [SetUp]
        public virtual void SetUp()
        {
            _fixture = new Fixture();
        }
    }
}