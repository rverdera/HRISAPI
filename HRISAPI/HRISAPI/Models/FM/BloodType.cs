namespace HRISAPI.Models.FM;

[Table("BloodType",Schema = "FM")]
public class BloodType : BaseModel_FM
{
    [Key]    
    public int BloodTypeID { get; set; }
    
}
