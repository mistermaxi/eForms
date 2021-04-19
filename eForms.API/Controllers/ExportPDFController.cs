using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace eForms.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ExportPDFController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var stream = new FileStream(@"PDF/DEMO Form.pdf", FileMode.Open);
            return new FileStreamResult(stream, "application/pdf");
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Download(string id)
        //{
        //    PdfDocument pdfDocument = new PdfDocument(new PdfWriter(new FileStream("/PDF/DEMO Form.pdf", FileMode.Create, FileAccess.Write)));
        //    Document document = new Document(pdfDocument);

        //    String line = "Hello! Welcome to iTextPdf";
        //    document.Add(new Paragraph(line));
        //    document.Close();

        //    Stream stream = await { { __get_stream_based_on_id_here__} }

        //    if (stream == null)
        //        return NotFound(); // returns a NotFoundResult with Status404NotFound response.

        //    return File(stream, "application/octet-stream"); // returns a FileStreamResult
        //}

        //[HttpGet("get-file-stream/{id}"]
        //public async Task<FileStreamResult> DownloadAsync(string id)
        //{
        //    var fileName = "myfileName.txt";
        //    var mimeType = "application/....";
        //    var stream = await GetFileStreamById(id);

        //    return new FileStreamResult(stream, mimeType)
        //    {
        //        FileDownloadName = fileName
        //    };
        //}

    }

    //public string ReadFile(string pdfPath)
    //{
    //    var pageText = new StringBuilder();
    //    using (PdfDocument pdfDocument = new PdfDocument(new PdfReader(pdfPath)))
    //    {
    //        var pageNumbers = pdfDocument.GetNumberOfPages();
    //        for (int i = 1; i <= pageNumbers; i++)
    //        {
    //            LocationTextExtractionStrategy strategy = new LocationTextExtractionStrategy();
    //            PdfCanvasProcessor parser = new PdfCanvasProcessor(strategy);
    //            parser.ProcessPageContent(pdfDocument.GetFirstPage());
    //            pageText.Append(strategy.GetResultantText());
    //        }
    //    }
    //    return pageText.ToString();
    //}
}
