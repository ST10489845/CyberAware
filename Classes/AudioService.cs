

using System;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Text;
using System.Threading;

namespace CyberAware.Classes
{
    public class AudioService
    {
        public void PlayGreeting()
        {
            // Look for files inside the "Audio" folder
            string wavPath = FindFileInAudioFolder("greeting.wav");
            string m4aPath = FindFileInAudioFolder("greeting.m4a");
            string audioPath = null;

            if (wavPath != null && File.Exists(wavPath))
            {
                audioPath = wavPath;

                if (IsPcmWav(audioPath))
                {
                    PlayWav(audioPath);
                }
                else
                {
                    Console.WriteLine("[Audio] WAV is not PCM — launching default app as fallback.");
                    PlayWithDefaultApp(audioPath);
                }
            }
            else if (m4aPath != null && File.Exists(m4aPath))
            {
                audioPath = m4aPath;
                PlayWithDefaultApp(audioPath);
            }
            else
            {
                ShowFileNotFoundMessage();
            }

            Thread.Sleep(500);
        }

        private void PlayWav(string path)
        {
            try
            {
                using var player = new SoundPlayer(path);
                player.PlaySync(); 
                Console.WriteLine("[Audio] ✓ Voice greeting played!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Audio] Could not play WAV: {ex.Message}");
                Console.Beep();
            }
        }

        private void PlayWithDefaultApp(string path)
        {
            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = path,
                    UseShellExecute = true
                };

                var proc = Process.Start(psi);
                Console.WriteLine("[Audio] ✓ Opened greeting with default app");

                
                if (proc != null)
                {
                    proc.WaitForExit(3500);
                }
                else
                {
                    Thread.Sleep(3500);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Audio] Could not play audio: {ex.Message}");
                Console.Beep();
            }
        }

        private bool IsPcmWav(string path)
        {
            try
            {
                using var fs = File.OpenRead(path);
                if (fs.Length < 44)
                    return false;

                
                byte[] header = new byte[12];
                fs.Read(header, 0, 12);
                if (Encoding.ASCII.GetString(header, 0, 4) != "RIFF" ||
                    Encoding.ASCII.GetString(header, 8, 4) != "WAVE")
                {
                    return false;
                }

                
                fs.Seek(12, SeekOrigin.Begin);
                while (fs.Position <= fs.Length - 8)
                {
                    byte[] chunkHdr = new byte[8];
                    fs.Read(chunkHdr, 0, 8);
                    string chunkId = Encoding.ASCII.GetString(chunkHdr, 0, 4);
                    int chunkSize = BitConverter.ToInt32(chunkHdr, 4);

                    if (chunkId == "fmt ")
                    {
                        if (chunkSize < 2)
                            return false;

                        byte[] fmt = new byte[chunkSize];
                        fs.Read(fmt, 0, chunkSize);
                        ushort audioFormat = BitConverter.ToUInt16(fmt, 0);
                        
                        return audioFormat == 1;
                    }

                    
                    fs.Seek(chunkSize, SeekOrigin.Current);
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        private string FindFileInAudioFolder(string fileName)
        {
            
            string[] searchPaths = {
                
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Audio", fileName),
                
               
                Path.Combine(Directory.GetCurrentDirectory(), "Audio", fileName),
                
                
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Audio", fileName),
                
                
                Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "Audio", fileName),
            };

            foreach (string path in searchPaths)
            {
                try
                {
                    string fullPath = Path.GetFullPath(path);
                    if (File.Exists(fullPath))
                    {
                        Console.WriteLine($"[Audio] Found: {fullPath}");
                        return fullPath;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Audio] Error accessing path {path}: {ex.Message}");
                    
                }
            }

            
            string fallbackPath = FindFile(fileName);
            if (fallbackPath != null)
            {
                Console.WriteLine($"[Audio] Found in root directory (consider moving to Audio folder): {fallbackPath}");
                return fallbackPath;
            }

            return null;
        }

        
        private string FindFile(string fileName)
        {
            string[] searchPaths = {
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName),
                Path.Combine(Directory.GetCurrentDirectory(), fileName),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", fileName),
            };

            foreach (string path in searchPaths)
            {
                try
                {
                    string fullPath = Path.GetFullPath(path);
                    if (File.Exists(fullPath))
                    {
                        return fullPath;
                    }
                }
                catch
                {
                    
                }
            }
            return null;
        }

        private void ShowFileNotFoundMessage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[Audio] greeting.wav or greeting.m4a not found in the 'Audio' folder");
            Console.WriteLine("[Audio] Expected location: [ProjectDirectory]/Audio/greeting.wav or .m4a");
            Console.ResetColor();
            Console.Beep();
        }
    }
}