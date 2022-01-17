using Ardalis.HttpClientTestExtensions;
using Newtonsoft.Json;
using System.Net.Http.Json;
using XUnitTest.Configurations;
using static XUnitTest.Endpoints.EmployeeModelClassData;

namespace XUnitTest.Endpoints;

[Collection("Sequential")]
public class EmployeeList : IClassFixture<CustomWebApplicationFactory<EmployeeUI>>
{
    private readonly HttpClient _client;

    public EmployeeList(CustomWebApplicationFactory<EmployeeUI> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task ReturnAllEmployee_Test()
    {
        var results = await _client.GetAndDeserialize<List<EmployeeModel>>(Get._urlBase);
        Assert.NotNull(results);
        Assert.True(results.Count > 0, "Expected to be greater than 0.");
    }

    [Theory]
    [InlineData(26, "FN Employee 1")]
    [InlineData(27, "FN Employee 2")]
    [InlineData(28, "FN Employee 3")]
    [InlineData(29, "FN Employee 4")]
    public async Task ReturnEmployeeById_Test(int id, string expected)
    {
        var result = await _client.GetAndDeserialize<EmployeeModel>(Get.GetEmployee(id));
        Assert.Equal(expected, result.firstName);
        Assert.Contains(expected, result.firstName);
    }

    [Theory]
    [InlineData("FN Employee 1", 26)]
    [InlineData("FN Employee 2", 27)]
    [InlineData("FN Employee 3", 28)]
    [InlineData("FN Employee 4", 29)]
    public async Task ReturnEmployeeByName(string name, int expected)
    {

        var result = await _client.GetAndDeserialize<EmployeeModel>(Get.GetEmployeeByFName(name));
        Assert.Equal(expected, result.id);
    }

    [Theory]
    [ClassData(typeof(EmployeeModelClassData))]
    public async Task ReturnPostedEmployee_Test(EmployeeModel model)
    {
        string expected = model.firstName;
        var result = await _client.PostAsJsonAsync(Get._urlBase, model);
        var con = await result.Content.ReadAsStringAsync();
        var deserializedData = JsonConvert.DeserializeObject<EmployeeModel>(con);
        Assert.Equal(expected, deserializedData?.firstName);
    }
}

public class EmployeeModelClassData : IEnumerable<object[]>
{
    IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
             new EmployeeModel()
            {
                firstName = "fname test",
                lastName = "lname test"
            }
         };
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

    IEnumerator<object[]> IEnumerable<object[]>.GetEnumerator() => GetEnumerator();

    public static class Get
    {
        private const string ApiUrlBase = "api/Employee";
        public const string _urlBase = ApiUrlBase;
        public static string GetEmployee(int id)
        {
            return $"{ApiUrlBase}/{id}";
        }
        public static string GetEmployeeByFName(string fname)
        {
            return $"{ApiUrlBase}/GetByName/{fname}";
        }
    }
}
