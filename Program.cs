using System;

public class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        if (title == null || title.Length > 100) throw new ArgumentNullException("Judul video tidak valid.");
        Random random = new Random();
        id = random.Next(10000, 99999);
        this.title = title;
        playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        if (count < 0 || count > 10000000) throw new ArgumentOutOfRangeException("Input penambahan play count tidak valid");
        try
        {
            checked { playCount += count; }
        }
        catch (OverflowException e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        playCount += count;
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("ID: " + id);
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Play Count: " + playCount);
    }

    public static void Main(string[] args)
    {
        string judulVideo = "Tutorial Design By Contract - fajae";
        SayaTubeVideo video = new SayaTubeVideo(judulVideo);
        for (int i = 0; i < 100000; i++)
        {
            video.IncreasePlayCount(30);
        }
        video.PrintVideoDetails();
    }
}