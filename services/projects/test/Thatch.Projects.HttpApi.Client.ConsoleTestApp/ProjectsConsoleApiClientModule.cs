﻿using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Thatch.Projects;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ProjectsHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class ProjectsConsoleApiClientModule : AbpModule
{

}
