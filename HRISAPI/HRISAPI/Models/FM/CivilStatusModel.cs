namespace HRISAPI.Models.FM;

[Table("CivilStatus", Schema = "FM")]
public class CivilStatusModel : BaseModel_FM
{
    [Key]    
    public int CivilStatusID { get; set; }
    
}
