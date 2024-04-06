using Model;
using service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));


builder.Services.AddControllers();
builder.Services.AddScoped<Taskservice>();
builder.Services.AddScoped<Userservice>();



builder.Services.Configure<Googlekey>(builder.Configuration.GetSection("Googlekey"));

builder.Services.AddAuthentication("auth")
                .AddCookie("auth")
                .AddGoogle("Google",opt =>
                {

                    opt.SignInScheme = "auth";
                    var auth = builder.Configuration.GetSection("Googlekey").Get<Googlekey>();
                    if (auth == null) return;
                    opt.ClientId = auth.ClientId;
                    opt.ClientSecret = auth.ClientSecret;


                });


builder.Services.AddAuthorization();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if(builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(options =>
    {
        
        options.AddDefaultPolicy(
            policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
    });
}

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
