using HrisApp.Shared.Models.StaticData;

namespace HrisApp.Shared.Models.Assets
{
    public class AssetSubAccessoryT
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string LeadType { get; set; } = string.Empty;
        public string SubType { get; set; } = string.Empty;

        public AssetStatusT? AssetStatus { get; set; }
        public int AssetStatusId { get; set; }

        public DateTime? DateAdded { get; set; }
        public DateTime? DatePurchase { get; set; }
        public string Serial { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
    }
}