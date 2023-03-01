﻿using System.Text.RegularExpressions;

namespace IRunes.ViewModels.Tracks
{
    public class TrackDetailsViewModel
    {
        public string Name { get; set; }

        public string Price { get; set; }

        public string Link { get; set; }

        public string IFrameSource
        {
            get
            {
                if (Link.Contains("youtube"))
                {
                    var regex = new Regex(@"youtu(?:\.be|be\.com)/(?:(.*)v(/|=)|(.*/)?)(?<id>[a-zA-Z0-9-_]+)", RegexOptions.IgnoreCase);

                    var videoId = regex.Match(Link).Groups["id"];

                    return $"https://www.youtube.com/embed/{videoId}";
                }
                else
                {
                    return Link;
                }
            }
        }

        public string AlbumId { get; set; }
    }
}
