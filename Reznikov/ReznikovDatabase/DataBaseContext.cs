using Microsoft.EntityFrameworkCore;

namespace ReznikovDatabase
{
    public class DataBaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ReznicovCOPLaba3;Integrated Security=True;
MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Student> Students { set; get; }
        public virtual DbSet<AverageMark> AverageMarks { set; get; }
        public virtual DbSet<EducationForm> EducationForms { set; get; }
    }
}
