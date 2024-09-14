using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using Mostra.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");


    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting(); // Habilita o roteamento, que define como as URLs s�omapeadas para as a��es.
app.UseAuthorization(); // Habilita a autoriza��o, garantindo que o acesso arecursos seja controlado.
// Mapeia as p�ginas Razor para os endpoints no aplicativo.
app.MapRazorPages();
// Testa a conex�o com o banco de dados antes de executar o aplicativo.
TestDatabaseConnection(app);
// Inicia a aplica��o web.
app.Run();
// Fun��o que testa a conex�o com o banco de dados.
void TestDatabaseConnection(WebApplication app)
{
    // Cria um escopo para obter os servi�os do container de depend�ncia.
    using (var scope = app.Services.CreateScope())
    {

        var services = scope.ServiceProvider;
        try
        {
            // Obt�m o contexto de banco de dados injetado.
            var context =
            services.GetRequiredService<ApplicationDbContext>();
            // Verifica se � poss�vel conectar ao banco de dados.
            if (context.Database.CanConnect())
            {
                Console.WriteLine("Connection to the database successful!");
                // Conex�o bem-sucedida.
            }
            else
            {
                Console.WriteLine("Failed to connect to the database."); //Falha na conex�o.

            }
        }
        catch (Exception ex)
        {
            // Captura qualquer exce��o e imprime uma mensagem de erro.
            Console.WriteLine($"An exception occurred: {ex.Message}");
        }
    }
}