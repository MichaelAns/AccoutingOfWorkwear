namespace AoW.EntityFramework.Models
{
    public class ExtraditionInfo : Base.BaseEntity<int>
    {
        public DateOnly Date { get; set; }
        public int Term { get; set;  }  
        public int WorkWearID { get; set; }
        public virtual WorkWear WorkWear { get; set; }
        public virtual string StaffID { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
