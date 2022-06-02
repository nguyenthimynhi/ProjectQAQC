using Microsoft.EntityFrameworkCore;
using QAQCDesktopApplication.Core.Domain.Communication;
using QAQCDesktopApplication.Core.Domain.Model;
using QAQCDesktopApplication.Core.Domain.Persistence.Context;
using QAQCDesktopApplication.Core.Domain.Persistence.Repositories;
using QAQCDesktopApplication.Core.Persistence.Repositories;
using QAQCDesktopApplication.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAQCDesktopApplication.Core.Service
{
    public class DatabaseService : IDatabaseService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public DatabaseService(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        #region Historyedit
        public async Task<ServiceResponse> InsertEditHistory(EditHistory standard)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var _editHistoryRepository = new EditHistoryRepository(context);
                var _unitOfWork = new UnitOfWork(context);
                try
                {
                    _editHistoryRepository.InsertAsync(standard);
                    await _unitOfWork.SaveChangeAsync();
                    return ServiceResponse.Successful();
                }
                catch
                {
                    //_unitOfWork.DetachChange();
                    Error error = new Error
                    {
                        ErrorCode = "Database.Insert",
                        Message = "Lỗi khác."
                    };
                    return ServiceResponse.Failed(error);
                }
            }

        }
        public async Task<IList<EditHistory>> LoadEditHistory(DateTime timestart, DateTime timestop)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var _editHistoryRepository = new EditHistoryRepository(context);
                var _unitOfWork = new UnitOfWork(context);

                try
                {
                    var data = _editHistoryRepository.Load(timestart, timestop);
                    //foreach (var item in data)
                    //{
                    //    var r = context.Entry(item);
                    //    r.Reference(p => p.Product).Load();
                    //}
                    await _unitOfWork.SaveChangeAsync();
                    return data;
                }
                catch
                {
                    // _unitOfWork.DetachChange();
                    return null;
                }
            }
        }
        #endregion
        #region Historyreport
        public async Task<ServiceResponse> InsertReportHistory(ReportHistory report)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var _reportHistoryRepository = new ReportHistoryRepository(context);
                var _unitOfWork = new UnitOfWork(context);
                try
                {
                    _reportHistoryRepository.InsertAsync(report);
                    await _unitOfWork.SaveChangeAsync();
                    return ServiceResponse.Successful();
                }
                catch
                {
                    // _unitOfWorkTest.DetachChange();
                    Error error = new Error
                    {
                        ErrorCode = "Database.Insert",
                        Message = "Lỗi khác."
                    };
                    return ServiceResponse.Failed(error);
                }
            }
        }
        public async Task<IList<ReportHistory>> LoadReportHistory(DateTime timestart, DateTime timestop)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var _reportHistoryRepository = new ReportHistoryRepository(context);
                var _unitOfWork = new UnitOfWork(context);
                try
                {
                    var data = _reportHistoryRepository.Load(timestart, timestop);
                    await _unitOfWork.SaveChangeAsync();
                    //foreach (var item in data)
                    //{
                    //    var r = context.Entry(item);
                    //    r.Reference(p => p.Product).Load();
                    //}
                    return data;
                }
                catch
                {
                    //_unitOfWork.DetachChange();
                    return null;
                }
            }
        }
        #endregion
    }
}
