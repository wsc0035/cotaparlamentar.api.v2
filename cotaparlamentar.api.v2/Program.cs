using cotaparlamentar.api.v2.AppService;
using cotaparlamentar.api.v2.Infraestructure.DataContext;
using Integration;
using Integration.PuppeterInegration;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseKestrel(so =>
{
    so.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(3);
    so.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(3);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<DeputadoService>();
builder.Services.AddScoped<CotaParlamentarService>();
builder.Services.AddScoped<AssessorParlamentarService>();
builder.Services.AddScoped<PuppeterApi>();
builder.Services.AddScoped<IntegrationService>();
builder.Services.AddSingleton(new MysqlDataContext(Environment.GetEnvironmentVariable("mysql")));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();