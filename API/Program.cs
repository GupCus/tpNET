using API.EndPoints;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpLogging(o => { });

            var app = builder.Build();

            // Estaba en el ejemplo, agrega el logger http y el https redirection.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseHttpLogging();
            }

            app.UseHttpsRedirection();

            //Map endpoints

            app.MapGet("/", () =>
                Results.Redirect("/swagger/"));

            app.MapCategoriaGastosEndpoints();
            app.MapTareaEndPoints();

            app.Run();
        }
    }
}
