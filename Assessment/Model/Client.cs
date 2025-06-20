using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Assessment.Model;

public class Client
{
    public int Id { get; set; }

    [DisplayName("Nome")]
    [Required(ErrorMessage = "O nome é obrigatório")]
    public string? Name { get; set; }

    [DisplayName("E-mail")]
    [Required(ErrorMessage = "O e-mail é obrigatório")]
    public string? Email { get; set; }

    public List<Reservation>? Reservations { get; set; }
}