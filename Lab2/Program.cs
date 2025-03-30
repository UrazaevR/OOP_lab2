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
var ans1 = asyncTask($"https://random.dog/woof.json");
var ans2 = asyncTask($"https://rickandmortyapi.com/api/character/1");
var ans3 = asyncTask($"https://http.hexlet.app/http-api/users/1/posts");

await ans1;
await ans2;
await ans3;

Console.WriteLine($"Task 1 answer is: {ans1.Result}\n");
Console.WriteLine($"Task 2 answer is: {ans2.Result}\n");
Console.WriteLine($"Task 3 answer is: {ans3.Result} \n");

timer.Stop();
Console.WriteLine($"The async program ran for {timer.ElapsedMilliseconds} ms");