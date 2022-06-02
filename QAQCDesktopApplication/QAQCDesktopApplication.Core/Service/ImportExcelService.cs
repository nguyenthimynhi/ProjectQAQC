using Microsoft.Win32;
using OfficeOpenXml;
using QAQCDesktopApplication.Core.Domain.Communication;
using QAQCDesktopApplication.Core.Domain.Model;
using QAQCDesktopApplication.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAQCDesktopApplication.Core.Service
{
    public class ImportExcelService : IImportExcelService
    {
        private ExcelPackage package;
        private ExcelWorksheet worksheet;
        private readonly IRegularExpressionService _regularExpression;

        public ImportExcelService()
        {
            //this._regularExpression = regularExpression;
        }

        private ServiceResponse ReadExcelFile()
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            try
            {
                // mở file excel
                package = new ExcelPackage(new FileInfo(@"D:\ExcelFile.xlsx"));
                // lấy ra sheet đầu tiên để thao tác
                worksheet = package.Workbook.Worksheets["Baocao"];
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
        private ServiceResponse EditExcel(ObservableCollection<Machine> shift)
        {
            try
            {
                int i = 0;
                while (true)
                {
                    string a = Convert.ToString(worksheet.Cells["L" + Convert.ToString(8 + i)].Value);
                    if (a != "1" && a != "0")
                    { break; }
                    else { i++; }
                }
                int j = 0;
                for (j = 0; j < i; j++)
                {
                    DateTime Date = Convert.ToDateTime(worksheet.Cells["F" + Convert.ToString(8 + j)].Value.ToString());
                    string id = Convert.ToString(worksheet.Cells["H" + Convert.ToString(8 + j)].Value.ToString());
                    string moldid = worksheet.Cells["I" + Convert.ToString(8 + j)].Value.ToString();
                    string idproduct = worksheet.Cells["B" + Convert.ToString(8 + j)].Value.ToString();
                    string nameproduct = worksheet.Cells["D" + Convert.ToString(8 + j)].Value.ToString();
                    bool Thongsocaidat = Convert.ToBoolean(worksheet.Cells["J" + Convert.ToString(8+ j)].Value); 
                    bool Quytrinhhoatdong = Convert.ToBoolean(worksheet.Cells["K" + Convert.ToString(8 + j)].Value);
                    bool Nhancong = Convert.ToBoolean(worksheet.Cells["L" + Convert.ToString(8 + j)].Value); 
                    bool Nhietdo = Convert.ToBoolean(worksheet.Cells["M" + Convert.ToString(8 + j)].Value);
                    shift.Add(new Machine(id, moldid, new Product(idproduct, nameproduct), Date, Thongsocaidat, Quytrinhhoatdong, Nhancong, Nhietdo));
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
        public async Task<ServiceResponse> Import(ObservableCollection<Machine> machine)
        {
            var step1 = ReadExcelFile();
            var step2 = EditExcel(machine);
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
                    return ServiceResponse.Successful();
                }
            }
        }

        private ServiceResponse EditReport(ObservableCollection<Machine> report)
        {
            try
            {
                int i = 0;
                foreach (Machine item in report)
                {
                    //worksheet.Cells["B" + Convert.ToString(8 + i)].Value = item.standard.id;
                    //worksheet.Cells["C" + Convert.ToString(8 + i)].Value = item.standard.product.id;
                    //worksheet.Cells["D" + Convert.ToString(8 + i)].Value = item.standard.product.name;
                    //worksheet.Cells["E4"].Style.Numberformat.Format = "dd-mm-yyyy";
                    //worksheet.Cells["E4"].Value = item.timestamp;
                    //worksheet.Cells["F" + Convert.ToString(8 + i)].Value = item.batchQuantity;
                    //worksheet.Cells["I" + Convert.ToString(8 + i)].Value = item.moldId;
                    //worksheet.Cells["G" + Convert.ToString(8 + i)].Value = item.timestamp;
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


        public async Task<ServiceResponse> Export(ObservableCollection<Machine> machine)
        {
            var step1 = ReadExcelFile();
            var step2 = EditReport(machine);
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
