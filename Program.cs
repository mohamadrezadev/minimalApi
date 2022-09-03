using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyAPi.Data;
using MyAPi.Dtos;
using MyAPi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var sqlbuilder=new SqlConnectionStringBuilder();
sqlbuilder.ConnectionString=builder.Configuration.GetConnectionString("SQlDBConnection");
sqlbuilder.UserID=builder.Configuration["UserId"];
sqlbuilder.Password=builder.Configuration["Password"];

builder.Services.AddDbContext<AppDbContext>(opt =>opt.UseSqlServer(sqlbuilder.ConnectionString));
builder.Services.AddScoped<ICommandRepo,CommandRepo>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/v1/commands",async (ICommandRepo repo,IMapper mapper )=>{
    var commands=await repo.GEtAllCommands();
    return Results.Ok(mapper.Map<IEnumerable<CommandReadDto>>(commands));
});
app.MapGet("Api/v1/Commadns",async(ICommandRepo repo,IMapper mapper, int id)=>{
    var commands=await repo.GetCommandbyId(id);
    if(commands!=null)
    {
            return Results.Ok(mapper.Map<CommandReadDto>(commands));
    }
    return Results.NotFound();
} );
app.MapPost("api/v1/commands",async (ICommandRepo repo,IMapper mapper,CommandCreateDto commandCreateDto )=>{
    var commandmodel=mapper.Map<Command>(commandCreateDto);
    await repo.CreateCommand(commandmodel);
    await repo.SavaChanges();

    var cmdReadDto=mapper.Map<CommandReadDto>(commandmodel);
    return Results.Created($"api.v1/Command/{cmdReadDto}",cmdReadDto);

});
app.MapPut("api/v1/Command/{id}",async (ICommandRepo repo,IMapper mapper,int id,CommandUpdateDto commandUpdateDto )=>{
    var commands=await repo.GetCommandbyId(id);
    if(commands==null)
    {
            return Results.NotFound();
    }
    mapper.Map(commandUpdateDto,commands);
    await repo.SavaChanges();
    return Results.NoContent();
});
app.MapDelete("api/v1/Command/{id}",async (ICommandRepo repo,IMapper mapper,int id)=>{

    var commands=await repo.GetCommandbyId(id);
    if(commands==null)
    {
            return Results.NotFound();
    }
    repo.DeletCommand(commands);
    await repo.SavaChanges();
    return Results.NoContent(); 
});
app.Run();

