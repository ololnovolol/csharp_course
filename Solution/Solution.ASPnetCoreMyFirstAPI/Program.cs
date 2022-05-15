using Solution.ASPnetCoreMyFirstAPI;
using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
PersonLoger ilog = new PersonLoger();


app.Run(async (context) =>
{
    var response = context.Response;
    var request = context.Request;
    var path = context.Request.Path;
    response.ContentType = "text/html; charset=utf-8";

    //string expressionForNumber = "^/api/users/([0 - 9]+)$";   // если id представляет число

    // 2e752824-1657-4c7f-844b-6ec2e168e99c
    string expressionForGuid = @"^/api/users/\w{8}-\w{4}-\w{4}-\w{4}-\w{12}$";


    if (path == "/api/users" && request.Method == "GET")
    {
        await ilog.GetAllPersonsAsync(response);
    }
    else if (Regex.IsMatch(path, expressionForGuid) && request.Method == "GET")
    {
        // получаем id из адреса url
        string? id = path.Value?.Split("/")[3];
        await ilog.GetPersonAsync(id, response, request);
    }
    else if (path == "/api/users" && request.Method == "POST")
    {
        await ilog.CreatePersonAsync(response, request);
    }
    else if (path == "/api/users" && request.Method == "PUT")
    {
        await ilog.UpdatePersonAsync(response, request);
    }
    else if (Regex.IsMatch(path, expressionForGuid) && request.Method == "DELETE")
    {
        string? id = path.Value?.Split("/")[3];
        await ilog.DeletePersonAsync(id, response, request);
    }
    else if (path == "/upload" && request.Method == "POST")
    {
        IFormFileCollection files = request.Form.Files;

        string uploadPath = $"{Directory.GetCurrentDirectory()}/uploads";

        Directory.CreateDirectory(uploadPath);

        foreach (var file in files)
        {
            string filePath = $"{uploadPath}/{file.FileName}";

            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fs);
            }

        }
        await response.WriteAsync("Files has been saved");

    }
    else
    {
        response.ContentType = "text/html; charset=utf-8";
        await response.SendFileAsync("html/index.html");
    }
});

app.Run();
