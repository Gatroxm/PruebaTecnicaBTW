
using System.Collections.Generic;
using MediatR;
using UserManagement.Application.DTOs;

namespace UserManagement.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserDto>>
    {
    }
}
