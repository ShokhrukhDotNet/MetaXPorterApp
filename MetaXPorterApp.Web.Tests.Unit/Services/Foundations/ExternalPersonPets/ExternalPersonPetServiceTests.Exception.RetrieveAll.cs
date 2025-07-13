//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using MetaXPorterApp.Web.Models.Foundations.ExternalPersons;
using MetaXPorterApp.Web.Models.Foundations.ExternalPersons.Exceptions;
using Moq;

namespace MetaXPorterApp.Web.Tests.Unit.Services.Foundations.ExternalPersonPets
{
    public partial class ExternalPersonPetServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrieveIfIOExceptionOccursAndLogItAsync()
        {
            // given
            var ioException = new IOException();

            var failedExternalPersonPetDependencyException =
                new FailedExternalPersonPetDependencyException(ioException);

            var expectedExternalPersonPetDependencyException =
                new ExternalPersonPetDependencyException(failedExternalPersonPetDependencyException);

            this.sheetBrokerMock.Setup(broker =>
                broker.ReadAllExternalPersonPetsAsync())
                    .ThrowsAsync(ioException);

            // when
            ValueTask<List<ExternalPerson>> retrieveAllExternalPersonPetsTask =
                this.externalPersonPetService.RetrieveAllExternalPersonPetsAsync();

            ExternalPersonPetDependencyException actualExternalPersonPetDependencyException =
                await Assert.ThrowsAsync<ExternalPersonPetDependencyException>(
                    retrieveAllExternalPersonPetsTask.AsTask);

            // then
            actualExternalPersonPetDependencyException.Should()
                .BeEquivalentTo(expectedExternalPersonPetDependencyException);

            this.sheetBrokerMock.Verify(broker =>
                broker.ReadAllExternalPersonPetsAsync(), Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedExternalPersonPetDependencyException))), Times.Once);

            this.sheetBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnRetrieveIfServiceErrorOccursAndLogItAsync()
        {
            // given
            string exceptionMessage = GetRandomString();
            var serviceException = new Exception(exceptionMessage);

            var failedExternalPersonPetServiceException =
                new FailedExternalPersonPetServiceException(serviceException);

            var expectedExternalPersonPetServiceException =
                new ExternalPersonPetServiceException(failedExternalPersonPetServiceException);

            this.sheetBrokerMock.Setup(broker =>
                broker.ReadAllExternalPersonPetsAsync())
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<List<ExternalPerson>> retrieveAllExternalPersonPetsTask =
                this.externalPersonPetService.RetrieveAllExternalPersonPetsAsync();

            ExternalPersonPetServiceException actualExternalPersonPetServiceException =
                await Assert.ThrowsAsync<ExternalPersonPetServiceException>(
                    retrieveAllExternalPersonPetsTask.AsTask);

            // then
            actualExternalPersonPetServiceException.Should()
                .BeEquivalentTo(expectedExternalPersonPetServiceException);

            this.sheetBrokerMock.Verify(broker =>
                broker.ReadAllExternalPersonPetsAsync(), Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedExternalPersonPetServiceException))), Times.Once);

            this.sheetBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
