using OplossingPublishers.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OplossingPublishers.Data.Repository
{
    public interface IJobsRepository
    {
        public IEnumerable<Job> OphalenJobs();
    }
}