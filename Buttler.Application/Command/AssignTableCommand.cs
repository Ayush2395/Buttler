using Buttler.Application.DTOs;
using Buttler.Application.Repository;
using Domain.Models;
using MediatR;

namespace Buttler.Application.Command
{
    public class AssignTableCommand : IRequest<Tables>
    {
        public int CustomerId { get; set; }
        public TablesDto Tables { get; set; }
        public class Handler : IRequestHandler<AssignTableCommand, Tables>
        {
            readonly ITablesRepo _repo;

            public Handler(ITablesRepo repo)
            {
                _repo = repo;
            }

            public Task<Tables> Handle(AssignTableCommand request, CancellationToken cancellationToken)
            {
                return _repo.AssignTableToCustomer(request.Tables, request.CustomerId);
            }
        }
    }
}
