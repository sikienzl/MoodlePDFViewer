using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MoodleDownloader
{
    class WorkWithContent
    {
        private static String loginurl = "https://moodle.htwg-konstanz.de/moodle/login/index.php";
        //private String username = "";
        //private String password = "";
        private String tmp_path = Path.GetTempPath();

        private HttpWebRequest request;
        private CookieContainer container;
        private WebResponse response;
        private StreamReader reader;
        private Stream dataStream;
        private List<Course> courseList;
        private List<CourseFile> courseFilesList;
        public Dictionary<Course, List<CourseFile>> courseFileDict;
       
        public WorkWithContent()
        {
            courseList = new List<Course>();
            courseFileDict = new Dictionary<Course, List<CourseFile>>();
        }

        public static bool AcceptAllCertifications(object sender,
            System.Security.Cryptography.X509Certificates.X509Certificate certification,
            System.Security.Cryptography.X509Certificates.X509Chain chain,
            System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public bool authenticationCheck(String username, String password)
        {
            bool authenticate_success = false;
            request = (HttpWebRequest)WebRequest.Create(loginurl);
            // Set the Method property of the request to POST.
            request.Method = "POST";
            string cookieName = null;

            container = new CookieContainer();

            if (cookieName != null)
                container.Add(new Cookie(cookieName, username, "/", new Uri(loginurl).Host));

            request.CookieContainer = container;

            // Create POST data and convert it to a byte array.  Modify this line accordingly
            string postData = String.Format("username={0}&password={1}", username, password);

            ServicePointManager.ServerCertificateValidationCallback =
                new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            response = request.GetResponse();
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();

            //easy mechanism to detect if authentication failed.
            if (!responseFromServer.Contains("Sie sind nicht angemeldet."))
            {
                //Console.WriteLine("Authentication failed\nThe Application will be closed!");
                //Thread.Sleep(4000);
                //Environment.Exit(-1);
                authenticate_success = true;
            }
            return authenticate_success;
        }

        public void Load_Course()
        {
            HtmlAgilityPack.HtmlDocument doc = getHtmlDoc("https://moodle.htwg-konstanz.de/moodle");


            

            HtmlAgilityPack.HtmlNodeCollection htmlNodeColl = doc.DocumentNode.SelectNodes("//div[@id='inst34284']//ul[@class='unlist']//div[@class='column c1']");

            for(int i = 0; i < htmlNodeColl.Count; i ++)
            {
                Course course = new Course();
                var link = htmlNodeColl[i].Descendants("a")
                                          .First(x => x.Attributes["title"] != null);
                course.setCourseHref(link.Attributes["href"].Value);
                course.setCourseHtmlTitle(link.Attributes["title"].Value);
                course.setCourseName(htmlNodeColl[i].InnerText);

                courseList.Add(course);
            }
                reader.Close();
            dataStream.Close();
            response.Close();

        }
        public void load_course_files()
        {
            for(int i = 0; i < courseList.Count; i++)
            {
                
                HtmlAgilityPack.HtmlDocument doc = getHtmlDoc(courseList[i].getCourseHref());
                //li[@class='section main clearfix']
                HtmlAgilityPack.HtmlNodeCollection htmlNodeColl = doc.DocumentNode.SelectNodes("//div[@id='page-content']//ul[@class='topics']//li");
                HtmlAgilityPack.HtmlNodeCollection htmlNodeColl2 = doc.DocumentNode.SelectNodes("//div[@id='page-content']//ul[@class='topics']//ul");


                /*for(int k= 0; k < htmlNodeColl2.Count; k++)
                { 
                    var element2 = htmlNodeColl2[k].Descendants("a").First(y => y.Attributes["href"] != null);

                    Console.WriteLine(element2.Attributes["href"].Value);
                }*/


                courseFilesList = new List<CourseFile>();
                for (int j = 0; j < htmlNodeColl.Count; j++)
                {

                    /*var img = htmlNodeColl[j].Descendants("img")
                                            .First(y => y.Attributes["src"] != null);
                    if(img.Attributes["src"].Value.Equals("https://moodle.htwg-konstanz.de/moodle/theme/image.php/_s/htr2018/core/1523028771/f/pdf-24"))
                    {
                        CourseFile courseFile = new CourseFile();
                        var filelink = htmlNodeColl[j].Descendants("a")
                                                      .First(y => y.Attributes["href"] != null);
                        //Console.WriteLine(filelink.Attributes["href"].Value);
                        courseFile.setFileLink(filelink.Attributes["href"].Value);
                        var instancename = htmlNodeColl[j].Descendants("span")
                                          .First(x => x.Attributes["class"] != null);
                        courseFile.setFileName(instancename.InnerText.Replace("Datei", ""));
                        
                        courseFilesList.Add(courseFile);
                    }*/
                    var element = htmlNodeColl[j].Descendants("a")
                                    .First(y => y.Attributes["onclick"] != null);

                    //var element2 = htmlNodeColl[j].Descendants("a").First(y => y.Attributes["href"] != null);

                    //Console.WriteLine(element.Attributes["href"].Value);

                    if (element.Attributes["onclick"].Value != "")
                    {
                        String referenceUrl = getReferenceUrl(element.Attributes["onclick"].Value);
                        List<String> fileLinks = new List<String>();
                        fileLinks = getFileLink(referenceUrl);
                        foreach(String link in fileLinks)
                        {
                            
                            CourseFile cf = new CourseFile();
                            cf.setFileLink(link);
                            cf.setFileName(getFileName(link));
                            courseFilesList.Add(cf);
                        }  
                        
                    }
                    else if (element.Attributes["href"].Value != "" 
                        && element.Attributes["href"].Value.Contains("folder"))
                    {
                        String referenceUrl = getReferenceUrl(element.Attributes["href"].Value);
                           
                        


                        List<String> fileLinks = new List<String>();
                        fileLinks = getFileLinkFolder(referenceUrl);
                       
                        foreach (String link in fileLinks)
                        {

                            
                            
                            if(!courseFilesList.Exists( x=>x.getFileName() == getFileName(link)))
                            {
                                CourseFile cf = new CourseFile();
                                cf.setFileLink(link);
                                cf.setFileName(getFileName(link));
                                courseFilesList.Add(cf);
                            }
                                
                        }
                    }

                }
                courseFileDict.Add(courseList[i], courseFilesList);

            }
        }

        
        private List<String> getFileLinkFolder(String referenceUrl)
        {
            List<String> fileLinks = new List<string>();
            HtmlAgilityPack.HtmlDocument doc = getHtmlDoc(referenceUrl);
            HtmlAgilityPack.HtmlNodeCollection htmlNodeColl = doc.DocumentNode.SelectNodes("//section[@id='region-main']//div[@id='folder_tree0']//span[@class='fp-filename-icon']");
            for(int i = 0; i < htmlNodeColl.Count; i++)
            {
                var element = htmlNodeColl[i].Descendants("a")
                                                 .First(y => y.Attributes["href"] != null);
               
                String value = element.Attributes["href"].Value;

                
                int indexOfChar = value.IndexOf("?")  ;
                int removeCount = (value.Length) - indexOfChar;
                String url = value.Remove(indexOfChar, removeCount);

                

                if (url.EndsWith(".pdf"))
                {
                    fileLinks.Add(url);
                }
            }
            return fileLinks;
        }

        private List<String> getFileLink(String referenceUrl)
        {
            HtmlAgilityPack.HtmlDocument doc = getHtmlDoc(referenceUrl);
            HtmlAgilityPack.HtmlNodeCollection htmlNodeColl = doc.DocumentNode.SelectNodes("//div[@id='page-content']");
            List<String> fileLinks = new List<string>();
            for (int j = 0; j < htmlNodeColl.Count; j++)
            {
                var element = htmlNodeColl[j].Descendants("a")
                                                 .First(y => y.Attributes["href"] != null);
                String value = element.Attributes["href"].Value;
                if (value.EndsWith(".pdf"))
                {
                    fileLinks.Add(value);
                }

            }

            return fileLinks;
        }

        private String getReferenceUrl(String value)
        {
            String url = String.Empty;
            if(!value.Contains("folder"))
            { 
                String beginOfLink = value.Remove(0, 18);

                int indexOfChar = beginOfLink.IndexOf(";") - 1;
                int removeCount = (beginOfLink.Length - 1) - indexOfChar;
                url = beginOfLink.Remove(indexOfChar, removeCount);           //.Remove(indexOfChar, beginOfLink.Length - 1);
            } else
            {
                url = value;
            }

            return url;
        }

        public String downloadPdfintoTmp(String url)
        {
            String filepath = tmp_path + getFileName(url);
            if (!File.Exists(filepath))
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.CookieContainer = container;

                response = request.GetResponse();
                return tmp_path + CreatePDF(url, response, tmp_path);
            }
              else
            {
                return filepath;
            }
        }

        private static String CreatePDF(String url, WebResponse response, String storagePath)
        {
            //writes stream to a PDF file
            String filename = getFileName(url);

            if(filename.Contains("="))
            {
                int getCountOfCharacter = filename.IndexOf("=");
                filename = filename.Remove(0, getCountOfCharacter + 1);
                Console.WriteLine(filename);
            }

            if (!filename.Contains(".pdf"))
            {
                filename += ".pdf";
            }
            using (var streamFile = File.Create(storagePath + filename))
                response.GetResponseStream().CopyTo(streamFile);
            return filename;
        }
        private static String getFileName(String url)
        {
            int pos = url.LastIndexOf("/") + 1;
            return url.Substring(pos, url.Length - pos);
        }

        private HtmlAgilityPack.HtmlDocument getHtmlDoc(String link)
        {
            request = (HttpWebRequest)WebRequest.Create(link);
            request.CookieContainer = container;

            response = request.GetResponse();

            dataStream = response.GetResponseStream();

            //reader = new StreamReader(dataStream);


            string strResult = "";
            using (reader = new StreamReader(dataStream))
            {
                strResult = reader.ReadToEnd();
                // Close and clean up the StreamReader
                reader.Close();
            }

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(strResult);
            return doc;
        }
    }
}
