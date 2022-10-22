using cotaparlamentar.api.v2.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace cotaparlamentar.api.v2.Infraestructure.DataContext;

public class MysqlDataContext : DbContext
{
    private readonly string _configuration;
    public MysqlDataContext(string configuration)
	{
        _configuration = configuration;
    }

    public DbSet<Deputado> Deputado { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(_configuration,
        new MySqlServerVersion(new Version(8, 0, 11)));
    }
}
