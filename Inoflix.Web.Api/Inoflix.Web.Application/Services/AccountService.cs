using FluentValidation;
using Inoflix.Web.Application.Contracts.Service;
using Inoflix.Web.Application.Features.Users.Command;
using Inoflix.Web.Application.Helpers;
using MediatR;

namespace Inoflix.Web.Application.Services
{
    [InoflixDIRegistyService(typeof(IAccountService), LifetimeOfService.Scoped)]
    public class AccountService : IAccountService
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreateUserCommand> _validator;
        public AccountService(IMediator mediator, IValidator<CreateUserCommand> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        public async Task<CreateUserResponse> CreateUserAsync(CreateUserCommand request)
        {
            var validator = _validator.Validate(request);

            if (!validator.IsValid)
                return new CreateUserResponse
                {
                    IsSuccess = validator.IsValid,
                    Messages = { validator.Errors.FirstOrDefault()?.ErrorMessage }
                };

            return await _mediator.Send(request);
        }

        public bool TestMethod()
        {
            return true;
        }
    }
}
