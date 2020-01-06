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
            string mdPath = @"..\..\resume.md";
            string templatePath = @"..\..\resume_template.html";
            string resumePath = @"..\..\resume.html";

            string replacementString = "{{body}}";

            var markdown = File.ReadAllText(mdPath);
            var htmlTemplate = File.ReadAllText(templatePath);

            var html = Parse(markdown);

            string resumeHTML = htmlTemplate.Replace(replacementString, html);
            File.WriteAllText(resumePath, resumeHTML, Encoding.UTF8);
            //Console.WriteLine(resumeHTML);
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
