using Microsoft.EntityFrameworkCore;
using Forum;
using Forum.Services;
using Forum.Db_Context;
using Forum.Helpers;
using AutoMapper;
using Forum.Auth;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddAuthentication("Bearer").AddIdentityServerAuthentication("Bearer", opt =>
//{
//    opt.ApiName = "ForumAPI";
//    opt.Authority = "https://localhost:7204";

//});

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "onlyCertainOrigin",
        policy =>
        {

            policy.AllowAnyHeader().WithOrigins("https://localhost:44383").WithMethods("Get");

        });

    opt.AddPolicy(name: "openForAll",
        policy =>
        {

            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

        });
});
builder.Services.AddAutoMapper(typeof(Program));


builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddScoped<IForumpostService, ForumpostService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddDbContext<DataContext>();

builder.Services.AddScoped<IJwtUtils, JwtUtils>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//app.UseCors("onlyCertainOrigin");
app.UseCors("openForAll");

app.UseHttpsRedirection();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseMiddleware<JwtMiddleware>();

app.MapControllers();
app.Run();
