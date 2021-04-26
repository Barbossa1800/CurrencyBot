using CurrencyBot.Infrastructure.Database.Context;
using CurrencyBot.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyBot.Infrastructure.Services.Impls
{
    public class EFScheduleRepository : IScheduleRepository
    {
        private readonly ScheduleContext _db;
        public EFScheduleRepository()
        {
            _db = new ScheduleContext();
        }

        public async Task<Schedule> AddScheduleAsync(Schedule shedule)
        {
            await _db.Schedules.AddAsync(shedule);
            await _db.SaveChangesAsync();
            return shedule;
        }

        public async Task<Schedule> EditScheduleAsync(Schedule shedule)
        {
            _db.Schedules.Update(shedule);
            await _db.SaveChangesAsync();
            return shedule;
        }

        public async Task<List<Schedule>> GetScheduleByChatIdAsync(int chatId)
        {
            return await _db.Schedules.AsNoTracking().Where(d => d.ChatId == chatId).ToListAsync();
        }

        public async Task<List<Schedule>> GetSchedulesByTimeAsync(DateTime time)
        {
            return await _db.Schedules.AsNoTracking().Where(d => d.Time.Hour == time.Hour && d.Time.Minute == time.Minute).ToListAsync();
        }

        public async Task RemoveScheduleAsync(Schedule shedule)
        {
            _db.Schedules.Remove(shedule);
            await _db.SaveChangesAsync();
        }
    }
}
