
using ConvertHtmlPdf.Models;
using DinkToPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diet.Application.Service;

public interface IPDFService
{
    public Task GeneratePdf(string path, string text);
    public string LoadTemplate(string title);
}
public class PDFService : IPDFService
{
    public async Task GeneratePdf(string path, string text)
    {
        var context = new CustomAssemblyLoadContext();
        context.LoadUnmanagedLibrary(Path.Combine(Directory.GetCurrentDirectory(), "libs\\64bit\\libwkhtmltox.dll"));

        var converter = new SynchronizedConverter(new PdfTools());

        var doc = new HtmlToPdfDocument()
        {
            GlobalSettings = {
                PaperSize = PaperKind.A4
            },
            Objects = {
                new ObjectSettings() {
                    HtmlContent =text,
                    WebSettings = { DefaultEncoding = "utf-8" }
                }
            }
        };
        var pdf = converter.Convert(doc);
        await File.WriteAllBytesAsync(path, pdf);
    }


    public string LoadTemplate(string title)
    {
        var sb = new StringBuilder();

        sb.AppendLine(@"<!DOCTYPE html>
<html lang='fa' dir='rtl'>
<head>
  <meta charset='utf-8'>
  <title>برنامه غذایی روزانه</title>
  <style>
    @page { size: A4; margin: 18mm; }
    body {
      font-family: Tahoma, 'Vazirmatn', 'IRANSans', sans-serif;
      margin: 0;
      background: #fff;
      color: #111;
      line-height: 1.8;
    }
    .container { max-width: 820px; margin: 0 auto; }
    header {
      text-align: center;
      margin-bottom: 16px;
      padding-bottom: 8px;
      border-bottom: 2px solid #e5e7eb;
    }
    h1 { font-size: 22px; margin: 0; font-weight: 800; }
    .section {
      margin: 14px 0 22px;
      border: 1px solid #e5e7eb;
      border-radius: 10px;
      padding: 12px 14px;
      background: #fafafa;
    }
    .section h2 { margin: 0 0 10px; font-size: 18px; font-weight: 700; }
    table { width: 100%; border-collapse: collapse; background: #fff; border-radius: 8px; overflow: hidden; }
    th, td { padding: 8px 10px; border-bottom: 1px solid #e5e7eb; text-align: right; font-size: 14px; }
    th { font-weight: 700; background: #f3f4f6; }
    tr:last-child td { border-bottom: none; }
    .footer { margin-top: 24px; font-size: 12px; color: #6b7280; text-align: center; }
  </style>
</head>
<body>
  <div class='container'>
    <header>
      <h1>"+title+
      "</h1> </header>");

       


            sb.AppendLine("<section class='section'>");
            sb.AppendLine($"<h2> مشخصات فردی</h2>");
            sb.AppendLine("<table>");
            sb.AppendLine("<thead><tr><th>ایدی</th><th>نام</th><th>نام و خوانوادگی</th><th> سن </th></tr></thead>");
            sb.AppendLine("<tbody>");

            foreach (var p in PersonViewModel.Persons)
            {
            
                    sb.AppendLine("<tr>");
                    sb.AppendLine($"<td>{p.Id}</td>");
                    sb.AppendLine($"<td>{p.Name}</td>");
                    sb.AppendLine($"<td>{p.Family}</td>");
                    sb.AppendLine($"<td>{p.Age}</td>");
                    sb.AppendLine("</tr>");
                
            }

            sb.AppendLine("</tbody>");
            sb.AppendLine("</table>");
            sb.AppendLine("</section>");

        

        sb.AppendLine(@"
    <div class='footer'>
      <span>تهیه شده برای تبدیل به PDF با abolfazlshabani</span>
    </div>
  </div>
</body>
</html>
");

        return sb.ToString();

    }
}
public class CustomAssemblyLoadContext : System.Runtime.Loader.AssemblyLoadContext
{
    public IntPtr LoadUnmanagedLibrary(string absolutePath)
    {
        return LoadUnmanagedDll(absolutePath);
    }
    protected override IntPtr LoadUnmanagedDll(string unmanagedDllPath)
    {
        return LoadUnmanagedDllFromPath(unmanagedDllPath);
    }
    protected override System.Reflection.Assembly Load(System.Reflection.AssemblyName assemblyName)
    {
        return null;
    }
}