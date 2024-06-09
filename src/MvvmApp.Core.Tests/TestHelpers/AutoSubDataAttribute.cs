using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit2;

namespace MvvmApp.Core.Tests.TestHelpers
{
    public class AutoSubDataAttribute : AutoDataAttribute
    {
        public AutoSubDataAttribute()
            : base(() => new Fixture().Customize(new AutoNSubstituteCustomization())) { }
    }
}
