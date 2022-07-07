namespace HRISAPI.Models;

public class BaseModel
{
    [DefaultValue(true)]
    public bool IsActive { get; set; } = true;

    [DefaultValue(false)]
    public bool IsDel { get; set; } = false;

    [MaxLength(20)]
    public string UserStamp { get; set; } = string.Empty;

    [Column(TypeName = "datetime")]
    public DateTime DateTimeStamp { get; set; } = DateTime.Now;
}
