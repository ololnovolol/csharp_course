namespace Solution.ASPnetCoreMyFirstAPI
{
    public class PersonLoger : ILoger
    {
        List<Person> users;

        public PersonLoger()
        {
            users = new List<Person>()
            {
                new() {Id = Guid.NewGuid().ToString(), Name = "Oleg", Age = 25 },
                new() {Id = Guid.NewGuid().ToString(), Name = "Semen", Age = 46 },
                new() {Id = Guid.NewGuid().ToString(), Name = "Bill", Age = 12}
            };
        }

        public async Task CreatePersonAsync(HttpResponse response, HttpRequest request)
        {
            try
            {
                var user = await request.ReadFromJsonAsync<Person>();
                if (user == null)
                {
                    throw new Exception("Некорректные данные");
                }
                else
                {
                    user.Id = Guid.NewGuid().ToString();
                    users.Add(user);
                    await response.WriteAsJsonAsync(user);
                }
            }
            catch (Exception)
            {
                response.StatusCode = 400;
                await response.WriteAsJsonAsync(new { message = "Некорректные данные" });
            }
        }

        async public Task DeletePersonAsync(string? id, HttpResponse response, HttpRequest request)
        {
            Person? user = users.FirstOrDefault((u) => u.Id == id);
            if (user != null)
            {
                users.Remove(user);
                await response.WriteAsJsonAsync(user);
            }
            else
            {
                response.StatusCode = 404;
                await response.WriteAsJsonAsync(new { message = "Пользователь с таким именем не найден!" });
            }
        }

        async public Task GetAllPersonsAsync(HttpResponse response)
        {
            await response.WriteAsJsonAsync(users);
        }

        async public Task GetPersonAsync(string? id, HttpResponse response, HttpRequest request)
        {
            Person? user = users.FirstOrDefault((u) => u.Id == id); // ищем юзера в списке, если его нет возвращаем дефолд

            if (user != null)
            {
                await response.WriteAsJsonAsync(user);
            }
            else
            {
                response.StatusCode = 404;
                await response.WriteAsJsonAsync(new { message = "Пользователь с таким именем не найден!" });
            }
        }

        public async Task UpdatePersonAsync(HttpResponse response, HttpRequest request)
        {
            try
            {
                Person? userData = await request.ReadFromJsonAsync<Person>();

                if (userData != null)
                {
                    Person user = users.FirstOrDefault((u) => u.Id == userData.Id);

                    user.Name = userData.Name;
                    user.Age = userData.Age;

                    await response.WriteAsJsonAsync(user);
                }
                else
                {
                    response.StatusCode = 404;
                    await response.WriteAsJsonAsync(new { message = "Некорректные данные" });
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("Некорректные данные");
            }
        }
    }
}
