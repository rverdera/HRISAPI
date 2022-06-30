namespace HRISAPI.Models.FM;

[Table("BloodType",Schema = "FM")]
public class BloodTypeModel : BaseModel_FM
{
    [Key]    
    public int BloodTypeID { get; set; }
    

}
