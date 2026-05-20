using MvcSolidDemo.Services; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// THÊM MỚI: Đăng ký DI Container tại đây
builder.Services.AddTransient<IDiscountStrategy, ClearanceDiscount>(); // Đang chọn xả kho 20%
builder.Services.AddScoped<IProductService, ProductService>();
// ------------------------------------

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

// SỬA LẠI: Trỏ controller mặc định từ "Home" thành "Product"
app.MapStaticAssets();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}") // Đã sửa chữ Home thành Product
    .WithStaticAssets();

app.Run();