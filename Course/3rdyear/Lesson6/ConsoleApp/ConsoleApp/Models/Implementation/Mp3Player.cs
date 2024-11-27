using ConsoleApp.Models.Interfaces;

namespace ConsoleApp.Models.Implementation
{
    public class Mp3Player : IAudioPlayer
    {
        public void PlayAudio(string? fileName)
        {   
            Console.WriteLine($"Mp3Player::PlayAudio({fileName})");
        }
    }
}