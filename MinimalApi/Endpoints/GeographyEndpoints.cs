using MinimalApi.Data;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Data;
using MinimalApi.Models;

namespace MinimalApi.Endpoints
{
    public static class GeographyEndpoints
    {
        public static async Task MapGeographyEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/geography");

            group.MapGet("/", async (ApplicationDbContext db) =>
            {
                var geography = await db.Geographies.ToListAsync();

                return Results.Ok(geography);
            });

            group.MapGet("/{id:int}", async (
                int id,
                ApplicationDbContext db) =>
            {
                var geography = await db.Geographies.FindAsync(id);

                if (geography is null)
                    return Results.NotFound();

                return Results.Ok(geography);
            });

            group.MapPost("/", async (Geography geography, ApplicationDbContext db) =>
            {
                db.Geographies.Add(geography);

                await db.SaveChangesAsync();

                return Results.Created($"/api/geography/{geography.Id}", geography);
            });

            group.MapDelete("/{id:int}", async (
            int id,
            ApplicationDbContext db) =>
            {
                var geography = await db.Geographies.FindAsync(id);

                if(geography == null)
                {
                    return Results.NotFound();
                }

                db.Geographies.Remove(geography);

                await db.SaveChangesAsync();

                return Results.NoContent();
            });
        }
    }
}
