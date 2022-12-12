namespace unitTests;

public class TestAPIController
{
    private readonly HttpClient _httpClient;
    IDataService _dataService;

    public TestAPIController()
    {
        _httpClient = new HttpClient();
        _dataService = new DataService();
    }

    [Fact]
    public async Task GetPropertiesAsyncTest()
    {
        // Arrange
        // Act
        var response = await _httpClient.GetAsync("http://localhost:8000/api/prop/");
        // Assert
        response.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);
    }

    [Theory]
    [InlineData(1)]
    public async Task RemovePropAsyncTest(int Id)
    {
        // Arrange
        int id = Id;
        // Act
        var response = await _httpClient.DeleteAsync($"http://localhost:8000/api/prop/{id}");
        // Assert
        response.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);
    }

}