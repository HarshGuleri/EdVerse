using System;
using System.Collections.Generic;
using System.Text;

namespace EdVerse.Data.Data.Entity.Base;

public abstract class BaseEntity
{
    public int Id { get; set; }

    public bool IsActive { get; set; } = true;

    public bool IsDeleted { get; set; } = false;

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedOn { get; set; }

    public DateTime? DeletedOn { get; set; }

    public string? CreatedByUserId { get; set; }

    public string? UpdatedByUserId { get; set; }

    public string? DeletedByUserId { get; set; }
}