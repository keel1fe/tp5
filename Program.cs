var builder = WebApplication.CreateBuilder(args);

// Добавляем необходимые сервисы
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor(); // Добавляем эту строку

var app = builder.Build();

// Остальной код остается без изменений
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Dance/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dance}/{action=Index}/{id?}");

app.Run();