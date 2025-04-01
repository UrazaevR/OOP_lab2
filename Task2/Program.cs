using System.Diagnostics;

async Task<string> SyncTask(string url)
{
    HttpClient client = new HttpClient();
    try
    {
        var res = client.GetAsync(url);
        if (res.Result.IsSuccessStatusCode)
        {
            return await res.Result.Content.ReadAsStringAsync();
        }
        else
        {
            Console.WriteLine($"Error: {res.Result.StatusCode}");
            return null;
        }
    }
    catch (System.Net.Http.HttpRequestException ex)
    {
        Console.WriteLine($"Something went wrong during the request.(");
        return ex.Message;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Something went wong(");
        return ex.Message;
    }
}


Console.WriteLine("Sync programm");
Stopwatch timer = new Stopwatch();
timer.Start();
Console.WriteLine($"Task 1 answer is: {SyncTask($"https://random.dog/woof.json").Result}");
Console.WriteLine($"Task 2 answer is: {SyncTask($"https://rickandmortyapi.com/api/character/1").Result}");
Console.WriteLine($"Task 3 answer is: {SyncTask($"https://http.hexlet.app/http-api/users/1/posts").Result}");

timer.Stop();
Console.WriteLine($"The sync program ran for {timer.ElapsedMilliseconds} ms");