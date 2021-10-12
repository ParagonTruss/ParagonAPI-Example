using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParagonApi;
using ParagonApi.Models;


namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private static Truss MyTruss = null;

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
             await GetTruss();
             label1.Text = MyTruss.Name;
        }


        public static async Task GetTruss()
        {
            using var connection = await Paragon.Connect(new ParagonApiConfiguration
            {
                Environment = ParagonApi.Environments.Environment.Production
            });

            var trussGuid = Guid.Parse("63662fce-48f7-45b0-870f-2b31ca33b3c2");
            MyTruss = await connection.Trusses.Find(trussGuid);
        }
    }
}