﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLibraryApi.Model
{
    [Table("Books")] // Nome da tabela, opcional se for igual ao nome da classe
    public class Book
    {
        [Key]
        [Column("book_id")]
        public int BookId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("title")]
        public string Title { get; set; } = "";

        [Required]
        [MaxLength(50)]
        [Column("first_name")]
        public string FirstName { get; set; } = "";

        [Required]
        [MaxLength(50)]
        [Column("last_name")]
        public string LastName { get; set; } = "";

        [Required]
        [Column("total_copies")]
        public int TotalCopies { get; set; } = 0;

        [Required]
        [Column("copies_in_use")]
        public int CopiesInUse { get; set; } = 0;

        [MaxLength(50)]
        [Column("type")]
        public string? Type { get; set; }

        [MaxLength(80)]
        [Column("isbn")]
        public string? Isbn { get; set; }

        [MaxLength(50)]
        [Column("category")]
        public string? Category { get; set; }
    }
}
