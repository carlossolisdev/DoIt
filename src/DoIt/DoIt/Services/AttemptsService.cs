using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoIt.Services
{
    public class AttemptsService
    {
        public async Task CreateAttempt(Attempt attempt)
        {
            using (var context = new DoItEntities())
            {
                context.Attempts.Add(attempt);
                await context.SaveChangesAsync();
            }
        }

        public Attempt GetAttemptById(int id)
        {
            Attempt attemptToReturn;
            using (var context = new DoItEntities())
            {
                attemptToReturn = context.Attempts.FirstOrDefault(x => x.AttemptId == id);
            }
            return attemptToReturn;
        }

        public IEnumerable<Attempt> GetAttemptsByServiceId(int serviceId)
        {
            using (var context = new DoItEntities())
            {
                return context.Attempts.Where(x => x.ServiceId == serviceId).ToList();
            }
        }

        public async Task UpdateAttempt(Attempt attempt)
        {
            using (var context = new DoItEntities())
            {
                var attemptToUpdate = context.Attempts.FirstOrDefault(x => x.AttemptId == attempt.AttemptId);
                attemptToUpdate = attempt;
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAttempt(int id)
        {
            using (var context = new DoItEntities())
            {
                var attemptToDelete = context.Attempts.FirstOrDefault(x => x.AttemptId == id);
                context.Attempts.Remove(attemptToDelete);
                await context.SaveChangesAsync();
            }
        }
    }
}