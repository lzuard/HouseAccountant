using WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
/*builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueFrontend", builder => builder
    .WithOrigins("http://localhost:8080")
    .AllowAnyMethod()
    .AllowAnyHeader());
});*/


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Auth middleWare is not ready yet
//app.UseMiddleware<AuthMiddleware>();

//app.UseHttpsRedirection();
app.UseRouting();

// Use CORES TODO: do not deploy in production
app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
