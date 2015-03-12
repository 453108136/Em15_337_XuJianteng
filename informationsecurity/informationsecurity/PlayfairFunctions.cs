using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace informationsafety
{
    //建立查询表
    static class PlayfairFunctions
    {
        static char[,] initialKey(string key)
        {
            char[,] cube = new char[5, 5];
            string distinctKey = TextHandle.distinctString(key);
            for (int i = 0; i < 5; i++)
            {
                for (int k = 0; k < 5; k++)
                {
                    //先插入没有重复字符的distinctKey
                    if (5 * i + k < key.Length)
                    {
                        cube[i, k] = key[5 * i + k];
                    }
                    //所有字母遍历查询表，如果没有该字幕则插入
                    else
                    {
                        for (char c = 'a'; c <= 'z'; c++)
                        {
                            //判断、插入i或j
                            if (c == 'i')
                            {
                                for (int w = 0; w < 25; w++)
                                {
                                    if (cube[w / 5, w % 5] == c || cube[w / 5, w % 5] == c + 1)
                                    {
                                        break;
                                    }
                                    if (cube[w / 5, w % 5] == '\0')
                                    {
                                        cube[w / 5, w % 5] = c;
                                        break;
                                    }
                                }
                                c++;
                                continue;
                            }
                            for (int w = 0; w < 25; w++)
                            {
                                if (cube[w / 5, w % 5] == c)
                                {
                                    break;
                                }
                                if (cube[w / 5, w % 5] == '\0')
                                {
                                    cube[w / 5, w % 5] = c;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return cube;
        }

        //加密两个字母
        static char[] playfair_Encrypt_One_Group(char l, char r, char[,] table)
        {
            int ll = new int(), lr = new int(), rl = new int(), rr = new int();         //获得l、r表中的行和列
            int nll = new int(), nlr = new int(), nrl = new int(), nrr = new int();     //加密后新的行和列
            //获得行列号
            for (int i = 0; i < 5; i++)
            {
                for (int k = 0; k < 5; k++)
                {
                    if (table[i, k] == 'i' || table[i, k] == 'j')
                    {
                        if ('i' == l || 'j' == l)
                        {
                            lr = i;
                            ll = k;
                        }
                    }
                    else
                    {
                        if (table[i, k] == l)
                        {
                            lr = i;
                            ll = k;
                        }
                    }
                }
            }
            for (int i = 0; i < 5; i++)
            {
                for (int k = 0; k < 5; k++)
                {
                    if (table[i, k] == 'i' || table[i, k] == 'j')
                    {
                        if ('i' == r || 'j' == r)
                        {
                            rr = i;
                            rl = k;
                        }
                    }
                    else
                    {
                        if (table[i, k] == r)
                        {
                            rr = i;
                            rl = k;
                        }
                    }
                }
            }
            //列相同，行都+1
            if (ll == rl)
            {
                if (lr == 4)
                {
                    nlr = 0;
                }
                else
                {
                    nlr = lr + 1;
                }
                if (rr == 4)
                {
                    nrr = 0;
                }
                else
                {
                    nrr = rr + 1;
                }
                nll = ll;
                nrl = rl;
                return new char[] { table[nlr, nll], table[nrr, nrl] };
            }
            else
            {

                //行相同，列都+1
                if (lr == rr)
                {

                    if (ll == 4)
                    {
                        nll = 0;
                    }
                    else
                    {
                        nll = ll + 1;
                    }
                    if (rl == 4)
                    {

                        nrl = 0;
                    }
                    else
                    {
                        nrl = rl + 1;
                    }
                    nlr = lr;
                    nrr = rr;

                    return new char[] { table[nlr, nll], table[nrr, nrl] };
                }
                else
                {
                    //行列都不同，交换列号
                    return new char[] { table[lr, rl], table[rr, ll] };
                }
            }
        }

        //解密两个字母
        static char[] playfair_Decrypt_One_Group(char l, char r, char[,] table)
        {
            int ll = new int(), lr = new int(), rl = new int(), rr = new int();         //获得l、r表中的行和列
            int nll = new int(), nlr = new int(), nrl = new int(), nrr = new int();     //加密后新的行和列
            //获得行列号
            for (int i = 0; i < 5; i++)
            {
                for (int k = 0; k < 5; k++)
                {
                    if (table[i, k] == 'i' || table[i, k] == 'j')
                    {
                        if ('i' == l || 'j' == l)
                        {
                            lr = i;
                            ll = k;
                        }
                    }
                    else
                    {
                        if (table[i, k] == l)
                        {
                            lr = i;
                            ll = k;
                        }
                    }
                }
            }
            for (int i = 0; i < 5; i++)
            {
                for (int k = 0; k < 5; k++)
                {
                    if (table[i, k] == 'i' || table[i, k] == 'j')
                    {
                        if ('i' == r || 'j' == r)
                        {
                            rr = i;
                            rl = k;
                        }
                    }
                    else
                    {
                        if (table[i, k] == r)
                        {
                            rr = i;
                            rl = k;
                        }
                    }
                }
            }
            //列相同，行都+1
            if (ll == rl)
            {
                if (lr == 0)
                {
                    nlr = 4;
                }
                else
                {
                    nlr = lr - 1;
                }
                if (rr == 0)
                {
                    nrr = 4;
                }
                else
                {
                    nrr = rr - 1;
                }
                nll = ll;
                nrl = rl;
                return new char[] { table[nlr, nll], table[nrr, nrl] };
            }
            else
            {
                //行相同，列都+1
                if (lr == rr)
                {

                    if (ll == 0)
                    {
                        nll = 4;
                    }
                    else
                    {
                        nll = ll - 1;
                    }
                    if (rl == 0)
                    {

                        nrl = 4;
                    }
                    else
                    {
                        nrl = rl - 1;
                    }
                    nlr = lr;
                    nrr = rr;

                    return new char[] { table[nlr, nll], table[nrr, nrl] };
                }
                else
                {
                    //行列都不同，交换列号
                    return new char[] { table[lr, rl], table[rr, ll] };
                }
            }
        }

        //playfair加密
        static public string playfair_Encrypt(string str, string key)
        {
            str = str.ToLower();
            key = key.ToLower();
            char[,] table = initialKey(key);        //建立查询表
            char[] onegroup;
            string encrypt = "";
            str = TextHandle.insertXBetweenTheSame(str);
            for (int i = 0; i < str.Length; i = i + 2)      //每两个字母进行加密
            {
                if (i + 1 < str.Length)
                {
                    onegroup = playfair_Encrypt_One_Group(str[i], str[i + 1], table);
                    encrypt = encrypt + onegroup[0] + onegroup[1];
                }
                else
                {
                    encrypt += str[i];
                }
            }
            return encrypt;
        }

        //playfair解密
        static public string playfair_Decrypt(string str, string key)
        {
            str = str.ToLower();
            key = key.ToLower();
            char[,] table = initialKey(key);         //建立查询表
            char[] onegroup;
            string decrypt = "";
            str = TextHandle.insertback(str);
            for (int i = 0; i < str.Length; i = i + 2)          //每两个字母进行解密
            {
                if (i + 1 < str.Length)
                {
                    onegroup = playfair_Decrypt_One_Group(str[i], str[i + 1], table);

                    decrypt = decrypt + onegroup[0];
                    if (onegroup[0] == 'i')
                        decrypt += "(j)";
                    if (onegroup[0] == 'j')
                        decrypt += "(i)";

                    decrypt += onegroup[1];
                    if (onegroup[1] == 'i')
                        decrypt += "(j)";
                    if (onegroup[1] == 'j')
                        decrypt += "(i)";
                }
                else
                {
                    decrypt += str[i];
                }
            }
            return decrypt;
        }
    }
}
