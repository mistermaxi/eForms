using eForms.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eForms.Domain.Models
{
    public class UploadDoc : DefaultModel
    {
        [Comment("Reference this attachment to Form ID.")]
        public int FormID { get; set; }

        [Comment("GUID number uniquely identifying the record. Used to reference attachment from each request.")]
        public string GUID { get; set; }

        [Comment("File attachment name.")]
        public string FileName { get; set; }

        [Comment("File attachment type.")]
        public string FileType { get; set; }

        [Comment("File attachment extension.")]
        public string FileExtension { get; set; }

        [Comment("Binary of File attachment.")]
        public byte[] UploadedDoc { get; set; }


        public virtual NewArrvEMP NewArrvEMP { get; set; }
        public virtual OpenNetReq OpenNetReq { get; set; }
        public virtual ClassNetReq ClassNetReq { get; set; }
        public virtual DS7642 DS7642 { get; set; }

    }
}
