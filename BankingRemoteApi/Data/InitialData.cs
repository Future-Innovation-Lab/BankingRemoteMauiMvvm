using System.Linq;

namespace BankingRemoteApi.Data
{
    public static class InitialData
    {
        public static void Seed(this BankingContext dbContext)
        {
            if (!dbContext.Clients.Any())
            {



                dbContext.SaveChanges();
            }
        }
    }
}
