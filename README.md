# ConvertHtmlPdf

ConvertHtmlPdf is a .NET console application for converting HTML files to PDF using the DinkToPdf library and wkhtmltopdf native binaries.

## Features
- Convert HTML to PDF from file or string
- Uses DinkToPdf (.NET wrapper for wkhtmltopdf)
- Supports Windows (x64)

## Prerequisites
- .NET 8.0 SDK or later
- Windows x64
- wkhtmltopdf native binaries (included in `Libs/64bit/libwkhtmltox.dll`)
  
### Important: Where to Place `libwkhtmltox.dll`
You must ensure that `libwkhtmltox.dll` is present in both:
- `ConvertHtmlPdf/Libs/64bit/` (source folder)
- `bin/Debug/net8.0/Libs/64bit/` (output folder after build)
If the file is missing from the output folder, copy it manually after building. The application will not work without this native library in the output directory.

## Getting Started

### 1. Clone the repository
```powershell
git clone https://github.com/abolfazlshs80/ConvertHtmlPdf.git
cd ConvertHtmlPdf
```

### 2. Build the project
```powershell
dotnet build
```

### 3. Run the application
```powershell
dotnet run --project ConvertHtmlPdf/ConvertHtmlPdf.csproj
```

### 4. Usage
The application will convert HTML to PDF using the provided logic in `Program.cs`. You can modify `Program.cs` to change input/output paths or conversion logic.

#### About `IPDFService`
The `IPDFService` interface (located in `Sercice/IPDFService.cs`) defines the contract for PDF conversion services in the project. You can implement this interface to customize how HTML is converted to PDF, allowing for better separation of concerns and easier testing or extension of PDF-related functionality.

##### Main Methods
- `Task GeneratePdf(string path, string text);`
	- Generates a PDF file at the specified `path` using the provided HTML `text`.
	- Returns a Task for asynchronous operation.
- `string LoadTemplate(string title);`
	- Loads and returns an HTML template as a string, using the given `title`.
	- Useful for customizing the content of the PDF before generation.

## Project Structure
- `ConvertHtmlPdf/Program.cs` - Main entry point
- `ConvertHtmlPdf/Models/Person.cs` - Example model
- `ConvertHtmlPdf/Sercice/IPDFService.cs` - PDF service interface
- `ConvertHtmlPdf/Libs/64bit/libwkhtmltox.dll` - Native library for PDF conversion

## Dependencies
- [DinkToPdf](https://github.com/rdvojmoc/DinkToPdf)

## Notes
- Ensure `libwkhtmltox.dll` is present in the output directory (`bin/Debug/net8.0/Libs/64bit/`).
- For custom HTML input/output, edit `Program.cs` as needed.

## License
MIT
