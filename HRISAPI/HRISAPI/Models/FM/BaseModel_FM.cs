namespace HRISAPI.Models.FM;


public class BaseModel_FM : BaseModel
{
    [MaxLength(1000)]
    public string Description { get; set; }
}
