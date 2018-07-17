/*
 * Copyright (c) 2018 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 * 
 * http://github.com/tidyui/razorblog
 * 
 */

using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorBlog;
using RazorBlog.Http;
using RazorBlog.Services;

public static class BlogExtensions
{
    /// <summary>
    /// Adds the RazorBlog services.
    /// </summary>
    /// <param name="services">The service collection</param>
    /// <param name="options">The db options</param>
    /// <returns>The updated service collection</returns>
    public static IServiceCollection AddRazorBlog(this IServiceCollection services,
        Action<DbContextOptionsBuilder> options)
    {
        services.AddDbContext<Db>(options);
        services.AddScoped<IBlogService, BlogService>();

        return services;
    }

    /// <summary>
    /// Adds the RazorBlog to the application pipeline.
    /// </summary>
    /// <param name="builder">The application builder</param>
    /// <returns>The application builder</returns>
    public static IApplicationBuilder UseRazorBlog(this IApplicationBuilder builder)
    {
        return builder
            .UseMiddleware<BlogMiddleware>();
    }
}