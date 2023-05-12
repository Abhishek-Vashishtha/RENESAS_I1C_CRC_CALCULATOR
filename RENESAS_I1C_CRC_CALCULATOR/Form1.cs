using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RENESAS_I1C_CRC_CALCULATOR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Tb_crcval.Text = "CRC32:";
            Tb_crcval.SelectionAlignment = HorizontalAlignment.Center;
        }

        string hex_file_path = null;
        public static string[] get_hex_char = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };

        public static readonly UInt16[] fcs_table =
        {
              0x0000, 0x1189, 0x2312, 0x329b, 0x4624, 0x57ad, 0x6536, 0x74bf,
              0x8c48, 0x9dc1, 0xaf5a, 0xbed3, 0xca6c, 0xdbe5, 0xe97e, 0xf8f7,
              0x1081, 0x0108, 0x3393, 0x221a, 0x56a5, 0x472c, 0x75b7, 0x643e,
              0x9cc9, 0x8d40, 0xbfdb, 0xae52, 0xdaed, 0xcb64, 0xf9ff, 0xe876,
              0x2102, 0x308b, 0x0210, 0x1399, 0x6726, 0x76af, 0x4434, 0x55bd,
              0xad4a, 0xbcc3, 0x8e58, 0x9fd1, 0xeb6e, 0xfae7, 0xc87c, 0xd9f5,
              0x3183, 0x200a, 0x1291, 0x0318, 0x77a7, 0x662e, 0x54b5, 0x453c,
              0xbdcb, 0xac42, 0x9ed9, 0x8f50, 0xfbef, 0xea66, 0xd8fd, 0xc974,
              0x4204, 0x538d, 0x6116, 0x709f, 0x0420, 0x15a9, 0x2732, 0x36bb,
              0xce4c, 0xdfc5, 0xed5e, 0xfcd7, 0x8868, 0x99e1, 0xab7a, 0xbaf3,
              0x5285, 0x430c, 0x7197, 0x601e, 0x14a1, 0x0528, 0x37b3, 0x263a,
              0xdecd, 0xcf44, 0xfddf, 0xec56, 0x98e9, 0x8960, 0xbbfb, 0xaa72,
              0x6306, 0x728f, 0x4014, 0x519d, 0x2522, 0x34ab, 0x0630, 0x17b9,
              0xef4e, 0xfec7, 0xcc5c, 0xddd5, 0xa96a, 0xb8e3, 0x8a78, 0x9bf1,
              0x7387, 0x620e, 0x5095, 0x411c, 0x35a3, 0x242a, 0x16b1, 0x0738,
              0xffcf, 0xee46, 0xdcdd, 0xcd54, 0xb9eb, 0xa862, 0x9af9, 0x8b70,
              0x8408, 0x9581, 0xa71a, 0xb693, 0xc22c, 0xd3a5, 0xe13e, 0xf0b7,
              0x0840, 0x19c9, 0x2b52, 0x3adb, 0x4e64, 0x5fed, 0x6d76, 0x7cff,
              0x9489, 0x8500, 0xb79b, 0xa612, 0xd2ad, 0xc324, 0xf1bf, 0xe036,
              0x18c1, 0x0948, 0x3bd3, 0x2a5a, 0x5ee5, 0x4f6c, 0x7df7, 0x6c7e,
              0xa50a, 0xb483, 0x8618, 0x9791, 0xe32e, 0xf2a7, 0xc03c, 0xd1b5,
              0x2942, 0x38cb, 0x0a50, 0x1bd9, 0x6f66, 0x7eef, 0x4c74, 0x5dfd,
              0xb58b, 0xa402, 0x9699, 0x8710, 0xf3af, 0xe226, 0xd0bd, 0xc134,
              0x39c3, 0x284a, 0x1ad1, 0x0b58, 0x7fe7, 0x6e6e, 0x5cf5, 0x4d7c,
              0xc60c, 0xd785, 0xe51e, 0xf497, 0x8028, 0x91a1, 0xa33a, 0xb2b3,
              0x4a44, 0x5bcd, 0x6956, 0x78df, 0x0c60, 0x1de9, 0x2f72, 0x3efb,
              0xd68d, 0xc704, 0xf59f, 0xe416, 0x90a9, 0x8120, 0xb3bb, 0xa232,
              0x5ac5, 0x4b4c, 0x79d7, 0x685e, 0x1ce1, 0x0d68, 0x3ff3, 0x2e7a,
              0xe70e, 0xf687, 0xc41c, 0xd595, 0xa12a, 0xb0a3, 0x8238, 0x93b1,
              0x6b46, 0x7acf, 0x4854, 0x59dd, 0x2d62, 0x3ceb, 0x0e70, 0x1ff9,
              0xf78f, 0xe606, 0xd49d, 0xc514, 0xb1ab, 0xa022, 0x92b9, 0x8330,
              0x7bc7, 0x6a4e, 0x58d5, 0x495c, 0x3de3, 0x2c6a, 0x1ef1, 0x0f78
        };
        private void Btn_about_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This software is used to calculate CRC for renesas I1C 256kb design.\nPlease share your feedback @abhishek.vashishtha@genus.in", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Btn_brwse_Hex_Click(object sender, EventArgs e)
        {
            OpenFileDialog hexfilepath = new OpenFileDialog();
            hexfilepath.Title = "Browse the hex file";
            hexfilepath.Filter = "hex files (*.hex)|*.hex|All files (*.*)|*.*";
            hexfilepath.ShowDialog();

            Btn_brwse_Hex.Text = hexfilepath.SafeFileName;

            hex_file_path = hexfilepath.FileName;

            try
            {
                FileStream file_hex = new FileStream(hexfilepath.FileName, FileMode.Open, FileAccess.Read);
                Lb_hexfilesize.Text = file_hex.Length.ToString()+ " BYTES";

                if(file_hex.Length != 737365)
                {
                    MessageBox.Show("Invalid size of file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Btn_brwse_Hex.Text = "BROWSE HEX FILE";
                    Lb_hexfilesize.Text = "FILE SIZE";
                }
                file_hex.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Btn_brwse_Hex.Text = "BROWSE HEX FILE";
            }
        }

        private void Btn_cal_crc_Click(object sender, EventArgs e)
        {
            if(Btn_brwse_Hex.Text == "BROWSE HEX FILE")
            {
                MessageBox.Show("Please select hex file", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FileStream temp_hex_file;

                byte[] hex_temp_arr = new byte[1000];

                byte[] temp_arr = new byte[256];

                byte[] temp_b_arr = new byte[16];
                temp_hex_file = new FileStream(hex_file_path, FileMode.Open, FileAccess.Read);

                UInt32 crc= 0;

                for(UInt16 i =0;i<256;i++)
                {
                    temp_hex_file.Read(hex_temp_arr, 0, 720);

                    for(UInt16 j = 0;j<16;j++)
                    {
                        temp_b_arr =  ascii_byte_array_to_hex_byte_array(hex_temp_arr, 32, (UInt16)(9+(45*j)));
                        for(UInt16 k = 0;k<16;k++)
                        {
                            temp_arr[(j * 16) + k] = temp_b_arr[k];
                        }
                    }
                    if(i == 128)
                    {
                        i++;
                        i--;
                    }
                    crc += FCS(temp_arr, 256);
                }
                temp_hex_file.Read(hex_temp_arr, 0, 17);
                for (UInt16 i = 0; i < 256; i++)
                {
                    temp_hex_file.Read(hex_temp_arr, 0, 720);

                    for (UInt16 j = 0; j < 16; j++)
                    {
                        temp_b_arr = ascii_byte_array_to_hex_byte_array(hex_temp_arr, 32, (UInt16)(9 + (45 * j)));
                        for (UInt16 k = 0; k < 16; k++)
                        {
                            temp_arr[(j * 16) + k] = temp_b_arr[k];
                        }
                    }
                    crc += FCS(temp_arr, 256);
                }
                temp_hex_file.Read(hex_temp_arr, 0, 17);
                for (UInt16 i = 0; i < 256; i++)
                {
                    temp_hex_file.Read(hex_temp_arr, 0, 720);

                    for (UInt16 j = 0; j < 16; j++)
                    {
                        temp_b_arr = ascii_byte_array_to_hex_byte_array(hex_temp_arr, 32, (UInt16)(9 + (45 * j)));
                        for (UInt16 k = 0; k < 16; k++)
                        {
                            temp_arr[(j * 16) + k] = temp_b_arr[k];
                        }
                    }
                    crc += FCS(temp_arr, 256);
                }
                temp_hex_file.Read(hex_temp_arr, 0, 17);
                for (UInt16 i = 0; i < 254; i++)
                {
                    temp_hex_file.Read(hex_temp_arr, 0, 720);

                    for (UInt16 j = 0; j < 16; j++)
                    {
                        temp_b_arr = ascii_byte_array_to_hex_byte_array(hex_temp_arr, 32, (UInt16)(9 + (45 * j)));
                        for (UInt16 k = 0; k < 16; k++)
                        {
                            temp_arr[(j * 16) + k] = temp_b_arr[k];
                        }
                    }
                    crc += FCS(temp_arr, 256);
                }

                crc = ~crc+1;
                Tb_crcval.Text = "CRC32:";
                Tb_crcval.Text += Number_to_hex_string(crc);
                Tb_crcval.SelectionAlignment = HorizontalAlignment.Center;
            }
        }

        public static string Number_to_hex_string(UInt32 Num)
        {
            string str = null;
            for(UInt16 i = 0; i < 8; i++)
            {
                str += get_hex_char[(Num & 0xF0000000)>>28];
                Num <<= 4;
            }
            return str;
        }
        public static UInt16 FCS(byte[] data,UInt16 len)
        {
            UInt16 t_crc = 0,t_val = 0;
            t_crc = FCS_CAL(data, len,0xFFFF);
            t_crc ^= 0xFFFF;

            t_val = (UInt16)(t_crc << 8);
            t_val |= (UInt16)(t_crc >> 8);

            t_crc = t_val;
            return t_crc;
        }

        public static UInt16 FCS_CAL(byte[] d,UInt16 len,UInt16 fix_val)
        {
            UInt16 t_res = fix_val;
            for (UInt16 i = 0; i < len; i++)
            {
                t_res = (UInt16)((t_res >> 8) ^ fcs_table[(t_res ^ d[i]) & 0xFF]);
            }
            return (t_res);
        }
        public static byte[] ascii_byte_array_to_hex_byte_array(byte[] ascii_b_array,UInt16 size,UInt16 start_ptr)
        {
            byte[] hex_byte_array = new byte[size/2];

            for(int i = 0;i<size;i+=2)
            {

                UInt16 temp_byte = 0;

                if (ascii_b_array[start_ptr + i] >= 0x30 && ascii_b_array[start_ptr + i] <=0x39)
                {
                    temp_byte = (UInt16)((ascii_b_array[start_ptr + i]-0x30)<<4);
                }
                else if (ascii_b_array[start_ptr + i] >= 0x41 && ascii_b_array[start_ptr + i] <= 0x46)
                {
                    temp_byte = (UInt16)((ascii_b_array[start_ptr + i] - 0x37)<<4);
                }
                if (ascii_b_array[start_ptr + i+1] >= 0x30 && ascii_b_array[start_ptr + i+1] <= 0x39)
                {
                    temp_byte |= (UInt16)(ascii_b_array[start_ptr + i + 1] - 0x30);
                }
                else if (ascii_b_array[start_ptr + i + 1] >= 0x41 && ascii_b_array[start_ptr + i + 1] <= 0x46)
                {
                    temp_byte |= (UInt16)(ascii_b_array[start_ptr + i + 1] - 0x37);
                }
                hex_byte_array[i/2] = (byte)temp_byte;
            }
            return hex_byte_array;
        }
      
        private void Tb_crcval_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
