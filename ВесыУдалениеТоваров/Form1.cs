using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ВесыУдалениеТоваров
{
    public partial class Form1 : Form
    {

        public class RootObject // сгенерировать класс http://json2csharp.com/
        {
            public string abbr_sort { get; set; }
            public string barcode { get; set; }
            public string best_before_data { get; set; }
            public string branch_id { get; set; }
            public string category_num { get; set; }
            public string department_num { get; set; }
            public string disabled { get; set; }
            public string exp_date { get; set; }
            public string image_filename { get; set; }
            public string ingredients { get; set; }
            public string label_format_num { get; set; }
            public string label_image { get; set; }
            public string name_sort { get; set; }
            public string nutrition { get; set; }
            public string original_price { get; set; }
            public string pack_date { get; set; }
            public string pcs_flag { get; set; }
            public string place_of_origin { get; set; }
            public string pos_no { get; set; }
            public string pre_tare_unit_index { get; set; }
            public string pre_tare_value { get; set; }
            public string price_unit_index { get; set; }
            public string prod_date { get; set; }
            public string produced { get; set; }
            public string product_abbr { get; set; }
            public string product_code { get; set; }
            public string product_name { get; set; }
            public string product_number { get; set; }
            public string reccommend_days { get; set; }
            public string remark_1 { get; set; }
            public string remark_2 { get; set; }
            public string remark_3 { get; set; }
            public string remark_4 { get; set; }
            public string remark_5 { get; set; }
            public string remark_6 { get; set; }
            public string remark_7 { get; set; }
            public string remark_8 { get; set; }
            public string sales_price { get; set; }
            public string shelf_num { get; set; }
            public string shop_id { get; set; }
            public string temperature_info { get; set; }
            public string used_by_days { get; set; }
        }
        List<RootObject> result;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
                                 
        }

        // curl аналог - "curl -X DELETE --data ""{""productNumbers"":""{NUMBER}""}"" ""http://{IP}:1235/products""";
        private void button1_Click(object sender, EventArgs e)
        {
            if (PLU_TB.Text == "") return;
            try
            {
                //Request
                string url = $"http://{IP_TB.Text}:1235/products";
                System.Net.WebRequest req = System.Net.WebRequest.Create(url);
                req.Timeout = 5000;
                req.Method = "DELETE";

                System.IO.Stream stream2 = req.GetRequestStream();

                //json content
                string data_str = @"{""productNumbers"":""{NUM}""}";
                data_str = data_str.Replace("{NUM}", PLU_TB.Text);
                //Write
                var data = Encoding.ASCII.GetBytes(data_str);
                stream2.Write(data, 0, data.Length);
                //Response
                System.Net.WebResponse resp = req.GetResponse();
                System.IO.Stream stream = resp.GetResponseStream();
                System.IO.StreamReader sr = new System.IO.StreamReader(stream);
                OUT_TB.Text = sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                OUT_TB.AppendText("DELETE: " + ex.Message + Environment.NewLine);
            }
            GET_R();
        }

        //get all products
        public void GET_R()
        {
            try
            {
                string url = $"http://{IP_TB.Text}:1235/products";
                System.Net.WebRequest req = System.Net.WebRequest.Create(url);
                req.Timeout = 5000;
                System.Net.WebResponse resp = req.GetResponse();
                System.IO.Stream stream = resp.GetResponseStream();
                System.IO.StreamReader sr = new System.IO.StreamReader(stream);

                string ss = sr.ReadToEnd();

                ss= ss.Replace(@"\","I"); //если попадется символ '\' десериализация будет с ошибкой

                result = JsonConvert.DeserializeObject<List<RootObject>>(ss);

                dataGridView1.DataSource = result;
            }
            catch (Exception ex)
            {
                OUT_TB.AppendText("GET: " + ex.Message + Environment.NewLine);
            }
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            GET_R();
        }               

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rown = e.RowIndex;
                string prod_n = dataGridView1["product_number", rown].Value.ToString();
                PLU_TB.Text = prod_n;
            }
            catch
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            stop_delete_all = false;

            DialogResult dialogResult = MessageBox.Show("Удалить все продукты с весов?", "УДАЛЕНИЕ ВСЕХ ПРОДУКТОВ", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DialogResult dialogResult2 = MessageBox.Show("Последнее подтверждение. Все продукты будут удалены! Продолжить?", "УДАЛЕНИЕ ВСЕХ ПРОДУКТОВ", MessageBoxButtons.YesNo);
                if (dialogResult2 == DialogResult.Yes)
                {
                    string url = $"http://{IP_TB.Text}:1235/products";
                    foreach (RootObject ro in result)
                    {
                        if (stop_delete_all)
                        {
                            OUT_TB.AppendText("STOP DELETE" + Environment.NewLine);
                            return;
                        }

                        OUT_TB.AppendText("DELETE PLU=" + ro.product_number + Environment.NewLine);

                        System.Net.WebRequest req = System.Net.WebRequest.Create(url);
                        req.Method = "DELETE";

                        System.IO.Stream stream2 = req.GetRequestStream();

                        string data_str = @"{""productNumbers"":""{NUM}""}";
                        data_str = data_str.Replace("{NUM}", ro.product_number);

                        var data = Encoding.ASCII.GetBytes(data_str);
                        stream2.Write(data, 0, data.Length);

                        System.Net.WebResponse resp = req.GetResponse();
                        System.IO.Stream stream = resp.GetResponseStream();

                        System.IO.StreamReader sr = new System.IO.StreamReader(stream);
                        OUT_TB.AppendText(sr.ReadToEnd() + Environment.NewLine);

                        Thread.Sleep(50);

                        Application.DoEvents();
                    }

                    OUT_TB.AppendText("ALL PRODUCTS DELETED!" + Environment.NewLine);
                    GET_R();
                }            }
        }      

        bool stop_delete_all = false;
        private void button5_Click_1(object sender, EventArgs e)
        {
            stop_delete_all = true;           
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            RootObject ro=null;
            try
            {
                int rown = e.RowIndex;
                string prod_n = dataGridView1["product_number", rown].Value.ToString();

                foreach (RootObject r in result)
                {
                    if (r.product_number == prod_n)
                    {
                        ro = r;
                    }
                }

                if (ro != null)
                {
                    Form2 f2 = new Form2(ro, IP_TB.Text);
                    f2.ShowDialog();
                    GET_R();
                }
            }
            catch
            {

            }

            
        }
                
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(IP_TB.Text);
            f3.ShowDialog();
            GET_R();
        }
    }

       
}
