using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bug_tracker_data.Models;
using BugTrackerData.Models;
using Microsoft.EntityFrameworkCore;

namespace bug_tracker_data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Orgranization> Organization { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketPriority> TicketPriorities { get; set; }
        public DbSet<TicketStatus> TicketsStatuses { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
        public DbSet<Token> Tokens { get; set; }

    }
}
