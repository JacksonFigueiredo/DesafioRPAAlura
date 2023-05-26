using OpenQA.Selenium;
using RPA_Alura.Domain.Models;
using RPA_Alura.Repository.Interfaces;

namespace RPA_Alura.Services.Services
{
    public class AluraSearchService
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IWebDriver _driver;

        public AluraSearchService(ICursoRepository cursoRepository, IWebDriver driver)
        {
            _cursoRepository = cursoRepository;
            _driver = driver;
        }

        public async Task RealizarBusca(string termo)
        {
            _driver.Navigate().GoToUrl("https://www.alura.com.br/");

            var campoBusca = _driver.FindElement(By.Id("header-barraBusca-form-campoBusca"));
            campoBusca.SendKeys(termo);
            campoBusca.Submit();

            var resultados = _driver.FindElements(By.ClassName("busca-resultado"));

            foreach (var resultado in resultados.ToList())
            {
                try
                {
                    var curso = new Curso
                    {
                        Titulo = resultado.FindElement(By.ClassName("busca-resultado-nome")).Text,
                        Descricao = resultado.FindElement(By.ClassName("busca-resultado-descricao")).Text
                    };

                    await _cursoRepository.AdicionarAsync(curso);
                }
                catch (NoSuchElementException ex)
                {
                    Console.WriteLine($"Ocorreu um erro ao processar o resultado da pesquisa. {ex.Message}");
                    continue;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro inesperado ao processar o resultado da pesquisa.\r\n\r\n {ex.Message}");
                    break;
                }
            }
        }
    }
}
