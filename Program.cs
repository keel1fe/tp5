var builder = WebApplication.CreateBuilder(args);

// ��������� ����������� �������
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor(); // ��������� ��� ������

var app = builder.Build();

// ��������� ��� �������� ��� ���������
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