using MediatR;
using ParkingSys.API.Abstractions.Results;

namespace ParkingSys.API.Abstractions.Messaging;

public interface ICommand : IRequest<Result>{}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>{}
