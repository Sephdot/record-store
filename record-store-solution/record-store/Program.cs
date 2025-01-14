using Microsoft.EntityFrameworkCore;
using record_store.Repositories;
using record_store.Services;

namespace record_store
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IAlbumsRepo, AlbumsRepo>();
            builder.Services.AddScoped<IAlbumsService, AlbumsService>();

            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddDbContext<RecordStoreDbContext>(options => options.UseInMemoryDatabase("InMemoryDb"));
            }
            else if (builder.Environment.IsProduction())
            {
                builder.Services.AddDbContext<RecordStoreDbContext>(options => options.UseSqlServer("ProductionConnection"));
            }
            else
            {
                throw new Exception("Invalid environment, must be either development or production");
            }

            

            var app = builder.Build();

            // Ensures the database is initialized
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<RecordStoreDbContext>();
                dbContext.Database.EnsureCreated();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
