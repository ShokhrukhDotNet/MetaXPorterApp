//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System;
using System.Linq;
using System.Threading.Tasks;
using EFxceptions.Models.Exceptions;
using MetaXPorterApp.Web.Models.Foundations.Persons;
using MetaXPorterApp.Web.Models.Foundations.Persons.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Xeptions;

namespace MetaXPorterApp.Web.Services.Foundations.Persons
{
    public partial class PersonService
    {
        private delegate ValueTask<Person> ReturningPersonFunction();
        private delegate IQueryable<Person> ReturningPeopleFunction();

        private async ValueTask<Person> TryCatch(ReturningPersonFunction returningPersonFunction)
        {
            try
            {
                return await returningPersonFunction();
            }
            catch (NullPersonException nullPersonException)
            {
                throw CreateAndLogValidationException(nullPersonException);
            }
            catch (InvalidPersonException invalidPersonException)
            {
                throw CreateAndLogValidationException(invalidPersonException);
            }
            catch (SqlException sqlException)
            {
                var failedPersonStorageException = new FailedPersonStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedPersonStorageException);
            }
            catch (NotFoundPersonException notFoundPersonException)
            {
                throw CreateAndLogValidationException(notFoundPersonException);
            }
            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                var lockedPersonException = new LockedPersonException(dbUpdateConcurrencyException);

                throw CreateAndLogDependencyValidationException(lockedPersonException);
            }
            catch (DbUpdateException dbUpdateException)
            {
                var failedPersonStorageException = new FailedPersonStorageException(dbUpdateException);

                throw CreateAndLogDependencyException(failedPersonStorageException);
            }
            catch (DuplicateKeyException duplicateKeyException)
            {
                var alreadyExistPersonException =
                    new AlreadyExistPersonException(duplicateKeyException);

                throw CreateAndLogDependencyValidationException(alreadyExistPersonException);
            }
            catch (Exception exception)
            {
                var failedPersonServiceException =
                    new FailedPersonServiceException(exception);

                throw CreateAndLogServiceException(failedPersonServiceException);
            }
        }

        private IQueryable<Person> TryCatch(ReturningPeopleFunction returningPeopleFunction)
        {
            try
            {
                return returningPeopleFunction();
            }
            catch (SqlException sqlException)
            {
                var failedPersonStorageException =
                    new FailedPersonStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedPersonStorageException);
            }
            catch (Exception exception)
            {
                var failedPersonServiceException =
                    new FailedPersonServiceException(exception);

                throw CreateAndLogServiceException(failedPersonServiceException);
            }
        }

        private PersonValidationException CreateAndLogValidationException(Xeption exception)
        {
            var personValidationException =
                new PersonValidationException(exception);

            this.loggingBroker.LogError(personValidationException);

            return personValidationException;
        }

        private PersonDependencyException CreateAndLogCriticalDependencyException(Xeption exception)
        {
            var personDependencyException = new PersonDependencyException(exception);
            this.loggingBroker.LogCritical(personDependencyException);

            return personDependencyException;
        }

        private PersonDependencyValidationException CreateAndLogDependencyValidationException(
            Xeption exception)
        {
            var personDependencyValidationException =
                new PersonDependencyValidationException(exception);

            this.loggingBroker.LogError(personDependencyValidationException);

            return personDependencyValidationException;
        }

        private PersonDependencyException CreateAndLogDependencyException(Xeption exception)
        {
            var personDependencyException = new PersonDependencyException(exception);
            this.loggingBroker.LogError(personDependencyException);

            return personDependencyException;
        }

        private PersonServiceException CreateAndLogServiceException(Xeption exception)
        {
            var personServiceException = new PersonServiceException(exception);
            this.loggingBroker.LogError(personServiceException);

            return personServiceException;
        }
    }
}
