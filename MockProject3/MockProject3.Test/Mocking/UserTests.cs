using System;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using MockProject3.DA;
using MockProject3.DA.Models;
using MockProject3.DA.RepositoryPattern;
using MockProject3.Api;

namespace MockProject3.Test.Mocking
{
    public class UserTests
    {
        private Mock<ForecastContext> _mockContext;
        private IRepository<User> _userRepository;

        [Fact]
        public void GetUsers_NoId_ReturnCollection()
        {
            // Arrange

            // Act

            // Assert
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
                    NameId = Guid.NewGuid()
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
