using HotelProject.BusinessLayer.Container;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<Context>(); //context aktif
builder.Services.AddCustomServices(); //custom servisleri çekme
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); //mapleme




builder.Services.AddCors(opt =>
{
    opt.AddPolicy("OtelApiCors", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
}); //Apiyi Consume Edebilmemiz için



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("OtelApiCors"); //Apiyi Consume Edebilmemiz için

app.UseAuthorization();

app.MapControllers(); 

app.Run();
