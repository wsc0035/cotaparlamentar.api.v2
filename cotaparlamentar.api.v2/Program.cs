using cotaparlamentar.api.v2.AppService;
using Integration;
using Integration.PuppeterInegration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<DeputadoService>();
builder.Services.AddScoped<CotaParlamentarService>();
builder.Services.AddScoped<AssessorParlamentarService>();
builder.Services.AddScoped<PuppeterApi>();
builder.Services.AddScoped<IntegrationService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();