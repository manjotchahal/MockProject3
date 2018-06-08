using System;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using MockProject3.DA;
using MockProject3.DA.Models;
using MockProject3.DA.Repos;
using MockProject3.Api;

namespace MockProject3.Test.Mocking
{
    public class UserTests
    {
        private ForecastContext _context;
        private IRepo<User> _userRepository;

        [Fact]
        public void GetUsers_ReturnCollection()
        {
            var options = new DbContextOptionsBuilder<ForecastContext>()
                .UseInMemoryDatabase(databaseName: "InMemDb")
                .Options;

            using(_context = new ForecastContext(options)) {
                // Arrange
                IEnumerable<User> users;
                _userRepository = new UserRepo(_context);
                _context.Users.Add(getTestUser());
                _context.SaveChanges();

                // Act
                users = _userRepository.Get();

                // Assert
                Assert.NotEmpty(users);
            }
        }

        [Fact]
        public void GetUsers_WithId_ReturnUser()
        {
            // Arrange

            // Act

            // Assert
        }

        private void init() {
        }

        private User getTestUser() {
            User result = new User{
                Name = new Name {
                    NameId = Guid.NewGuid(),
                    First = "first",
                    Last = "last"
                },
                Id = Guid.NewGuid(),
                Location = "Reston",
                Email = "test@test.com",
                Gender = "M",
                Type = "test",
                UserId = Guid.NewGuid()
            };
            return result;
        }
    }
}
