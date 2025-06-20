using Assessment.Model.Context;

namespace Assessment.Pages.cruds.utils;

public class Corrections
{
    public static bool isSameDate(TripContext context, int clientId, int touristPackageId, DateTime reservationDate)
    {
        return context.Reservations.Any(r =>
            r.ClientId == clientId &&
            r.TouristPackageId == touristPackageId &&
            r.ReservationDate.Date == reservationDate.Date);
    }
}