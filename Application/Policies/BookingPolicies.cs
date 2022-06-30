namespace Application.Policies;

public static class BookingPolicies
{
    public static bool CanBeDeleted(DateTime checkInDate) =>
        checkInDate > DateTime.Now.AddDays(3);
}
