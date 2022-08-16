namespace HRISAPI.Contracts.FM;

public interface ICivilStatusRepository : IBaseRepository<CivilStatus>
{
    void CreateCivilStatus(CivilStatus civilStatus);
}
