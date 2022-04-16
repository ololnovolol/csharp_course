

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//app.UseWelcomePage(); // подключение к мидлвару WelcomePageMiddleware

int x = 2;

//app.Run(async (myContext) => await myContext.Response.WriteAsync("dcc"));
// or
//app.Run(HandleRequest);



//// получение пути запроса https://localhost:7094/next/daily/hello
//app.Run(async (context) => await context.Response.WriteAsync
//($"Path: {context.Request.Path}")); 

//или так https://localhost:7256/users?name=Tom&age=37
//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";

//    //Каждому параметру с помощью знака равно передается некоторое значение.
//    await context.Response.WriteAsync($"<p>Path: {context.Request.Path}</p>" +
//        $"<p>QueryString: {context.Request.QueryString}</p>");
//});

//https://localhost:7094/users?name=Tom&age=37 можно вытащить из словаря Query
app.Run(async (context) =>
{
    string name = context.Request.Query["name"];
    string age = context.Request.Query["age"];
    await context.Response.WriteAsync($"{name} - {age}");
});

//app.Run(HandleResponse);

app.Run();









//async Task HandleRequest(HttpContext context)
//{
//    await context.Response.WriteAsync("hi hi");
//}

//async Task HandleRequest(HttpContext context)
//{

//    x = x * 2;
//    await context.Response.WriteAsync($"result 2 * 2 = {x}", System.Text.Encoding.Default);
//}

//async Task HandleRequest(HttpContext context)
//{
//    var response = context.Response;
//    //response.StatusCode = 404;  // Установка кодов статуса
//    response.Headers.ContentLanguage = "ru=RU";
//    response.Headers.ContentType = "text/plain; charset=utf-8"; // для вывода кирилицы
//    response.Headers.Append("secret-id", "256"); // добавление кастомного заголовка
//    await response.WriteAsync("моя проэкт лежит на GitHub =)");
//}

//async Task HandleRequest(HttpContext context)
//{
//    var response = context.Response;
//    response.Headers.ContentType = "text/html; charset=utf-8"; // для вывода HTML
//    await response.WriteAsync("<h2>Воробушек=)</h2>" +
//        "<h3>Welcome to web site vorobushek.com </h3>");
//}

async Task HandleResponse(HttpContext context)
{
    var response = context.Response;
    response.ContentType = "text/html; charset=utf-8";
    var stringBuilder = new System.Text.StringBuilder("<table>");

    foreach (var header in context.Request.Headers)
    {
        stringBuilder.Append($"<tr><td>{header.Key}</td><td>{header.Value}</td></tr>");
    }
    stringBuilder.Append("</table>");
    await context.Response.WriteAsync(stringBuilder.ToString());
}
