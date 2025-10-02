using Xunit;
using IntegrationTests.Abstractions;

namespace IntegrationTests.Helpers
{
    [CollectionDefinition("FunctionalTest")]
    public class FunctionalTestCollectionFixture : ICollectionFixture<FunctionalTestWebAppFactory>
    {
        // Этот класс не содержит кода, его цель - быть местом для применения
        // [CollectionDefinition] и всех интерфейсов ICollectionFixture<>
    }
}
