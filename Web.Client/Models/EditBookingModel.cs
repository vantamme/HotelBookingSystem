using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Web.Client.Models;

public class EditBookingModel
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public DateTime CheckIn { get; set; }
    [Required]
    public DateTime CheckOut { get; set; }
    [Required]
    public Guid RoomId { get; set; }
    [Required]
    public Guid GuestId { get; set; }
    [ValidateComplexType]
    public Guest Guest { get; set; } = default!;
}
