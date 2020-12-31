using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestCC
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string ipt = "a";
			string[] codes = new string[62];
			ulong[] process = new ulong[6];
			int posnow = 1, codeasc = 0;
			uint tmp = 'A';
			string src="1", str="", sfinal = "";
			for (uint i = 0; i <= 25; i++)
			{
				codes[i] += Convert.ToChar(i + 65);
				codes[i + 26] += Convert.ToChar(i + 97);
			}
			for (uint i = 0; i <= 9; i++)
			{
				codes[i + 52] += i;
			}
			src = " " + ipt;
			for (uint i = 1; i <= 20; i++)
			{
				for (uint j = 1; j <= 4; j++)
				{
					process[j] = process[j + 1];
				}
				codeasc = Asc(src.Substring(posnow, 1));
				process[5] = (ulong)(((process[5] + process[5] * (ulong)posnow + (ulong)(codeasc * i)) % 1000000000000) / 2);
                process[5] = (ulong)(((ulong)process[5] + (ulong)process[5] * (ulong)i + (ulong)codeasc * (ulong)posnow) % 1000000000000 / 2);
				posnow = posnow % (src.Length - 1) + 1;
			}
			for(uint i = 1; i <= 5; i++)
            {
				str = process[i].ToString() + str;
            }
			str = " "+str;
			for(int i = 5; i <= 44; i += 2)
            {
				tmp = uint.Parse(str.Substring(i, 2));
				tmp = (uint)(int)((double)tmp / 99.0 * 61.0 + 0.5);
				sfinal = sfinal + codes[tmp];
			}
			MessageBox.Show(sfinal);



		}
		/// <summary>
		/// 123
		/// </summary>
		/// 
		/// <returns></returns>
		/// <param name="a">121</param>
		private int asd(int a,int b)
        {
			int c = a + b;
			return 0;
        }
		public int Asc(string inp)
        {
			int ret;
			ret = Encoding.ASCII.GetBytes(inp)[0];
			return ret;
		}
	}
	}



