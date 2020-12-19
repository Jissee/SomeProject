using System;
using System.IO;

namespace myHashCC
{
    public class myHashCC
    {

        string My_HashCC(string ipt)
        {
            string[] codes = new string[61];
            int[] process = new int[5];
            int posnow = 1;
            int tmp = 0;
            string src, str, sfinal = "";
            for (int i = 0; i <= 25; i++)
            {
                codes[i] += Convert.ToChar(i + 65);
                codes[i + 26] += Convert.ToChar(i + 97);
            }
            for (int i = 0; i <= 9; i++)
            {
                codes[i + 52] += Convert.ToChar(i);
            }
            src = ipt;
            for (int i = 1; i <= 20; i++)
            {
                for (int j = 0; j <= 4; j++)
                {
                    process[j] = process[j + 1];

                }
                process[5] = (int)((process[5] + process[5] * posnow + Convert.ToInt32(src.Substring(posnow, 1)) * i) % 1000000000000 / 2);
                process[5] = (int)((process[5] + process[5] * i + Convert.ToInt32(src.Substring(posnow, 1)) * posnow) % 1000000000000 / 2);
            }





            return "";
        }
    }
}
    



