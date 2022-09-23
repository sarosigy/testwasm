var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://*:7878");

string CorsPolicyName = "CliCors";
// Add services to the container.

// Different hosting url of Api and WASM App, so it is required
builder.Services.AddCors(options =>
{
    options.AddPolicy(CorsPolicyName, policy =>
    {
        policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(CorsPolicyName);

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
