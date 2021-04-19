using System.Text;

namespace _01Logger
{
    public class XmlLayout : ILayout
    {
        public string FormatReport(string dateTime, string reportLevel, string message)
        {
            StringBuilder reportBuilder = new StringBuilder();
            reportBuilder.AppendLine("<log>")
                .Append('\t')
                .Append("<date>")
                .Append(dateTime)
                .Append("</date>")
                .AppendLine()
                .Append('\t')
                .Append("<level>")
                .Append(reportLevel)
                .Append("</level>")
                .AppendLine()
                .Append('\t')
                .Append("<message>")
                .Append(message)
                .Append("</message>")
                .AppendLine()
                .AppendLine("</log>");

            return reportBuilder.ToString().Trim();
        }
    }
}