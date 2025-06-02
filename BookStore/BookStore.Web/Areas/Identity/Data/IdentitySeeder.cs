using Microsoft.AspNetCore.Identity;

public static class IdentitySeeder
{
    public static async Task SeedAdminAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        // Tài khoản Admin
        var adminEmail = "admin@site.com";
        var adminPassword = "Admin@123"; // 🔒 Đổi mật khẩu mạnh hơn

        // 1. Tạo role "Admin" nếu chưa có
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        // 2. Tạo tài khoản admin nếu chưa có
        var adminUser = await userManager.FindByEmailAsync(adminEmail);
        if (adminUser == null)
        {
            adminUser = new IdentityUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(adminUser, adminPassword);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
        else
        {
            // Đảm bảo tài khoản admin có role "Admin"
            var roles = await userManager.GetRolesAsync(adminUser);
            if (!roles.Contains("Admin"))
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }

        // Tài khoản User
        var userEmail = "user@site.com";
        var userPassword = "User@123"; // 🔒 Đổi mật khẩu mạnh hơn

        // 3. Tạo role "User" nếu chưa có
        if (!await roleManager.RoleExistsAsync("User"))
        {
            await roleManager.CreateAsync(new IdentityRole("User"));
        }

        // 4. Tạo tài khoản user nếu chưa có
        var normalUser = await userManager.FindByEmailAsync(userEmail);
        if (normalUser == null)
        {
            normalUser = new IdentityUser
            {
                UserName = userEmail,
                Email = userEmail,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(normalUser, userPassword);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(normalUser, "User");
            }
        }
        else
        {
            // Đảm bảo tài khoản user có role "User"
            var roles = await userManager.GetRolesAsync(normalUser);
            if (!roles.Contains("User"))
            {
                await userManager.AddToRoleAsync(normalUser, "User");
            }
        }
    }
}
