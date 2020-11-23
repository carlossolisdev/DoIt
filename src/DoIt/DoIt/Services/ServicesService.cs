using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoIt.Services
{
    public class ServicesService
    {
        public async Task CreateService(Service service)
        {
            using (var context = new DoItEntities())
            {
                context.Services.Add(service);
                await context.SaveChangesAsync();
            }
        }

        public Service GetServiceById(int serviceId)
        {
            using (var context = new DoItEntities())
            {
                return context.Services.FirstOrDefault(x => x.ServiceId == serviceId);
            }
        }

        public IEnumerable<Service> GetServicesByAuthorId(int authorId)
        {
            using (var context = new DoItEntities())
            {
                return context.Services.Where(x => x.AuthorId == authorId).ToList();
            }
        }

        public async Task UpdateService(Service service)
        {
            using (var context = new DoItEntities())
            {
                var serviceToUpdate = context.Services.FirstOrDefault(x => x.ServiceId == service.ServiceId);
                serviceToUpdate = service;
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteService(int id)
        {
            using (var context = new DoItEntities())
            {
                var serviceToDelete = context.Services.FirstOrDefault(x => x.ServiceId == id);
                context.Services.Remove(serviceToDelete);
                await context.SaveChangesAsync();
            }
        }
    }
}