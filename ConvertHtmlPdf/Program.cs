// See https://aka.ms/new-console-template for more information
using Diet.Application.Service;

Console.WriteLine("Hello, World!");
IPDFService service=new PDFService();


    await service.GeneratePdf("test.pdf", service.LoadTemplate("برنامه غذایی روزانه"));

