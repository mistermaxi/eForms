using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using eForms.Domain.Models;
using eForms.Services.Interfaces;
using eForms.Services.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Html;
using System.Net.Http;
using System.Net.Http.Headers;

namespace eForms.Pages
{
    public class UploadFileModel : PageModel
    {
        
        public IEnumerable<eForms.Services.Models.UploadDocModel> uploaddocs { get; set; }

        [BindProperty]
        public eForms.Services.Models.UploadDocModel uploaddoc { get; set; }

        IUploadService uploadService;
        IPDFService pdfService;

        public UploadFileModel(IUploadService _uploadService, IPDFService _pdfService)
        {
            uploadService = _uploadService;
            pdfService = _pdfService;
        }

        public void OnGet()
        {
            ViewData["UploadStatus"] = "Upload File";
        }

        //public async Task<IActionResult> OnPost(IFormFile files)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (files != null)
        //        {                    
        //                if (files.Length > 0)
        //                {
        //                    var fileName = Path.GetFileName(files.FileName);
        //                    uploaddoc.FileName = fileName;
        //                    uploaddoc.FileExtension = Path.GetExtension(fileName);
        //                    uploaddoc.FormID = 18;

        //                    using (var target = new MemoryStream())
        //                    {
        //                        files.CopyTo(target);
        //                        uploaddoc.UploadedDoc = target.ToArray();
        //                    }
        //                    await uploadService.CreateUpload(uploaddoc);                            
        //                }                    
        //        }                
        //    }
        //    return Page();
        //}
        public async Task<IActionResult> OnPostUpload(List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        uploaddoc.FileName = fileName;
                        uploaddoc.FileExtension = Path.GetExtension(fileName);
                        uploaddoc.FormID = 18;

                        using (var target = new MemoryStream())
                        {
                            file.CopyTo(target);
                            uploaddoc.UploadedDoc = target.ToArray();
                        }
                        await uploadService.CreateUpload(uploaddoc);
                    }
                }
                
            }
            return Page();

        }
       
        public IActionResult OnPostUpload2Folder(IFormFile files)
        {
            //if (files != null)
            //{
            //    if (files.Length > 0)
            //    {
            //        //Getting FileName
            //        var fileName = Path.GetFileName(files.FileName);

            //        //Assigning Unique Filename (Guid)
            //        var myUniqueFileName = Convert.ToString(Guid.NewGuid());

            //        //Getting file Extension
            //        var fileExtension = Path.GetExtension(fileName);

            //        // concatenating  FileName + FileExtension
            //        var newFileName = String.Concat(myUniqueFileName, fileExtension);

            //        // Combines two strings into a path.
            //        var filepath =
            //new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "TempUpload")).Root + $@"\{newFileName}";

            //        using (FileStream fs = System.IO.File.Create(filepath))
            //        {
            //            files.CopyTo(fs);
            //            fs.Flush();
            //        }
            //    }
            //}
            if (files != null)
            {
                //if (uploadService.Upload2Folder(files) == "Upload Failed")
                //{
                //    //return Error();
                //    ViewData["UploadStatus"] = "Failed" ;
                //}
                //else
                //    ViewData["UploadStatus"] = "Upload Completed";
                //uploadService.Upload2Folder(files);
                
                //var str = new HtmlString(uploadService.Upload2Folder(files).ToString());
                var str = pdfService.ExtractPdfField(uploadService.Upload2Folder(files).ToString());
                ViewData["UploadStatus"] = str;

                //ViewData["UploadStatus"] = uploadService.Upload2Folder(files);

            }

            return Page();
        }
    }
}
