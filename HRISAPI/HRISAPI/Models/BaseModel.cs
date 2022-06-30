namespace HRISAPI.Models;

public class BaseModel
{    
    public bool IsDel { get; set; } = false;
    [StringLength(20)]
    public string UserStamp { get; set; } = string.Empty;
    public DateTime DateStamp { get; set; } = DateTime.Now;
}
