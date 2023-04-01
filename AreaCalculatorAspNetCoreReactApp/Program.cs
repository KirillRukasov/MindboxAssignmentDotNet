using AreaCalculatorDotNetLibrary;
using AreaCalculatorMindbox.Controllers;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<AreaCalculator>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowAllOrigins");


app.MapGet("/circle/area", (double radius, AreaCalculator areaCalculator) =>
{
    var circleController = new CircleController(areaCalculator);
    var result = circleController.GetArea(radius);

    return result switch
    {
        OkObjectResult okResult => Results.Ok(okResult.Value),
        BadRequestObjectResult badRequestResult => Results.BadRequest(badRequestResult.Value),
        _ => Results.BadRequest()
    };
});

app.MapGet("/triangle/area", (double sideA, double sideB, double sideC, AreaCalculator areaCalculator) =>
{
    var triangleController = new TriangleController(areaCalculator);
    var result = triangleController.GetArea(sideA, sideB, sideC);

    return result switch
    {
        OkObjectResult okResult => Results.Ok(okResult.Value),
        BadRequestObjectResult badRequestResult => Results.BadRequest(badRequestResult.Value),
        _ => Results.BadRequest()
    };
});

app.MapGet("/triangle/isRight", (double sideA, double sideB, double sideC, AreaCalculator areaCalculator) =>
{
    var triangleController = new TriangleController(areaCalculator);
    var result = triangleController.IsRight(sideA, sideB, sideC);

    return result switch
    {
        OkObjectResult okResult => Results.Ok(okResult.Value),
        BadRequestObjectResult badRequestResult => Results.BadRequest(badRequestResult.Value),
        _ => Results.BadRequest()
    };
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
