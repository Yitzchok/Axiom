﻿/* ----------------------------------------------------------------------
Axiom UI
Copyright (C) 2017-2019 Matt McManis
http://github.com/MattMcManis/Axiom
http://axiomui.github.io
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
    public class FFV1
    {
        // ---------------------------------------------------------------------------
        // Arguments
        // ---------------------------------------------------------------------------

        // -------------------------
        // Codec
        // -------------------------
        // Codec
        public static string codec = "ffv1";

        // Codec Parameters
        public static string codecParameters = "-level 3 -coder 1 -context 1 -g 1 -slices 24 -slicecrc 1";



        // ---------------------------------------------------------------------------
        // Items Source
        // ---------------------------------------------------------------------------

        // -------------------------
        // Encode Speed
        // -------------------------
        public static List<ViewModel.VideoEncodeSpeed> encodeSpeed = new List<ViewModel.VideoEncodeSpeed>()
        {
             new ViewModel.VideoEncodeSpeed() { Name = "None", Command = ""},
        };

        // -------------------------
        // Pixel Format
        // -------------------------
        public static List<string> pixelFormat = new List<string>()
        {
            "auto",
            "yuv420p",
            "yuva420p",
            "yuva422p",
            "yuv444p",
            "yuva444p",
            "yuv440p",
            "yuv422p",
            "yuv411p",
            "yuv410p",
            "bgr0",
            "bgra",
            "yuv420p16le",
            "yuv422p16le",
            "yuv444p16le",
            "yuv444p9le",
            "yuv422p9le",
            "yuv420p9le",
            "yuv420p10le",
            "yuv422p10le",
            "yuv444p10le",
            "yuv420p12le",
            "yuv422p12le",
            "yuv444p12le",
            "yuva444p16le",
            "yuva422p16le",
            "yuva420p16le",
            "yuva444p10le",
            "yuva422p10le",
            "yuva420p10le",
            "yuva444p9le",
            "yuva422p9le",
            "yuva420p9le",
            "gray16le",
            "gray",
            "gbrp9le",
            "gbrp10le",
            "gbrp12le",
            "gbrp14le",
            "gbrap10le",
            "gbrap12le",
            "ya8",
            "gray10le",
            "gray12le",
            "gbrp16le",
            "rgb48le",
            "gbrap16le",
            "rgba64le",
            "gray9le",
            "yuv420p14le",
            "yuv422p14le",
            "yuv444p14le",
            "yuv440p10le",
            "yuv440p12le"
        };

        // -------------------------
        // Quality
        // -------------------------
        public static List<ViewModel.VideoQuality> quality = new List<ViewModel.VideoQuality>()
        {
             new ViewModel.VideoQuality() { Name = "Auto",     CRF = "", CBR_BitMode = "", CBR = "", VBR_BitMode = "", VBR = "", Minrate = "", Maxrate = "", Bufsize ="", NA = "" },
             new ViewModel.VideoQuality() { Name = "Lossless", CRF = "", CBR_BitMode = "", CBR = "", VBR_BitMode = "", VBR = "", Minrate = "", Maxrate = "", Bufsize ="", Lossless = "" },
        };

        // -------------------------
        // Pass
        // -------------------------
        public static void EncodingPass(ViewModel vm)
        {
            // -------------------------
            // Quality
            // -------------------------
            // Auto
            if (vm.Video_Quality_SelectedItem == "Auto")
            {
                vm.Video_Pass_Items = new List<string>()
                {
                    "2 Pass"
                };

                vm.Video_Pass_SelectedItem = "2 Pass";
                vm.Video_Pass_IsEnabled = false;
                VideoControls.passUserSelected = false;

                vm.Video_CRF_IsEnabled = false;
            }
            // Lossless
            else if (vm.Video_Quality_SelectedItem == "Lossless")
            {
                vm.Video_Pass_Items = new List<string>()
                {
                    "1 Pass",
                    "2 Pass"
                };

                vm.Video_Pass_IsEnabled = true;
                vm.Video_CRF_IsEnabled = false;
            }
            // Custom
            else if (vm.Video_Quality_SelectedItem == "Custom")
            {
                vm.Video_Pass_Items = new List<string>()
                {
                    "1 Pass",
                    "2 Pass"
                };

                vm.Video_Pass_IsEnabled = true;
                vm.Video_CRF_IsEnabled = true;
            }
            // None
            else if (vm.Video_Quality_SelectedItem == "None")
            {
                vm.Video_Pass_Items = new List<string>()
                {
                    "auto"
                };

                vm.Video_Pass_IsEnabled = false;
                vm.Video_CRF_IsEnabled = false;
            }
            // Presets: Ultra, High, Medium, Low, Sub
            else
            {
                vm.Video_Pass_Items = new List<string>()
                {
                    "1 Pass",
                    "2 Pass"
                };

                vm.Video_Pass_IsEnabled = true;
                vm.Video_CRF_IsEnabled = false;

                // Default to CRF
                if (VideoControls.passUserSelected == false)
                {
                    vm.Video_Pass_SelectedItem = "2 Pass";
                    VideoControls.passUserSelected = true;
                }
            }

            // Clear TextBoxes
            if (vm.Video_Quality_SelectedItem == "Auto" ||
                vm.Video_Quality_SelectedItem == "Lossless" ||
                vm.Video_Quality_SelectedItem == "Custom" ||
                vm.Video_Quality_SelectedItem == "None"
                )
            {
                vm.Video_CRF_Text = string.Empty;
                vm.Video_Bitrate_Text = string.Empty;
                vm.Video_Minrate_Text = string.Empty;
                vm.Video_Maxrate_Text = string.Empty;
                vm.Video_Bufsize_Text = string.Empty;
            }

        }

        // -------------------------
        // Optimize
        // -------------------------
        public static List<ViewModel.VideoOptimize> optimize = new List<ViewModel.VideoOptimize>()
        {
            new ViewModel.VideoOptimize() { Name = "None", Tune = "none", Profile = "none", Level = "none", Command = "" },
        };

        // -------------------------
        // Tune
        // -------------------------
        public static List<string> tune = new List<string>()
        {
            "none",
        };

        // -------------------------
        // Profile
        // -------------------------
        public static List<string> profile = new List<string>()
        {
            "none",
        };

        // -------------------------
        // Level
        // -------------------------
        public static List<string> level = new List<string>()
        {
            "none",
        };



        // ---------------------------------------------------------------------------
        // Controls Behavior
        // ---------------------------------------------------------------------------

        // -------------------------
        // Items Source
        // -------------------------
        public static void controlsItemSource(ViewModel vm)
        {
            // Encode Speed
            vm.Video_EncodeSpeed_Items = encodeSpeed;

            // Pixel Format
            vm.Video_PixelFormat_Items = pixelFormat;

            // Pass
            //vm.Video_Pass_Items = pass;
            EncodingPass(vm);

            // Video Quality
            vm.Video_Quality_Items = quality;

            // Optimize
            vm.Video_Optimize_Items = optimize;
            // Tune
            vm.Optimize_Tune_Items = tune;
            // Profile
            vm.Optimize_Profile_Items = profile;
            // Level
            vm.Video_Optimize_Level_Items = level;
        }


        // -------------------------
        // Selected Item
        // -------------------------
        public static void controlsSelected(ViewModel vm)
        {

            // Pixel Format
            vm.Video_PixelFormat_SelectedItem = "yuv422p10le";

            // Framerate
            vm.Video_FPS_SelectedItem = "auto";
        }

        // -------------------------
        // Checked
        // -------------------------
        public static void controlsChecked(ViewModel vm)
        {
            // None
        }

        // -------------------------
        // Unchecked
        // -------------------------
        public static void controlsUnhecked(ViewModel vm)
        {
            // Bitrate Mode
            vm.Video_VBR_IsChecked = false;
        }

        // -------------------------
        // Enabled
        // -------------------------
        public static void controlsEnable(ViewModel vm)
        {
            // Video Codec
            vm.Video_Codec_IsEnabled = true;

            // Video Quality
            vm.Video_Quality_IsEnabled = true;

            // Pixel Format
            vm.Video_PixelFormat_IsEnabled = true;

            // Framerate
            vm.Video_FPS_IsEnabled = true;

            // Scaling
            vm.Video_ScalingAlgorithm_IsEnabled = true;

            // Crop
            vm.Video_Crop_IsEnabled = true;

            // Subtitle Codec
            vm.Subtitle_Codec_IsEnabled = true;

            // Subtitle Stream
            vm.Subtitle_Stream_IsEnabled = true;
        }

        // -------------------------
        // Disabled
        // -------------------------
        public static void controlsDisable(ViewModel vm)
        {
            // Video Encode Speed
            vm.Video_EncodeSpeed_IsEnabled = false;

            // Video VBR
            vm.Video_VBR_IsEnabled = false;

            // Optimize
            vm.Video_Optimize_IsEnabled = false;
        }


    }
}
