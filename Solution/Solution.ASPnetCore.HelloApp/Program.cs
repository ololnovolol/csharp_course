

using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");  // call base hello world

//BaseMidlewareHelloASPnet(); // call base asp midleware world

//app.Run(async (myContext) => await myContext.Response.WriteAsync("dcc"));
////or
//app.Run(HandleRequest0); // call base my string

//app.Run(HandleRequest1);
//app.Run(HandleRequest2);
//app.Run(HandleRequest3);

//// ��������� ���� ������� https://localhost:7094/next/daily/hello
//app.Run(async (context) => await context.Response.WriteAsync
//($"Path: {context.Request.Path}"));

////��� ��� https://localhost:7256/users?name=Tom&age=37
//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";

//    //������� ��������� � ������� ����� ����� ���������� ��������� ��������.
//    await context.Response.WriteAsync($"<p>Path: {context.Request.Path}</p>" +
//        $"<p>QueryString: {context.Request.QueryString}</p>");
//});

//app.Run(HandleResponse);

////��������� ���� �������
//app.Run(async (context) => await context.Response.WriteAsync($"Path: {context.Request.Path}"));

////�������������� � ������
//app.Run(HandlePathResponse);

//app.Run(HandleQueryvar1);

//app.Run(HandleQueryvar2);

//app.Run(HandleQueryvar3);

////run FileImage
//app.Run(async (context) =>
//    await context.Response.SendFileAsync("pictures/iAmPicture.jpg"));

//Run HtmlFile
//app.Run(async (context) =>
//{
//    var path = context.Request.Path;
//    var fullPath = $"Html/{path}";
//    //var fullPath = "Html//";
//    var response = context.Response;

//    response.ContentType = "text/html; charset=utf-8";

//    if (File.Exists(fullPath))
//    {
//        //https://localhost:7094/about.html
//        //https://localhost:7094/contact.html
//        //https://localhost:7094/index.html
//        await response.SendFileAsync(fullPath);
//    }
//    else
//    {
//        response.StatusCode = 404;
//        await response.WriteAsync("<h2>404 Not Found</h2>");
//    }

//});

//���������� �����
//app.Run(async (context) =>
//{
//    context.Response.Headers.ContentDisposition = "attachment; filename=my_picture.jpg";
//    await context.Response.SendFileAsync("pictures/iAmPicture.jpg");

//});

// ���������� ����� ������ ���� �������� �� � ��������� �������, � ���� ���������� � ���� ������� IFieInfo
//app.Run(async (context) =>
//{
//    var fileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
//    var fileinfo = fileProvider.GetFileInfo("pictures/iAmPicture.jpg");

//    context.Response.Headers.ContentDisposition = "attachment; filename=my_forest2.jpg";
//    await context.Response.SendFileAsync(fileinfo);
//});

//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";

//    // ���� ��������� ���� �� ������ "/postuser", �������� ������ �����
//    if (context.Request.Path == "/postuser")
//    {
//        var form = context.Request.Form;
//        string name = form["name"];
//        string age = form["age"];
//        string[] languages = form["languages"];

//        await context.Response.WriteAsync($"<div>" +
//                            $"<p>Name: {name}</p>" +
//                            $"<p>Age: {age}</p>" +
//                            $"<p>Languages:{languages[0]}{languages[1]}{languages[2]}</p>" +
//                            $"</div>");
//    }
//    else
//    {
//        await context.Response.SendFileAsync("html/index.html");
//    }
//});

//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";

//    // ���� ��������� ���� �� ������ "/postuser", �������� ������ �����
//    if (context.Request.Path == "/postuser")
//    {
//        var form = context.Request.Form;
//        string name = form["name"];
//        string age = form["age"];
//        string[] languages = form["languages"];

//        string langs = string.Empty;
//        foreach (var item in languages)
//        {
//            langs += " [" + item + "]";
//        }

//        await context.Response.WriteAsync($"<div>" +
//            $"<p>Name: {name}</p>" +
//            $"<p>Age: {age}</p>" +
//            $"<p>Languages:{langs}</p></div>");
//    }
//    else
//    {
//        await context.Response.SendFileAsync("html/index.html");
//    }
//});

app.Run(async (context) =>
{
    if (context.Request.Path == "/old")
    {
        //context.Response.Redirect("/new");
        context.Response.Redirect("https://z2.fm/");
    }
    else if (context.Request.Path == "/new")
    {
        await context.Response.SendFileAsync("html/index.html");
    }
    else
    {
        await context.Response.WriteAsync("<p><a href=https://localhost:7094/new >/new</ a ></ p > " +
            "<p><a href=https://localhost:7094/old>/old</a></p>" +
            "<p><a href=https://localhost:7094/main>/this main</a></p>");
    }

});

app.Run();

#region HandleRequests

void BaseMidlewareHelloASPnet()
{
    app.UseWelcomePage(); // ����������� � �������� WelcomePageMiddleware
}

async Task HandleRequest0(HttpContext context)
{
    await context.Response.WriteAsync("hi hi");
}

async Task HandleRequest1(HttpContext context)
{
    int x = 2;
    x = x * 2;
    await context.Response.WriteAsync($"result 2 * 2 = {x}", System.Text.Encoding.Default);
}

async Task HandleRequest2(HttpContext context)
{
    var response = context.Response;
    //response.StatusCode = 404;  // ��������� ����� �������
    response.Headers.ContentLanguage = "ru=RU";
    response.Headers.ContentType = "text/plain; charset=utf-8"; // ��� ������ ��������
    response.Headers.Append("secret-id", "256"); // ���������� ���������� ���������
    await response.WriteAsync("��� ������ ����� �� GitHub =)");
}

async Task HandleRequest3(HttpContext context)
{
    var response = context.Response;
    response.Headers.ContentType = "text/html; charset=utf-8"; // ��� ������ HTML
    await response.WriteAsync("<h2>���������=)</h2>" +
        "<h3>Welcome to web site vorobushek.com </h3>");
}

async Task HandleResponse(HttpContext context)
{
    var response = context.Response;
    response.ContentType = "text/html; charset=utf-8";
    var stringBuilder = new System.Text.StringBuilder("<table>");

    foreach (var header in context.Request.Headers)
    {
        stringBuilder.Append($"<tr>" +
            $"<td>{header.Key}</td>" +
            $"<td>{header.Value}</td>" +
            $"</tr>");
    }
    stringBuilder.Append("</table>");
    await context.Response.WriteAsync(stringBuilder.ToString());
}

async Task HandlePathResponse(HttpContext context)
{
    var response = context.Response;
    var path = context.Request.Path;
    var now = DateTime.Now;

    if (path == "/data")
    {
        await response.WriteAsync($"Date: {now.ToShortDateString()}");
    }
    else if (path == "/time")
    {
        await response.WriteAsync($"Time: {now.ToShortTimeString()}");
    }
    else if (path == "/minute")
    {
        await response.WriteAsync($"Minute: {now.ToString()}");
    }
    else
    {
        await response.WriteAsync($"\tdata => https://localhost:7094/data \n\thours => https://localhost:7094/time  \n\tminutes => https://localhost:7094/minute");

    }

}

async Task HandleQueryvar1(HttpContext context)
{
    //https://localhost:7094/users?name=Tom&age=37
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.WriteAsync($"<p>Path: {context.Request.Path}</p>" +
        $"<p>QueryString: {context.Request.QueryString}</p>");
}

async Task HandleQueryvar2(HttpContext context)
{
    context.Response.ContentType = "text/html; charset=utf-8";
    System.Text.StringBuilder stringB = new System.Text.StringBuilder
        ("<h3>��������� ������ �������</h3><table>");
    stringB.Append("<tr><td>��������</td><td>��������</td></tr>");

    foreach (var item in context.Request.Query)
    {
        stringB.Append($"<tr><td>{item.Key}</td><td>{item.Value}</td></tr>");
    }
    stringB.Append("<table>");

    await context.Response.WriteAsync(stringB.ToString());
}

async Task HandleQueryvar3(HttpContext context)
{
    //https://localhost:7094/users?name=Tom&age=37 ����� �������� �� ������� Query

    string name = context.Request.Query["name"];
    string age = context.Request.Query["age"];
    await context.Response.WriteAsync($"{name} - {age}");
}

#endregion
