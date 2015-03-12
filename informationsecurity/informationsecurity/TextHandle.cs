using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace informationsafety
{
    static class TextHandle
    {
        //字节转换成二进制
        public static int[] byteToBit(byte ch)
        {
            int[] bit = new int[8];
            for (int i = 0; i < 8; i++)
            {
                bit[i] = (ch >> i) & 1;
            }
            return bit;
        }

        //二进制转换成字节
        public static byte bitToByte(int[] bit)
        {
            byte ch;
            int temp = 0;
            for (int i = 0; i < 8; i++)
            {
                temp |= bit[i] << i;
            }
            return ch = byte.Parse(temp.ToString());
        }

        //将长度为8的字节数组转为二进制位串
        public static int[] byte8ToBit64(byte[] ch)
        {
            int[] bit = new int[0];
            for (int i = 0; i < 8; i++)
            {
                bit = intArrayConect(bit, byteToBit(ch[i]));
            }
            return bit;
        }

        //将二进制位串转为长度为8的字节数组
        public static byte[] bit64ToByte8(int[] bit)
        {
            byte[] ch = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                ch[i] = bitToByte(bit.Skip(8 * i).Take(8).ToArray());

            }
            return ch;
        }

        //合并两个int数组
        static int[] intArrayConect(int[] array1, int[] array2)
        {
            int newlength = array1.Length + array2.Length;
            int[] conarr = new int[newlength];
            for (int i = 0; i < newlength; i++)
            {
                if (i < array1.Length)
                {
                    conarr[i] = array1[i];
                }
                else
                {
                    conarr[i] = array2[i - array1.Length];
                }
            }
            return conarr;
        }

        //字节数组转化为字符串
        public static string byteArray2String(byte[] by)
        {
            return System.Text.Encoding.ASCII.GetString(by);
        }

        //字符串转化为字节数组
        public static byte[] string2ByteArray(string str)
        {
            return System.Text.Encoding.ASCII.GetBytes(str);
        }

        //字符串转化为int数组
        public static int[][] string2IntArray(string str)
        {
            if (str == "" || str == null)
                return new int[0][];
            int r = 0, l = 0;
            byte[] stringByte = string2ByteArray(str);
            byte[][] stringByte8 = new byte[(stringByte.Length - 1) / 8 + 1][];
            int[][] stringInt = new int[(stringByte.Length - 1) / 8 + 1][];
            for (int i = 0; i < stringByte.Length; i++)
            {
                if (stringByte8[r] == null)
                {
                    stringByte8[r] = new byte[8];
                }
                stringByte8[r][l] = stringByte[i];
                l++;
                if (l == 8)
                {
                    l = 0;
                    stringInt[r] = byte8ToBit64(stringByte8[r]);
                    r++;
                }
            }
            if (l != 0)
            {
                stringInt[r] = byte8ToBit64(stringByte8[r]);
            }
            return stringInt;
        }

        //int数组转化为字符串
        public static string intArray2String(int[][] intArray)
        {
            string str = "";
            byte[] bytearray = new byte[0];
            for (int i = 0; i < intArray.Length; i++)
            {
                intArray2String(intArray[i]);
            }
            //str =  byteArray2String(bytearray);
            return str;
        }


        //int数组转化为字符串
        public static string intArray2String(int[] intArray)
        {
            string str = "";
            byte[] bytearray = new byte[0];
            bytearray = bit64ToByte8(intArray);
            str = str + byteArray2String(bytearray);

            //str =  byteArray2String(bytearray);
            return str;
        }

        //连接byte数组
        public static byte[] byteArrayConnect(byte[] byte1, byte[] byte2)
        {
            byte[] byteall = new byte[byte1.Length + byte2.Length];
            for (int i = 0; i < byteall.Length; i++)
            {
                if (i < byte1.Length)
                {
                    byteall[i] = byte1[i];
                }
                else
                {
                    byteall[i] = byte2[i - byte1.Length];
                }
            }
            return byteall;
        }

        //连接int数组
        public static int[] intArrayConnect(int[] int1, int[] int2)
        {
            int[] intall = new int[int1.Length + int2.Length];
            for (int i = 0; i < intall.Length; i++)
            {
                if (i < int1.Length)
                {
                    intall[i] = int1[i];
                }
                else
                {
                    intall[i] = int2[i - int1.Length];
                }
            }
            return intall;
        }


        // 从int数组中截取一部分成新的数组
        public static int[] SplitArray(int[] Source, int StartIndex, int EndIndex)
        {
            int[] result = new int[EndIndex - StartIndex + 1];
            for (int i = 0; i <= EndIndex - StartIndex; i++)
            {
                result[i] = Source[i + StartIndex];
            }
            return result;

        }



        //十六进制化为2进制
        public static int[] hexToBin(string hex)
        {
            int[] bin = new int[0];
            int[] one = new int[1];
            string binstr = Convert.ToString(Convert.ToInt64(hex, 16), 2);
            for (int i = 0; i < binstr.Length; i++)
            {
                if (binstr[i] == '1')
                    one[0] = 1;
                if (binstr[i] == '0')
                    one[0] = 0;
                bin = intArrayConnect(bin, one);
            }
            return bin;
        }

        //二进制化为十六进制
        public static string binToHex(int[] bin)
        {
            string binstr = "";
            for (int i = 0; i < bin.Length; i++)
                binstr += bin[i].ToString();
            return Convert.ToString(Convert.ToInt64(binstr, 2), 16);
        }
        //Convert.ToInt32("111101", 2)


        //bcd码化为2进制
        public static int[] bcdToBin(char x)
        {
            int[] i;
            switch (x)
            {
                case '0':
                    i = new int[] { 0, 0, 0, 0 };
                    return i;
                case '1':
                    i = new int[] { 0, 0, 0, 1 };
                    return i;
                case '2':
                    i = new int[] { 0, 0, 1, 0 };
                    return i;
                case '3':
                    i = new int[] { 0, 0, 1, 1 };
                    return i;
                case '4':
                    i = new int[] { 0, 1, 0, 0 };
                    return i;
                case '5':
                    i = new int[] { 0, 1, 0, 1 };
                    return i;
                case '6':
                    i = new int[] { 0, 1, 1, 0 };
                    return i;
                case '7':
                    i = new int[] { 0, 1, 1, 1 };
                    return i;
                case '8':
                    i = new int[] { 1, 0, 0, 0 };
                    return i;
                case '9':
                    i = new int[] { 1, 0, 0, 1 };
                    return i;
                case 'a':
                    i = new int[] { 1, 0, 1, 0 };
                    return i;
                case 'b':
                    i = new int[] { 1, 0, 1, 1 };
                    return i;
                case 'c':
                    i = new int[] { 1, 1, 0, 0 };
                    return i;
                case 'd':
                    i = new int[] { 1, 1, 0, 1 };
                    return i;
                case 'e':
                    i = new int[] { 1, 1, 1, 0 };
                    return i;
                case 'f':
                    i = new int[] { 1, 1, 1, 1 };
                    return i;
                case 'A':
                    i = new int[] { 1, 0, 1, 0 };
                    return i;
                case 'B':
                    i = new int[] { 1, 0, 1, 1 };
                    return i;
                case 'C':
                    i = new int[] { 1, 1, 0, 0 };
                    return i;
                case 'D':
                    i = new int[] { 1, 1, 0, 1 };
                    return i;
                case 'E':
                    i = new int[] { 1, 1, 1, 0 };
                    return i;
                case 'F':
                    i = new int[] { 1, 1, 1, 1 };
                    return i;

                default:
                    i = new int[] { -1 };
                    return i;
            }
        }

        //判断是否为bcd
        public static bool isBcd(string str)
        {
            int[] fail = new int[] { -1 };
            for (int i = 0; i < str.Length; i++)
            {
                if (bcdToBin(str[i]).GetValue(0).Equals(fail.GetValue(0)))
                {
                    return false;
                }
            }
            return true;
        }

        //获得2进制64位密钥
        public static int[] get64BinKey(string key)
        {/*
            int[] bin = new int[0];
            for (int i = 0; i < 16; i++)
            {
                bin = intArrayConect(bin, bcdToBin(key[i]));
            }*/
            return string2IntArray(key)[0];
        }

        //获得2进制128位密钥
        public static int[] get128BinKey(string key)
        {
            return TextHandle.intArrayConnect(string2IntArray(key)[0], string2IntArray(key)[1]);
        }

        //插入二维int数组
        public static void insertIntoArray(int insert_row, int line_length, int[][] array1, int[] insert_array)
        {
            if (array1[insert_row] == null)
            {
                array1[insert_row] = new int[line_length];
            }
            for (int i = 0; i < line_length; i++)
            {
                array1[insert_row][i] = insert_array[i];
            }
        }

        //二进制int数组转十进制
        public static int binToDex(int[] bin)
        {
            string dec = "";
            for (int i = 0; i < bin.Length; i++)
            {
                dec = dec + Convert.ToString(bin.GetValue(i));
            }
            return Convert.ToInt32(dec, 2);
        }


        //十进制数转二进制int数组
        public static int[] dexToBin(int dec, int arrayLength)
        {
            string intstr = Convert.ToString(dec, 2);
            int[] bin = new int[arrayLength];
            for (int i = 0; i < intstr.Length; i++)
            {
                bin[arrayLength - i - 1] = int.Parse(Convert.ToString(intstr[intstr.Length - i - 1]));
            }
            return bin;
        }

        //去掉字符串中重复的字符
        public static string distinctString(string str)
        {
            string newstr = str[0].ToString();
            for (int i = 0; i < str.Length; i++)
            {
                for (int k = 0; k < newstr.Length; k++)
                {
                    if (str[i] == newstr[k])
                        break;
                    if (k == newstr.Length - 1)
                    {
                        newstr += str[i];
                        break;
                    }
                }
            }
            return newstr;
        }

        //在相邻相同字母间插入x
        public static string insertXBetweenTheSame(string str)
        {
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i - 1] == str[i])
                {
                    if (str[i] != 'x')
                    {
                        str = str.Insert(i, "x");
                    }
                    else
                    {
                        str = str.Insert(i, "z");
                    }
                    i++;
                }
            }
            return str;
        }


        //恢复相邻相同字母
        public static string insertback(string str)
        {
            for (int i = 2; i < str.Length; i++)
            {
                if ((str[i - 1] == 'x' || str[i - 1] == 'z') && (str[i - 2] == str[i]))
                {
                    str = str.Substring(0, i - 2) + str.Substring(i);
                }
            }
            return str;
        }
    }
}
