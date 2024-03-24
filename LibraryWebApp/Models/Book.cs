using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebApp.Models
{
    [PrimaryKey(nameof(Id))]
    public class Book
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required uint Year { get; set; }
        public required string Author { get; set; }
        public required string Status { get; set; }

        public required uint BookCount { get; set; }

    }
}
