using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Assessment.Model;

public class City
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório")]
    [MinLength(5, ErrorMessage = "O nome deve ter pelo menos 5 caracteres")]
    [DisplayName("Nome")]
    public string? Name { get; set; }

    [DisplayName("País")]
    [Required(ErrorMessage = " O país é obrigatório")]
    public string? Country { get; set; }
}