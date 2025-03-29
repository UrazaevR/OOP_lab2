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
var ans1 = asyncTask($"http://www.google.com");
var ans2 = asyncTask($"http://www.vk.com");
var ans3 = asyncTask($"http://www.github.com");

await ans1;
await ans2;
await ans3;

Console.WriteLine($"Task 1 answer is: {ans1.Result}");
Console.WriteLine($"Task 2 answer is: {ans2.Result}");
Console.WriteLine($"Task 3 answer is: {ans3.Result}");

timer.Stop();
Console.WriteLine($"The async program ran for {timer.ElapsedMilliseconds} ms");