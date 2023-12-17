namespace Backend.Services
{

  public class ContentService
  {
    private readonly DataContext _context;

    public ContentService(DataContext context)
    {
      _context = context;
    }

        // public async Task<List<ContentDto>> GetContents()
        // {
        //   // Get the list of the contennt avec graphql
        // }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Content> GetContents([Service] DataContext context)
        {
          return context.Content;
        }
    }
}