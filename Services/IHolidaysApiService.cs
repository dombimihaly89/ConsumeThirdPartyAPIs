using System.Threading.Tasks;
using System.Collections.Generic;

namespace ConsumeThirdPartyAPIs.Services
{
    public interface IHolidaysApiService
    {
        Task<List<HolidayModel>> GetHolidays(int year, string countryCode);
    }
}
