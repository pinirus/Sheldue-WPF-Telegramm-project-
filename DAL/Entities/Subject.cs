﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities;

public class Subject
{
    [Key] public int Id { get; set; }

    [Required] [StringLength(50)] public string Name { get; set; } = string.Empty;

    [Required] public bool IsPractice { get; set; }

    [Required] public Group OwnerGroup { get; set; } = new();

    [Column(TypeName = "VARCHAR")]
    [StringLength(200)]
    public string? Url { get; set; }

    [StringLength(50)] public string? Location { get; set; }

    [StringLength(50)] public string? Teacher { get; set; }
}