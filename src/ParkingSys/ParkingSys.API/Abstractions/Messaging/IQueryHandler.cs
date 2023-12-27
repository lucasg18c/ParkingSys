using MediatR;
using ParkingSys.API.Abstractions.Results;

namespace ParkingSys.API.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>> 
    where TQuery : IQuery<TResponse>
{
}
