using System.ComponentModel.DataAnnotations;
namespace sithecapi.models;

public class HumanoModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nombre { get; set; }

    public string Sexo { get; set; }

    [Required]
    public int Edad { get; set; }

    public float Altura {get; set;}

    public float Peso {get; set;}
}
