using QAQCDesktopApplication.Core.Domain.Communication;
using QAQCDesktopApplication.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Windows;
using QAQCDesktopApplication.Core.Domain.Model;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using System.IO;
using System.Collections.ObjectModel;

namespace QAQCDesktopApplication.Core.Service
{
    public class ExcelExportService : IExcelExportService
    {
        private ExcelPackage package;
        private ExcelWorksheet worksheet;
        private readonly IRegularExpressionService _regularExpression;

        public ExcelExportService()
        {
            //this._regularExpression = regularExpression;
        }

        private ServiceResponse ReadExcelFile(string path)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            try
            {
                // mở file excel
                package = new ExcelPackage(new FileInfo(path));
                // lấy ra sheet đầu tiên để thao tác
                worksheet = package.Workbook.Worksheets["Sheet1"];
                return ServiceResponse.Successful();
            }
            catch (Exception ex)
            {
                Error error = new Error
                {
                    ErrorCode = "ReadExcel",
                    Message = ex.ToString()
                };
                return ServiceResponse.Failed(error);
            }
        }

        private ServiceResponse EditExcelTest(ObservableCollection<qcreport> report)
        {
            try
            {
                int i = 0;
                foreach (qcreport item in report)
                {
                    worksheet.Cells["B" + Convert.ToString(8 + i)].Value = item.standard.id;
                    worksheet.Cells["B6"].Value = "Mã tiêu chuẩn";
                    worksheet.Cells["C6"].Value = "Mã sản phẩm";
                    worksheet.Cells["D6"].Value = "Tên sản phẩm";
                    worksheet.Cells["F6"].Value = "Số lượng kiểm";
                    worksheet.Cells["C" + Convert.ToString(8 + i)].Value = item.standard.product.id;
                    worksheet.Cells["D" + Convert.ToString(8 + i)].Value = item.standard.product.name;
                    worksheet.Cells["C4"].Value = "NGÀY KIỂM TRA";
                    worksheet.Cells["E4"].Style.Numberformat.Format = "dd-mm-yyyy";
                    worksheet.Cells["E4"].Value = item.timestamp;
                    worksheet.Cells["F" + Convert.ToString(8 + i)].Value = item.batchQuantity;
                    worksheet.Cells["I" + Convert.ToString(8 + i)].Value = item.moldId;
                    worksheet.Cells["G" + Convert.ToString(8 + i)].Value = item.timestamp;
                    i++;
                }
                    return ServiceResponse.Successful();
            }
            catch (Exception ex)
            {
                Error error = new Error
                {
                    ErrorCode = "EditExcel",
                    Message = ex.ToString()
                };
                return ServiceResponse.Failed(error);
            }                         
        }

        private async Task<ServiceResponse> ExportExcelFile()
        {
            string filePath = "";
            // tạo SaveFileDialog để lưu file excel
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel | *.xlsx";
            // Nếu mở file và chọn nơi lưu file thành công sẽ lưu đường dẫn lại dùng
            if (dialog.ShowDialog() == true)
            {
                filePath = dialog.FileName;
                var file = new FileInfo(filePath);
                try
                {
                    using (package)
                    {
                        await package.SaveAsAsync(file);
                    }
                    return ServiceResponse.Successful();
                }
                catch (Exception ex)
                {
                    Error error = new Error
                    {
                        ErrorCode = "ExportExcel",
                        Message = ex.ToString()
                    };
                    return ServiceResponse.Failed(error);
                }
            }
            else
            {
                // nếu đường dẫn null hoặc rỗng thì báo không hợp lệ và return hàm
                if (string.IsNullOrEmpty(filePath))
                {
                    Error error = new Error
                    {
                        ErrorCode = "ExportExcel",
                        Message = "Đường dẫn không hợp lệ"
                    };
                    return ServiceResponse.Failed(error);
                }
                else
                {
                    Error error = new Error
                    {
                        ErrorCode = "ExportExcel",
                        Message = "Lỗi Lưu file"
                    };
                    return ServiceResponse.Failed(error);
                }
            }
        }

        public async Task<ServiceResponse> ExportTest(string path, ObservableCollection<qcreport> report)
        {
            var step1 = ReadExcelFile(path);
            var step2 = EditExcelTest(report);
            var step3 = await ExportExcelFile();
            if (step1.Success != true)
            {
                return step1;
            }
            else
            {
                if (step2.Success != true)
                {
                    return step2;
                }
                else
                {
                    if (step3.Success != true)
                    {
                        return step3;
                    }
                    else
                    {
                        return ServiceResponse.Successful();
                    }
                }
            }
        }
    }
}
