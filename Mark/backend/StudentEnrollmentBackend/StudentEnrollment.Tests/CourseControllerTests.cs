using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using StudentEnrollment.API.Constants;
using StudentEnrollment.API.Controllers;
using StudentEnrollment.API.Models.Course.RequestModel;
using StudentEnrollment.API.Models.Shared.ResponseModel;
using StudentEnrollment.Business.Models.SearchModels;
using StudentEnrollment.Business.Repository;
using StudentEnrollment.Business.Services.Interfaces;
using Xunit.Abstractions;

namespace StudentEnrollment.Tests;

public class CourseControllerTests
{
    private readonly Mock<ICourseService> _mockCourseService;
    private readonly Mock<IMapper> _mockMapper;
    private readonly CourseController _controller;
    private readonly ITestOutputHelper _output;
    
    public CourseControllerTests(ITestOutputHelper output)
    {
        _output = output;
        _mockCourseService = new Mock<ICourseService>();
        _mockMapper = new Mock<IMapper>();
        _controller = new CourseController(_mockCourseService.Object, _mockMapper.Object);
    }

    [Fact]
    public void GetCourses_ReturnsOkResult_WithListOfCourses()
    {
        // Arrange
        var courseList = new List<Course>
        {
            new Course
            {
                Id = 1,
                Name = "Introduction to Data Science",
                Description = "Basic concepts of data science",
                StartDate = new DateTime(2024, 11, 01),
                EndDate = new DateTime(2024, 11, 15),
                Fees = 500,
                LocationAddress = "123 Data St, Cityville",
                ContactPerson = "Alice Johnson"
            },
            new Course
            {
                Id = 2,
                Name = "Advanced SQL Programming",
                Description = "In-depth SQL training",
                StartDate = new DateTime(2024, 11, 05),
                EndDate = new DateTime(2024, 12, 05),
                Fees = 800,
                LocationAddress = "456 SQL Ln, Dataville",
                ContactPerson = "Bob Smith"
            }
        };

        var controllerSearchModel = new GetCoursesRequestModel();
        var searchModel = new CourseSearchModel();
        
        _mockCourseService.Setup(service => service.GetCourses(searchModel))
            .Returns(courseList);

        _mockMapper.Setup(mapper => mapper.Map<CourseSearchModel>(controllerSearchModel))
            .Returns(searchModel);
        
        // Act
        var apiResult = _controller.Index(controllerSearchModel);
        
        // Assert
        var okResult = Assert.IsType<ObjectResult>(apiResult);
        _output.WriteLine($"okResult value: {okResult.Value}");
        
        var returnValue = Assert.IsType<BaseDataAPIResponseModel>(okResult.Value);
        _output.WriteLine($"returnValue value: {returnValue.Data}");
        
        var dataValue = Assert.IsType<List<Course>>(returnValue.Data);
        Assert.Equal(APIStatusCode.SUCCESS, returnValue.StatusCode);
        Assert.Equal(courseList.Count, dataValue.Count);
    }
}