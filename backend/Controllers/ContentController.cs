namespace Backend.Controllers
{
  [ApiController]
  [Route("api/v1/[controller]")]

  public class ContentController : ControllerBase
  {
    // Set up the service
    private readonly ContentService _contentService;
    private readonly DataContext _context;
    public ContentController(ContentService contentService, DataContext context)
    {
      _contentService = contentService;
      _context = context;

    }

    [HttpGet]
    public ActionResult<List<Content>> GetContents()
    {
      return _contentService.GetContents(_context).ToList();
    }
  }
}