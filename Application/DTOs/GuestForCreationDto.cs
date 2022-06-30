using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class GuestForCreationDto
{
    [Required(ErrorMessage = "Guest first name is a required field.")]
    public string FirstName { get; set; } = default!;
    [Required(ErrorMessage = "Guest last name is a required field.")]
    public string LastName { get; set; } = default!;
    [Required(ErrorMessage = "Guest email is a required field.")]
    public string Email { get; set; } = default!;
    [Required(ErrorMessage = "Guest personal code is a required field.")]
    public ulong PersonalCode { get; set; }
}
