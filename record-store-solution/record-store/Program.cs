using Microsoft.EntityFrameworkCore;

namespace record_store
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<RecordStoreDbContext>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
