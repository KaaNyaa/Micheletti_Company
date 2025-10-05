using Micheletti_Company.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Micheletti_Company.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {

            string supervisorRole = "Supervisor";
            string employeeRole = "Employee";

            if (await roleManager.FindByNameAsync(supervisorRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(supervisorRole));
            }

            // Create Employee Role if it doesn't exist
            if (await roleManager.FindByNameAsync(employeeRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(employeeRole));
            }

            string supervisorEmail = "supervisor@michelettico.com";

            if (await userManager.FindByEmailAsync(supervisorEmail) == null)
            {
                var supervisorUser = new ApplicationUser
                {
                    UserName = "name", 
                    Email = supervisorEmail,
                    EmailConfirmed = true,
                    // Mandatory custom fields
                    FirstName = "Name",
                    LastName = "Supervisor",
                    // Optional custom field
                    City = "Burlington"
                };

                // Create user with a strong default password
                IdentityResult result = await userManager.CreateAsync(supervisorUser, "Supervisor!1");

                if (result.Succeeded)
                {
                    // Assign the Supervisor role
                    await userManager.AddToRoleAsync(supervisorUser, supervisorRole);
                }
            }

            string employeeEmail = "employee@michelettico.com";

            if (await userManager.FindByEmailAsync(employeeEmail) == null)
            {
                var employeeUser = new ApplicationUser
                {
                    UserName = "employee", 
                    Email = employeeEmail,
                    EmailConfirmed = true,
                    // Mandatory custom fields
                    FirstName = "Name",
                    LastName = "Employee",
                    // Optional custom field
                    City = "Burlington"
                };

                // Create user with a strong default password
                IdentityResult result = await userManager.CreateAsync(employeeUser, "Employee!1");

                if (result.Succeeded)
                {
                    // Assign the Employee role
                    await userManager.AddToRoleAsync(employeeUser, employeeRole);
                }
            }
        }
    }
}