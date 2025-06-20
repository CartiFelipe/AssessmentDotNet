namespace Assessment.Model.Service;

public interface IReservationValidator
{
    Task<IList<string>> ValidateAsync(Reservation reservation);
}