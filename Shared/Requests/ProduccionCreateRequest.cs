using System.ComponentModel.DataAnnotations;

namespace TORO.Shared.Requests;

public class ProduccionCreateRequest
{
    public DateTime FechaProd { get; set; } = DateTime.Now;
    public int VacasProd { get; set; }
    public int LitrosLeche { get; set; }
}

public class ProduccionUpdateRequest:ProduccionCreateRequest
{
    [Required(ErrorMessage ="Se debe proporcionar el Id de la producción a modificar.")]
    public int ID { get; set; }
}