
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Repositories;

namespace UserManagement.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user;

            if (request.IsAdmin)
            {
                user = new AdminUser(request.Name, request.Email);
            }
            else
            {
                user = new StandardUser(request.Name, request.Email);
            }

            await _userRepository.AddAsync(user);

            return user.Id;
        }
    }
}
