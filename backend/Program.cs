var builder = WebApplication.CreateBuilder(args);
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CardinDB")));

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
// builder.Services.AddAutoMapper(typeof(Program).Assembly);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

System.Reflection.Assembly assembly = typeof(Program).Assembly;
IEnumerable<Type> types = assembly.ExportedTypes
            .Where(x => x.IsClass && x.IsPublic);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

builder.Services.AddTransient<ContentService, ContentService>();

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
            {
                policy.WithOrigins("http://localhost:3000", "cardintiako.com"); // allow multiple origins (domain name tweetz.com)
                policy.AllowAnyMethod();
                policy.AllowCredentials();
            });
});
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//CORS POLICY
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();
app.MapControllers();
app.MapGraphQL("/graphql");


if (app.Environment.IsDevelopment())
{
    using IServiceScope scope = app.Services.CreateScope();
    DataContext context = scope.ServiceProvider.GetRequiredService<DataContext>();
    ILogger<DataContextSeed>? logger = app.Services.GetService<ILogger<DataContextSeed>>();
    await context.Database.MigrateAsync();

    await new DataContextSeed().SeedAsync(context);
    // await integEventContext.Database.MigrateAsync();
}

app.Run();


