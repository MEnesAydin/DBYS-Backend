using System.Text.Json.Serialization;
using DerslikBilgiSistemi.Entity;

namespace Entities.Models;

public class CourseProgram
{
    public int Id { get; set; }
    [JsonConverter(typeof(DateOnlyJsonConverter))]
    public DateOnly Date { get; set; }
    public int SemesterId { get; set; }
    public Semester Semester { get; set; }

    public ICollection<CoursePosition> CoursePositions { get; set; }
}