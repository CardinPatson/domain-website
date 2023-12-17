namespace Backend.Data
{
  public class DataContextSeed
  {
    public async Task SeedAsync(DataContext context)
    {
      if (!context.Content.Any())
      {
        await context.Content.AddRangeAsync(GetPreconfiguredContent());
        await context.SaveChangesAsync();
      }
    }

    private IEnumerable<Content> GetPreconfiguredContent()
    {
      return new List<Content>()
      {
        new()
        {
          ContTitle = "Bienvenue sur mon site",
          ContDescription = "Aujourd'hui on va s'envoler ensemble ..."
        }
      };
    }
  }
}