using System;
using Sys = Cosmos.System;
using Cosmos.System.Audio.IO;
using IL2CPU.API.Attribs;

namespace NiVi.etc
{
    public class MetaData
    {
        [ManifestResourceStream(ResourceName = "NiVi.etc.sfx.startup.wav")] public static byte[] StartupB;
        [ManifestResourceStream(ResourceName = "NiVi.etc.sfx.shutdown.wav")] public static byte[] ShutdownB;

        public static MemoryAudioStream Shutdown = MemoryAudioStream.FromWave(ShutdownB);
        public static MemoryAudioStream Startup = MemoryAudioStream.FromWave(StartupB);
    }
}