using ProyectoRest;
using ProyectoRest.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Cors : acepta todas las urls
builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader())
);

//configuracion entity frameworks
builder.Services.AddSqlServer<TareasContext>("Data source=NB101388;Initial Catalog=TareasDb;user id=sa;password=Andreani");
//builder.Services.AddSqlServer<UsuarioDbContext>("Data source=NB101388;Initial Catalog=UsuarioDb;user id=sa;password=Andreani;Encrypt=False");
//builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();
builder.Services.AddScoped<UsuarioDbContext>();
//configuracion de dependencias
builder.Services.AddScoped<IHelloWorldService>(p=> new HelloWorldService());
builder.Services.AddScoped<ICategoriaService,CategoriaService>();
builder.Services.AddScoped<ITareasService,TareasService>();
builder.Services.AddScoped<IUsuarioService,UsuarioService>();
builder.Services.AddScoped<IPaisService,PaisService>();
builder.Services.AddScoped<IProvinciaService,ProvinciaService>();
builder.Services.AddScoped<ICiudadService,CiudadService>();

var app = builder.Build(); 
//Crea una funcion que borra y crea la bd

/*
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<UsuarioContext>();

    dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated();
}
*/

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

//app.UseWelcomePage();
//app.UseTimeMiddleware();

app.MapControllers();

app.Run();
