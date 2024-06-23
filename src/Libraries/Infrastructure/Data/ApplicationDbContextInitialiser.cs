using BuildingMaterialAccounting.Application.Customers;
using BuildingMaterialAccounting.Domain.Entities.Customers;
using BuildingMaterialAccounting.Domain.ValueObjects;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingMaterialAccounting.Infrastructure.Data
{
    public static class InitialiserExtensions
    {
        public static async Task InitialiseDatabaseAsync(this WebApplication? app)
        {
            if (app == null)
                return;

            using var scope = app.Services.CreateScope();

            var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

            await initialiser.InitialiseAsync();

            await initialiser.SeedAsync();
        }
    }

    public class ApplicationDbContextInitialiser
    {
        #region Fields

        private readonly ILogger<ApplicationDbContextInitialiser> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserService _userService;

        #endregion

        #region Ctor

        public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger,
            ApplicationDbContext context, UserService userService)
        {
            _logger = logger;
            _context = context;
            _userService = userService;
        }

        #endregion

        public async Task InitialiseAsync()
        {
            try
            {
                await _context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        public async Task TrySeedAsync()
        {
            // Default users
            var administrator = new UserEntity()
            {
                PhoneNumber = "09058089095",
                Password = PasswordHash.Parse("123456")
            };

            if (_context.Users.All(u => u.PhoneNumber != administrator.PhoneNumber))
            {
                await _userService.AddAsync(administrator);
            }
        }
    }
}