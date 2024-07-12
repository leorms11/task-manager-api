using Newtonsoft.Json;
using TaskManager.Api.Exceptions;
using TaskManager.Application.Repositories;
using TaskManager.Application.UseCases.Tasks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(x => x.Filters.Add<ExceptionHandler>())
    .AddNewtonsoftJson(x =>
    {
        x.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRouting(option => option.LowercaseUrls = true);

builder.Services.AddSingleton<TasksRepository>();
builder.Services.AddScoped<CreateTaskUseCase>();
builder.Services.AddScoped<UpdateTaskUseCase>();
builder.Services.AddScoped<GetAllTasksUseCase>();
builder.Services.AddScoped<GetTaskByIdUseCase>();
builder.Services.AddScoped<DeleteTaskUseCase>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();