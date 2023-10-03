using LaborDoctor.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LaborDoctor.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<MedicoModel>? tb_medico { get; set; }
        public DbSet<ClinicaModel>? tb_clinica { get; set; }
        public DbSet<PacienteModel>? tb_paciente { get; set; }
        public DbSet<ConsultaModel>? tb_consulta { get; set; }
        public DbSet<ScheduleModel>? tb_schedule { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MedicoModel>(entity =>
            {
                entity.HasKey(e => e.id_medico);
                entity.Property(e => e.nome).IsRequired();
                entity.Property(e => e.crm).IsRequired();
                entity.Property(p => p.cpf).HasMaxLength(15);
                entity.HasData(
                    new MedicoModel
                    {
                        id_medico = 1,
                        nome = "Rodrigo Ribeiro",
                        crm = "045465/SP",
                        cpf = "12345678910",
                        telefone = "11992668225",
                        email = "rodrignucleo@labordoctor.com"
                    });
                entity.HasData(
                    new MedicoModel
                    {
                        id_medico = 2,
                        nome = "Patricia Oliveira",
                        crm = "221748/PR",
                        cpf = "98765412398",
                        telefone = "9899265826597",
                        email = "patricia.oliveira@labordoctor.com",
                    });
            });

            modelBuilder.Entity<PacienteModel>(entity =>
            {
                entity.HasKey(e => e.id_paciente);
                entity.Property(e => e.nome).IsRequired();
                entity.Property(p => p.cpf).HasMaxLength(15);
                entity.HasData(
                    new PacienteModel
                    {
                        id_paciente = 1,
                        nome = "root Paciente",
                        cpf = "111.222.333-44",
                        telefone = "(45) 96666-1234",
                        email = "root",
                        senha = BCrypt.Net.BCrypt.HashPassword("123"),
                        senha_antiga = BCrypt.Net.BCrypt.HashPassword("123")
                    });
                entity.HasData(
                    new PacienteModel
                    {
                        id_paciente = 2,
                        nome = "Estevão Rocha",
                        cpf = "987.458.236-98",
                        telefone = "(11) 99478-5200",
                        email = "estevao@labordoctor.com",
                        senha = BCrypt.Net.BCrypt.HashPassword("123"),
                        senha_antiga = BCrypt.Net.BCrypt.HashPassword("123")
                    });
            });

            modelBuilder.Entity<ClinicaModel>(entity =>
            {
                entity.HasKey(e => e.id_clinica);
                entity.Property(e => e.nome).IsRequired();
                entity.Property(p => p.cnpj).HasMaxLength(19);
                entity.HasData(
                    new ClinicaModel
                    {
                        id_clinica = 1,
                        nome = "root Clinica",
                        nome_fantasia = "root Clinica",
                        cnpj = "11.777.5555/0001-99",
                        telefone = "(45) 96666-1234",
                        email = "root",
                        senha = BCrypt.Net.BCrypt.HashPassword("123"),
                        senha_antiga = BCrypt.Net.BCrypt.HashPassword("123")
                    });
                entity.HasData(
                    new ClinicaModel
                    {
                        id_clinica = 2,
                        nome = "GNDI",
                        nome_fantasia = "GNDI",
                        cnpj = "10.136.4860/0001-85",
                        telefone = "(11) 98524-5698",
                        email = "gndi@clinica.com",
                        senha = BCrypt.Net.BCrypt.HashPassword("gndi"),
                        senha_antiga = BCrypt.Net.BCrypt.HashPassword("gndi")
                    });
            });

            modelBuilder.Entity<ScheduleModel>()
                .Property(e => e.status)
                .HasConversion<string>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL("server=127.0.0.1;database=LaborDoctor_db;user=root;port=3307;password=123123");
        }

    }
}