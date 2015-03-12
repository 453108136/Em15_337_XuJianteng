using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace informationsafety
{
    static class DesFunctions
    {
        //生成子密钥
        static int[][] makeSubKeys(int[] key)
        {
            int[] key56 = new int[56];
            int[][] subkey = new int[16][];/*
            for (int i = 0, k = 0; i < key.Length; i++)
            {
                if ((i + 1) % 8 != 0)
                {
                    key56[k] = key[i];
                    k++;
                }
            }*/
            key56 = pc1Transform(key);//PC1置换
            for (int i = 0; i < 16; i++)
            {
                //16轮跌代，产生16个子密钥
                rol(key56, Const_table.MOVE_TIMES[i]);//循环左移
                TextHandle.insertIntoArray(i, 48, subkey, pc2Transform(key56));//PC2置换，产生子密钥
            }
            return subkey;
        }

        //生成3des子密钥
        static int[][][] make3DesSubKeys(int[] key)
        {
            int[][][] subkey = new int[2][][];
            subkey[0] = makeSubKeys(TextHandle.SplitArray(key, 0, 63));
            subkey[1] = makeSubKeys(TextHandle.SplitArray(key, 64, 127));
            return subkey;
        }

        //密钥置换1
        static int[] pc1Transform(int[] key)
        {
            int[] pc1 = new int[56];
            for (int i = 0; i < 56; i++)
            {
                pc1[i] = key[Const_table.PC_1[i]];
            }
            return pc1;
        }

        //密钥置换2
        static int[] pc2Transform(int[] key)
        {
            int[] key48 = new int[48];
            for (int i = 0; i < 48; i++)
            {
                key48[i] = key[Const_table.PC_2[i]];
            }
            return key48;
        }

        //循环左移
        static void rol(int[] pc1, int time)
        {
            int a, b;
            a = pc1[time];
            b = pc1[time + 28];
            for (int i = 0; i < 27; i++)
            {
                if (i + 2 * time < 28)
                {
                    pc1[i + time] = pc1[i + 2 * time];
                    pc1[i + time + 28] = pc1[i + 2 * time + 28];
                }
                else
                {
                    if (i + time < 28)
                    {
                        pc1[i + time] = pc1[i + 2 * time - 28];
                        pc1[i + time + 28] = pc1[i + 2 * time];
                    }
                    else
                    {
                        pc1[i + time - 28] = pc1[i + 2 * time - 28];
                        pc1[i + time] = pc1[i + 2 * time];
                    }
                }
            }
            pc1[time - 1] = a;
            pc1[time + 27] = b;

        }

        //IP置换
        static int[] DES_IP_Transform(int[] data)
        {
            int[] temp = new int[64];
            for (int i = 0; i < 64; i++)
            {
                temp[i] = data[Const_table.IP_Table[i]];
            }
            return temp;
        }

        //IP逆置换
        static int[] DES_IP_1_Transform(int[] data)
        {
            int[] temp = new int[64];
            for (int i = 0; i < 64; i++)
            {
                temp[i] = data[Const_table.IP_1_Table[i]];
            }
            return temp;
        }


        //扩展置换
        static int[] DES_E_Transform(int[] data)
        {
            int[] temp = new int[48];
            for (int i = 0; i < 48; i++)
            {
                temp[i] = data[Const_table.E_Table[i]];
            }
            return temp;
        }


        //异或
        static int[] DES_Xor(int[] left, int[] right)
        {
            int[] result = new int[left.Length];
            for (int i = 0; i < left.Length; i++)
            {
                result[i] = right[i] ^ left[i];
            }
            return result;
        }


        //S盒置换
        static int[] DES_SBOX(int[] data)
        {
            int line, row;
            int[] linenum = new int[4], rownum = new int[2];
            int[] temp = new int[4];
            int[] data32 = new int[0];
            for (int g = 0; g < 8; g++)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (i == 0 || i == 5)
                    {
                        if (i == 0)
                        {
                            rownum[0] = data[6 * g + i];
                        }
                        else
                        {
                            rownum[1] = data[6 * g + i];
                        }
                    }
                    else
                    {
                        linenum[i - 1] = data[6 * g + i];
                    }
                    row = TextHandle.binToDex(rownum);
                    line = TextHandle.binToDex(linenum);
                    temp = TextHandle.dexToBin(Const_table.S[i, row, line], 4);
                }
                data32 = TextHandle.intArrayConnect(data32, temp);
            }
            return data32;
        }

        //P置换
        static int[] DES_P_Transform(int[] data)
        {
            int[] temp = new int[32];
            for (int i = 0; i < 32; i++)
            {
                temp[i] = data[Const_table.P_Table[i]];
            } return temp;
        }


        //加密单个分组
        static int[] DES_Encrypt_One_Group(int[] textint, int[][] subKeys)
        {
            int[] copytext = textint;
            int[] intAfterEncode = new int[0];
            int[] left;
            int[] copyright;
            int[] right;

            //初始置换（IP置换）
            copytext = DES_IP_Transform(textint);

            //16轮迭代
            for (int i = 0; i < 16; i++)
            {
                left = TextHandle.SplitArray(copytext, 0, 31);
                right = TextHandle.SplitArray(copytext, 32, 63);
                copyright = right;
                //将右半部分进行扩展置换，从32位扩展到48位
                right = DES_E_Transform(right);
                //将右半部分与子密钥进行异或操作
                right = DES_Xor(right, subKeys[i]);
                //异或结果进入S盒，输出32位结果
                right = DES_SBOX(right);
                //P置换
                right = DES_P_Transform(right);
                //将明文左半部分与右半部分进行异或
                right = DES_Xor(left, right);
                copytext = TextHandle.intArrayConnect(copyright, right);
                if (i == 15)
                {

                    intAfterEncode = TextHandle.intArrayConnect(right, copyright);
                }

            }
            //逆初始置换（IP^1置换）
            intAfterEncode = DES_IP_1_Transform(intAfterEncode);
            return intAfterEncode;
        }

        //解密单个分组
        static int[] DES_Decrypt_One_Group(int[] desTextint, int[][] subKeys)
        {
            int[] copytext = desTextint;
            int[] intAfterDecode = new int[0];
            int[] left;
            int[] copyright;
            int[] right;

            //初始置换（IP置换）
            copytext = DES_IP_Transform(desTextint);

            //16轮迭代
            for (int i = 15; i >= 0; i--)
            {
                left = TextHandle.SplitArray(copytext, 0, 31);
                right = TextHandle.SplitArray(copytext, 32, 63);
                copyright = right;
                //将右半部分进行扩展置换，从32位扩展到48位
                right = DES_E_Transform(right);
                //将右半部分与子密钥进行异或操作
                right = DES_Xor(right, subKeys[i]);
                //异或结果进入S盒，输出32位结果
                right = DES_SBOX(right);
                //P置换
                right = DES_P_Transform(right);
                //将明文左半部分与右半部分进行异或
                right = DES_Xor(left, right);
                copytext = TextHandle.intArrayConnect(copyright, right);
                if (i == 0)
                {
                    intAfterDecode = TextHandle.intArrayConnect(right, copyright);
                }
            }
            //逆初始置换（IP^1置换）
            intAfterDecode = DES_IP_1_Transform(intAfterDecode);
            return intAfterDecode;
        }

        //加密
        public static string DES_Encrypt(string text, string key)
        {
            int[][] textbit = TextHandle.string2IntArray(text);
            int[][] afterencode = new int[textbit.Length][];
            int[][] subkeys = makeSubKeys(TextHandle.get64BinKey(key));
            string encodestr = "";
            for (int i = 0; i < textbit.Length; i++)
            {
                afterencode[i] = new int[0];
                afterencode[i] = TextHandle.intArrayConnect(afterencode[i], DES_Encrypt_One_Group(textbit[i], subkeys));
                encodestr += TextHandle.binToHex(afterencode[i]);
            }
            return encodestr;
        }


        //加密
        public static string thribleDES_Encrypt(string text, string key)
        {
            int[][] textbit = TextHandle.string2IntArray(text);
            int[][] afterencode = new int[textbit.Length][];
            int[][][] subkeys = make3DesSubKeys(TextHandle.get128BinKey(key));
            string encodestr = "";
            for (int i = 0; i < textbit.Length; i++)
            {
                afterencode[i] = new int[0];
                afterencode[i] = DES_Encrypt_One_Group(textbit[i], subkeys[0]);
            }

            for (int i = 0; i < afterencode.Length; i++)
            {
                afterencode[i] = DES_Decrypt_One_Group(afterencode[i], subkeys[1]);
            }

            for (int i = 0; i < textbit.Length; i++)
            {
                afterencode[i] = DES_Encrypt_One_Group(afterencode[i], subkeys[0]);
                encodestr += TextHandle.binToHex(afterencode[i]);
            }
            return encodestr;
        }


        //解密
        public static string DES_Decrypt(string text, string key)
        {
            int[][] textbit = new int[text.Length / 16][];
            int[][] subkeys = makeSubKeys(TextHandle.get64BinKey(key));
            string decodestr = "";
            for (int i = 0; i < textbit.Length; i++)
            {
                textbit[i] = TextHandle.hexToBin(text.Substring(16 * i, 16));
                while (textbit[i].Length < 64)
                    textbit[i] = TextHandle.intArrayConnect(new int[1] { 0 }, textbit[i]);
                decodestr += TextHandle.intArray2String(DES_Decrypt_One_Group(textbit[i], subkeys));
            }
            return decodestr;
        }

        //3des解密
        public static string thribleDES_Decrypt(string text, string key)
        {
            int[][] textbit = new int[text.Length / 16][];
            int[][][] subkeys = make3DesSubKeys(TextHandle.get128BinKey(key));
            int[][] decode = new int[textbit.Length][];
            string decodestr = "";
            for (int i = 0; i < textbit.Length; i++)
            {
                textbit[i] = TextHandle.hexToBin(text.Substring(16 * i, 16));
                while (textbit[i].Length < 64)
                    textbit[i] = TextHandle.intArrayConnect(new int[1] { 0 }, textbit[i]);
                decode[i] = DES_Decrypt_One_Group(textbit[i], subkeys[0]);
            }

            for (int i = 0; i < textbit.Length; i++)
            {
                decode[i] = DES_Encrypt_One_Group(decode[i], subkeys[1]);
            }
            for (int i = 0; i < textbit.Length; i++)
            {
                decodestr += TextHandle.intArray2String(DES_Decrypt_One_Group(decode[i], subkeys[0]));
            }
            return decodestr;
        }
    }
}