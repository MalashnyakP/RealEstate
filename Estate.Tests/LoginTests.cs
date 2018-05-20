using System;
using System.Collections.Generic;
using System.Text;
using Estate.Controllers;
using Estate.Data;
using Xunit;

namespace Estate.Tests
{
    public class LoginTests
    {
        [Fact]
        public void User_With_Correct_Username_And_Pass_Should_Login_Successfully()
        {
            // Arrange
            var accountService = new AccountService();

            // Act
            bool result = accountService.DoLogin("test", "test");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void User_With_Correct_Username_And_Pass_Should_Not_Login()
        {
            // Arrange
            var accountService = new AccountService();

            // Act
            bool result = accountService.DoLogin("test", "");

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void User_Without_Login()
        {
            // Arrange
            var accountService = new AccountService();

            // Act
            bool result = accountService.NoLogin("", "password");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void User_Without_Password()
        {
            // Arrange
            var accountService = new AccountService();

            // Act
            bool result = accountService.NoPassword("test", "");

            // Assert
            Assert.True(result);
        }

       

        public class AccountService : AccountController
        {
            public bool DoLogin(string username, string password)
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                    return false;

                return true;
            }
            
            public bool NoLogin(string username, string password)
            {
                if (string.IsNullOrEmpty(username))
                    return true;

                return false;
            }

            public bool NoPassword(string username, string password)
            {
                if (string.IsNullOrEmpty(password))
                    return true;

                return false;
            }
        }
    }
}
