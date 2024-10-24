using IT_Lab.Services;

var builder = WebApplication.CreateBuilder(args);

// ������� ������ �� ���������� DI.
builder.Services.AddControllersWithViews();

// ��������� DatabaseService �� Singleton.
builder.Services.AddSingleton<DatabaseService>();

var app = builder.Build();

// ������������ ������� ������� HTTP-������.

// ���� ���������� �� � ����� ��������, �������������� ������� ������� �� HSTS.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// ��������������� HTTP �� HTTPS.
app.UseHttpsRedirection();

// �������������� ��������� �����.
app.UseStaticFiles();

// ������������ �������������.
app.UseRouting();

// ����������� (���� ���������������).
app.UseAuthorization();

// ������������ �������� ����������.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// ������ ����������.
app.Run();
