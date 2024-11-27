using ConsoleApp.Models.Interfaces;

namespace ConsoleApp.Models.Implementation
{
    public class WavPlayer : IAudioPlayer
    {
        public void PlayAudio(string? fileName)
        {   
            Console.WriteLine($"WavPlayer::PlayAudio({fileName})");
        }
    }
}