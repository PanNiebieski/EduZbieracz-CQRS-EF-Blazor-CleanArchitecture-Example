using AutoMapper;
using EduZbieracz.Application.Contracts.Persistence;
using EduZbieracz.Application.Functions.Categories.Commands.CreateCategory;
using EduZbieracz.Application.Mapper;
using EduZbieracz.Application.UnitTest.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace EduZbieracz.Application.UnitTest.Categories.Commands
{
    public class CreateCategoryTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoryRepository> _mockCategoryRepository;

        public CreateCategoryTests()
        {
            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidCategory_AddedToCategoriesRepo()
        {
            var handler = new CreatedCategoryCommandHandler(_mockCategoryRepository.Object, _mapper);

            var allCategoriesBeforeCount = (await _mockCategoryRepository.Object.GetAllAsync()).Count;

            var response = await handler.Handle(new CreatedCategoryCommand()
            { Name = "Test", DisplayName = "Test" }
            , CancellationToken.None);

            var allCategories = await _mockCategoryRepository.Object.GetAllAsync();

            response.Success.ShouldBe(true);
            response.ValidationErrors.Count.ShouldBe(0);
            allCategories.Count.ShouldBe(allCategoriesBeforeCount + 1);
            response.CategoryId.ShouldNotBeNull();

        }
    }
}
