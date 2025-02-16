using APIMarvel.src.Application.Interfaces;
using APIMarvel.src.Application.Services;
using APIMarvel.src.Domain.Entities;
using Moq;
using Xunit;

namespace APIMarvel.tests
{
    public class AuthServiceTests
    {
        //private readonly Mock<IUserRepository> _userRepositoryMock;
        //private readonly AuthService _authService;

        //public AuthServiceTests()
        //{
        //    _userRepositoryMock = new Mock<IUserRepository>();
        //    _authService = new AuthService(_userRepositoryMock.Object);
        //}

        //[Fact]
        //public async Task RegisterAsync_ShouldReturnToken_WhenUserIsRegistered()
        //{
        //    // Arrange
        //    string email = "test@example.com";
        //    string password = "password123";
        //    _userRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<User>()))
        //        .Returns(Task.CompletedTask);

        //    // Act
        //    var token = await _authService.RegisterAsync(email, password);

        //    // Assert
        //    Assert.NotNull(token);
        //}

        //[Fact]
        //public async Task LoginAsync_ShouldReturnToken_WhenCredentialsAreValid()
        //{
        //    // Arrange
        //    string email = "test@example.com";
        //    string password = "password123";
        //    var user = new User(email, password);
        //    _userRepositoryMock.Setup(repo => repo.GetByEmailAsync(email))
        //        .ReturnsAsync(user);

        //    // Act
        //    var token = await _authService.LoginAsync(email, password);

        //    // Assert
        //    Assert.NotNull(token);
        //}

        //[Fact]
        //public async Task LoginAsync_ShouldReturnNull_WhenCredentialsAreInvalid()
        //{
        //    // Arrange
        //    string email = "wrong@example.com";
        //    string password = "wrongpassword";
        //    _userRepositoryMock.Setup(repo => repo.GetByEmailAsync(email))
        //        .ReturnsAsync((User)null);

        //    // Act
        //    var token = await _authService.LoginAsync(email, password);

        //    // Assert
        //    Assert.Null(token);
        //}

        //[Fact]
        //public async Task ResetPasswordAsync_ShouldReturnTrue_WhenTokenIsValid()
        //{
        //    // Arrange
        //    string email = "test@example.com";
        //    string token = "valid-token";
        //    string newPassword = "NewPassword123";
        //    var user = new User(email, "oldpassword");
        //    _userRepositoryMock.Setup(repo => repo.GetByEmailAsync(email))
        //        .ReturnsAsync(user);
        //    _userRepositoryMock.Setup(repo => repo.UpdateAsync(user))
        //        .Returns(Task.CompletedTask);

        //    // Act
        //    var result = await _authService.ResetPasswordAsync(email, token, newPassword);

        //    // Assert
        //    Assert.True(result);
        //}

        //[Fact]
        //public async Task ResetPasswordAsync_ShouldReturnFalse_WhenUserDoesNotExist()
        //{
        //    // Arrange
        //    string email = "nonexistent@example.com";
        //    string token = "valid-token";
        //    string newPassword = "NewPassword123";
        //    _userRepositoryMock.Setup(repo => repo.GetByEmailAsync(email))
        //        .ReturnsAsync((User)null);

        //    // Act
        //    var result = await _authService.ResetPasswordAsync(email, token, newPassword);

        //    // Assert
        //    Assert.False(result);
        //}

        //[Fact]
        //public async Task ResetPasswordAsync_ShouldReturnFalse_WhenTokenIsInvalid()
        //{
        //    // Arrange
        //    string email = "test@example.com";
        //    string token = "invalid-token";
        //    string newPassword = "NewPassword123";
        //    var user = new User(email, "oldpassword");
        //    _userRepositoryMock.Setup(repo => repo.GetByEmailAsync(email))
        //        .ReturnsAsync(user);

        //    // Act
        //    var result = await _authService.ResetPasswordAsync(email, token, newPassword);

        //    // Assert
        //    Assert.False(result);
        //}
    }
}
