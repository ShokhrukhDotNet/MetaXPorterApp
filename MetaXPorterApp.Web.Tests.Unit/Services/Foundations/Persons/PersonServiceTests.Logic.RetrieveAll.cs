//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Linq;
using FluentAssertions;
using Force.DeepCloner;
using MetaXPorterApp.Web.Models.Foundations.Persons;
using Moq;

namespace MetaXPorterApp.Web.Tests.Unit.Services.Foundations.Persons
{
    public partial class PersonServiceTests
    {
        [Fact]
        public void ShouldRetrieveAllPeople()
        {
            // given
            IQueryable<Person> randomPerson = CreateRandomPeople();
            IQueryable<Person> storagePerson = randomPerson;
            IQueryable<Person> expectedPerson = storagePerson.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllPeople())
                    .Returns(storagePerson);

            // when
            IQueryable<Person> actualPerson =
                this.personService.RetrieveAllPeople();

            // then
            actualPerson.Should().BeEquivalentTo(expectedPerson);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllPeople(),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
