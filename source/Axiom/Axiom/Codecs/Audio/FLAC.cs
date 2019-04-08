﻿/* ----------------------------------------------------------------------
Axiom UI
Copyright (C) 2017-2019 Matt McManis
https://github.com/MattMcManis/Axiom
https://axiomui.github.io
mattmcmanis@outlook.com

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.If not, see <http://www.gnu.org/licenses/>. 
---------------------------------------------------------------------- */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axiom
{
    public class FLAC
    {
        // ---------------------------------------------------------------------------
        // Codec
        // ---------------------------------------------------------------------------
        public static List<AudioView.AudioCodec> codec = new List<AudioView.AudioCodec>()
        {
             new AudioView.AudioCodec()
             {
                 Codec = "flac",
                 Parameters = ""
             }
        };

        public static void Codec_Set()
        {
            // Combine Codec + Parameters
            List<string> codec = new List<string>()
            {
                "-c:a",
                FLAC.codec.FirstOrDefault()?.Codec,
                FLAC.codec.FirstOrDefault()?.Parameters
            };

            VM.AudioView.Audio_Codec = string.Join(" ", codec.Where(s => !string.IsNullOrEmpty(s)));
        }



        // ---------------------------------------------------------------------------
        // Items Source
        // ---------------------------------------------------------------------------

        // -------------------------
        // Stream
        // -------------------------
        public static string stream = "1";

        // -------------------------
        // Channel
        // -------------------------
        public static List<string> channel = new List<string>()
        {
            "Source",
            "Mono",
            "Stereo",
            "5.1"
        };

        // -------------------------
        // Quality
        // -------------------------
        public static List<AudioView.AudioQuality> quality = new List<AudioView.AudioQuality>()
        {
             new AudioView.AudioQuality() { Name = "Auto",     CBR_BitMode = "",     CBR = "",    VBR_BitMode = "", VBR = "", NA = "" },
             new AudioView.AudioQuality() { Name = "Lossless", CBR_BitMode = "",     CBR = "",    VBR_BitMode = "", VBR = ""   },
             new AudioView.AudioQuality() { Name = "320",      CBR_BitMode = "-b:a", CBR = "320", VBR_BitMode = "", VBR = ""   },
             new AudioView.AudioQuality() { Name = "256",      CBR_BitMode = "-b:a", CBR = "256", VBR_BitMode = "", VBR = ""   },
             new AudioView.AudioQuality() { Name = "224",      CBR_BitMode = "-b:a", CBR = "224", VBR_BitMode = "", VBR = ""   },
             new AudioView.AudioQuality() { Name = "192",      CBR_BitMode = "-b:a", CBR = "192", VBR_BitMode = "", VBR = ""   },
             new AudioView.AudioQuality() { Name = "160",      CBR_BitMode = "-b:a", CBR = "160", VBR_BitMode = "", VBR = ""   },
             new AudioView.AudioQuality() { Name = "128",      CBR_BitMode = "-b:a", CBR = "128", VBR_BitMode = "", VBR = ""   },
             new AudioView.AudioQuality() { Name = "96",       CBR_BitMode = "-b:a", CBR = "96",  VBR_BitMode = "", VBR = ""   },
             new AudioView.AudioQuality() { Name = "Custom",   CBR_BitMode = "-b:a", CBR = "",    VBR_BitMode = "", VBR = ""   },
             new AudioView.AudioQuality() { Name = "Mute",     CBR_BitMode = "",     CBR = "",    VBR_BitMode = "", VBR = ""   }
        };

        // -------------------------
        // Compression Level
        // -------------------------
        public static List<string> compressionLevel = new List<string>()
        {
            "auto",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
        };

        // -------------------------
        // Sample Rate
        // -------------------------
        public static List<AudioView.AudioSampleRate> sampleRate = new List<AudioView.AudioSampleRate>()
        {
             new AudioView.AudioSampleRate() { Name = "auto",     Frequency = "" },
             new AudioView.AudioSampleRate() { Name = "8k",       Frequency = "8000" },
             new AudioView.AudioSampleRate() { Name = "11.025k",  Frequency = "11025" },
             new AudioView.AudioSampleRate() { Name = "12k",      Frequency = "12000" },
             new AudioView.AudioSampleRate() { Name = "16k",      Frequency = "16000" },
             new AudioView.AudioSampleRate() { Name = "22.05k",   Frequency = "22050" },
             new AudioView.AudioSampleRate() { Name = "24k",      Frequency = "24000" },
             new AudioView.AudioSampleRate() { Name = "32k",      Frequency = "32000" },
             new AudioView.AudioSampleRate() { Name = "44.1k",    Frequency = "44100" },
             new AudioView.AudioSampleRate() { Name = "48k",      Frequency = "48000" }
        };

        // -------------------------
        // Bit Depth
        // -------------------------
        public static List<AudioView.AudioBitDepth> bitDepth = new List<AudioView.AudioBitDepth>()
        {
             new AudioView.AudioBitDepth() { Name = "auto", Depth = "" },
             new AudioView.AudioBitDepth() { Name = "16",   Depth = "-sample_fmt s16" },
             new AudioView.AudioBitDepth() { Name = "32",   Depth = "-sample_fmt s32" }
        };



        // ---------------------------------------------------------------------------
        // Controls Behavior
        // ---------------------------------------------------------------------------

        // -------------------------
        // Items Source
        // -------------------------
        public static void Controls_ItemsSource()
        {
            // Channel
            VM.AudioView.Audio_Channel_Items = channel;

            // Quality
            VM.AudioView.Audio_Quality_Items = quality;

            // Compression Level
            VM.AudioView.Audio_CompressionLevel_Items = compressionLevel;

            // Samplerate
            VM.AudioView.Audio_SampleRate_Items = sampleRate;

            // Bit Depth
            VM.AudioView.Audio_BitDepth_Items = bitDepth;
        }

        // -------------------------
        // Selected Items
        // -------------------------
        public static void Controls_Selected()
        {
            //VM.AudioView.Audio_Stream_SelectedItem = "all";

            // Compression Level
            VM.AudioView.Audio_CompressionLevel_SelectedItem = "auto";
        }

        // -------------------------
        // Checked
        // -------------------------
        public static void Controls_Checked()
        {
            // None
        }

        // -------------------------
        // Unchecked
        // -------------------------
        public static void Controls_Unhecked()
        {
            // BitRate Mode
            VM.AudioView.Audio_VBR_IsChecked = false;
        }

        // -------------------------
        // Enabled
        // -------------------------
        public static void Controls_Enable()
        {
            // Audio Codec
            VM.AudioView.Audio_Codec_IsEnabled = true;

            // Stream
            VM.AudioView.Audio_Stream_IsEnabled = true;

            // Channel
            VM.AudioView.Audio_Channel_IsEnabled = true;

            // Audio Quality
            VM.AudioView.Audio_Quality_IsEnabled = true;

            // Compression Level
            VM.AudioView.Audio_CompressionLevel_IsEnabled = true;

            // SampleRate
            VM.AudioView.Audio_SampleRate_IsEnabled = true;

            // Bit Depth
            VM.AudioView.Audio_BitDepth_IsEnabled = true;

            // Volume
            VM.AudioView.Audio_Volume_IsEnabled = true;

            // Hard Limiter
            VM.AudioView.Audio_HardLimiter_IsEnabled = true;
        }

        // -------------------------
        // Disabled
        // -------------------------
        public static void Controls_Disable()
        {
            // VBR Button
            VM.AudioView.Audio_VBR_IsEnabled = false;
        }
    }
}
