namespace HRISAPI.Models;

public class PersonModel : BaseModel
{
    [Key]
    public int PersonID { get; set; }
    [StringLength(150)]
    public string FirstName { get; set; }
    [StringLength(150)]
    public string MiddleName { get; set; }
    [StringLength(150)]
    public string LastName { get; set; }
    [StringLength(150)]
    public string ExtensionName { get; set; }
}
