using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ВесыУдалениеТоваров
{
    public partial class Form3 : Form
    {
        public string IP;
        public Form3(string ip)
        {
            InitializeComponent();
            IP = ip;
        }


        //public string abbr_sort { get; set; }
        //public string barcode { get; set; }
        //public string best_before_data { get; set; }
        //public string branch_id { get; set; }
        //public string category_num { get; set; }
        //public string department_num { get; set; }
        //public string disabled { get; set; }
        //public string exp_date { get; set; }
        //public string image_filename { get; set; }
        //public string ingredients { get; set; }
        //public string label_format_num { get; set; }
        //public string label_image { get; set; }
        //public string name_sort { get; set; }
        //public string nutrition { get; set; }
        //public string original_price { get; set; }
        //public string pack_date { get; set; }
        //public string pcs_flag { get; set; }
        //public string place_of_origin { get; set; }
        //public string pos_no { get; set; }
        //public string pre_tare_unit_index { get; set; }
        //public string pre_tare_value { get; set; }
        //public string price_unit_index { get; set; }
        //public string prod_date { get; set; }
        //public string produced { get; set; }
        //public string product_abbr { get; set; }
        //public string product_code { get; set; }
        //public string product_name { get; set; }
        //public string product_number { get; set; }
        //public string reccommend_days { get; set; }
        //public string remark_1 { get; set; }
        //public string remark_2 { get; set; }
        //public string remark_3 { get; set; }
        //public string remark_4 { get; set; }
        //public string remark_5 { get; set; }
        //public string remark_6 { get; set; }
        //public string remark_7 { get; set; }
        //public string remark_8 { get; set; }
        //public string sales_price { get; set; }
        //public string shelf_num { get; set; }
        //public string shop_id { get; set; }
        //public string temperature_info { get; set; }
        //public string used_by_days { get; set; }


        private void Form3_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (product_name_TB.Text == "" || product_code_TB.Text == "" || original_price_TB.Text=="" 
                || shelf_num_TB.Text == "")
            {
                MessageBox.Show("Не заполнено.");
                return;
            }

            Form1.RootObject RootObj = new Form1.RootObject();
            
            RootObj.product_name = product_name_TB.Text;
            RootObj.product_code = product_code_TB.Text;
            RootObj.original_price = original_price_TB.Text;
            RootObj.product_code = product_code_TB.Text;
            RootObj.shelf_num = shelf_num_TB.Text;
            RootObj.product_abbr = product_name_TB.Text;

            RootObj.abbr_sort = product_name_TB.Text;
            RootObj.barcode = "0";
            RootObj.category_num = "0";
            RootObj.department_num = "0";
            RootObj.disabled = "0";
            RootObj.ingredients = ingredients_TB.Text; if(RootObj.ingredients == "") RootObj.ingredients = "." ;
            RootObj.label_format_num = "0";
            RootObj.label_image = "";
            RootObj.name_sort = product_name_TB.Text;
            RootObj.pcs_flag = "0";
            RootObj.pre_tare_unit_index = "-1";
            RootObj.pre_tare_value = "0";
            RootObj.price_unit_index = "0";

            RootObj.product_number = product_number_TB.Text;
            RootObj.used_by_days = used_by_days_TB.Text;

            RootObj.remark_1 = remark_1_TB.Text;
            RootObj.remark_2 = remark_2_TB.Text;
            RootObj.remark_3 = remark_3_TB.Text;
            RootObj.remark_4 = remark_4_TB.Text;

            RootObj.best_before_data = "";
            RootObj.remark_5 = "";
            RootObj.remark_6 = "";
            RootObj.remark_7 = "";
            RootObj.remark_8 = "";
            RootObj.temperature_info = "";
            RootObj.branch_id = "";
            RootObj.exp_date = "";
            RootObj.image_filename = "";
            RootObj.nutrition = "";
            RootObj.pack_date = "";
            RootObj.place_of_origin = "";
            RootObj.pos_no = "";
            RootObj.prod_date = "";
            RootObj.produced = "";
            RootObj.reccommend_days = "";
            RootObj.shop_id = "";


            string out_str = JsonConvert.SerializeObject(RootObj);
            out_str = "[" + out_str + "]";

            string url = $"http://{IP}:1235/products";

            System.Net.WebRequest req = System.Net.WebRequest.Create(url);
            req.Method = "POST";

            System.IO.Stream stream2 = req.GetRequestStream();

            string data_str = out_str;
            var data = Encoding.UTF8.GetBytes(data_str);
            stream2.Write(data, 0, data.Length);

            System.Net.WebResponse resp = req.GetResponse();
            System.IO.Stream stream = resp.GetResponseStream();

            System.IO.StreamReader sr = new System.IO.StreamReader(stream);                 


            this.Close();
        }
    }
}
