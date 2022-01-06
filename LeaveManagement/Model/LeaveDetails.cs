namespace LeaveManagement.Model
{
    public partial class LeaveDetails
    {
        public int TotalMannedHours { get; set; }
        public int? LeaveHours { get; set; }
        public int? ProjectId { get; set; }
        public virtual Projects Project { get; set; }
    }
}
