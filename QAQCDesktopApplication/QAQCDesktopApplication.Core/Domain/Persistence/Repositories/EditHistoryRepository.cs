using QAQCDesktopApplication.Core.Domain.Model;
using QAQCDesktopApplication.Core.Domain.Persistence.Context;
using QAQCDesktopApplication.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAQCDesktopApplication.Core.Domain.Persistence.Repositories
{
    public class EditHistoryRepository : IEditHistoryRepository
    {
        private readonly ApplicationDbContext _context;
        public EditHistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void InsertAsync(EditHistory entry)
        {
            _context.editHistory.Add(entry);
        }

        //public async Task ClearAsync()
        //{
        //    var list = await _context.editHistory.ToListAsync();
        //    foreach (var item in list)
        //    {
        //        _context.editHistory.Remove(item);
        //    }
        //}

        public IList<EditHistory> Load(DateTime timestart, DateTime timestop)
        {
            var _timestart = timestart.AddHours(0).AddMinutes(0).AddSeconds(0);
            var _timestop = timestop.AddHours(0).AddMinutes(0).AddSeconds(0);
            var data = _context.editHistory
                .Where(f => f.Date >= _timestart && f.Date <= _timestop)
                .ToList();
            return data;
        }
    }
}
