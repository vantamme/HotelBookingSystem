using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class BookingManipulationDto : IValidatableObject
{
    [Required(ErrorMessage = "CheckIn is a required field.")]
    public DateTime CheckIn { get; set; }
    [Required(ErrorMessage = "CheckOut is a required field.")]
    public DateTime CheckOut { get; set; }
    [Required(ErrorMessage = "Guest is a required field.")]
    public Guest Guest { get; set; } = default!;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (CheckIn.Date < DateTime.Now.Date)
            yield return new ValidationResult("Check in date has to be in the future!");

        if (CheckOut.Date <= CheckIn.Date)
            yield return new ValidationResult("Check out date can't be earlier than check in date!");
    }
}
