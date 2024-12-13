namespace UrlsMania.Server.Common.Handler;

public interface IHandler<TRequest, TResponse>
{
    Result<TResponse> Handle(TRequest request);
    Task<Result<TResponse>> HandleAsync(TRequest request, CancellationToken token = default);
}
public interface IRequestHandler<TRequest>
{
    Result Handle(TRequest request);
    Task<Result> HandleAsync(TRequest request, CancellationToken token = default);
}
public interface IResponseHandler<TResponse>
{
    Result<TResponse> Handle();
    Task<Result<TResponse>> HandleAsync(CancellationToken token = default);
}