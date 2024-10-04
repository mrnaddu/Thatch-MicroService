var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Thatch_AuthServer>("thatch-authserver", launchProfileName: "Thatch.AuthServer");

builder.AddProject<Projects.Thatch_Administration_HttpApi_Host>("thatch-administration-httpapi-host", launchProfileName: "Thatch.Administration.Host");

builder.AddProject<Projects.Thatch_IdentityService_HttpApi_Host>("thatch-identityservice-httpapi-host", launchProfileName: "Thatch.IdentityService.Host");

builder.Build().Run();