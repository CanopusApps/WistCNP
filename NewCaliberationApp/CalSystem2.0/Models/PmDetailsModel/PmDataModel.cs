using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CalSystem2._0.Models.PmDetailsModel
{
    public class PmDataModel
    {
        public class PmModel
        {
            [JsonPropertyName("machineIdSn")]
            public string MachineIdSn { get; set; }

            [JsonPropertyName("isCheck")]
            public bool IsCheck { get; set; }

            [JsonPropertyName("lastCheck")]
            public DateOnly? LastCheck { get; set; }

            [JsonPropertyName("machineName")]
            public string MachineName { get; set; }

            [JsonPropertyName("project")]
            public string Project { get; set; }

            [JsonPropertyName("line")]
            public string Line { get; set; }

            [JsonPropertyName("subLine")]
            public string SubLine { get; set; }

            [JsonPropertyName("machineLocation")]
            public string MachineLocation { get; set; }

            [JsonPropertyName("make")]
            public string Make { get; set; }

            [JsonPropertyName("checklistNo")]
            public string ChecklistNo { get; set; }

            [JsonPropertyName("machineCategory")]
            public string MachineCategory { get; set; }

            [JsonPropertyName("tataDRIName")]
            public string TataDRIName { get; set; }

            [JsonPropertyName("vendorDRI")]
            public string VendorDRI { get; set; }

            [JsonPropertyName("firstTimePmScheduleDate")]
            public DateTime FirstTimePmScheduleDate { get; set; }

            [JsonPropertyName("frequency")]
            public string Frequency { get; set; }
        }

        public class PMScheduleModel : PmModel
        {
            [JsonPropertyName("pmDurationHrs")]
            public string PmDurationHrs { get; set; }

            [JsonPropertyName("actualPmDate")]
            public DateTime? ActualPmDate { get; set; }

            [JsonPropertyName("pmAdherence")]
            public string PmAdherence { get; set; }

            [JsonPropertyName("currentPmStatus")]
            public bool CurrentPmStatus { get; set; }

            [JsonPropertyName("pmManager")]
            public string PmManager { get; set; }

            [JsonPropertyName("engineeringManager")]
            public string EngineeringManager { get; set; }

            [JsonPropertyName("dccCheckListLink")]
            public string DccCheckListLink { get; set; }

            [JsonPropertyName("toolList")]
            public string ToolList { get; set; }

        //[JsonProperty("requiredCriticalSparePartList")]
        //public string RequiredCriticalSparePartList { get; set; }

        //[JsonProperty("headCountSize")]
        //public string HeadCountSize { get; set; }

        //[JsonProperty("plantHead")]
        //public string PlantHead { get; set; }

        //[JsonProperty("pmScheduleFlow")]
        //public string PmScheduleFlow { get; set; }

        //[JsonProperty("threeDaysAlert")]
        //public DateTime? ThreeDaysAlert { get; set; }

        //[JsonProperty("oneDayAlert")]
        //public DateTime? OneDayAlert { get; set; }

        //[JsonProperty("oneDayAfter")]
        //public DateTime? OneDayAfter { get; set; }

        //[JsonProperty("twoDaysAfter")]
        //public DateTime? TwoDaysAfter { get; set; }

        //[JsonProperty("threeDaysAfter")]
        //public DateTime? ThreeDaysAfter { get; set; }

        //[JsonProperty("secondTimePmSchedule")]
        //public DateTime? SecondTimePmSchedule { get; set; }

        //[JsonProperty("thirdTimePmSchedule")]
        //public DateTime? ThirdTimePmSchedule { get; set; }

        //[JsonProperty("fourthTimePmSchedule")]
        //public DateTime? FourthTimePmSchedule { get; set; }

        //[JsonProperty("fifthTimePmSchedule")]
        //public DateTime? FifthTimePmSchedule { get; set; }

        //[JsonProperty("sixthTimePmSchedule")]
        //public DateTime? SixthTimePmSchedule { get; set; }

        //[JsonProperty("seventhTimePmSchedule")]
        //public DateTime? SeventhTimePmSchedule { get; set; }

        //[JsonProperty("eighthTimePmSchedule")]
        //public DateTime? EighthTimePmSchedule { get; set; }

        //[JsonProperty("frequency")]
        //public DateTime? NinthTimePmSchedule { get; set; }

        //[JsonProperty("tenthTimePmSchedule")]
        //public DateTime? TenthTimePmSchedule { get; set; }

        //[JsonProperty("eleventhTimePmSchedule")]
        //public DateTime? EleventhTimePmSchedule { get; set; }

        //[JsonProperty("twelfthTimePmSchedule")]
        //public DateTime? TwelfthTimePmSchedule { get; set; }

        //[JsonProperty("pmWorkFlow")]
        //public string PmWorkFlow { get; set; }


        //[JsonProperty("month")]
        //public DateTime? Month { get; set; }

        //[JsonProperty("modified")]
        //public DateTime? Modified { get; set; }

        //[JsonProperty("created")]
        //public DateTime? Created { get; set; }

        //[JsonProperty("createdBy")]
        //public string CreatedBy { get; set; }

        //[JsonProperty("modifiedBy")]
        //public string ModifiedBy { get; set; }
    }

        public class ScheduleModel : DateModel
        {
            [JsonProperty("machineIdSn")]
            public string MachineIdSn { get; set; }

            [JsonProperty("requiredCriticalSparePartList")]
            public string RequiredCriticalSparePartList { get; set; }

            [JsonProperty("headCountSize")]
            public string HeadCountSize { get; set; }

            [JsonProperty("plantHead")]
            public string PlantHead { get; set; }

            [JsonProperty("pmScheduleFlow")]
            public string PmScheduleFlow { get; set; }

            [JsonProperty("threeDaysAlert")]
            public DateTime? ThreeDaysAlert { get; set; }

            [JsonProperty("oneDayAlert")]
            public DateTime? OneDayAlert { get; set; }

            [JsonProperty("oneDayAfter")]
            public DateTime? OneDayAfter { get; set; }

            [JsonProperty("twoDaysAfter")]
            public DateTime? TwoDaysAfter { get; set; }

            [JsonProperty("threeDaysAfter")]
            public DateTime? ThreeDaysAfter { get; set; }

            [JsonProperty("pmWorkFlow")]
            public string PmWorkFlow { get; set; }


            [JsonProperty("month")]
            public string Month { get; set; }

            [JsonProperty("modified")]
            public DateTime? Modified { get; set; }

            [JsonProperty("created")]
            public DateTime? Created { get; set; }

            [JsonProperty("createdBy")]
            public string CreatedBy { get; set; }

            [JsonProperty("modifiedBy")]
            public string ModifiedBy { get; set; }
        }

        public class DateModel
        {
            [JsonProperty("firstTimePmSchedule")]
            public DateTime? FirstTimePmSchedule { get; set; }


            [JsonProperty("secondTimePmSchedule")]
            public DateTime? SecondTimePmSchedule { get; set; }

            [JsonProperty("thirdTimePmSchedule")]
            public DateTime? ThirdTimePmSchedule { get; set; }

            [JsonProperty("fourthTimePmSchedule")]
            public DateTime? FourthTimePmSchedule { get; set; }

            [JsonProperty("fifthTimePmSchedule")]
            public DateTime? FifthTimePmSchedule { get; set; }

            [JsonProperty("sixthTimePmSchedule")]
            public DateTime? SixthTimePmSchedule { get; set; }

            [JsonProperty("seventhTimePmSchedule")]
            public DateTime? SeventhTimePmSchedule { get; set; }

            [JsonProperty("eighthTimePmSchedule")]
            public DateTime? EighthTimePmSchedule { get; set; }

            [JsonProperty("frequency")]
            public DateTime? NinthTimePmSchedule { get; set; }

            [JsonProperty("tenthTimePmSchedule")]
            public DateTime? TenthTimePmSchedule { get; set; }

            [JsonProperty("eleventhTimePmSchedule")]
            public DateTime? EleventhTimePmSchedule { get; set; }

            [JsonProperty("twelfthTimePmSchedule")]
            public DateTime? TwelfthTimePmSchedule { get; set; }


        }

        public class PmIdModel
        {
            [JsonProperty("machineIdSn")]
            public string MachineIdSn { get; set; }
        }
    }
}
