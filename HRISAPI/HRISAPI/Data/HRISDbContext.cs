using HRISAPI.Models.PDS;

namespace HRISAPI.Data;

public class HRISDbContext : DbContext
{
    public HRISDbContext(DbContextOptions<HRISDbContext> options) : base(options) { }

    public virtual DbSet<PersonModel> Person { get; set; } = null!;
    public virtual DbSet<BloodTypeModel> BloodType { get; set; } = null!;
    public virtual DbSet<CivilStatusModel> CivilStatus { get; set; } = null!;

}