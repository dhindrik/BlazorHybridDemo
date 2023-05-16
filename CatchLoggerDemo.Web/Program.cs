﻿global using InterfaceGenerator;

global using CatchLoggerDemo.Web.Models;
global using CatchLoggerDemo.Web.Services;
using CatchLoggerDemo.Core.Helpers;
using CatchLoggerDemo.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddSingleton<ICatchService, CatchService>();

builder.Services.AddSingleton<IFilePathProvider, WebFilePathProvider>();
builder.Services.AddSingleton<IPlatformInfoProvider, WebPlatformInfoProvider>();

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

