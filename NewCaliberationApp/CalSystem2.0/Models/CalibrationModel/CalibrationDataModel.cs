using System.Text.Json.Serialization;

namespace CalSystem2._0.Models.CalibrationModel
{
    public class CalibrationDataModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("assetTag")]
        public string AssetTag {  get; set; }

        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("plantId")]
        public string PlantId { get; set; }

        [JsonPropertyName("project")]
        public string Project { get; set; }

        [JsonPropertyName("brand")]
        public string Brand { get; set; }

        [JsonPropertyName("calPeriod")]
        public string CalPeriod { get; set; }

        [JsonPropertyName("calDept")]
        public string CalDept { get; set; }

        [JsonPropertyName("serialNo")]
        public string SerialNo { get; set; }

        [JsonPropertyName("userPic")]

        public string UserPic { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("userDept")]
        public string UserDept { get; set; }

        [JsonPropertyName("keeper")]
        public string Keeper { get; set; }

        [JsonPropertyName("lastCalDate")]
        public string LastCalDate { get; set; }

        [JsonPropertyName("nextCalDate")]
        public string NextCalDate { get;  set; }

        [JsonPropertyName("oldAssetTag")]
        public string OldAssetTag { get;set; }

        [JsonPropertyName("attach")]
        public string Attach { get; set; }

        [JsonPropertyName("attribute")]
        public string Attribute {  get; set; }

        [JsonPropertyName("calType")]
        public string CalType { get; set; }

        [JsonPropertyName("calStatus")]
        public int CalStatus { get; set; }

        [JsonPropertyName("cALCertificationNo")]
        public string CALCertificationNo { get; set; }

        [JsonPropertyName("remark")]
        public string Remark { get; set; }

        [JsonPropertyName("logDate")]
        public string LogDate { get; set; }

        [JsonPropertyName("loginId")]
        public string LoginId { get; set; }

    }

    public class CalModelDetails
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("brand")]
        public string Brand { get; set; }

        [JsonPropertyName("calPeriod")]
        public string CalPeriod { get; set; }

        [JsonPropertyName("calDept")]
        public string CalDept { get; set; }

        [JsonPropertyName("nextCalDate")]
        public DateOnly? NextCalDate { get; set; }

        [JsonPropertyName("lastCalDate")]
        public DateOnly LastCalDate { get; set; }

        [JsonPropertyName("attribute")]
        public string Attribute { get; set; }
    }
}
