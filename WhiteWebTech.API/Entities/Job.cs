using System;
using System.Collections.Generic;

namespace WhiteWebTech.API.Entities;

public partial class Job 
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? IsActive { get; set; }

    public DateTime? CreateTime { get; set; }
}
