﻿using HrisApp.Shared.Models.MasterData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrisApp.Shared.Models.Assets;

namespace HrisApp.Shared.Models.Images
{
    public class AssetImageT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string AssetCode { get; set; } = string.Empty;
        public string Img_Filename { get; set; } = string.Empty;
        public string Img_Contenttype { get; set; } = string.Empty;
        public string Img_URL { get; set; } = string.Empty;

        public AssetCategoryT? Category { get; set; }
        public int CategoryId { get; set; }

        public AssetSubCategoryT? SubCategory { get; set; }
        public int SubCategoryId { get; set; }

        public byte[]? Img_Data { get; set; }
        public DateTime Img_Date { get; set; }
        public string JM_Code { get; set; } = string.Empty;
    }
}