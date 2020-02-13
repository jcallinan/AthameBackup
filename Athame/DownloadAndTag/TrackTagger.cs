using System;
using System.IO;
using Athame.PluginAPI.Service;
using Athame.Settings;
using TagLib;
using File = TagLib.File;
using SysFile = System.IO.File;

namespace Athame.DownloadAndTag
{
    public class TrackTagger
    {
        private const string CopyrightText = "Respect the artists! Pay for music when you can! Downloaded with Athame";

        public static void Write(string path, Track track)
        {
            

            using (var file = File.Create(path))
            {
                file.Tag.Title = track.Title;
                file.Tag.Performers = new[] {track.Artist.Name};
                if (track.Album.Artist != null)
                {
                    file.Tag.AlbumArtists = new[] {track.Album.Artist.Name};
                }
                file.Tag.Genres = new[] {track.Genre};
                file.Tag.Album = track.Album.Title;
                file.Tag.Track = (uint) track.TrackNumber;
                file.Tag.TrackCount = (uint) (track.Album.GetNumberOfTracksOnDisc(track.DiscNumber) ?? 0);
                file.Tag.Disc = (uint) track.DiscNumber;
                file.Tag.DiscCount = (uint) (track.Album.GetTotalDiscs() ?? 0 );
                file.Tag.Year = (uint) track.Year;
                file.Tag.Copyright = CopyrightText;
                file.Tag.Comment = CopyrightText;
              

                file.Save();
            }

            string fileName = null;
         
        }
    }
}
