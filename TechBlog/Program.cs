using Business.Abstract;
using Business.Concrete;
using Core.Entity.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddIdentity<User, Role>(opt =>
//{
//    opt.Password.RequireNonAlphanumeric = false;
//    opt.Password.RequireUppercase = false;
//    opt.Password.RequireLowercase = false;
//}).AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddScoped<AppDbContext>();

builder.Services.AddScoped<IBlogService, BlogManager>();
builder.Services.AddScoped<IBlogDal, BlogDal>();

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, CategoryDal>();

builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactDal, ContactDal>();

builder.Services.AddScoped<ICommentService, CommentManager>();
builder.Services.AddScoped<ICommentDal, CommentDal>();

builder.Services.AddScoped<IWriterService, WriterManager>();
builder.Services.AddScoped<IWriterDal, WriterDal>();

builder.Services.AddControllersWithViews();


builder.Services.AddMvc(config =>
{
	var policy = new AuthorizationPolicyBuilder()
					 .RequireAuthenticatedUser()
					 .Build();
	config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddSession();

builder.Services.AddMvc();


builder.Services.AddAuthentication(
		CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(x =>
	{
		x.LoginPath = "/Writer/Login";
	});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Blog}/{action=Index}/{id?}"
    );
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Blog}/{action=Index}/{id?}"
    );



app.Run();
