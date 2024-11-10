using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StudentEnrollmentWPF.MVVM.Model;

namespace StudentEnrollmentWPF.Services;

public class StudentEnrollmentAPIService : IStudentEnrollmentAPIService
{
    public async Task<List<Course>> GetCourses()
    {
        using (HttpClient client = new HttpClient())
        {
            var response = await client.GetAsync("http://localhost:5109/api/courses");
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                string stringResponse = await response.Content.ReadAsStringAsync();
                JObject jsonObject = JObject.Parse(stringResponse);
                return jsonObject["data"]?.ToObject<List<Course>>();
            }
            else
            {
                return new List<Course>();
            }
        }
    }

    public async Task<bool> DeleteCourse(int id)
    {
        using (HttpClient client = new HttpClient())
        {
            var url = $"http://localhost:5109/api/courses/{id}/delete";

            var response = await client.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                string stringResponse = await response.Content.ReadAsStringAsync();
                JObject jsonObject = JObject.Parse(stringResponse);
                return jsonObject["data"]?.ToObject<bool>() == true;
            }
            else
            {
                return false;
            }
        }
    }
}