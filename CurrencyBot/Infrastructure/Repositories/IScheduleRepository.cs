using CurrencyBot.Infrastructure.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyBot.Infrastructure.Services
{
    public interface IScheduleRepository
    {
        Task<Schedule> AddScheduleAsync(Schedule shedule);
        Task<Schedule> EditScheduleAsync(Schedule shedule);
        Task<List<Schedule>> GetScheduleByChatIdAsync(int chatId);
        Task RemoveScheduleAsync(Schedule shedule);
        Task<List<Schedule>> GetSchedulesByTimeAsync(DateTime time);
    }
}
