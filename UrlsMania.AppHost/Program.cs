using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
    .WithImage("postgres", "17.0-alpine3.20")
    .WithLifetime(ContainerLifetime.Persistent);

builder.AddProject<UrlsMania_Server>("api")
    .WaitFor(postgres)
    .WithReference(postgres);

builder.Build().Run();