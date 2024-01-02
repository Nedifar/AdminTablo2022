using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminTabloNetCore.Models
{
    public class context : DbContext
    {
        private static context _context;
        public static context GetContext()
        {
            _context = _context ?? new context();
            return _context;
        }
        public static void RestartContext()
        {
            _context = new context();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string con = "Host=192.168.147.58; port=5432; Database=TabloRecreate; username=postgres; password=1";
            //string con = "Host=localhost; port=5432; Database=InformationTabloBase; username=postgres; password=gaz_gaz_Ilyas12";
            optionsBuilder.UseNpgsql(con).UseLazyLoadingProxies();
        }

        public DbSet<WeekName> WeekNames { get; set; }
        public DbSet<TimeShedule> TimeShedules { get; set; }
        public DbSet<SupervisorShedule> SupervisorShedules { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<DatesSupervisior> DatesSupervisiors { get; set; }
        public DbSet<MonthYear> MonthYear { get; set; }
        public DbSet<DayPartHeader> DayPartHeaders { get; set; }
        public DbSet<SpecialDayWeekName> SpecialDayWeekNames { get; set; }
        public DbSet<Para> Paras { get; set; }
        public DbSet<TypeInterval> TypeIntervals { get; set; }
        public DbSet<SpecialBackgroundPhoto> SpecialBackgroundPhotos { get; set; }
        public DbSet<User> Users { get; set; } 

        public DbSet<AdditionalLessonsModels.DayWeek> DayWeeks { get; set; }
        public DbSet<AdditionalLessonsModels.SheduleAdditionalLesson> SheduleAdditionalLessons { get; set; }
        public DbSet<AdditionalLessonsModels.Lesson> Lessons { get; set; }
        public DbSet<AdditionalLessonsModels.Time> Times { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityColumns();
        }
    }
}
