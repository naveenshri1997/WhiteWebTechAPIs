using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;

namespace WhiteWebTech.API.Entities;

public partial class NewQuery
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Mobile { get; set; }

    public string? Query { get; set; }
}


public static class NewQueryEndpoints
{
	public static void MapNewQueryEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/NewQuery").WithTags(nameof(NewQuery));

        group.MapGet("/", () =>
        {
            return new [] { new NewQuery() };
        })
        .WithName("GetAllNewQueries")
        .WithOpenApi();

        group.MapGet("/{id}", (int id) =>
        {
            //return new NewQuery { ID = id };
        })
        .WithName("GetNewQueryById")
        .WithOpenApi();

        group.MapPut("/{id}", (int id, NewQuery input) =>
        {
            return TypedResults.NoContent();
        })
        .WithName("UpdateNewQuery")
        .WithOpenApi();

        group.MapPost("/", (NewQuery model) =>
        {
            //return TypedResults.Created($"/api/NewQueries/{model.ID}", model);
        })
        .WithName("CreateNewQuery")
        .WithOpenApi();

        group.MapDelete("/{id}", (int id) =>
        {
            //return TypedResults.Ok(new NewQuery { ID = id });
        })
        .WithName("DeleteNewQuery")
        .WithOpenApi();
    }
}