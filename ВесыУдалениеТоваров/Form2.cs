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
    public partial class Form2 : Form
    {
        public Form1.RootObject RootObj;
        public string IP;
        public Form2(Form1.RootObject ro, string ip)
        {
            InitializeComponent();
            RootObj = ro;
            IP = ip;

            product_name_TB.Text = RootObj.product_name;

            product_code_TB.Text = RootObj.product_code;
            original_price_TB.Text = RootObj.original_price;
            product_code_TB.Text = RootObj.product_code;
            shelf_num_TB.Text = RootObj.shelf_num;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RootObj.product_name = product_name_TB.Text;
            RootObj.product_code = product_code_TB.Text ;
            RootObj.original_price = original_price_TB.Text  ; 
            RootObj.product_code = product_code_TB.Text;
            RootObj.shelf_num = shelf_num_TB.Text ;

            RootObj.product_abbr = product_name_TB.Text;
            RootObj.name_sort = product_name_TB.Text;
            RootObj.abbr_sort = product_name_TB.Text;


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

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
