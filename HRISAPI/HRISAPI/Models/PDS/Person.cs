namespace HRISAPI.Models.PDS;

[Table("Person", Schema = "PDS")]
public class Person : BaseModel
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

    public CivilStatus CivilStatus { get; set; }
    public BloodType BloodType { get; set; }

}
