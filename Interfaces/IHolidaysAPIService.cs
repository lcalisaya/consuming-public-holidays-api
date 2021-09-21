using ConsumingHolidaysAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsumingHolidaysAPI.Interfaces
{
    public interface IHolidaysAPIService
    {
        Task<List<HolidayModel>> GetHolidays(string countryCode, int year);
    }
}
