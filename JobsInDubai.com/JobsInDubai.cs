using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;


/*
Require dependencies
Name:	ChromeDriver
ID:	WebDriver.ChromeDriver.win32
URL:	https://www.nuget.org/packages/WebDriver.ChromeDriver.win32/2.14.0

Name:	Selenium
ID:	Selenium.WebDriver
URL:	https://www.nuget.org/packages/Selenium.WebDriver/2.45.0
*/

/*well I am including over here */
using OpenQA.Selenium;
/* Chrome will do Perfect Job so adding it. :) */
using OpenQA.Selenium.Chrome;
/* Some File Writing */
using System.IO;
/* Xpath Lib */
using System.Xml.XPath;

namespace JobsInDubai.com
{
    public partial class JobsInDubai : Form
    {

        //user desktop path to store display files
        string path_Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        //https://www.jobsindubai.com/jobs.asp			678 * 10 Jobs
        //https://www.jobsindubai.com/job_list.asp?page=663&lstIndustryID=0&txtKeyword=&isSearch=False
        //http://web.archive.org/web/*/https://www.jobsindubai.com/jobs.asp
        public String default_Url = "https://www.jobsindubai.com";

        public void JobsInDubai_Scraper(string default_Url)
        {
            var job_title = "";
            var job_company = "";
            var job_desc = "";

            var job_location = "";
            var job_nationality = "";
            var job_experience = "";
            var job_keyskils = "";
            var job_function = "";
            var job_region = "United Arab Emirates";
            var job_industry = "";
            var job_date = "";
            var job_education = "";
            var next_page_class = 0;
            var page_number = 1;
            nextPage_label.Text = "Yes";

            /* initializing chrome driver */
            var chrome_Driver = ChromeDriverService.CreateDefaultService();
            //no need to show disturbing command window so set it hidden
            chrome_Driver.HideCommandPromptWindow = true;

            var main_page_chrome_Driver_Obj = new ChromeDriver(chrome_Driver, new ChromeOptions());

            /* create a csv file for output*/
            try
            {
                File.WriteAllText(Path.Combine(path_Desktop, "JobsInDubai_Scrapped_DataSet_allTypesJobs.csv"), "Job Title, Company, Description, Location, Experience,  Keyskills, Education, Region, Industry, Date\r\n");
            }
            catch (Exception ex)
            {

                //incase of file is open or readonly or no permission show message
                result_richTextBox.AppendText(ex.StackTrace);
                MessageBox.Show("Cannot write to file !");
            }

            do
            {

                if (next_page_class == 0) { nextPage_label.Text = "No"; }
                //this.page_no_label.Text = page_number.ToString();

                main_page_chrome_Driver_Obj.Navigate().GoToUrl(default_Url + "/job_list.asp?page=" + page_number + "&lstIndustryID=0&txtKeyword=&isSearch=False");

                // click the Detail View Link to show extra information for jobs
                var click_Detail_View = main_page_chrome_Driver_Obj.FindElement(By.XPath("//*/div[@id='divShowAll']/a"));
                if (click_Detail_View.Text == "Detail View") { click_Detail_View.Click(); }

                //count number of jobs on main page max 10 jobs
                var var_job_count = main_page_chrome_Driver_Obj.FindElementsByXPath("//*[@class='even']");
                var var_job_des = main_page_chrome_Driver_Obj.FindElementsByXPath("//*/table[@class='expand']");

                for (int job_index = 0; job_index < var_job_count.Count(); job_index++)
                {
                    job_title = var_job_count[job_index].FindElement(By.XPath("./td[2]")).Text;
                    job_title = cleanString(job_title);

                    job_company = var_job_des[job_index].FindElement(By.XPath("./tbody/tr[2]/td[2]/span[1]")).Text;
                    job_company = cleanString(job_company);

                    job_location = var_job_des[job_index].FindElement(By.XPath("./tbody/tr[2]/td[2]/span[2]")).Text;
                    job_location = cleanString(job_location);

                    var job_full_desc_raw = var_job_des[job_index].FindElement(By.XPath("./tbody/tr[4]/td")).Text;
                    var job_full_desc = job_full_desc_raw.Replace(System.Environment.NewLine, " ");

                    job_experience = ParseBetween(job_full_desc, "Experience :", "Years");
                    job_experience = cleanString(job_experience);
                    if (job_experience == string.Empty) { job_experience = "Not Required"; } else { job_experience = job_experience + " Years"; }

                    job_education = ParseBetween(job_full_desc, "Education :", "Experience :");
                    job_education = cleanString(job_education);
                    if (job_education == string.Empty) { job_education = "NULL"; }

                    //All this headach to extract Skills
                    
                    job_keyskils = ParseBetween(job_full_desc, "Skills :", "Description :");
                    job_keyskils = cleanString(job_keyskils);
                    if (job_keyskils == string.Empty)
                    {
                        job_keyskils = ParseBetween(job_full_desc, "Skills :", "Responsibilities :");
                        job_keyskils = cleanString(job_keyskils);
                        if (job_keyskils == string.Empty)
                        {
                            job_keyskils = ParseBetween(job_full_desc, "Responsibilities :", "Description :");
                            job_keyskils = cleanString(job_keyskils);
                            if (job_keyskils == string.Empty) { job_keyskils = "NULL"; }
                        }
                    }

                    //End Skills

                    job_industry = var_job_count[job_index].FindElement(By.XPath("./td[3]")).Text;
                    job_industry = cleanString(job_industry);

                    job_date = var_job_count[job_index].FindElement(By.XPath("./td[4]")).Text;
                    job_date = cleanString(job_date);
                    job_date = timeStampCnversion(job_date);

                    job_desc = cleanString(job_full_desc);
                    //+++++++++++++ values Scraper Region ENd +++++++++++++++++++++++++

                    //Dispaly Output and write data to CSV file
                    //Job Title, Company, Description, Location, Experience,  Keyskills, Region, Industry, Date\r\n
                    result_richTextBox.AppendText("\nJob Title: " + job_title.ToString().Trim() + "\nCompany: " + job_company.ToString().Trim() + "\nDescription: " + job_desc.ToString().Trim() + "\nLocation: " + job_location.ToString().Trim() + "\nExperience: " + job_experience.ToString().Trim() + "\nKeyskills: " + job_keyskils.ToString().Trim() + "\nEducation: " + job_education.ToString().Trim() + "\nRegion: " + job_region.ToString().Trim() + "\nIndustry: " + job_industry.ToString().Trim() + "\nDate: " + job_date.ToString().Trim() + "\r.....................................................................................................\n");
                    File.AppendAllText(Path.Combine(path_Desktop, "JobsInDubai_Scrapped_DataSet_allTypesJobs.csv"), job_title.ToString().Trim().Replace(",", "") + "," + job_company.ToString().Trim().Replace(",", "") + "," + job_desc.ToString().Trim().Replace(",", "") + "," + job_location.ToString().Trim().Replace(",", "") + "," + job_experience.ToString().Trim().Replace(",", "") + "," + job_keyskils.ToString().Trim().Replace(",", "") + "," + job_education.ToString().Trim().Replace(",", "") + "," + job_region.ToString().Trim().Replace(",", "") + "," + job_industry.ToString().Trim().Replace(",", "") + "," + job_date.ToString().Trim().Replace(",", "") + "\r\n");

                }

                //these three line to loop main pages
                var var_next_page_class = main_page_chrome_Driver_Obj.FindElementsByXPath("//*[@class='next']");
                next_page_class = var_next_page_class.Count();
                page_number++;
            } while (next_page_class == 1);
            main_page_chrome_Driver_Obj.Quit();
            main_page_chrome_Driver_Obj.Dispose();
        }

        public JobsInDubai()
        {
            InitializeComponent();
        }

        private void start_Btn_Click(object sender, EventArgs e)
        {
            JobsInDubai_Scraper(default_Url);
        }

        private void open_btn_Click(object sender, EventArgs e)
        {
            Process.Start(path_Desktop);
        }

        private void quit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nextPage_label_Click(object sender, EventArgs e)
        {

        }

        private void result_richTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        public string ParseBetween(string Subject, string Start, string End)
        {
            return Regex.Match(Subject, Regex.Replace(Start, @"[][{}()*+?.\\^$|]", @"\$0") + @"\s*(((?!" + Regex.Replace(Start, @"[][{}()*+?.\\^$|]", @"\$0") + @"|" + Regex.Replace(End, @"[][{}()*+?.\\^$|]", @"\$0") + @").)+)\s*" + Regex.Replace(End, @"[][{}()*+?.\\^$|]", @"\$0"), RegexOptions.IgnoreCase).Value.Replace(Start, "").Replace(End, "");
        }

        //Date to Time Stamp Converter Function
        public string timeStampCnversion(string string_date)
        {
            //standard date timeStampCnversion format is 6/14/2015
            // current website date format is 2/22/2013
            string s = string_date;
            string[] values = s.Split('/');
            string str_month = values[0].Trim();
            string str_day = values[1].Trim();
            string str_year = values[2].Trim();
            int int_year = int.Parse(str_year);
            int int_month = int.Parse(str_month);
            int int_day = int.Parse(str_day);


            DateTime date = new DateTime(int_year, int_month, int_day, 12, 0, 0, 0);
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan span = (date - epoch);
            double unixTime = span.TotalSeconds;
            return unixTime.ToString();
        }

        public string cleanString(string str)
        {
            return str.Trim(new Char[] { ' ', '\r', '\n' });
        }

        private void page_no_label_Click(object sender, EventArgs e)
        {

        }
    }
}
