using CalculatorApplicationService.Controller;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);
var baseAddress = builder.Configuration.GetValue<string>("ASPNETCORE_URLS");

builder.Services.AddHttpClient("CalculatorClient", client =>
{
    if (!string.IsNullOrEmpty(baseAddress))
    {
        client.BaseAddress = new Uri(baseAddress);
    }
    else
    {
        throw new NotSupportedException("Base Address not found.");
    }
});

builder.Services.AddControllers()
    .AddXmlSerializerFormatters();

builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
