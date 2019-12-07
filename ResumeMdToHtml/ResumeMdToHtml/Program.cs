using System;
using System.IO;
using System.Text;
using Markdig;

namespace ResumeMdToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\..\..\..\resume.md";
            var markdown = File.ReadAllText(path);
            var html = Parse(markdown);
            File.WriteAllText(@"..\..\..\..\..\resume.html", html, Encoding.UTF8);
            //Console.WriteLine(html);
        }

        public static string Parse(string markdown)
        {
            var pipeline = new MarkdownPipelineBuilder()
                .UseAdvancedExtensions()
                .Build();
            return Markdown.ToHtml(markdown, pipeline);
        }
    }
}
