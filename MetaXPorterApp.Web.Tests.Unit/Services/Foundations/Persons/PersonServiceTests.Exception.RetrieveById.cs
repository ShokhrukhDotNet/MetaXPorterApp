//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using System.Threading.Tasks;
using FluentAssertions;
using MetaXPorterApp.Web.Models.Foundations.Persons;
using MetaXPorterApp.Web.Models.Foundations.Persons.Exceptions;
using Microsoft.Data.SqlClient;
using Moq;

namespace MetaXPorterApp.Web.Tests.Unit.Services.Foundations.Persons
{
    public partial class PersonServiceTests
    {
        [Fact]
        public async Task ShouldThrowCriticalDependencyExceptionOnRetrieveByIdIfSqlErrorOccursAndLogItAsync()
        {
            // given
            Guid someId = Guid.NewGuid();
            SqlException sqlException = GetSqlError();

            var failedPersonStorageException =
                new FailedPersonStorageException(sqlException);

            PersonDependencyException expectedPersonDependencyException =
                new PersonDependencyException(failedPersonStorageException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectPersonByIdAsync(It.IsAny<Guid>()))
                    .ThrowsAsync(sqlException);

            // when
            ValueTask<Person> retrievePersonById =
                this.personService.RetrievePersonByIdAsync(someId);

            PersonDependencyException actualPersonDependencyException =
                await Assert.ThrowsAsync<PersonDependencyException>(
                    retrievePersonById.AsTask);

            // then
            actualPersonDependencyException.Should()
                .BeEquivalentTo(expectedPersonDependencyException);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectPersonByIdAsync(someId), Times.Once());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogCritical(It.Is(SameExceptionAs(
                    expectedPersonDependencyException))), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnRetrieveByIdAsyncIfServiceErrorOccursAndLogItAsync()
        {
            // given
            Guid someId = Guid.NewGuid();
            Exception serverException = new Exception();

            var failedPersonServiceException =
                new FailedPersonServiceException(serverException);

            PersonServiceException expectedPersonServiceException =
                new PersonServiceException(failedPersonServiceException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectPersonByIdAsync(It.IsAny<Guid>()))
                    .ThrowsAsync(serverException);

            // when
            ValueTask<Person> retrievePersonById =
                this.personService.RetrievePersonByIdAsync(someId);

            PersonServiceException actualPersonServiceException =
                await Assert.ThrowsAsync<PersonServiceException>(
                    retrievePersonById.AsTask);

            // then
            actualPersonServiceException.Should().BeEquivalentTo(expectedPersonServiceException);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectPersonByIdAsync(someId), Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedPersonServiceException))), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
