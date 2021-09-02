using AutoMapper;
using eForms.Domain.Context;
using eForms.Domain.Enums;
using eForms.Domain.Models;
using eForms.Services.Interfaces;
using eForms.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Layout;
using iText.Layout.Element;
using System.Text;
using iText.Forms;
using iText.Forms.Fields;

namespace eForms.Services.Interfaces
{
    public class UploadService : IUploadService
    {
        StringBuilder sb_question = new StringBuilder();
        StringBuilder sb_answer = new StringBuilder();

        private IeFormsContext context;
        private IMapper mapper;
        private ISanitizationService sanitizer;
        public UploadService(IeFormsContext _context, IMapper _mapper, ISanitizationService _sanitizer)
        {
            context = _context;
            mapper = _mapper;
            sanitizer = _sanitizer;
            //authorizationService = _authorizationService;
        }
        private DbSet<UploadDoc> GetDbSet()
        {
            return context.tbl_UploadDocs;
        }

        public async Task<List<UploadDocModel>> GetAllUploads()
        {

            List<UploadDocModel> dto = mapper.Map<List<UploadDoc>, List<UploadDocModel>>(await GetDbSet().ToListAsync());

            return dto;
        }
        public async Task<int> CountAsync()
        {
            return await GetQueryable().CountAsync();
        }
        private IQueryable<UploadDoc> GetQueryable()
        {
            return context.tbl_UploadDocs;
        }
        public async Task<UploadDocModel> ReadAsync(int id)
        {
            UploadDoc model = await GetDbSet()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return mapper.Map<UploadDocModel>(model);
        }
        public async Task<int> CreateUpload(UploadDocModel model)
        {
            UploadDoc uploaddoc = mapper.Map<UploadDoc>(model);
            context.tbl_UploadDocs.Add(uploaddoc);
            await context.SaveChangesAsync();
            return uploaddoc.Id;
        }
        public async Task UpdateUploadAsync(UploadDocModel model)
        {
            context.tbl_UploadDocs.Update(mapper.Map<UploadDoc>(model));
            await context.SaveChangesAsync();
        }
        public async Task<List<UploadDocModel>> SearchForUploadsAsync(string search)
        {
            List<UploadDoc> uploaddocs = await context.tbl_UploadDocs
                .Where(x => x.FileName.Contains(search))
                .Take(5)
                .ToListAsync();
            return mapper.Map<List<UploadDocModel>>(uploaddocs);
        }
        public async Task DeleteFile(int id)
        {
            //await authorizationService.Challenge(PermissionType.ManageMilRank, id);
            context.tbl_UploadDocs.Remove(new UploadDoc() { Id = id });
            await context.SaveChangesAsync();
        }

        public string Upload2Folder(IFormFile files)
        {
            try
            {
                if (files != null)
                {
                    if (files.Length > 0)
                    {
                        //Getting FileName
                        string fileName = Path.GetFileName(files.FileName);

                        //Assigning Unique Filename (Guid)
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                        //Getting file Extension
                        var fileExtension = Path.GetExtension(fileName);

                        // concatenating  FileName + FileExtension
                        //var newFileName = String.Concat(myUniqueFileName, fileExtension);

                        // Combines two strings into a path.
                        var newFileName = String.Concat(System.DateTime.Now.ToString("ddMMyyHHmmss"), fileExtension);
                        var filepath =
                new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "TempUpload")).Root + $@"\{newFileName}";

                        using (FileStream fs = System.IO.File.Create(filepath))
                        {
                            files.CopyTo(fs);
                            fs.Flush();
                        }
                        return filepath;
                        //ExtractPdfField(filepath); //-- This is Good
                    }
                }
                
                return sb_answer.ToString();
            }
            catch (Exception ex)
            {
                return sb_answer.ToString();
            }
            
            
        }
        public StringBuilder ExtractPdfField(String src)
        {
            
            PdfReader reader = new PdfReader(src);
            PdfDocument pdfDoc = new PdfDocument(reader);
            // Get the fields from the reader (read-only!!!)
            PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);
            // Loop over the fields and get info about them
            IDictionary<String, PdfFormField> fields = form.GetFormFields();

            foreach (var field in fields)
            {
                if (form.GetField(field.Key).GetValueAsString().Trim() != "")
                {
                    string key = field.Key.ToString();
                    string value = form.GetField(field.Key).GetValueAsString();
                    sb_answer.Append(key + " : " + value.ToString().Trim() + "<br />");
                }
            }
            pdfDoc.Close();
            return sb_answer;

        }
        // Get a list of fields in a PDF
        public void ManipulatePdf(String src)
        {
            //PdfDocument pdfDoc = new PdfDocument(new PdfReader(src));
            //PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);
            //IDictionary<String, PdfFormField> fields = form.GetFormFields();
            //foreach (var field in fields)
            //{
            //    //if (string.IsNullOrEmpty(field.Value.ToString()))
            //    //{
            //    //    if (field.Key.ToString() == "Name")
            //    //    {
            //    //        var myvalue = field.Value.ToString();
            //    //    }
            //    //    //var mykey = fields[field.Key];
            //    //    //var myvalue = fields[field.Value.ToString()];
            //    //}
            //    if (field.Key.ToString() == "Name")
            //    {
            //        var myvalue = field.Value.ToString();
            //    }
            //}
            //pdfDoc.Close();
            PdfReader reader = new PdfReader(src);
            PdfDocument pdfDoc = new PdfDocument(reader);
            // Get the fields from the reader (read-only!!!)
            PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);
            // Loop over the fields and get info about them
            IDictionary<String, PdfFormField> fields = form.GetFormFields();

            //List<String> result = form.GetField(field.Key).GetValueAsString();

            foreach (var field in fields)
            {
                //writer.print(field + ": ");
                PdfName type = form.GetField(field.Key).GetFormType();
                if (0 == PdfName.Btn.CompareTo(type))
                {
                    if (((PdfButtonFormField)form.GetField(field.Key)).IsPushButton())
                    {
                        //writer.println("Pushbutton");
                        string err = "Pushbutton";
                    }
                    else
                    {
                        if (((PdfButtonFormField)form.GetField(field.Key)).IsRadio())
                        {
                            //writer.println("Radiobutton");
                            string err = "Radiobutton";
                        }
                        else
                        {
                            //writer.println("Checkbox");
                            string err = "Checkbox";
                        }
                    }
                }
                else if (0 == PdfName.Ch.CompareTo(type))
                {
                    //writer.println("Choicebox");
                }
                else if (0 == PdfName.Sig.CompareTo(type))
                {
                    //writer.println("Signature");
                    string err = "Signature";
                }
                else if (0 == PdfName.Tx.CompareTo(type))
                {
                    //writer.println("Text");
                    
                    string err = form.GetField(field.Key).GetValueAsString();
                    err = "Text";
                }
                else
                {
                    //writer.println("?");
                }
            }
            pdfDoc.Close();
        }
        //public void ManipulatePdf1(String dest)
        //{
        //    PdfDocument pdfDoc = new PdfDocument(new PdfReader(SRC), new PdfWriter(dest));
        //    PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, true);
        //    IDictionary<String, PdfFormField> fields = form.GetFormFields();
        //    PdfFormField checkedField = fields[CHECKED_FIELD_NAME];
        //    PdfFormField uncheckedField = fields[UNCHECKED_FIELD_NAME];


        //    // Get array of possible values of the checkbox
        //    String[] states = checkedField.GetAppearanceStates();

        //    // See all possible values in the console
        //    foreach (String state in states)
        //    {
        //        Console.Write(state + "; ");
        //    }

        //    // Search and set checked state to the previously unchecked checkbox and vice versa
        //    foreach (String state in states)
        //    {
        //        if (state.Equals(CHECKED_STATE_VALUE))
        //        {
        //            uncheckedField.SetValue(state);
        //        }
        //        else if (state.Equals(UNCHECKED_STATE_VALUE))
        //        {
        //            checkedField.SetValue(state);
        //        }
        //    }

        //    pdfDoc.Close();
        //}
        public string ReadFile(string pdfPath)
        {
            var pageText = new StringBuilder();
            using (PdfDocument pdfDocument = new PdfDocument(new PdfReader(pdfPath)))
            {
                var pageNumbers = pdfDocument.GetNumberOfPages();
                for (int i = 1; i <= pageNumbers; i++)
                {
                    LocationTextExtractionStrategy strategy = new LocationTextExtractionStrategy();
                    PdfCanvasProcessor parser = new PdfCanvasProcessor(strategy);
                    parser.ProcessPageContent(pdfDocument.GetFirstPage());
                    pageText.Append(strategy.GetResultantText());
                }
            }
            return pageText.ToString();
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
    }
}
