using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Room
{
    [Column("RoomId")]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Room number is a required field.")]
    public int RoomNr { get; set; }
    [Required(ErrorMessage = "Room price is a required field.")]
    public decimal Price { get; set; }
    [Required(ErrorMessage = "Room capacity is a required field.")]
    public int Capacity { get; set; }
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
