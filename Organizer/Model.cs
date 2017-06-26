using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public Category ParentCategory { get; set; }
        public int Level { get; set; }
    }

    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
    }

    public class Comment
    {
        public int CommentId { get; set; }
        public string Text { get; set; }

        public User User { get; set; }
    }
}
