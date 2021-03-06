using Project3_Base_Code.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IGetFaculty, GetFaculty>();
builder.Services.AddTransient<IGetAbout, GetAbout>();
builder.Services.AddTransient<IGetDegrees, GetDegrees>();
builder.Services.AddTransient<IGetMinors, GetMinors>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
