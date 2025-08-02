using Common;
using Persistence.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Persistence.Entities;

public class HomePagePhoto : IEntity
{
    [Key]
    public int Id { get; set; }
    public string Url { get; set; }
    public string? Title { get; set; }
    public HomePagePhotoCategory Category { get; set; }
}
