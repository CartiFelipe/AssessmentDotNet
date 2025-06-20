using Assessment.Model;
using Assessment.Model.Context;
using Assessment.Model.Service;
using Microsoft.EntityFrameworkCore;

public class ReservationValidator : IReservationValidator
{
    private readonly TripContext _context;

    public ReservationValidator(TripContext context)
    {
        _context = context;
    }

    public async Task<IList<string>> ValidateAsync(Reservation reservation)
    {
        var errors = new List<string>();


        if (reservation.ReservationDate == default) errors.Add("A data da reserva não pode ser nula ou inválida.");

        var exists = await _context.Reservations.AnyAsync(r =>
            r.ClientId == reservation.ClientId &&
            r.TouristPackageId == reservation.TouristPackageId &&
            r.ReservationDate.Date == reservation.ReservationDate.Date);

        if (exists) errors.Add("O cliente já reservou este pacote para esta data.");

        var clientsRegistered = await _context.Reservations
            .CountAsync(r => r.TouristPackageId == reservation.TouristPackageId);

        var package = await _context.TouristPackages
            .FirstOrDefaultAsync(p => p.Id == reservation.TouristPackageId);

        if (package != null && clientsRegistered >= package.MaximumPeople)
            errors.Add("O número máximo de clientes para este pacote foi atingido.");

        if (package.InitialDate < reservation.ReservationDate.Date)
            errors.Add("A data inicial do pacote não pode ser anterior a data da reserva.");

        return errors;
    }
}