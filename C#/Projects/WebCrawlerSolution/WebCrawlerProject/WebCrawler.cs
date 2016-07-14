using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebCrawlerProject
{
    public class WebCrawler
    {
        private int workerCount = Environment.ProcessorCount;
        private Task[] workerTasks;
        private ConcurrentQueue<string> pendingUrls;
        private string host;
        private List<string> downloadedImages;

        public WebCrawler()
        {
            downloadedImages = new List<string>();
            pendingUrls = new ConcurrentQueue<string>();
        }

        public void AddPendingUrl(string url)
        {
            pendingUrls.Enqueue(url);
        }

        public async Task RunAsync(string host)
        {
            await Task.Run(() => Run(host));
            Console.WriteLine("Running complete");
        }

        public void Run(string host)
        {
            if (!Directory.Exists("Files"))
            {
                Directory.CreateDirectory("Files");
            }
            this.host = host;
            //workerTasks = new Task[workerCount];
            //for (int i = 0; i < workerCount; i++)
            //{
            //    var task = new Task(() => RunWorker());
            //    workerTasks[i] = task;
            //    task.Start();
            //}

            RunWorker();
            //Task.WaitAll(workerTasks);
        }

        void RunWorker()
        {
            while (pendingUrls.Count > 0)
            {
                string url;
                if (!pendingUrls.TryDequeue(out url))
                {
                    break;
                }
                using (var webClient = new WebClient())
                {
                    var html = webClient.DownloadString(url);
                    Console.WriteLine("{0} donwloading {1}", Task.CurrentId ,url);
                    var relativeImgUrls = HtmlParser.ParseImgTags(html);

                    foreach (var relativeImgUrl in relativeImgUrls)
                    {
                        if (downloadedImages.Contains(relativeImgUrl))
                        {
                            continue;
                        }

                        string imgUrl;
                        if (relativeImgUrl.Contains(host))
                        {
                            imgUrl = relativeImgUrl;
                        }
                        else
                        {
                            imgUrl = host + relativeImgUrl;
                        }
                        var lastBackSlash = relativeImgUrl.LastIndexOf('/');
                        var imageName = relativeImgUrl.Substring(lastBackSlash + 1);
                        using (var downloader = new WebClient())
                        {
                            downloader.DownloadFile(imgUrl, "Files/" + imageName);
                        }

                        downloadedImages.Add(relativeImgUrl);
                    }
                }
            }
        }
    }
}