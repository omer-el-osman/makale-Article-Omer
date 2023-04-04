using makaledeneme1.Core;
using makaledeneme1.Data;
using makaledeneme1.Data.SqlServerEF;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();


///////Onemliiiiiiiiiiiiiiiiiiiiiiiiiiiii
///inject table ///////////////////////////////////////////////////////////////////////////////////////
builder.Services.AddSingleton<IDataHelper<Category>, CategoryEntity>();
builder.Services.AddSingleton<IDataHelper<Author>, AuthorEntity>();
builder.Services.AddSingleton<IDataHelper<AuthorPost>, AuthorPostEntity>();



builder.Services.AddAuthorization(op =>
    {
        op.AddPolicy("User", op=>op.RequireClaim("User"));
        op.AddPolicy("Admin", op => op.RequireClaim("Admin"));
    }

);
//builder.Services.AddMvc(op => op.EnableEndpointRouting = false);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
//app.UseMvcWithDefaultRoute();
////////////////////////////////////////////////  Onemliiiiiiiii mvc ve razor page gostermek icin
app.UseEndpoints(Endpoints =>
{
    Endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    Endpoints.MapRazorPages();
});
////////////////////////////////////////////////////////////////////////////////


app.Run();
