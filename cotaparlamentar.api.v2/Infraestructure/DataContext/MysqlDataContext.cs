using cotaparlamentar.api.v2.Model;
using Microsoft.EntityFrameworkCore;

namespace cotaparlamentar.api.v2.Infraestructure.DataContext;

public class MysqlDataContext : DbContext
{
    private readonly string _configuration;
    public MysqlDataContext(string configuration)
	{
        _configuration = configuration;
    }

    public DbSet<Deputado> Deputado { get; set; }
    public DbSet<CotaParlamentar> CotaParlamentar { get; set; }
    public DbSet<Assessor> Assessor { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(_configuration,
        new MySqlServerVersion(new Version(8, 0, 11)));
    }
}
