using ElevatorControl.Services;

namespace ElevatorControl
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

			builder.Services
				.AddSingleton<IElevatorState, ElevatorState>(serviceProvider => new(16)) //Hard-coding the number of floors here; value should be read from config
				.AddTransient<IElevatorService, ElevatorService>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseAuthorization();
			app.MapControllers();

			app.Run();
		}
	}
}