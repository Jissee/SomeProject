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
			string ipt = "A";
			string[] codes = new string[62];
			uint[] process = new uint[6];
			int posnow = 1;
			uint tmp = 'A';
            MessageBox.Show(tmp.ToString());

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
			//MessageBox.Show(Convert.ToString(Encoding.ASCII.GetBytes("A")[0]));
			//Encoding.ASCII.GetBytes(src.Substring(posnow, 1)))[0]
			src = " " + ipt;
			for (uint i = 1; i <= 20; i++)
			{
				for (uint j = 1; j <= 4; j++)
				{
					process[j] = process[j + 1];
				}
				process[5] = (uint)(((process[5] + process[5] * posnow + (Encoding.ASCII.GetBytes(src.Substring(posnow, 1))[0]) * i) % 10000000000000) / 2);
                process[5] = (uint)((process[5] + (uint)((ulong)process[5] * (ulong)i) + Encoding.ASCII.GetBytes(src.Substring(posnow, 1))[0] * posnow) % 10000000000000 / 2);
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
				tmp = tmp * 61 / 99;
				sfinal = sfinal + codes[tmp];
			}
			MessageBox.Show(sfinal);



		}

	}
	}



