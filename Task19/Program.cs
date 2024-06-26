using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IUserManager, UserManager>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(
    c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "APi", Version = "v1" }));
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(
        c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api")
        );
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllers();

app.Run();
public class User
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }
}

public interface IUserManager
{
    public User ChangeSome(User user);
}

public class UserManager : IUserManager
{
    public User ChangeSome(User user)
    {
        user.Name = user.Name.ToUpper();
        return user;
    }
}