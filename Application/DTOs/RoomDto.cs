namespace Application.DTOs;

public class RoomDto
{
    public Guid Id { get; set; }
    public int RoomNr { get; set; }
    public decimal Price { get; set; }
    public int Capacity { get; set; }
}
