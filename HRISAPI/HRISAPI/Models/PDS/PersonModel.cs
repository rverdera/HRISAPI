namespace HRISAPI.Models.PDS;

[Table("Person", Schema = "PDS")]
public class PersonModel : BaseModel
{
    [Key]
    public int PersonID { get; set; }
    [MaxLength(150)]
    public string FirstName { get; set; }
    [MaxLength(150)]
    public string MiddleName { get; set; }
    [MaxLength(150)]
    public string LastName { get; set; }
    [MaxLength(150)]
    public string ExtensionName { get; set; }

    [ForeignKey("CivilStatusID")]
    public int CivilStatusID { get; set; }

    [ForeignKey("BloodTypeID")]
    public int BloodTypeID { get; set; }

    public CivilStatusModel CivilStatus { get; set; }
    public BloodTypeModel BloodType { get; set; }

}
