using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace Repositories.EFCore.Extensions;

public static class CourseProgramExtensions
{
    public static IQueryable<CourseProgram>? IdFilter(this IQueryable<CourseProgram>? query, int id)
    {
        if (id != 0)
        {
            return query.Where(cp => cp.Id == id);
        }
        else
        {
            return query;
        }
    }
    public static IQueryable<CourseProgram> DateFilter(this IQueryable<CourseProgram>? query,
        CourseProgramParameters parameters)
    {
        if (parameters.Id == 0)
        {
            if (parameters.Date == DateOnly.MinValue)
            {
                DateOnly today = DateOnly.FromDateTime(DateTime.Today);
                return query
                    .Where(cp => cp.Date < today)
                    .OrderByDescending(cp => cp.Date)
                    .ThenByDescending(cp => cp.Id);
            }
            //DateOnly monday = today.AddDays(-(((int)today.DayOfWeek - (int)DayOfWeek.Monday + 7) % 7));
            return query
                .Where(cp => cp.Date <= parameters.Date)
                .OrderByDescending(cp => cp.Date)
                .ThenByDescending(cp => cp.Id);
        }

        return query;

    }

    public static IQueryable<CourseProgram> FacultyFilter(this IQueryable<CourseProgram>? query, int id)
    {
        if (id == 0)
        {
            return query;
        }

        return query.Include(cp => cp.CoursePositions)
            .ThenInclude(cp => cp.ClassRoom)
            .Where(cp => cp.CoursePositions.Any(c => c.ClassRoom.FacultyId == id));
    }
}