using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Assessment.Model;

public class Reservation
{
    [Key] public int Id { get; set; }

    [DisplayName("Cliente")]
    [Required(ErrorMessage = "O cliente é obrigatório")]

    public int? ClientId { get; set; }

    public Client? Client { get; set; } = default!;


    [DisplayName("Pacote Turístico")]
    [Required(ErrorMessage = "O pacote turístico é obrigatório")]
    public int? TouristPackageId { get; set; }


    public TouristPackage? TouristPackage { get; set; } = default!;


    [DisplayName("Data da Reserva")] public DateTime ReservationDate { get; set; } = default;
}