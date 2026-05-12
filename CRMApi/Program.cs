using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection'");
builder.Services.AddDbContext<CRM.DataAccess.ApplicationDbContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(c => {c.SwaggerDoc("v1", new OpenApiInfo { Title = "CRM API", Version = "v1" });});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CRM API v1"));
}


app.UseHttpRedirection();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.Rum();

