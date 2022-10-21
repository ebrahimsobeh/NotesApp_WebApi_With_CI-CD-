using Microsoft.AspNetCore.Mvc;
using NotesApp_WebApi.Contracts;
using NotesApp_WebApi.Controllers;
using NotesApp_WebApi.Data;
using NotesApp_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace NotesApp_WebApi_Tests
{
    public class NoteControllerTest
    {
        
        private readonly NoteController _controller;
        private readonly IService<NoteDto> _service;
        public NoteControllerTest()
        {
            _service = new NoteServiceFake();
            _controller = new NoteController(_service);

        }

        [Fact]
        public async void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = await _controller.GetNotes();
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public async void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = await _controller.GetNotes() as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<NoteDto>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public async void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = await _controller.GetNoteById(Guid.NewGuid());

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public async void GetById_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            var testGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");

            // Act
            var okResult = await _controller.GetNoteById(testGuid);

            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public async void GetById_ExistingGuidPassed_ReturnsRightItem()
        {
            // Arrange
            var testGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");

            // Act
            var okResult = await _controller.GetNoteById(testGuid) as OkObjectResult;

            // Assert
            Assert.IsType<NoteDto>(okResult.Value);
            Assert.Equal(testGuid, (okResult.Value as NoteDto).Id);
        }

        [Fact]
        public async void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var nameMissingItem = new NoteDto()
            {
                Title = "Guinness"

            };
            _controller.ModelState.AddModelError("DESCRPTION", "Required");

            // Act
            var badResponse = await _controller.AddNote(nameMissingItem);

            // Assert
            Assert.IsType<BadRequestResult>(badResponse);
        }

        [Fact]
        public async void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            var testItem = new NoteDto()
            {
                Title = "Guinness Original 6 Pack",
                Description = "Guinness"
            };

            // Act
            var createdResponse = await _controller.AddNote(testItem);

            // Assert
            Assert.IsType<OkObjectResult>(createdResponse);
        }

        [Fact]
        public async void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            var testItem = new NoteDto()
            {
                Title = "Guinness Original 6 Pack",
                Description = "Guinness"
            };

            // Act
            var ContentResponse = await _controller.AddNote(testItem);

            Assert.IsType<OkObjectResult>(ContentResponse);


            // Assert
            //Assert.IsType<Note>(ContentResponse);
            //Assert.Equal("Guinness Original 6 Pack", ContentResponse);
        }

        [Fact]
        public async void Remove_NotExistingGuidPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var notExistingGuid = Guid.NewGuid();

            // Act
            var badResponse = await _controller.DeleteNoteById(notExistingGuid);

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public async void Remove_ExistingGuidPassed_ReturnsNoContentResult()
        {
            // Arrange
            var existingGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");

            // Act
            var noContentResponse = await _controller.DeleteNoteById(existingGuid);

            // Assert
            Assert.IsType<OkObjectResult>(noContentResponse);
        }

        [Fact]
        public async void Remove_ExistingGuidPassed_RemovesOneItem()
        {
            // Arrange
            var existingGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");

            // Act
            var okResponse = await _controller.DeleteNoteById(existingGuid);

            // Assert
            Assert.Equal(2, _service.GetAllItems().Result.Count());





        }



    }
}
