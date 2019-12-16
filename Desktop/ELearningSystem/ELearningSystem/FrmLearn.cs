using ELearningSystem.Models;
using ELearningSystem.ResponseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELearningSystem
{
    public partial class FrmLearn : Form
    {
        static HttpClient client = new HttpClient();
        static String accessToken ="G7Zr6E-nqoXSBllFrJe1Qs3ZXQ4iaHNdDhHvE46w5AwU3GnESqpGWDOWCw6qDaQJ3k4_2w3WdSH6AaC0I_KNup7mqTJLk7IpBX_00x7gRQOs0AV5wIhhXVrO3OfRtgkFG-Z0FtX53xsAHnQ7KpmHZUqzGYhrsvj2UM6SF_pMKkcJOmSwq31r8IULUppSlPngIyHv0n6hWhwePjYfZ3kNF29wwRJYl1RZoNxdakzDAWVn2Tprkz_YexdUEFYn_aatppQThr0Yu6JJ_Xxw0Txqrz9kM-A-SMNl3uM8SOa17FcFl5JF-XMw1xUAn5a_-CHK7uBcI3XYKxxhIbgdfgwKPVZSfASQfIRvvcLlwHvGJoH4wnlIrLg6WUFPkinBbAjdSr3flIPn0pwEBlF1xw2M0EoU3rUYO4H-dAXXmbZP-aFYZ9PtwKUTY3mZYHUHMI7Hv3VVwqus7TojEEapRDRPvA";

        public object JsonConvert { get; private set; }

        public async void GetUserCourseAsync(string path)
        {
            UserCourseIDResponse userCourses = null;
            
            client.BaseAddress = new Uri("http://localhost:60793/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

            // Make an API call and receive HttpResponseMessage
            HttpResponseMessage responseMessage = await client.GetAsync(path, HttpCompletionOption.ResponseContentRead);
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = await responseMessage.Content.ReadAsStringAsync();
                userCourses = JsonConvert.DeserializeObject<UserCourseIDResponse>(result);
            }
            
            //MessageBox.Show(email);
        }

        /*public async Task<List<Course>> GetUserCourseAsync(string path)
        {
            List<Course> courses = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                courses = await response.Content.ReadAsAsync<Product>();
            }
            return courses;
        }*/

        public FrmLearn()
        {
            InitializeComponent();
        }

        private void FrmLearn_Load(object sender, EventArgs e)
        {
            GetUserCourseAsync("api/user-course/id");

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var embed = "<html><head>" +
            "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=Edge\"/>" +
            "</head><body>" +
            "<iframe width=\"800\" height=\"600\" src=\"{0}\"" +
            "frameborder = \"0\" allow = \"autoplay; encrypted-media\" allowfullscreen></iframe>" +
            "</body></html>";
            var url = "https://www.youtube.com/embed/L6ZgzJKfERM";
            this.webBrowser1.DocumentText = string.Format(embed, url);
        }



    }
}
