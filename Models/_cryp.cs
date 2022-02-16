namespace APIMuhasibat.Models
{
    public class _cryp
    {
        public static bool b = false;
        public static bool Cry(string str)
        {
            #region kod
            //string[] buf;
            //string ar = "";
            //buf = new string[1250];
            //for (int i = 65; i < 1250; i++)
            //{

            //    buf[i] = Char.ConvertFromUtf32(i);
            //    ar += " { " + i + "," + buf[i] + " } ";
            //}
            //char z;
            //for (z = 'A'; z <= 'ə'; ++z)
            //{
            //    //k = char(z);
            //    TextBox1.Text.IndexOf(z);

            //} 
            #endregion
            #region tap nede yazilib
            string tap = "", tap1 = "";
            char[] chr = str.ToCharArray();
            int i = 0, j = 0;
            int[] lat = new int[]
          { 97,98,99,100, 101,102,103,104, 105,106,107,108, 109,110,111,112, 113,114,115,116,
            117,118,119,120, 121,122,65,66, 67,68,69,70, 71,72,73,74, 75,76,77,78, 79,80,81,82,
            83,84,85,86, 87,88,89,90, 305,199,231,214, 246,220,252,286, 287,350,351,399, 601,

            1040, 1041,1042, 1043,1044, 1045,1046,1047,1048,1049,1050,1051,1052,
            1053,1054,1055,1056,1057,1058,1059,1060,1061,1062,1063, 1064,1065,
            1066,1067,1068,1069,1070,1071,1025,1072,1073,1074,1075,1076,1077,
            1078,1079,1080,1081,1082,1083,1084,1085,1086,1087,1088,1089,1090,
            1091,1092,1093,1094,1095, 1096,1097,1098,1099,1100,1101,1102,1103,
            1105 };
            for (i = 0; i < str.Length; i++)
            {
                for (j = 0; j < lat.Length; j++)
                {
                    if (chr[i] == lat[j])
                    {
                        if (chr[i] <= 601)
                        {
                            if (tap1 == "")
                            {
                                tap += str[i].ToString();
                                b = true;
                            }
                            else
                            {
                                b = false;
                            }
                        }
                        else if (chr[i] >= 1040)
                        {
                            if (tap == "")
                            {
                                tap1 += str[i].ToString();
                                b = true;
                            }
                            else
                            {
                                b = false;
                            }
                        }
                    }
                }


            }
            return b;
            #endregion
        }

    }
}
