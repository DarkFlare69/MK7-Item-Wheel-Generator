using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Item_Wheel_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool NTR = radioButton1.Checked;
            bool Gateway = radioButton2.Checked;
            bool A_Button = checkBox1.Checked;
            bool B_Button = checkBox2.Checked;
            bool X_Button = checkBox3.Checked;
            bool Y_Button = checkBox4.Checked;
            bool L_Button = checkBox5.Checked;
            bool R_Button = checkBox6.Checked;
            bool Select_Button = checkBox7.Checked;
            bool Start_Button = checkBox8.Checked;
            bool Up_Button = checkBox9.Checked;
            bool Down_Button = checkBox10.Checked;
            bool Left_Button = checkBox11.Checked;
            bool Right_Button = checkBox12.Checked;

            int button = 0;

            if (A_Button == true)
            {
                button += 1;
            }
            if (B_Button == true)
            {
                button += 2;
            }
            if (X_Button == true)
            {
                button += 0x400;
            }
            if (Y_Button == true)
            {
                button += 0x800;
            }
            if (L_Button == true)
            {
                button += 0x200;
            }
            if (R_Button == true)
            {
                button += 0x100;
            }
            if (Select_Button == true)
            {
                button += 4;
            }
            if (Start_Button == true)
            {
                button += 8;
            }
            if (Up_Button == true)
            {
                button += 0x40;
            }
            if (Down_Button == true)
            {
                button += 0x80;
            }
            if (Left_Button == true)
            {
                button += 20;
            }
            if (Right_Button == true)
            {
                button += 0x10;
            }

            int comboIndex = comboBox1.SelectedIndex;
            String ItemID = comboIndex.ToString("X");
            if (comboIndex != -1)
            {
                if (NTR)
                {
                    if (textBox1.Text.Contains("D3000000"))
                    {
                        textBox1.Text = "";
                    }
                    textBox1.Text += "\t\tif (is_pressed(0x" + button.ToString("X") + "))" + System.Environment.NewLine +
                    "\t\t\twriteItem(0x" + ItemID + ");" + System.Environment.NewLine;
                }
                if (Gateway)
                {
                    if (textBox1.Text.Contains("if"))
                    {
                        textBox1.Text = "";
                    }
                    textBox1.Text += "DD000000 00000" + button.ToString("X").PadLeft(3, '0') + System.Environment.NewLine +
                    "D3000000 14000074" + System.Environment.NewLine +
                    "B0000000 00000000" + System.Environment.NewLine +
                    "DC000000 FFFFE4A4" + System.Environment.NewLine +
                    "40000000 14000000" + System.Environment.NewLine +
                    "30000000 18000000" + System.Environment.NewLine +
                    "B0000000 00000000" + System.Environment.NewLine +
                    "B00027AC 00000000" + System.Environment.NewLine +
                    "0000003C FFFFFFFF" + System.Environment.NewLine +
                    "000000A8 00000203" + System.Environment.NewLine +
                    "000000C8 00000" + ItemID.PadLeft(3, '0') + System.Environment.NewLine +
                    "000000D8 3F800000" + System.Environment.NewLine +
                    "D2000000 00000000" + System.Environment.NewLine;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
            MessageBox.Show("Copied to Clipboard!");
        }
    }
}
