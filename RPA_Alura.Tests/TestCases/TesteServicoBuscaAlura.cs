using Moq;
using OpenQA.Selenium;
using RPA_Alura.Domain.Models;
using RPA_Alura.Repository.Interfaces;
using RPA_Alura.Services.Services;

namespace RPA_Alura.Tests.TestCases
    {
        public class TesteServicoBuscaAlura
        {
            private readonly Mock<ICursoRepository> _cursoRepositoryMock;
            private readonly Mock<IWebDriver> _webDriverMock;
            private readonly AluraSearchService _service;

            public TesteServicoBuscaAlura()
            {
                _cursoRepositoryMock = new Mock<ICursoRepository>();
                _webDriverMock = new Mock<IWebDriver>();
                _service = new AluraSearchService(_cursoRepositoryMock.Object, _webDriverMock.Object);
            }

            [Fact]
            public async Task RealizarBuscaTest()
            {
                // Arrange
                var termo = "teste";

                _webDriverMock.Setup(x => x.Navigate().GoToUrl(It.IsAny<string>()));
                _webDriverMock.Setup(x => x.FindElement(By.Id("header-barraBusca-form-campoBusca"))).Returns(new Mock<IWebElement>().Object);
                _webDriverMock.Setup(x => x.FindElements(By.ClassName("busca-resultado"))).Returns(new List<IWebElement> { new Mock<IWebElement>().Object }.AsReadOnly());
                _cursoRepositoryMock.Setup(x => x.AdicionarAsync(It.IsAny<Curso>())).Returns(Task.CompletedTask);

                // Act
                await _service.RealizarBusca(termo);

                // Assert
                _webDriverMock.Verify(x => x.Navigate().GoToUrl(It.IsAny<string>()), Times.Once);
                _webDriverMock.Verify(x => x.FindElement(By.Id("header-barraBusca-form-campoBusca")), Times.Once);
                _webDriverMock.Verify(x => x.FindElements(By.ClassName("busca-resultado")), Times.Once);

                _cursoRepositoryMock.Verify(x => x.ObterTodosAsync(), Times.Once);
            }
        }
    }

