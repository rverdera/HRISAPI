namespace HRISAPI.Models.PDS;

[Table("Person", Schema = "PIM")]
public class Person : BaseModel
{
    [Key]
    public int PersonID { get; set; }

    [MaxLength(150)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(150)]
    public string MiddleName { get; set; } = string.Empty;

    [MaxLength(150)]
    public string LastName { get; set; } = string.Empty;

    [MaxLength(150)]
    public string ExtensionName { get; set; } = string.Empty;

    public CivilStatus? CivilStatus { get; set; } 
    public BloodType? BloodType { get; set; }

}
