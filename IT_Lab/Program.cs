using IT_Lab.Services;

var builder = WebApplication.CreateBuilder(args);

// Додайте сервіси до контейнера DI.
builder.Services.AddControllersWithViews();

// Реєстрація DatabaseService як Singleton.
builder.Services.AddSingleton<DatabaseService>();

var app = builder.Build();

// Налаштування конвеєра обробки HTTP-запитів.

// Якщо застосунок не в режимі розробки, використовуйте сторінку помилок та HSTS.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Перенаправлення HTTP на HTTPS.
app.UseHttpsRedirection();

// Обслуговування статичних файлів.
app.UseStaticFiles();

// Налаштування маршрутизації.
app.UseRouting();

// Авторизація (якщо використовується).
app.UseAuthorization();

// Налаштування маршрутів контролерів.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Запуск застосунку.
app.Run();
