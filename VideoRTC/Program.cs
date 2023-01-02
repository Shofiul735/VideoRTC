var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
var configuration = new ConfigurationBuilder()
		   .AddCommandLine(args)
		   .Build();
var hostUrl = configuration["hosturl"]; // add this line
if (string.IsNullOrEmpty(hostUrl)) // add this line
	hostUrl = "http://0.0.0.0:5001"; // add this line

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

//http://10.23.0.24:5127