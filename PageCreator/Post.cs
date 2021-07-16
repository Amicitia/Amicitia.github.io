using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using static Amicitia.github.io.Program;

namespace Amicitia.github.io.PageCreator
{
    public class Post
    {
        public Post(string Id = "", string Type = "", string Title = "", List<string> Games = null, List<string> Authors = null, string Date = "", List<string> Tags = null, string Description = "", string EmbedURL = "", string UpdateText = "")
        {
            this.Id = Id;
            this.Type = Type;
            this.Title = Title;
            this.Games = Games;
            this.Authors = Authors;
            this.Date = Date;
            this.Tags = Tags;
            this.Description = Description;
            this.EmbedURL = EmbedURL;
            this.URL = URL;
            this.UpdateText = UpdateText;
        }
        public string Id { get; set; } = "";
        public string Type { get; set; } = "";
        public string Title { get; set; } = "";
        public List<string> Games { get; set; } = new List<string>();
        public List<string> Authors { get; set; } = new List<string>();
        public string Date { get; set; } = "";
        public List<string> Tags { get; set; } = new List<string>();
        public string Description { get; set; } = "";
        public string EmbedURL { get; set; } = "";
        public string URL { get; set; } = "";
        public string UpdateText { get; set; } = "";
        public static List<Post> Get(string indexPath)
        {
            List<Post> posts = new List<Post>();
            // For each TSV file...
            foreach (var tsv in Directory.GetFiles($"{indexPath}\\db").Where(x => Path.GetExtension(x).Equals(".tsv")))
            {
                // Get TSV lines...
                string[] tsvFile = File.ReadAllLines(tsv);
                for (int i = 1; i < tsvFile.Length; i++)
                {
                    // Separate tabs into array
                    var split = tsvFile[i].Split('\t');

                    // Add to post list
                    if (split.Any(x => !String.IsNullOrEmpty(x)))
                    {
                        Post post = new Post("", "", "", new List<string>(), new List<string>(), "", new List<string>(), "", "", "");
                        post.Id = split[0].Trim('"');
                        post.Type = split[1].ToLower().Trim('"');
                        post.Title = split[2].Trim('"');
                        post.Games = split[3].ToLower().Split(',').ToList();
                        for (int x = 0; x < post.Games.Count; x++)
                            post.Games[x] = post.Games[x].Trim('"').Trim(' ');
                        post.Authors = split[4].Split(',').ToList();
                        for (int x = 0; x < post.Authors.Count; x++)
                            post.Authors[x] = post.Authors[x].Trim('"').Trim(' ');
                        post.Date = split[5].Trim('"');
                        post.Tags = split[6].Split(',').ToList();
                        for (int x = 0; x < post.Tags.Count; x++)
                            post.Tags[x] = post.Tags[x].Trim('"').Trim(' ');
                        post.Description = split[7].Trim('"');
                        post.UpdateText = split[8].Trim('"');
                        post.EmbedURL = split[9].Trim('"');
                        post.URL = split[10].Trim('"');

                        posts.Add(post);
                    }
                }
            }
            return posts;
        }

        public static string Write(Post post, bool single)
        {
            string result;

            //Post Summary
            result = Properties.Resources.Post;
            //Copy Cheat to Clipboard
            if (post.Type == "cheat")
                result = result.Replace("More Information", "Copy to Clipboard").Replace("fas fa-ellipsis-h", "far fa-clipboard");
            //Thumbnail
            if (post.Type != "cheat")
            {
                // Use YouTube thumbnail as image and link to video
                if (post.EmbedURL.Contains("youtu"))
                {
                    string videoID = post.EmbedURL.Substring(post.EmbedURL.IndexOf("v=") + 2);
                    string ytThumb = $"https://img.youtube.com/vi/{videoID}/default.jpg";
                    result = result.Replace("POSTEMBED", $"<img src=\"{ytThumb}\">").Replace("POSTURL", "POSTMEDIAURL");
                }
                else if (post.EmbedURL.Contains("streamable.com"))
                {
                    // Use Streamable thumbnail as image and link to video
                    string videoID = post.EmbedURL.Replace("https://streamable.com/", "");
                    result = result.Replace("POSTEMBED", $"<img src=\"https:///cdn-cf-east.streamable.com/image/{videoID}.jpg\">").Replace("POSTMEDIAURL", $"https://streamable.com/e/{videoID}");
                }
                else if (post.EmbedURL != null && post.EmbedURL.Trim() != "") // Use provided image link
                    result = result.Replace("POSTMEDIAURL", post.EmbedURL).Replace("POSTEMBED", $"<img src=\"{post.EmbedURL}\">");
                else // If no URL, use default Amicitia icon and hide image link
                    result = result.Replace("POSTEMBED", $"<img src=\"https://amicitia.github.io/images/logo.svg\">").Replace("POSTMEDIAURL\"><div class=\"getlink\" style=\"", "POSTMEDIAURL\"><div class=\"getlink\" style=\"display: none;");
            }
            else
            {
                // If cheat, put cheatcode in thumbnail spot
                result = result.Replace("POSTEMBED", $"<div id=\"cheat{post.Id}\" class=\"cheatcode\">{post.UpdateText}</div>");
                result = result.Replace("POSTMEDIAURL", $"javascript:copyDivToClipboard('cheat{post.Id}')");
            }
            result = result.Replace("POSTID", "https://amicitia.github.io/post/" + post.Id);

            //Visible Post Details
            result = result.Replace("POSTTYPE", $"{post.Games.First().ToUpper()} {FirstCharToUpper(post.Type)}").Replace("POSTTITLE", post.Title);
            //Author
            string authors = "";
            foreach (string author in post.Authors.Where(x => !x.Equals("Unknown Author") && !String.IsNullOrWhiteSpace(x)))
            {
                authors += $"<a href=\"https://amicitia.github.io/author/{author.Trim()}\">{author.Trim()}</a>";
                if (post.Authors.IndexOf(author) != post.Authors.Count() - 1)
                    authors += ", ";
            }
            result = result.Replace("POSTAUTHORS", authors);
            if (!String.IsNullOrEmpty(post.UpdateText) && post.UpdateText.Trim() != "")
                result = result.Replace("POSTDATE", post.Date + " (updated)");
            else
                result = result.Replace("POSTDATE", post.Date);
            //Download
            result = result.Replace("POSTURL", post.URL);
            //Description
            result = result.Replace("POSTDESCRIPTION", $"{Webscraper.TruncateLongString(post.Description, 100)}");
            //Tags
            string tags = "";
            foreach (string tag in post.Tags.Where(x => !String.IsNullOrWhiteSpace(x)))
                tags += $"<a href=\"https://amicitia.github.io/tag/{tag.Trim()}\" rel=\"tag\">{tag}</a>";
            result = result.Replace("POSTTAGS", tags);

            return result;
        }
    }
}
