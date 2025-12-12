using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UserManagement.Domain.Repositories;

namespace UserManagement.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
            {
                return;
            }

            user.UpdateDetails(request.Name, request.Email);
            await _userRepository.UpdateAsync(user);
        }
    }
}
