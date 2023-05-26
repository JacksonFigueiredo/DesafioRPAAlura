using RPA_Alura.Repository.Interfaces;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using RPA_Alura.Repository.Services;
using OpenQA.Selenium;
using RPA_Alura.Services.Services;
using OpenQA.Selenium.Chrome;
using RPA_Alura.Repository.Data;

namespace RPA_Alura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register<MeuDbContext>(Lifestyle.Scoped);
            container.Register<ICursoRepository, CursoRepositoryService>();
            container.Register<IWebDriver>(() => new ChromeDriver(), Lifestyle.Scoped);
            container.Register<AluraSearchService>(Lifestyle.Scoped);

            container.Verify();

            using (AsyncScopedLifestyle.BeginScope(container))
            {
                var dbContext = container.GetInstance<MeuDbContext>();
                dbContext.Database.EnsureCreated();

                var aluraSearchService = container.GetInstance<AluraSearchService>();
                aluraSearchService.RealizarBusca("C#"); // Realizar busca com o termo desejado
            }
        }
    }
}