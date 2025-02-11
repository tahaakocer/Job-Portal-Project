using Job_Portal_Project.Models;
using Job_Portal_Project.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Job_Portal_Project.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IRepositoryManager _manager;
        public ApplicationService(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void createApplication(Application application, int jobid, string userid)
        {

            application.ApplicantId = userid;
            application.JobId = jobid;
            application.ApplicationDate = DateTime.Now;
            _manager.Application.createApplication(application);
            _manager.Save();
        }

        public void DeleteOneApplicationByApplicantID(string id)
        {
             var application = _manager.Application.GetOneApplicationByApplicantID(id,false);
            if (application is not null)
            {
                _manager.Application.DeleteOneApplication(application);
                _manager.Save();
            }
        }
        public IEnumerable<Application> GetApplicationsByUserID(string id, bool trackChanges)
        {
            return _manager.Application.GetApplications(id, trackChanges);
        }

        public Application? GetOneApplication(int id, bool trackChanges)
        {
            return _manager.Application.GetOneApplication(id, trackChanges);
        }
    }
}