using System.Text.RegularExpressions;
using ConsoleApp.Models.Interfaces;

namespace ConsoleApp.Models.Implementation
{
    public class MultimediaPlayer
    {
        private static readonly IVideoPlayer AviPlayer = new AviPlayer();
        private static readonly IAudioPlayer WavPlayer = new WavPlayer();
        private static readonly IAudioPlayer Mp3Player = new Mp3Player();
        
        public void PlayFile(string? fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return;
            }
            
            string pattern = @"\.(\w+)$";

            Match match = Regex.Match(fileName, pattern);

            if (match.Success)
            {
                string fileExtension = match.Groups[1].Value;
                switch (fileExtension)
                {
                    case "avi":
                        AviPlayer.PlayVideo(fileName);
                        break;
                    case "wav":
                        WavPlayer.PlayAudio(fileName);
                        break;
                    case "mp3":
                        Mp3Player.PlayAudio(fileName);
                        break;
                    default:
                        Console.WriteLine($"File {fileName} not supported");
                        break;
                }
            }
            else
            {
                Console.WriteLine($"File {fileName} not supported");
            }
        }
    }
}