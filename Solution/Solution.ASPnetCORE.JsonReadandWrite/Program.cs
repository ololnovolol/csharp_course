

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Run(async (context) =>
{
    var response = context.Response;
    var request = context.Request;

    if (request.Path == "/api/user")
    {
        var responseText = "Некорректные данные";   // содержание сообщения по умолчанию

        if (request.HasJsonContentType())
        {
            var person = await request.ReadFromJsonAsync<Person>();
            if (person != null)
                responseText = $"Name: {person.Name}  Age: {person.Age}";
        }
        await response.WriteAsJsonAsync(new { text = responseText });
    }
    else
    {
        response.ContentType = "text/html; charset=utf-8";
        await response.SendFileAsync("html/index.html");
    }
});

app.Run();

public record Person(string Name, int Age);