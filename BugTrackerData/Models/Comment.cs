﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bug_tracker_data.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string CommentMessage { get; set; }
        public TeamMember CommentAuthor { get; set; }
        public DateTime SubmitDate { get; set; }
    }
}
