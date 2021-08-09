using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Amicitia.github.io.Program;

namespace Amicitia.github.io.PageCreator
{
    public class Page
    {
        public static void DeleteExisting(string indexPath)
        {
            //Remove each of these folders (and their files) from exe directory
            string[] thingsToDelete = new string[] { "author", "cheats", "game", "guides", "index", "mods", "post", "tag", "tools" };

            foreach (var thing in thingsToDelete)
            {
                foreach (var file in Directory.GetFiles(indexPath, "*.*", SearchOption.AllDirectories))
                {
                    if (file.EndsWith(thing + ".html"))
                        File.Delete(file);
                }
                foreach (var dir in Directory.GetDirectories(indexPath, "*", SearchOption.AllDirectories))
                {
                    if (Path.GetFileName(dir) == thing)
                        Directory.Delete(dir, true);
                }
            }
        }

        public static void CreateSingle(List<Post> posts)
        {
            //Create single-post pages for hyperlinks
            foreach (var post in posts)
            {
                List<Post> singlePost = new List<Post>() { post };
                CreateHtml(singlePost, $"post\\{post.Id}");
            }
        }

        public static void Create(string content, string url, int pageNumber, bool morePages)
        {
            //Html Head Tag contents
            string html = "<!doctype html>\n<html>\n\t<head>\n" + Properties.Resources.IndexBeforeHeader;
            // Top of page, site navigation and title
            string game = "";
            string gameFull = "";
            string type = "";
            string pageName = "";

            foreach (var split in url.ToLower().Replace(".html", "").Split('\\').Reverse())
                if (gameList.Any(g => g.Item1.ToLower().Equals(split)))
                    game = split;
                else if (split == "mods" || split == "tools" || split == "guides" || split == "cheats")
                    type = split;

            if (!String.IsNullOrEmpty(game))
            {
                gameFull = gameList.Single(x => x.Item1.ToLower().Equals(game.ToLower())).Item2;
                pageName = gameFull;
            }
            if (!String.IsNullOrEmpty(type))
                pageName += $" {FirstCharToUpper(type)}";
            if (String.IsNullOrEmpty(pageName))
                pageName = "Mods & Resources";

            html += $"<title>{pageName}</title>";
            html += Properties.Resources.IndexHeader + "</head>" + Properties.Resources.IndexAfterHeader
                + $"<center><a href=\"https://amicitia.github.io\"><img src=\"https://amicitia.github.io/images/logo.svg\" " +
                $"style=\"width:150px;height:150px;\"><h1>{pageName}</h1></a></center>"
                + Properties.Resources.IndexBeforeContent + "<b><a href=\"https://shrinefox.com/\"><i class=\"fa fa-home\" aria-hidden=\"true\"></i> ShrineFox.com</a> > Resources > Browse Mods & Tools</b><br><br>";
            // Update selected navigation value
            html = html.Replace("<div class=\"content\">", $"{Properties.Resources.Navigation}<div class=\"content\">");
            html = html.Replace($"value=\"{game.ToLower()}\">", $"value=\"{game.ToLower()}\" selected>").Replace($"value=\"{type}\">", $"value=\"{type}\" selected>");

            // Set up for pagination and ref link depth
            int depth = url.Count(c => c == '\\');
            string url2 = url.Replace(".html", "");
            if (depth == 1)
                url2 = url2.Replace($"{url}\\{url}", $"{url}");
            // Table for pagination
            string pagination = "<center><nav class=\"pagination\" role=\"navigation\"><div class=\"nav-links\">";
            // Previous Page
            if (pageNumber > 1)
            {
                if (pageNumber == 2)
                    pagination += $"<a class=\"page-numbers\" href=\"https:\\\\amicitia.github.io\\{url2.Replace($"\\{pageNumber}", "")}\">1</a>";
                else
                    pagination += $"<a class=\"page-numbers\" href=\"https:\\\\amicitia.github.io\\{url2.Replace($"\\{pageNumber}", $"\\{pageNumber - 1}")}\">{pageNumber - 1}</a>";
            }
            // Current Page
            pagination += $"<span aria-current=\"page\" class=\"page-numbers current\">{pageNumber}</span>";
            // Next Page
            if (morePages)
            {
                if (pageNumber == 1)
                    pagination += $"<a class=\"page-numbers\" href=\"https:\\\\amicitia.github.io\\{url2}\\2\">2</a>";
                else
                    pagination += $"<a class=\"page-numbers\" href=\"https:\\\\amicitia.github.io\\{url2.Replace($"\\{pageNumber}", $"\\{pageNumber + 1}")}\">{pageNumber + 1}</a>";
            }
            // End pagination table
            pagination += "</div></nav></center>";

            // Hacky workaround for navbar ul class being renamed
            html = html.Replace("css3menu0", "TEMPcss3menu0");
            // Append content, navigation and footer to content
            html += content + "</article>"; // Body Content
            html += Properties.Resources.IndexFooter; // Footer
            html = html.Replace("<!--Pagination-->", pagination); // Pagination

            // Replace links based on depth
            if (depth == 1)
            {
                html = html.Replace("\"css", "\"../css");
                html = html.Replace("\"js", "\"../js");
                html = html.Replace("\"images", "\"../images");
            }
            else if (depth == 2)
            {
                html = html.Replace("\"../", "\"../../");
                html = html.Replace("\"css", "\"../../css");
                html = html.Replace("\"js", "\"../../js");
                html = html.Replace("\"images", "\"../../images");
            }
            else if (depth == 3)
            {
                html = html.Replace("\"../../", "\"../../../");
                html = html.Replace("\"css", "\"../../../css");
                html = html.Replace("\"js", "\"../../../js");
                html = html.Replace("\"images", "\"../../../images");
            }
            // Hacky workaround for navbar ul class being renamed
            html = html.Replace("TEMPcss3menu0", "css3menu0");
            //html = html.Replace("https://amicitia.github.io","."); // Use local files

            // Create page
            string htmlPath = Path.Combine(indexPath, url);
            Directory.CreateDirectory(Path.GetDirectoryName(htmlPath));
            File.WriteAllText(htmlPath, html);
            Console.WriteLine(htmlPath);
        }

        internal static void FlowscriptDocs(string indexPath)
        {
            foreach (string page in new string[] { "compiling", "decompiling", "flowscript", "hookingfunctions", "importing", "messagescript" })
            {
                Console.WriteLine($"Creating {page} doc...");
                string html = "<!doctype html>\n<html>\n\t<head>\n" + Properties.Resources.IndexBeforeHeader;
                html += $"<title>Amicitia - {FirstCharToUpper(page)}</title>";
                html += Properties.Resources.IndexHeader + "</head>" + Properties.Resources.IndexAfterHeader
                    + $"<center><a href=\"https://amicitia.github.io\"><img src=\"https://amicitia.github.io/images/logo.svg\" " +
                    $"style=\"width:150px;height:150px;\"><h1>Flowscript Docs</h1><h2>{FirstCharToUpper(page)}</h2></a></center>"
                    + Properties.Resources.IndexBeforeContent + $"<b><a href=\"https://shrinefox.com/\"><i class=\"fa fa-home\" aria-hidden=\"true\"></i> ShrineFox.com</a> > Resources > <a href=\"https://amicitia.github.io\">Browse Mods & Tools</a> > Flowscript Docs > {FirstCharToUpper(page)}</b><br><br>";
                html += Properties.Resources.toc + File.ReadAllText(Path.Combine(Path.Combine(Path.Combine(indexPath, "Templates"), "Flowscript"), page + ".html"));
                html += Properties.Resources.IndexFooter;
                File.WriteAllText(Path.Combine(Path.Combine(indexPath, "docs"), page + ".html"), html);
            }
        }

        internal static void Misc(string indexPath)
        {
            foreach (string page in new string[] { "404", "files" })
            {
                Console.WriteLine($"Creating {page} page...");
                string html = "<!doctype html>\n<html>\n\t<head>\n" + Properties.Resources.IndexBeforeHeader;
                html += $"<title>Amicitia - {FirstCharToUpper(page)}</title>";
                html += Properties.Resources.IndexHeader + "</head>" + Properties.Resources.IndexAfterHeader
                    + $"<center><a href=\"https://amicitia.github.io\"><img src=\"https://amicitia.github.io/images/logo.svg\" " +
                    $"style=\"width:150px;height:150px;\"><h1>{FirstCharToUpper(page)}</h1></a></center>"
                    + Properties.Resources.IndexBeforeContent + "<b><a href=\"https://shrinefox.com/\"><i class=\"fa fa-home\" aria-hidden=\"true\"></i> ShrineFox.com</a> > Resources > <a href=\"https://amicitia.github.io\">Browse Mods & Tools</a> > ";
                if (page == "404")
                    html += $"Not Found</b><br>{Properties.Resources._404}";
                else if (page == "files")
                    html += $"Files</b><br>{Properties.Resources.Files}";
                html += Properties.Resources.IndexSidebar + Properties.Resources.IndexFooter;
                File.WriteAllText(Path.Combine(indexPath, page + ".html"), html);
            }

            string forumThemePath = Path.Combine(indexPath, "forum//styles//prolight//template");
            // Overall Header
            string header = Properties.Resources.overall_header;
            header = header.Replace("<!--INDEXHEADER-->", Properties.Resources.IndexHeader.Replace("https://amicitia.github.io/", "https://shrinefox.com/"));
            header = header.Replace("<!--INDEXAFTERHEADER-->", Properties.Resources.IndexAfterHeader.Replace("<!--Notifications-->", Properties.Resources.LoginAndNotifications).Replace("<i class=\"fa fa-user-circle\"></i> Profile", "<!-- IF not S_USER_LOGGED_IN --><i class=\"fa fa-user-circle\"></i><!-- ELSE --><!-- IF CURRENT_USER_AVATAR --><a class=\"header-profile header-avatar has-avatar\">{CURRENT_USER_AVATAR}<strong class=\"badge header-profile-badge<!-- IF not NOTIFICATIONS_COUNT --> hidden<!-- ENDIF -->\">{NOTIFICATIONS_COUNT}</strong><span style=\"left:26px;position:relative;margin-right:20px;top:-5px;\">Profile </span></a><!-- ELSE --><a class=\"header-profile header-avatar no-avatar\"><strong class=\"badge header-profile-badge<!-- IF not NOTIFICATIONS_COUNT --> hidden<!-- ENDIF -->\">{NOTIFICATIONS_COUNT}</strong></a><!-- ENDIF --><!-- ENDIF -->"));
            header = header.Replace("<!--INDEXBEFORECONTENT-->", Properties.Resources.IndexBeforeContent);
            header = header.Replace("</div>\r\n<!--Top End-->", "").Replace("</div> <!--End Contents-->", "").Replace("</div> <!--End Component-->", "").Replace("</div> <!--End Sidebar-->", "");
            File.WriteAllText(Path.Combine(forumThemePath, "overall_header.html"), header);
            // Overall Footer
            File.WriteAllText(Path.Combine(forumThemePath, "overall_footer.html"), Properties.Resources.IndexFooter.Replace("<!--Footer-->", "</div>\n<!--Footer-->"));

            string blogThemePath = Path.Combine(indexPath, "blog//wp-content//themes//justread");
            foreach (string site in new string[] { "blog", "guides", "news" })
            {
                string path = blogThemePath + "//" + site;

                // Overall Header
                header = Properties.Resources.header;
                header = header.Replace("<!--INDEXHEADER-->", Properties.Resources.IndexHeader.Replace("https://amicitia.github.io/", "https://shrinefox.com/"));
                header = header.Replace("<!--INDEXAFTERHEADER-->", Properties.Resources.IndexAfterHeader);
                header = header.Replace("<!--INDEXBEFORECONTENT-->", Properties.Resources.IndexBeforeContent);
                header = header.Replace("=\"wrap\"", "=\"\"");
                if (site != "blog")
                    header = header.Replace("<h1>ShrineFox</h1>", "<h1>Amicitia</h1>").Replace("<h2>Blog</h2>", $"<h2>{FirstCharToUpper(site)}</h2>");
                header = header.Replace("</div>\r\n<!--Top End-->", "").Replace("</div> <!--End Contents-->", "").Replace("</div> <!--End Component-->", "").Replace("</div> <!--End Sidebar-->", "");
                File.WriteAllText(Path.Combine(path, "header.php"), header);
                // Overall Footer
                File.WriteAllText(Path.Combine(path, "footer.php"), Properties.Resources.IndexSidebar + Properties.Resources.IndexFooter.Replace("<!--INDEXFOOTER-->", Properties.Resources.IndexFooter));
            }
        }

        public static void CreateHtml(List<Post> posts, string url)
        {
            string content = "";
            int pages = 1; // Complete pages so far
            int pagePosts = 0; // Posts on this page so far
            int totalPages = Convert.ToInt32(RoundUp(Convert.ToDecimal(posts.Count) / Convert.ToDecimal(maxPosts), 0)); // Total number of pages
            //For each post...
            bool matchFound = false; //Show more resources if post is a mod or tool
            var urlSplit = url.Split('\\');
            if (posts.Count > 0)
            {
                /* Create Static Redirect Page to new Site for Google Search */
                content += posts[0].Description;
                string link = "";
                if (urlSplit.Any(x => x.Equals("index")))
                    link = "type=all";
                else if (urlSplit.Any(x => x.Equals("post")))
                    link = $"post={posts[0].Id}";
                else
                {
                    if (urlSplit.Any(x => x.Equals("game")))
                        link = $"game={urlSplit.First(x => gameList.Any(y => y.Item1.Equals(x.ToLower())))}";
                    else
                    {
                        if (urlSplit.Any(x => x.Equals("mods")))
                            link += $"&type=mod";
                        else if (urlSplit.Any(x => x.Equals("tools")))
                            link += $"&type=tool";
                        else if (urlSplit.Any(x => x.Equals("guides")))
                            link += $"&type=guide";
                        else if (urlSplit.Any(x => x.Equals("cheats")))
                            link += $"&type=cheat";
                        if (gameList.Any(x => urlSplit.Any(y => y.Equals(x.Item1))))
                            link += $"&game={gameList.First(x => urlSplit.Any(y => y.Equals(x.Item1))).Item1}";
                        if (urlSplit.Any(x => x.Equals("author")))
                            link = $"author={posts[0].Authors.First(x => url.ToUpper().Contains(x.ToUpper()))}";
                        if (urlSplit.Any(x => x.Equals("tag")))
                            link = $"tag={posts[0].Tags.First(x => url.ToUpper().Contains(x.ToUpper()))}";
                    }
                }
                link = link.TrimStart('&');
                content += "<meta http-equiv=\"refresh\" content=\"0;URL=https://shrinefox.com/browse?" + link + "\">";

                Create(content, $"{url}.html", 1, false);
            }
            /*
            for (int i = 0; i < posts.Count; i++)
            {
                //Start of page
                if (pagePosts == 0)
                {
                    content += Properties.Resources.PostTableHeader;
                    //Show total number of results if not a single post page
                    if (!url.Contains("\\post\\"))
                        content = content.Replace("(0 results)", $"({posts.Count} results)").Replace("Page 0/0", $"Page {pages}/{totalPages}");
                    if (posts.Count == 0) //Inform user if no posts found
                        content += $"<br><center>Sorry! No posts matching your query were found. Please check again later.</center>";
                    else if (url.Contains("p5r")) //Show Pan thank you message
                        content += "<center>Special thanks to <a href=\"https://twitter.com/regularpanties\">@regularpanties</a> for the generous donation of a 6.72 PS4<br>and a plethora of documentation that made this section possible.</center><br>";

                    if (!matchFound && (url.Contains("mods") || url.Contains("game")))
                    {
                        if (url.Contains("\\p5") && !url.Contains("\\p5r") && !url.Contains("\\p5s"))
                            content += "<br><center>To learn how to run P5 mods, see <a href=\"https://shrinefox.com/guides/2019/04/19/persona-5-rpcs3-modding-guide-1-downloads-and-setup\">this guide.</a></center>";
                        else if (url.Contains("\\p5r"))
                            content += "<br><center>To learn how to install and run P5R mods, see <a href=\"https://shrinefox.com/guides/2020/09/30/modding-persona-5-royal-jp-on-ps4-fw-6-72\">this guide</a>.";
                        else if (url.Contains("\\p3fes") || url.Contains("\\p4.html") || url.Contains("\\smt3.html"))
                            content += "<br><center>To learn how to run these mods, see <a href=\"https://amicitia.github.io/post/hostfs-guide\">this guide.</a></center>";
                        else if (url.Contains("\\p4g"))
                            content += "<br><center>To learn how to mod the PC version of P4G, see <a href=\"https://gamebanana.com/tuts/13379\">this guide.</a><br>More P4G PC mods available at <a href=\"https://gamebanana.com/games/8263\">gamebanana.com</a>.</center>";
                        else
                            content += "<br><center>To learn how to use these mods, see <a href=\"https://shrinefox.com/guides/2019/04/19/persona-5-rpcs3-modding-guide-1-downloads-and-setup\">this guide.</a> Although it's focused on Persona 5, the latter half applies to other games as well.</center>";
                        matchFound = true;
                    }
                }
                pagePosts++;

                // Add content to page after header
                if (url.Contains("post"))
                    content += Post.Write(posts[i], true);
                else
                    content += Post.Write(posts[i], false);

                // End of page, create new page
                if (pagePosts == maxPosts || posts.Count - 1 == i)
                {
                    pagePosts = 0;
                    if (pages == 1)
                        Create(content, $"{url}.html", pages, posts.Count - (pages * maxPosts) > 0);
                    else
                        Create(content, $"{url}\\{pages}.html", pages, posts.Count - (pages * maxPosts) > 0);
                    content = "";

                    pages++;
                }
            }
            */
        }

        public static void CreateGames(List<Post> posts)
        {
            //For each game...
            foreach (var game in gameList)
            {
                //Get games from each post
                List<Post> postsByGame = new List<Post>();
                foreach (var post in posts)
                {
                    if (post.Games.Any(x => x.ToLower().Equals(game.Item1.ToLower())))
                        postsByGame.Add(post);
                }
                //Create 
                CreateHtml(postsByGame, $"game\\{game.Item1.ToLower()}");
            }
        }

        public static void CreateAuthors(List<Post> posts)
        {
            //Get list of individual authors from all posts
            List<string> uniqueAuthors = new List<string>();
            foreach (var post in posts)
            {
                foreach (var author in post.Authors)
                    if (!uniqueAuthors.Contains(author.Trim()))
                        uniqueAuthors.Add(author.Trim());
            }

            //Create individual pages for each unique creator
            foreach (var author in uniqueAuthors)
            {
                var newpost = posts.Where(p => p.Authors.Any(x => x.Trim().Equals(author))).ToList();
                Page.CreateHtml(newpost, $"author\\{author}");
            }
        }

        public static void CreateTags(List<Post> posts)
        {
            //Get list of individual tags from all posts
            List<string> uniqueTags = new List<string>();
            foreach (var post in posts)
            {
                foreach (var tags in post.Tags)
                    if (!uniqueTags.Contains(tags.Trim()))
                        uniqueTags.Add(tags.Trim());
            }

            //Create individual pages for each unique creator
            foreach (var tag in uniqueTags)
            {
                var newpost = posts.Where(p => p.Tags.Any(x => x.Trim().Equals(tag))).ToList();
                Page.CreateHtml(newpost, $"tag\\{tag}");
            }
        }

        public static void CreateType(string type)
        {
            //Get list of all post matching type
            List<Post> typepost = posts.Where(p => p.Type.Equals(type)).ToList();

            //Create page with all posts matching type
            Page.CreateHtml(typepost, type.ToLower() + "s");
            foreach (var game in gameList)
            {
                List<Post> typepostByGame = new List<Post>();
                foreach (var post in typepost)
                {
                    if (post.Games.Any(x => x.Trim().ToLower().Equals(game.Item1.ToLower())))
                        typepostByGame.Add(post);
                }
                CreateHtml(typepostByGame, $"{type.ToLower()}s\\{game.Item1.ToLower()}");
            }
        }

        public static decimal RoundUp(decimal numero, int numDecimales)
        {
            decimal valorbase = Convert.ToDecimal(Math.Pow(10, numDecimales));
            decimal resultado = Decimal.Round(numero * 1.00000000M, numDecimales + 1, MidpointRounding.AwayFromZero) * valorbase;
            decimal valorResiduo = 10M * (resultado - Decimal.Truncate(resultado));

            if (valorResiduo > 0)
            {
                if (valorResiduo >= 5)
                {
                    var ajuste = Convert.ToDecimal(Math.Pow(10, -(numDecimales + 1)));
                    numero += ajuste;
                    return Decimal.Round(numero * 1.00000000M, numDecimales, MidpointRounding.AwayFromZero);
                }
                else
                    return Decimal.Round(numero * 1.00M, numDecimales, MidpointRounding.AwayFromZero) + 1;
            }
            else
            {
                return Decimal.Round(numero * 1.00M, numDecimales, MidpointRounding.AwayFromZero);
            }
        }

        private string[] splitUrl(string url)
        {
            Match match = Regex.Match(url, @"\:|\.(.{2,3}(?=/))"); // Regex Pattern
            if (match.Success)  // check if it has a valid match
            {
                string split = match.Groups[0].Value; // get the matched text
                int index = url.IndexOf(split);
                return new string[]
                {
            url.Substring(0, index + split.Length),
            url.Substring(index + (split.Length), url.Length - (index + split.Length))
                };
            }

            return null;
        }
    }
}
