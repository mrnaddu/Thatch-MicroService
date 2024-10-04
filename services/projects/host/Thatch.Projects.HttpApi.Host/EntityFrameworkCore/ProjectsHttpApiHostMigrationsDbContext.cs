﻿using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Thatch.Projects.EntityFrameworkCore;

public class ProjectsHttpApiHostMigrationsDbContext : AbpDbContext<ProjectsHttpApiHostMigrationsDbContext>
{
    public ProjectsHttpApiHostMigrationsDbContext(DbContextOptions<ProjectsHttpApiHostMigrationsDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureProjects();
    }
}