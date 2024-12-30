namespace UrlsMania.Server.Common.Handler;

public interface IHandler<TRequest, TResponse>
{
    Task<Result<TResponse>> HandleAsync(TRequest request, CancellationToken token = default);
}
public interface IRequestHandler<TRequest>
{
    Task<Result> HandleAsync(TRequest request, CancellationToken token = default);
}
public interface IResponseHandler<TResponse>
{
    Task<Result<TResponse>> HandleAsync(CancellationToken token = default);
}