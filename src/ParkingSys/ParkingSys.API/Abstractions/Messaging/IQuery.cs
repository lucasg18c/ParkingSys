using MediatR;
using ParkingSys.API.Abstractions.Results;

namespace ParkingSys.API.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
