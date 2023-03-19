using System.ComponentModel.DataAnnotations;

namespace TORO.Shared.Requests;

public class ProduccionCreateRequest
{
    [Required(ErrorMessage ="Se debe proporcionar la fecha de la producción.")]
    public DateTime FechaProd { get; set; } = DateTime.Now;
    [Required(ErrorMessage ="Se debe proporcionar la cantidad de vacas en producción.")]
    public int VacasProd { get; set; }
    [Required(ErrorMessage ="Se debe proporcionar la cantidad de litros de leche.")]
    public int LitrosLeche { get; set; }
}

public class ProduccionUpdateRequest:ProduccionCreateRequest
{
    [Required(ErrorMessage ="Se debe proporcionar el Id de la producción a modificar.")]
    public int ID { get; set; }
}