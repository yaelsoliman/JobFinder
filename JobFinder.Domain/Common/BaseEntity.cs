using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Domain.Common;

public interface IBaseEntity
{
    public Guid Id { get; set; }

    public Guid CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string? CreatorName { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public DateTime? LastModifiedOn { get; set; }
    public string? ModifierName { get; set; }
    public DateTime? DeletedOn { get; set; }
    public Guid? DeletedBy { get; set; }
    public string? DeleteName { get; set; }
    public bool IsActive { get; set; }
}


public class BaseEntity : IBaseEntity
{
    [Key]
    public Guid Id { get; set; }
    
    public Guid CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string? CreatorName { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public DateTime? LastModifiedOn { get; set; }
    public string? ModifierName { get; set; }
    public DateTime? DeletedOn { get; set; }
    public Guid? DeletedBy { get; set; }
    public string? DeleteName { get; set; }
    public bool IsActive { get; set; }
}
