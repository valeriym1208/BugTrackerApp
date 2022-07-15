using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTrackerData.Entities;

namespace bug_tracker_data.Models
{
    public class Comment : BaseEntity

    {
    [StringLength(100)] public string CommentMessage { get; set; }
    public TeamMember CommentAuthor { get; set; }
    public DateTime SubmitDate { get; set; }
    }
}
