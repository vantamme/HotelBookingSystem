namespace Web.Client.Models;

public class BookingModel
{
    public Guid Id { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public Guid RoomId { get; set; }
    public RoomModel? Room { get; set; }
    public Guid GuestId { get; set; }
    public GuestModel? Guest { get; set; }
}
