using System.Diagnostics;

async Task<string> asyncTask(string url)
{
    HttpClient client = new HttpClient();
    try
    {
        var res = await client.GetAsync(url);
        if (res.IsSuccessStatusCode)
        {
            return await res.Content.ReadAsStringAsync();
        }
        else
        {
            Console.WriteLine($"Error: {res.StatusCode}");
            return null;
        }
    }
    catch (System.Net.Http.HttpRequestException ex)
    {
        Console.WriteLine($"Something went wrong during the request(");
        return ex.Message;
    }
    catch (Exception ex) {
        Console.WriteLine($"Something went wong(");
        return ex.Message;
    }
}


Console.WriteLine("Async programm");
Stopwatch timer = new Stopwatch();
timer.Start();
var ans1 = await asyncTask($"https://random.dog/woof.json");
var ans2 = await asyncTask($"https://rickandmortyapi.com/api/character/1");
var ans3 = await asyncTask($"https://http.hexlet.app/http-api/users/1/posts");

Console.WriteLine($"Task 1 answer is: {ans1}\n");
Console.WriteLine($"Task 2 answer is: {ans2}\n");
Console.WriteLine($"Task 3 answer is: {ans3} \n");

timer.Stop();
Console.WriteLine($"The async program ran for {timer.ElapsedMilliseconds} ms");