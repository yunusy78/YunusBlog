using BlogWeb.Controllers;
using Business.Abstract;
using Entity.Concrete;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Xunit;

public class BlogControllerTests
{
    [Fact]
    public void Index_ReturnsViewResult_WithListOfBlogs()
    {
        // Arrange
        var mockContext = new Mock<Context>();
        var mockUserManager = new Mock<UserManager<ApplicationUser>>();
        var blogManagerMock = new Mock<BlogManager>(new EfBlogRepository(mockContext.Object));
        var controller = new BlogController(mockContext.Object, mockUserManager.Object, new Mock<IDataProtectionProvider>().Object)
        {
            ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = new System.Security.Claims.ClaimsPrincipal() }
            }
        };
        var blog = new Blog
        {
            Title = "Test Blog",
            Content = "Test Content",
            ImageUrl = "Test Image Path",
            CreatedAt = DateTime.Now,
            CategoryId = Guid.NewGuid(),
            WriterId = Guid.NewGuid(),
            Status = true
            
            
        };

        var formFile = new Mock<IFormFile>();

        // Act
        var result = controller.AddToBlog(blog, formFile.Object) as RedirectToActionResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Index", result.ActionName);
    }
}
