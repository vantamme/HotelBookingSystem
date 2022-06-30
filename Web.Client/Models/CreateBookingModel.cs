using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Web.Client.Models;

public class CreateBookingModel
{
    [Required]
    public DateTime CheckIn { get; set; }
    [Required]
    public DateTime CheckOut { get; set; }
    [Required]
    public Guid RoomId { get; set; }
    [ValidateComplexType]
    public Guest Guest { get; set; } = default!;
}
