using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Application.Models.ServiceModel;
public class SubmitTestRequest
{
    public Guid JobId { get; set; }
    public List<ApplyJobRequest> ApplyJobRequest { get; set; }
}
