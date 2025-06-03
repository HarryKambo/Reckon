using Polly;
using Reckon.Core;
using Reckon.Core.Interfaces;
using Reckon.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IResultsService, ResultService>();
builder.Services.AddTransient<IReckonApiService, ReckonApiService>();

builder.Services.AddCors(options => {
    options.AddPolicy("AllowAllOrigins", policy => {
        policy.AllowAnyOrigin();
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    });
});

builder.Services.AddHttpClient<ReckonApiClient>().AddPolicyHandler(
    Policy.HandleResult<HttpResponseMessage>(
        response  => !response.IsSuccessStatusCode)
    .RetryAsync(10));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();
app.UseCors("AllowAllOrigins");
app.MapControllers();

app.Run();
