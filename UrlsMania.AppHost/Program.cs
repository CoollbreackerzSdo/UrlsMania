using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("redis")
    .WithPersistence()
    .WithLifetime(ContainerLifetime.Persistent)
.WithImage("redis","8.0-M02-alpine3.20");

builder.AddProject<UrlsMania_Server>("api")
    .WaitFor(redis)
    .WithReference(redis);

builder.Build().Run();