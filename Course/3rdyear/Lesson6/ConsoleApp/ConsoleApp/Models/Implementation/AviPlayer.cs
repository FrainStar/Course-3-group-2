using ConsoleApp.Models.Interfaces;

namespace ConsoleApp.Models.Implementation
{
    public class AviPlayer : IVideoPlayer
    {
        public void PlayVideo(string? fileName)
        {   
            Console.WriteLine($"AviPlayer::PlayVideo({fileName})");
        }
    }
}