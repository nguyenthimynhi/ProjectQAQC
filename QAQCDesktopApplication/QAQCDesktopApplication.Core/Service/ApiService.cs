using AutoMapper;
using Newtonsoft.Json;
using QAQCDesktopApplication.Core.Domain.Communication;
using QAQCDesktopApplication.Core.Domain.Communication.WebApi;
using QAQCDesktopApplication.Core.Domain.Model;
using QAQCDesktopApplication.Core.Service.Interface;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Http.Internal;
using System.Reflection.Metadata;
using System.Net.Http.Headers;

namespace QAQCDesktopApplication.Core.Service
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        //private readonly IMapper _mapper;
        //private readonly IFormFile _formFile;
        //private string token = "";

        private const string serverUrl = "https://cha-qa-qc-test.azurewebsites.net"; //http://192.168.1.80:8086
        //private const string serverUrl = "http://10.84.70.80:8086";

        public object CurrentDocument { get; private set; }

        public ApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromMinutes(30);
        }

        //public async Task<ServiceResourceResponse<Employee>> LogInAsync(string username, string password)
        //{
        //    ServiceResourceResponse<Employee> result;

        //    var loginCredential = new LoginRequest(username, password);
        //    var json = JsonConvert.SerializeObject(loginCredential);

        //    try
        //    {
        //        var content = new StringContent(json, Encoding.UTF8, "application/json");

        //        string url = $"{serverUrl}/api/auth";
        //        var response = await _httpClient.PostAsync(url, content);
        //        string responseBody = await response.Content.ReadAsStringAsync();

        //        switch (response.StatusCode)
        //        {
        //            case HttpStatusCode.OK:
        //                var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(responseBody);

        //                token = loginResponse.Token.AuthToken;
        //                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        //                result = new ServiceResourceResponse<Employee>(loginResponse.Employee);
        //                return result;
        //            case HttpStatusCode.BadRequest:
        //                var error = new Error("Api.Login", "Tên đăng nhập hoặc mật khẩu không hợp lệ.");
        //                result = new ServiceResourceResponse<Employee>(error);
        //                return result;
        //            default:
        //                error = new Error("Api.Login", "Đã có lỗi xảy ra. Không thể thực hiện đăng nhập.");
        //                result = new ServiceResourceResponse<Employee>(error);
        //                return result;
        //        }
        //    }
        //    catch (HttpRequestException ex)
        //    {
        //        var error = new Error("Api.Connection", $"Đã có lỗi xảy ra. Không thể kết nối được với server vì: {ex.Message}");
        //        result = new ServiceResourceResponse<Employee>(error);
        //    }
        //    catch (Exception ex)
        //    {
        //        var error = new Error("Api.Login", $"Đã có lỗi xảy ra. Không thể thực hiện đăng nhập vì: {ex.Message}");
        //        result = new ServiceResourceResponse<Employee>(error);
        //        return result;
        //    }
        //    return result;
        //}

        //public void LogOut()
        //{
        //    token = "";
        //    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        //}       

        public async Task<ServiceResourceResponse<QueryResult<qcreport>>> GetReport(DateTime? startTime, DateTime? stopTime, string standardid)
        {
            ServiceResourceResponse<QueryResult<qcreport>> result;
            string queryString = "";
            string standard = "";
            if (startTime != null)
            {
                if (standardid != null)
                {
                    standard = "/standard/" + standardid;
                }
                string startTimestring = startTime.Value.ToString("yyyy-MM-ddTHH:mm:ss");
                string stopTimestring = stopTime.Value.ToString("yyyy-MM-ddTHH:mm:ss");
                queryString += standard + "?Starttime=" + startTimestring +"&Stoptime=" + stopTimestring;
            }
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{serverUrl}/api/QcReports" + queryString);
                string responseBody = await response.Content.ReadAsStringAsync();
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        var reportTest = JsonConvert.DeserializeObject<QueryResult<qcreport>>(responseBody);
                        result = new ServiceResourceResponse<QueryResult<qcreport>>(reportTest);
                        return result;
                    default:
                        var error = new Error("Api.Report.Get", "Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ server.");
                        result = new ServiceResourceResponse<QueryResult<qcreport>>(error);
                        return result;
                }
            }

            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", $"Đã có lỗi xảy ra. Không thể kết nối được với server vì: {ex.Message}");
                result = new ServiceResourceResponse<QueryResult<qcreport>>(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.Product.Get", $"Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ server vì: {ex.Message}");
                result = new ServiceResourceResponse<QueryResult<qcreport>>(error);
                return result;
            }
            return result;
        }
        public async Task<ServiceResourceResponse<List<StandardDetail>>> GetStandard()
        {
            ServiceResourceResponse<List<StandardDetail>> result;
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{serverUrl}/api/Standards/details");
                string responseBody = await response.Content.ReadAsStringAsync();
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        var all = JsonConvert.DeserializeObject<List<StandardDetail>>(responseBody);
                        result = new ServiceResourceResponse<List<StandardDetail>>(all);
                        return result;
                    default:
                        var error = new Error("Api.Report.Get", "Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ server.");
                        result = new ServiceResourceResponse<List<StandardDetail>>(error);
                        return result;
                }
            }
            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", $"Đã có lỗi xảy ra. Không thể kết nối được với server vì: {ex.Message}");
                result = new ServiceResourceResponse<List<StandardDetail>>(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.Product.Get", $"Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ server vì: {ex.Message}");
                result = new ServiceResourceResponse<List<StandardDetail>>(error);
                return result;
            }
            return result;
        }
        public async Task<ServiceResponse> PostStandard(Standard standard)
        {
            ServiceResponse result;
            var json = JsonConvert.SerializeObject(standard);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                string url = $"{serverUrl}/api/Standards";
                var response = await _httpClient.PostAsync(url, content);
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        //EndShiftStatus = true;
                        return ServiceResponse.Successful();
                    case HttpStatusCode.BadRequest:
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var serverError = JsonConvert.DeserializeObject<ServerError>(responseBody);
                        var error = new Error("Api.SettingMachine.Post", serverError.Message);
                        return ServiceResponse.Failed(error);
                    case HttpStatusCode.Unauthorized:
                        error = new Error("Api.SettingMachine.Post", "Vui lòng đăng nhập.");
                        return ServiceResponse.Failed(error);
                    default:
                        error = new Error("Api.SettingMachine.Post", "Đã có lỗi xảy ra.");
                        return ServiceResponse.Failed(error);
                }
            }
            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", $"Đã có lỗi xảy ra. Không thể kết nối được với server vì: {ex.Message}");
                result = new ServiceResourceResponse<Tester>(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.SettingMachine.Post", $"Đã có lỗi xảy ra. Không thể gửi dữ liệu về server được vì: {ex.Message}");
                result = ServiceResponse.Failed(error);
                return result;
            }
            return result;
        }
        public async Task<ServiceResponse> DeleteStandard(string standard)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"{serverUrl}/api/Standards/{standard}");
                string responseBody = await response.Content.ReadAsStringAsync();
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return ServiceResponse.Successful();
                    case HttpStatusCode.NotFound:
                        var error = new Error("Api.Standard.Delete", $"Đã có lỗi xảy ra. Không thể tìm thấy sản phẩm có mã ");
                        return ServiceResponse.Failed(error);
                    default:
                        error = new Error("Api.Standard.Delete", $"Đã có lỗi xảy ra. Không thể xoá sản phẩm.");
                        return ServiceResponse.Failed(error);
                }
            }
            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", $"Đã có lỗi xảy ra.Không thể kết nối được với server vì: {ex.Message}");
                return ServiceResponse.Failed(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.Alarm.Get", $"Đã có lỗi xảy ra. Không thể xoá sản phẩm vì: {ex.Message}");
                return ServiceResponse.Failed(error);
            }
        }
        public async Task<ServiceResponse> PatchStandard(string id, StandardDetail standard)     
        {
            //ServiceResponse result;
            var json = JsonConvert.SerializeObject(standard);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                HttpResponseMessage response = await _httpClient.PutAsync($"{serverUrl}/api/Standards/{id}", content);
                string responseBody = await response.Content.ReadAsStringAsync();
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return ServiceResponse.Successful();
                    case HttpStatusCode.NotFound:
                        var error = new Error("Api.Standard.Patch", $"Đã có lỗi xảy ra. Không thể tìm thấy mã  sản phẩm.");
                        return ServiceResponse.Failed(error);
                    default:
                        error = new Error("Api.Standard.Patch", $"Đã có lỗi xảy ra. Không thể thay thế sản phẩm.");
                        return ServiceResponse.Failed(error);
                }
            }
            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", $"Đã có lỗi xảy ra.Không thể kết nối được với server vì: {ex.Message}");
                return ServiceResponse.Failed(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.Alarm.Get", $"Đã có lỗi xảy ra. Không thể xoá sản phẩm vì: {ex.Message}");
                return ServiceResponse.Failed(error);
            }
            }
        public async Task<ServiceResourceResponse<QueryResult<Product>>> GetProduct() 
        {
            ServiceResourceResponse<QueryResult<Product>> result;
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{serverUrl}/api/Products");
                string responseBody = await response.Content.ReadAsStringAsync();
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        var all = JsonConvert.DeserializeObject<QueryResult<Product>>(responseBody);
                        result = new ServiceResourceResponse<QueryResult<Product>>(all);
                        return result;
                    default:
                        var error = new Error("Api.Report.Get", "Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ server.");
                        result = new ServiceResourceResponse<QueryResult<Product>>(error);
                        return result;
                }
            }
            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", $"Đã có lỗi xảy ra. Không thể kết nối được với server vì: {ex.Message}");
                result = new ServiceResourceResponse<QueryResult<Product>>(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.Product.Get", $"Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ server vì: {ex.Message}");
                result = new ServiceResourceResponse<QueryResult<Product>>(error);
                return result;
            }
            return result;
        }
        public async Task<ServiceResponse> PutFiles(filePDF file)
        {
            var json = JsonConvert.SerializeObject(file);
            string id = file.standardId;
            var fileContent = new StringContent(json, Encoding.UTF8, "application/json");
            //var request = new MultipartFormDataContent();
            try
            {                
                HttpResponseMessage response = await _httpClient.PostAsync($"{serverUrl}/api/Standards/file", fileContent);
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return ServiceResponse.Successful();
                    case HttpStatusCode.NotFound:
                        var error = new Error("Api.Standard.File", $"Đã có lỗi xảy ra. Không thể tìm thấy sản phẩm có mã ");
                        return ServiceResponse.Failed(error);
                    default:
                        error = new Error("Api.Standard.File", $"Đã có lỗi xảy ra");
                        return ServiceResponse.Failed(error);
                }
            }
            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", $"Đã có lỗi xảy ra.Không thể kết nối được với server vì: {ex.Message}");
                return ServiceResponse.Failed(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.Alarm.Get", $"Đã có lỗi xảy ra. Không thể xoá sản phẩm vì: {ex.Message}");
                return ServiceResponse.Failed(error);
            }

        }
        public async Task<ServiceResponse> PutImage(ImageError file)
        {
            var json = JsonConvert.SerializeObject(file);
            //string id = file.standardId;
            var fileContent = new StringContent(json, Encoding.UTF8, "application/json");
            //var request = new MultipartFormDataContent();
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync($"{serverUrl}/api/Standards/appearanceError", fileContent);
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return ServiceResponse.Successful();
                    case HttpStatusCode.NotFound:
                        var error = new Error("Api.Standard.File", $"Đã có lỗi xảy ra. Không thể tìm thấy sản phẩm có mã ");
                        return ServiceResponse.Failed(error);
                    default:
                        error = new Error("Api.Standard.File", $"Đã có lỗi xảy ra");
                        return ServiceResponse.Failed(error);
                }
            }
            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", $"Đã có lỗi xảy ra.Không thể kết nối được với server vì: {ex.Message}");
                return ServiceResponse.Failed(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.Alarm.Get", $"Đã có lỗi xảy ra. Không thể xoá sản phẩm vì: {ex.Message}");
                return ServiceResponse.Failed(error);
            }

        }
        public async Task<ServiceResourceResponse<filePDF>> GetFiles(string id)
        {
            ServiceResourceResponse<filePDF> result;       
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{serverUrl}/api/Standards/{id}/file");
                string responseBody = await response.Content.ReadAsStringAsync();
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        var filedata = JsonConvert.DeserializeObject<filePDF>(responseBody);
                        result = new ServiceResourceResponse<filePDF>(filedata);                       
                        //var ms = new MemoryStream(encodedTextBytes); // ms gets filled properly

                        return result;
                    default:
                        var error = new Error("Api.Report.Get", "Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ server.");
                        result = new ServiceResourceResponse<filePDF>(error);
                        return result;
                }
            }
            catch (HttpRequestException ex)
            {
                var error = new Error("Api.Connection", $"Đã có lỗi xảy ra. Không thể kết nối được với server vì: {ex.Message}");
                result = new ServiceResourceResponse<filePDF>(error);
            }
            catch (Exception ex)
            {
                var error = new Error("Api.Product.Get", $"Đã có lỗi xảy ra. Không thể truy xuất dữ liệu từ server vì: {ex.Message}");
                result = new ServiceResourceResponse<filePDF>(error);
                return result;
            }
            return result;
        }
    }
}
