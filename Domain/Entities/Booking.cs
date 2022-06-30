using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Booking
{
    [Column("BookingId")]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "CheckIn is a required field.")]
    public DateTime CheckIn { get; set; }
    [Required(ErrorMessage = "CheckOut is a required field.")]
    public DateTime CheckOut { get; set; }
    [Required(ErrorMessage = "Room id is a required field.")]
    public Guid RoomId { get; set; }
    public Room Room { get; set; } = default!;
    [Required(ErrorMessage = "Guest id is a required field.")]
    public Guid GuestId { get; set; }
    public Guest Guest { get; set; } = default!;
}
