#region Additional Namespaces
using Microsoft.EntityFrameworkCore;
using TrainWatchSystem;
#endregion

var builders = WebApplication.CreateBuilder(args);


var connectionString = builders.Configuration.GetConnectionString("TWDB");


builders.Services.WWBackendDependencies(options => options.UseSqlServer(connectionString));




builders.Services.AddRazorPages();

var app = builders.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
