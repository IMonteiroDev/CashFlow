using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Exception;
using CommonTestUtilities.Requests; // substitua pelo namespace correto
using FluentAssertions;

namespace Validators.Tests.Expenses.Register
{
    public class RegisterExpenseValidatorTests
    {
        [Fact]
        public void Success()
        {
            // Arrange
            var validator = new ExpenseValidator();
            var request = RequestRegisterExpenseJsonBuilder.Build();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void ErrorTitleEmpty()
        {
            // Arrange
            var validator = new ExpenseValidator();
            var request = RequestRegisterExpenseJsonBuilder.Build();
            request.Title = string.Empty;

            // Act
            var result = validator.Validate(request);

            // Assert
            result.IsValid.Should().BeFalse();
            result
                .Errors.Should()
                .ContainSingle()
                .And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessage.TITLE_REQUIRED));
        }

        [Fact]
        public void ErrorDateFuture()
        {
            // Arrange
            var validator = new ExpenseValidator();
            var request = RequestRegisterExpenseJsonBuilder.Build();
            request.Date = DateTime.UtcNow.AddDays(1);

            // Act
            var result = validator.Validate(request);

            // Assert
            result.IsValid.Should().BeFalse();
            result
                .Errors.Should()
                .ContainSingle()
                .And.Contain(e =>
                    e.ErrorMessage.Equals(ResourceErrorMessage.EXPENSES_CANNOT_FOR_THE_FUTURE)
                );
        }

        [Fact]
        public void ErrorInvalidPaymentType()
        {
            // Arrange
            var validator = new ExpenseValidator();
            var request = RequestRegisterExpenseJsonBuilder.Build();
            request.PaymentType = (PaymentType)4;

            // Act
            var result = validator.Validate(request);

            // Assert
            result.IsValid.Should().BeFalse();
            result
                .Errors.Should()
                .ContainSingle()
                .And.Contain(e =>
                    e.ErrorMessage.Equals(ResourceErrorMessage.PAYMENT_TYPE_IS_NOT_VALID)
                );
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-7)]
        public void ErrorAmount(decimal amount)
        {
            // Arrange
            var validator = new ExpenseValidator();
            var request = RequestRegisterExpenseJsonBuilder.Build();
            request.Amount = amount;

            // Act
            var result = validator.Validate(request);

            // Assert
            result.IsValid.Should().BeFalse();
            result
                .Errors.Should()
                .ContainSingle()
                .And.Contain(e =>
                    e.ErrorMessage.Equals(ResourceErrorMessage.AMOUNT_MUST_BE_GREATER_THAN_ZERO)
                );
        }
    }
}
