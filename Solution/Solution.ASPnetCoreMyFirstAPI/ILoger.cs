namespace Solution.ASPnetCoreMyFirstAPI
{
    public interface ILoger
    {
        Task GetAllPersonsAsync(HttpResponse response);

        Task GetPersonAsync(string? id, HttpResponse response, HttpRequest request);

        Task DeletePersonAsync(string? id, HttpResponse response, HttpRequest request);

        Task CreatePersonAsync(HttpResponse response, HttpRequest request);

        Task UpdatePersonAsync(HttpResponse response, HttpRequest request);

    }
}
