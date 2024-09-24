using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace curso.api.tests.Integrations.Controllers
{
    public class AlunoControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly HttpClient _httpClient;

        public AlunoControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _httpClient = _factory.CreateClient();
        }

        //WhenGivenThen
        //Quando_Dados_EntaoResultadoEsperado
        //Login_ENteringExistingEmailAndPassword_ReturnSuccess

        [Fact]
        public void Logar_InformandoUsuarioESenhaExistentes_RetornarSucesso()
        {

            //Arrange
            var loginViewModelInput = new LoginViewModelInput
            {
                Email = "adriano@teste.com",
                Senha = "321789"
            };

            //Act
            StringContent content = new StringContent(JsonConvert.SerializeObject(loginViewModelInput));

            var httpClientRequest = _httpClient.PostAsync("/api/alunos/login", content).GetAwaiter().GetResult();

            //Assert
            Assert.Equal(HttpStatusCode.OK, httpClientRequest.StatusCode);
        }
    }
}