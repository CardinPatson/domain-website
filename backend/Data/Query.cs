public class Query
{
  // public Content GetContent() =>
  //   new()
  //   {
  //     ContTitle = "This is the Title",
  //     ContDescription = "This is the description"
  //   };

  // post request sur http://localhost:5247/graphql/ avec comme corps : {query {contents{contId, contDescription} }}
  [UseProjection]
  [UseFiltering]
  [UseSorting]
  public IQueryable<Content> GetContents([Service] DataContext context) =>
    context.Content;


}