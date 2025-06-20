using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Assessment.Model;

public class TouristPackage
{
    public int Id { get; set; }

    [DisplayName("Titulo")]
    [Required(ErrorMessage = "O campo Titulo é obrigatório.")]
    public string? Title { get; set; }

    [DisplayName("Data Inicial")] public DateTime InitialDate { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "O campo Capacidade Máxima é obrigatório.")]
    [DisplayName("Capacidade Máxima")]
    public int? MaximumPeople { get; set; }

    [Required(ErrorMessage = "O campo Preço é obrigatório.")]
    [DisplayName("Preço")]
    public decimal? Price { get; set; }

    public List<City>? Cities { get; set; }
}