using Domain.Validators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Guest
{
    [Column("GuestId")]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Guest first name is a required field.")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Guest last name is a required field.")]
    public string LastName { get; set; }
    [Required(ErrorMessage = "Guest email is a required field.")]
    [EmailAddress(ErrorMessage = "Not valid email address.")]
    public string Email { get; set; }
    [PersonalCodeValidator]
    public long PersonalCode { get; set; }
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public Guest(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
}
