using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Forms.Fields;
using iText.Forms;

using AutoMapper;
using eForms.Domain.Context;
using eForms.Domain.Enums;
using eForms.Domain.Models;
using eForms.Services.Interfaces;
using eForms.Services.Models;

namespace eForms.Services.Interfaces
{
    public class PDFService : IPDFService
    {
        StringBuilder sb_question = new StringBuilder();
        StringBuilder sb_answer = new StringBuilder();
        
        public StringBuilder ExtractPdfField(String src) //--- This is Good
        {

            PdfReader reader = new PdfReader(src);
            PdfDocument pdfDoc = new PdfDocument(reader);
            // Get the fields from the reader (read-only!!!)
            PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);
            // Loop over the fields and get info about them
            IDictionary<String, PdfFormField> fields = form.GetFormFields();

            //Type NewArrivalEmpType = typeof(NewArrvEMP);
            //FieldInfo[] myField = NewArrivalEmpType.GetFields();

            //for (int i = 0; i < myField.Length; i++)
            //{
            //    if (key == myField[i].Name)
            //    {
            //        Temp_NewArrivalEmp.myField[i].Name = value.ToString().Trim();
            //    }
            //}

            var Temp_NewArrivalEmp = new NewArrvEMP();
            var Temp_NewArrvDEP = new NewArrvDEP();
            var Temp_NewArrvEMERG = new NewArrvEMERG();
            var Temp_NewArrvLANG = new NewArrvLANG();

            foreach (var field in fields)
            {
                if (form.GetField(field.Key).GetValueAsString().Trim() != "")
                {
                    string key = field.Key.ToString();
                    string value = form.GetField(field.Key).GetValueAsString();
                    sb_answer.Append(key + " : " + value.ToString().Trim() + "<br />");

                    switch (key)
                    {
                        case "FirstName":
                            Temp_NewArrivalEmp.FirstName = value.ToString().Trim();
                            break;
                        case "LastName":
                            Temp_NewArrivalEmp.LastName = value.ToString().Trim();
                            break;
                        case "JobTitle":
                            Temp_NewArrivalEmp.JobTitle = value.ToString().Trim();
                            break;
                        case "MI":
                            Temp_NewArrivalEmp.MI = value.ToString().Trim();
                            break;
                        case "OfficeSymbol":
                            Temp_NewArrivalEmp.OfficeSymbol = value.ToString().Trim();
                            break;
                        case "OfficialEmail":
                            Temp_NewArrivalEmp.OfficialEmail = value.ToString().Trim();
                            break;
                        case "PersonalEmail":
                            Temp_NewArrivalEmp.PersonalEmail = value.ToString().Trim();
                            break;
                    }

                    

                }
            }
            pdfDoc.Close();
            return sb_answer;

        }
        public class ExportPDF
        {
            //PdfDocument pdfDocument = new PdfDocument(new PdfWriter(new FileStream("/PDF/DEMO Form.pdf", FileMode.Create, FileAccess.Write)));
            //Document document = new Document(pdfDocument);

            //static void Main()
            //{
            //    PdfDocument pdfDocument = new PdfDocument(new PdfWriter(new FileStream("/PDF/DEMO Form.pdf", FileMode.Create, FileAccess.Write)));
            //    Document document = new Document(pdfDocument);

            //    String line = "Hello! Welcome to iTextPdf";
            //    document.Add(new Paragraph(line));
            //    document.Close();
            //    Console.WriteLine("Awesome PDF just got created.");
            //}
        }
        public void GeneratePdf(string[] paragraphs, string destination)
        {
            FileInfo file = new FileInfo(destination);
            file.Delete();
            var fileStream = file.Create();
            fileStream.Close();
            PdfDocument pdfdoc = new PdfDocument(new PdfWriter(file));
            pdfdoc.SetTagged();
            using (Document document = new Document(pdfdoc))
            {
                foreach (var para in paragraphs)
                {
                    document.Add(new Paragraph(para));
                }
                document.Close();
            }
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
}
