using JobFinder.Domain.Common;
using JobFinder.Shared.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Domain.Entities;
public class JobApplicantLifecycle : BaseEntity
{
    [ForeignKey(nameof(JobApplicant))]
    public Guid JobApplicantId { get; set; }

    public ApplicantRequestStatus OldStatus { get; set; }
    public ApplicantRequestStatus NewStatus { get; set; }

    public string? Note { get; set; }

    public virtual JobApplicant? JobApplicant { get; set; }
}
