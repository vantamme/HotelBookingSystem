using System.ComponentModel.DataAnnotations;

namespace Web.Client.Models;

public class BookingPeriod : IValidatableObject
{
    public DateTime CheckIn { get; set; } = DateTime.Now;
    public DateTime CheckOut { get; set; } = DateTime.Today.AddDays(1);

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (CheckIn.Date < DateTime.Now.Date)
            yield return new ValidationResult("Check in date has to be in the future!");

        if (CheckOut.Date <= CheckIn.Date)
            yield return new ValidationResult("Check out date can't be earlier than check in date!");
    }
}
