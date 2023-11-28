using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDoctorRepository, DoctorRepository>(x => new DoctorRepository(builder.Configuration.GetConnectionString("Main")));
builder.Services.AddScoped<IDoctorService, DoctorService>();

builder.Services.AddScoped<IPatientRepository, PatientRepository>(x => new PatientRepository(builder.Configuration.GetConnectionString("Main")));
builder.Services.AddScoped<IPatientService, PatientService>();

builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>(x => new AppointmentRepository(builder.Configuration.GetConnectionString("Main")));
builder.Services.AddScoped<IAppointmentService, AppointmentService>();

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IJwtService, JwtService>(x => new JwtService(builder.Configuration["JWT:SecretKey"], builder.Configuration["JWT:ExpirationDays"]));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
{
    o.SaveToken = true;
    o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecretKey"]))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers().RequireAuthorization();
});

app.Run();
