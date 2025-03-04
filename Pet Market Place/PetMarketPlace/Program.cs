using PetMarketPlace.Models.Interfaces;
using PetMarketPlace.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddTransient<IBuyerInterface, BuyerRepository>();
builder.Services.AddTransient<ISellerInterface, SellerRepository>();
builder.Services.AddTransient<ICatInterface, CatRepository>();
builder.Services.AddTransient<IDogInterface, DogRepository>();
builder.Services.AddTransient<IAllPetsInterface, AllPetsRepository>();
builder.Services.AddTransient<ITransectionInterfaces, TransactionRepository>();

var app = builder.Build();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
