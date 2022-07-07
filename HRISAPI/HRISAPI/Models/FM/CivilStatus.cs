namespace HRISAPI.Models.FM;

[Table("CivilStatus", Schema = "FM")]
public class CivilStatus : BaseModel_FM
{
    [Key]    
    public int CivilStatusID { get; set; }

    
    
}
