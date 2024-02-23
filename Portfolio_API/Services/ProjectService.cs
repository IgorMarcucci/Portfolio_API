using AutoMapper;

namespace Portfolio_API;

public class ProjectService
{
    private readonly ApplicationDatabaseContext _db;
    private readonly IMapper _mapper;

    public ProjectService(ApplicationDatabaseContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    
    
}
