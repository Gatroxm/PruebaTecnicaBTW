
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UserManagement.Application.DTOs;
using UserManagement.Domain.Repositories;

namespace UserManagement.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();
            
            // In a real app, use AutoMapper. Doing manual mapping for simplicity here.
            return users.Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = (string)u.Email,
                Role = u.GetRole(),
                IsActive = u.IsActive
            });
        }
    }
}
