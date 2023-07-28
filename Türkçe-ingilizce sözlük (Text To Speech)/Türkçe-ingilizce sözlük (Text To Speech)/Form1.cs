using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace Sözlük
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        WebBrowser webBrowser1 = new WebBrowser();
        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                webBrowser1.Navigate("https://translate.google.com/?hl=tr&sl=tr&tl=en&op=translate");
                webBrowser1.ScriptErrorsSuppressed = true;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            webBrowser1.Document.GetElementById("tta_input_ta").InnerText = textBox1.Text;
            timer1.Start();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (label1.Text == "Türkçe")
                {
                    label1.Text = "İngilizce";
                    label2.Text = "Türkçe";
                }
                else if (label1.Text == "İngilizce")
                {
                    label1.Text = "Türkçe";
                    label2.Text = "İngilizce";
                }
                webBrowser1.Document.GetElementById("tta_revIcon").InvokeMember("click");
                textBox2.Clear();
                textBox1.Clear();
                
            }
            catch
            { }
        }

        int say = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (say == 3) timer1.Stop();
                textBox2.Text = webBrowser1.Document.GetElementById("tta_output_ta").InnerText;
                textBox1.Focus();
                say++;
                
            }
            catch
            { }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                webBrowser1.Document.GetElementById("tta_playiconsrc").InvokeMember("click");
                
            }
            catch
            { }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                webBrowser1.Document.GetElementById("tta_playicontgt").InvokeMember("click");
                
            }
            catch
            { }
        }
    }
}