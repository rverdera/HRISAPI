namespace HRISAPI.Data;

public class HRISDbContext : DbContext
{
    public HRISDbContext(DbContextOptions<HRISDbContext> options) : base(options) { }

    public virtual DbSet<Person> Persons { get; set; } = null!;
    public virtual DbSet<BloodType> BloodTypes { get; set; } = null!; 
    public virtual DbSet<CivilStatus> CivilStatuses { get; set; } = null!; 

} 