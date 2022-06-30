namespace Application.DTOs;

public class BookingDto
{
    public Guid Id { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public Guid RoomId { get; set; }
    public Guid GuestId { get; set; }
}
