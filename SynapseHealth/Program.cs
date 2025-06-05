using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SynapseHealth.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<OpenAISettings>(builder.Configuration.GetSection("OpenAI"));
builder.Services.AddScoped<IOpenAIClientWrapper, OpenAIClientWrapper>();
builder.Services.AddScoped<IAIPromptService, OpenAIPromptService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SynapseHealth API", Version = "v1" });
});

var app = builder.Build();

app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SynapseHealth API v1");
    });
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();
app.Run();
