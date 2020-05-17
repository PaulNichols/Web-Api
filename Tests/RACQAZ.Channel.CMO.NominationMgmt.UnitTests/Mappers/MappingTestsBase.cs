namespace RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1.UnitTests
{
    using Helper.Library.Services;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using Moq;
    using System;
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public abstract class MappingTestsBase
    {
        protected Guid expectedCorrelationId;
        protected Mock<IActionContextAccessor> mockActionContextAccessor;
        protected Mock<IClockService> mockClock;

        public MappingTestsBase() => MockRepository = new MockRepository(MockBehavior.Default);

        public MockRepository MockRepository { get; set; }

        // public void Dispose() => this.MockRepository.VerifyAll();

        public T Resolve<T>() => (T)Resolve(typeof(T));

        protected object Resolve(Type type)
        {
            return null;
        }
    }
}