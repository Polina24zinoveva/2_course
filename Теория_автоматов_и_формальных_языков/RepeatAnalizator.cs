using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//repeat a[i] := d until b < c;
//REPEAT  _A_B := 12.3 - CL  UNTIL  ( _M_K );
//REPEAT  A_N := -12.001  UNTIL  ( A = B )  OR  ( C = 18.3 );
//repeat A[i] := 100 + C[2] until K;
//repeat A[A1] := A2 + 1 until A[A3];
//repeat a := b + c until (c < t) and (c > a);
//repeat a := b + c until (a[c] < a[t]) and (a[c] > a[u]);
//repeat _94jfi[2] := y[-34] mod t[54] until (_54r[op] <> 0) Xor (j[o] >= 3);
//repeat _94jfi[2] := -3.14 mod 0.542 until (5.32 <> +0.42) Xor (432.999 >= 4.333);
//repeat _94jfi[2] := -3.14 mod 0.542 until 5.32 <> +0.42;
//repeat   iy [ -45 ] := 10.3 div rd until fh    ;

namespace LR__automats_
{
    internal class RepeatAnalizator
    {
        private enum States
        {
            S,
            A, A1, A2, A3, A4, A5,
            B, B1, B2, B3, B4, B5, B6, B7, B8,   //левая часть
            C, C1,
            D, D1, D2, D3, D4, D5, D6, D7, //правая часть
            E, E1, E2, E3, E4, E5,
            G, G1, G2, G3, G4, G5,
            H, H1, H2, H3, H4, H5, H6, H7, H8,
            I, I1, I2, I3, I4, I5,
            J, J1, J2, J3, J4, J5,              //until
            K,
            L, L1, L2, L3, L4, L5, L6, L7,
            M, M1, M2, M3, M4, M5,
            N, N1, N2, N3, N4, N5, N6, N7, N8,
            O, O1, O2, O3, O4, O5, O6, O7,
            O10, O11, O12, O13, O14, O15,
            P, P1, P2, P3, P4, P5, P6,
            Q, Q1, Q2, Q3, Q4, Q5, Q6, Q7,
            Q10, Q11, Q12, Q13, Q14, Q15,
            SS, SS1, SS2,
            T, T1, T2, T3, T4, T5, T6, T7,
            T10, T11, T12, T13, T14, T15,
            U, U1, U2, U3, U4, U5, U6, U7,
            U10, U11, U12, U13, U14, U15,
            V, V1, V2,
            W, W1, W2, W3, W4, W5, W6, W7,
            W10, W11, W12, W13, W14, W15,
            X,
            Y,
            F,

        }

        public static string Main(string s)
        {
            States states = States.S;
            s = s.ToLower();

            int i = 0;
            while (i < s.Length)
            {
                switch (states)
                {
                    case States.S:
                        {
                            if (s[i] == ' ') { i++; }
                            else if (s[i] == 'r')
                            {
                                states = States.A;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались пробел или R", i);
                        }
                        break;
        //ввод repeat
                    case States.A:
                        {
                            if (s[i] == 'e')
                            {
                                states = States.A1;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидался символ: E", i);
                        }
                        break;
                    case States.A1:
                        {
                            if (s[i] == 'p')
                            {
                                states = States.A2;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидался символ: P", i);
                        }
                        break;
                    case States.A2:
                        {
                            if (s[i] == 'e')
                            {
                                states = States.A3;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидался символ: E", i);
                        }
                        break;
                    case States.A3:
                        {
                            if (s[i] == 'a')
                            {
                                states = States.A4;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидался символ: A", i);
                        }
                        break;
                    case States.A4:
                        {
                            if (s[i] == 't')
                            {
                                states = States.A5;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидался символ: T", i);
                        }
                        break;
                    case States.A5:
                        {
                            if (s[i] == ' ')
                            {
                                states = States.B;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидался пробел", i);
                        }
                        break;

        //ЛЕВАЯ ЧАСТЬ
                    //идентификатор
                    case States.B:
                        {
                            if (s[i] == ' ') { i++; }
                            else if ((s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.B1;
                            }
                            else throw new ExceptionWithPosition("Ожидался символ '_' или буквы от A до Z", i);
                        }
                        break;
                    case States.B1:
                        {

                            if ((s[i] >= '0' && s[i] <= '9') || (s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.B1;
                                i++;
                            }
                            else if (s[i] == '[')
                            {
                                states = States.B2;
                                i++;
                            }
                            else if (s[i] == ' ') { i++; }
                            else if (s[i] == ':')
                            {
                                states = States.C;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '[', ':', '_', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;
                    //левая часть после [
                    case States.B2:               //разделение на идентификатор и константу целую
                        {
                            if (s[i] == ' ') { i++; }
                            else if ((s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))   
                            {
                                states = States.B3;
                                i++;
                            }
                            else if ((s[i] >= '0' && s[i] <= '9') || s[i] == '+' || s[i] == '-')   
                            {
                                states = States.B5;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '+', '-', '_', буквы от A до Z или цифры от 0 до 9", i);
                            break;
                        }
                    //идентификатор
                    case States.B3:
                        {
                            if ((s[i] >= '0' && s[i] <= '9') || (s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.B3;
                                i++;
                            }
                            else if (s[i] == ']')
                            {
                                states = States.C;
                                i++;
                            }
                            else if (s[i] == ' ')
                            {
                                states = States.B4;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, ']', '_', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;
                    case States.B4:
                        {
                            if (s[i] == ' ') { i++; }
                            else if (s[i] == ']')
                            {
                                states = States.C;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидался символ ]", i);
                        }
                        break;
                    //проверка константы целой
                    case States.B5:
                        {
                            if (s[i] >= '1' && s[i] <= '9')
                            {
                                states = States.B7;
                                i++;
                            }
                            else if (s[i] == '0')
                            {
                                states = States.B8;
                                i++;
                            }
                            else if (s[i] == '+' || s[i] == '-')
                            {
                                states = States.B6;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: '+', '-' или цифры от 0 до 9", i);
                        }
                        break;
                    case States.B6:
                        {
                            if (s[i] >= '1' && s[i] <= '9')
                            {
                                states = States.B7;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: цифры от 1 до 9", i);
                        }
                        break;
                    case States.B7:
                        {
                            if (s[i] >= '0' && s[i] <= '9')
                            {
                                states = States.B7;
                                i++;
                            }
                            else if (s[i] == ']')
                            {
                                states = States.C;
                                i++;
                            }
                            else if (s[i] == ' ')
                            {
                                states = States.B4;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, ']' или цифры от 0 до 9", i);
                        }
                        break;
                    case States.B8:
                        {
                            if (s[i] == ' ') { i++; }
                            else if (s[i] == ']')
                            {
                                states = States.C;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел или ']'", i);
                        }
                        break;

        //:=
                    case States.C:
                        {
                            if (s[i] == ' ') { i++; }
                            else if (s[i] == ':')
                            {
                                states = States.C1;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидался символ : ", i);
                        }
                        break;
                    case States.C1:
                        {
                            if (s[i] == '=')
                            {
                                states = States.D;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидался символ = ", i);
                        }
                        break;

        //ПРАВАЯ ЧАСТЬ
                    //операнд
                    case States.D: //проверка на идент или константу любую
                        {
                            if (s[i] == ' ') { i++; }
                            else if ((s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.D1;
                                i++;
                            }
                            else if ((s[i] >= '0' && s[i] <= '9') || s[i] == '+' || s[i] == '-')
                            {
                                states = States.E;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '+', '-', '_', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;

                    //идентификатор
                    case States.D1:
                        {
                            if (s[i] == ' ')
                            {
                                states = States.D7; 
                                i++;
                            }
                            else if ((s[i] >= '0' && s[i] <= '9') || (s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.D1;
                                i++;
                            }
                            else if (s[i] == '[')
                            {
                                states = States.D2;
                                i++;
                            }
                            else if ((s[i] == 'd') || (s[i] == '/') || (s[i] == '+') || (s[i] == '-') || (s[i] == '*') || (s[i] == 'm'))
                            {
                                states = States.G; //выход из операнда
                            }
                            
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '+', '-', '_', '[', 'd', '/', '+', '-', '*', 'm', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;
                    case States.D2: //после [ проверка на идент или константу любую
                        {
                            if (s[i] == ' ') { i++; }
                            else if ((s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.D3;
                                i++;
                            }
                            else if ((s[i] >= '0' && s[i] <= '9') || s[i] == '+' || s[i] == '-')
                            {
                                states = States.D4;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '+', '-', '_', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;
                    //идентификатор
                    case States.D3:
                        {
                            if ((s[i] >= '0' && s[i] <= '9') || (s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.D3;
                                i++;
                            }
                            else if (s[i] == ']')
                            {
                                states = States.G;
                                i++;
                            }
                            else if (s[i] == ' ')
                            {
                                states = States.D7;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, ']', '_', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;
                    //проверка константы целой
                    case States.D4:
                        {
                            if (s[i] >= '1' && s[i] <= '9')
                            {
                                states = States.D6;
                                i++;
                            }
                            else if (s[i] == '0')
                            {
                                states = States.D7;
                                i++;
                            }
                            else if (s[i] == '+' || s[i] == '-')
                            {
                                states = States.D5;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '+', '-' или цифры от 0 до 9", i);
                        }
                        break;
                    case States.D5:
                        {
                            if (s[i] >= '1' && s[i] <= '9')
                            {
                                states = States.D6;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались цифры от 1 до 9", i);
                        }
                        break;
                    case States.D6:
                        {
                            if (s[i] >= '0' && s[i] <= '9')
                            {
                                states = States.D6;
                                i++;
                            }
                            else if (s[i] == ']')
                            {
                                states = States.G;
                                i++;
                            }
                            else if (s[i] == ' ')
                            {
                                states = States.D7;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, ']' или цифры от 0 до 9", i);
                        }
                        break;
                    case States.D7:
                        {
                            if (s[i] == ' ') { i++; }
                            else if (s[i] == '[')
                            {
                                states = States.D2;
                                i++;
                            }
                            else if ((s[i] == ']') || (s[i] == 'd') || (s[i] == '/') || (s[i] == '+') || (s[i] == '-') || (s[i] == '*') || (s[i] == 'm'))
                            {
                                states = States.G;
                            }
                            else if (s[i] == 'u')
                            {
                                states = States.J; //выход из правой части
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, ']', 'd', '/', '+', '-', '*', 'm', 'u'", i);
                        }
                        break;
                    //проверка константы любой
                    case States.E:
                        {
                            if (s[i] == '+' || s[i] == '-')
                            {
                                states = States.E1;
                                i++;
                            }
                            else if (s[i] >= '1' && s[i] <= '9')
                            {
                                states = States.E2;
                                i++;
                            }
                            else if (s[i] == '0')
                            {
                                states = States.E5;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '+', '-' или цифры от 0 до 9", i);
                        }
                        break;
                    case States.E1:
                        {
                            if (s[i] >= '1' && s[i] <= '9')
                            {
                                states = States.E2;
                                i++;
                            }
                            else if (s[i] == '0')
                            {
                                states = States.E4;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались цифры от 0 до 9", i);
                        }
                        break;
                    case States.E2:
                        {
                            if (s[i] >= '0' && s[i] <= '9')
                            {
                                states = States.E2;
                                i++;
                            }
                            else if (s[i] == '.')
                            {
                                states = States.E3;
                                i++;
                            }
                            else if ((s[i] == ' ') || (s[i] == 'd') || (s[i] == '/') || (s[i] == '+') || (s[i] == '-') || (s[i] == '*') || (s[i] == 'm'))
                            {
                                states = States.G; //выход из операнда
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '.', 'd', '/', '+', '-', '*', 'm' или цифры от 0 до 9", i);
                        }
                        break;
                    case States.E3:
                        {
                            if (s[i] >= '0' && s[i] <= '9')
                            {
                                states = States.E3;
                                i++;
                            }
                            else if ((s[i] == ' ') ||(s[i] == 'd') || (s[i] == '/') || (s[i] == '+') || (s[i] == '-') || (s[i] == '*') || (s[i] == 'm'))
                            {
                                states = States.G; //выход из операнда
                            }
                           /* else if (s[i] == ' ')
                            {
                                states = States.E3; 
                                i++;
                            }*/
                            else throw new ExceptionWithPosition(" Ожидались символы: пробел, 'd', '/', '+', '-', '*', 'm' или цифры от 0 до 9", i);
                        }
                        break;
                    case States.E4:
                        {
                            if (s[i] == '.')
                            {
                                states = States.E3;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидался символ '.'", i);
                        }
                        break;
                    case States.E5:
                        {
                            if (s[i] == '.')
                            {
                                states = States.E3;
                                i++;
                            }
                            else if ((s[i] == ' ') || (s[i] == 'd') || (s[i] == '/') || (s[i] == '+') || (s[i] == '-') || (s[i] == '*') || (s[i] == 'm'))
                            {
                                states = States.G; //выход из операнда
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '.', 'd', '/', '+', '-', '*' или 'm'", i);
                        }
                        break;
                    //операция арифметическая
                    case States.G:
                        {
                            if (s[i-1] == ' ' && s[i] == 'u')
                            {
                                states = States.J;
                            }
                            else if (s[i] == ' ') { i++; }
                            else if ((s[i] == '/') || (s[i] == '+') || (s[i] == '-') || (s[i] == '*'))
                            {
                                states = States.H;
                                i++;
                            }
                            else if (s[i] == 'd')
                            {
                                states = States.G1;
                                i++;
                            }
                            else if (s[i] == 'm')
                            {
                                states = States.G3;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, 'd', '/', '+', '-', '*', 'm' или 'u'", i);
                        }
                        break;
                    case States.G1:
                        {
                            if (s[i] == 'i')
                            {
                                states = States.G2;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидался символ i", i);
                        }
                        break;
                    case States.G2:
                        {
                            if (s[i] == 'v')
                            {
                                states = States.H;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидался символ v", i);
                        }
                        break;
                    case States.G3:
                        {
                            if (s[i] == 'o')
                            {
                                states = States.G4;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидался символ o", i);
                        }
                        break;
                    case States.G4:
                        {
                            if (s[i] == 'd')
                            {
                                states = States.H;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидался символ d", i);
                        }
                        break;
                    //операнд
                    case States.H: //проверка на идентификаор или константу любую
                        {
                            if (s[i] == ' ') { i++; }
                            else if ((s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.H1;
                                i++;
                            }
                            else if ((s[i] >= '0' && s[i] <= '9') || s[i] == '+' || s[i] == '-')
                            {
                                states = States.I;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '+', '-', '_', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;
                    //идентификатор
                    case States.H1:
                        {
                            if (s[i] == ' ') 
                            {
                                states = States.H8;
                                i++; 
                            }
                            else if ((s[i] >= '0' && s[i] <= '9') || (s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.H1;
                                i++;
                            }
                            else if (s[i] == '[')
                            {
                                states = States.H2;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '[', '+', '-', '_', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;
                    case States.H2: //после [ проверка на идент или константу любую
                        {
                            if (s[i] == ' ') { i++; }
                            else if ((s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.H3;
                                i++;
                            }
                            else if ((s[i] >= '0' && s[i] <= '9') || s[i] == '+' || s[i] == '-')
                            {
                                states = States.H4;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '+', '-', '_', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;
                    //идентификатор
                    case States.H3:
                        {
                            if ((s[i] >= '0' && s[i] <= '9') || (s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.H3;
                                i++;
                            }
                            else if (s[i] == ']')
                            {
                                states = States.J;
                                i++;
                            }
                            else if (s[i] == ' ')
                            {
                                states = States.H7;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, ']', '_', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;
                    //проверка константы целой
                    case States.H4:
                        {
                            if (s[i] >= '1' && s[i] <= '9')
                            {
                                states = States.H6;
                                i++;
                            }
                            else if (s[i] == '0')
                            {
                                states = States.H7;
                                i++;
                            }
                            else if (s[i] == '+' || s[i] == '-')
                            {
                                states = States.H5;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы:'+', '-' или цифры от 0 до 9", i);
                        }
                        break;
                    case States.H5:
                        {
                            if (s[i] >= '1' && s[i] <= '9')
                            {
                                states = States.H6;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались от 1 до 9", i);
                        }
                        break;
                    case States.H6:
                        {
                            if (s[i] >= '0' && s[i] <= '9')
                            {
                                states = States.H6;
                                i++;
                            }
                            else if (s[i] == ' ')
                            {
                                states = States.H7;
                                i++;
                            }
                            else if (s[i] == ']')
                            {
                                states = States.J;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, ']' или цифры от 0 до 9", i);
                        }
                        break;
                    case States.H7:
                        {
                            if (s[i] == ' ') { i++; }
                            else if (s[i] == ']')
                            {
                                states = States.J;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидался символ ]", i);
                        }
                        break;
                    case States.H8:
                        {
                            if (s[i] == ' ') { i++; }
                            else if (s[i] == 'u')
                            {
                                states = States.J;
                            }
                            else if (s[i] == '[')
                            {
                                states = States.H2;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '[' или 'u'", i);
                        }
                    break;
                    //проверка константы любой
                    case States.I:
                        {
                            if (s[i] == '+' || s[i] == '-')
                            {
                                states = States.I1;
                                i++;
                            }
                            else if (s[i] >= '1' && s[i] <= '9')
                            {
                                states = States.I2;
                                i++;
                            }
                            else if (s[i] == '0')
                            {
                                states = States.I5;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '+', '-' или цифры от 0 до 9", i);
                        }
                        break;
                    case States.I1:
                        {
                            if (s[i] >= '1' && s[i] <= '9')
                            {
                                states = States.I2;
                                i++;
                            }
                            else if (s[i] == '0')
                            {
                                states = States.I4;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались цифры от 0 до 9", i);
                        }
                        break;
                    case States.I2:
                        {
                            if (s[i] >= '0' && s[i] <= '9')
                            {
                                states = States.I2;
                                i++;
                            }
                            else if (s[i] == '.')
                            {
                                states = States.I3;
                                i++;
                            }
                            else if (s[i] == ' ')
                            {
                                states = States.J; //выход из правой части
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '.' или цифры от 0 до 9", i);
                        }
                        break;
                    case States.I3:
                        {
                            if (s[i] >= '0' && s[i] <= '9')
                            {
                                states = States.I3;
                                i++;
                            }
                            else if (s[i] == ' ')
                            {
                                states = States.J; //выход из правой части
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел или цифры от 0 до 9", i);
                        }
                        break;
                    case States.I4:
                        {
                            if (s[i] == '.')
                            {
                                states = States.I3;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидался символ .", i);

                        }
                        break;
                    case States.I5:
                        {
                            if (s[i] == '.')
                            {
                                states = States.I3;
                                i++;
                            }
                            else if (s[i] == ' ')
                            {
                                states = States.J; //выход из правой части
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел или '.'", i);
                        }
                        break;

        //UNTIL
                    case States.J:
                        {
                            if (s[i] == ' ') { i++; }
                            else if ((s[i-1] == ' ') && (s[i] == 'u'))
                            {
                                states = States.J1;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел или 'u'", i);
                        }
                        break;
                    case States.J1:
                        {
                            if (s[i] == 'n')
                            {
                                states = States.J2;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидался символ: n", i);
                        }
                        break;
                    case States.J2:
                        {
                            if (s[i] == 't')
                            {
                                states = States.J3;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидался символ: t", i);
                        }
                        break;
                    case States.J3:
                        {
                            if (s[i] == 'i')
                            {
                                states = States.J4;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидался символ: i", i);
                        }
                        break;
                    case States.J4:
                        {
                            if (s[i] == 'l')
                            {
                                states = States.J5;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидался символ: l", i);
                        }
                        break;
                    case States.J5:
                        {
                            if (s[i] == ' ')
                            {
                                states = States.K;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидался символ: пробел", i);
                        }
                        break;

        //УСЛОВИЕ
                    case States.K:
                        {
                            if (s[i] == ' ') { i++; }
                            else if (s[i] == '(')
                            {
                                states = States.L;
                                i++;
                            }
                            else if ((s[i] >= 'a' && s[i] <= 'z') || (s[i] >= '0' && s[i] <= '9') || s[i] == '+' || s[i] == '-' || (s[i] == '_'))
                            {
                                states = States.U; //отношения
                            }
                            else throw new ExceptionWithPosition("Ожидались символы 0...9||A...Z||_||(||пробел||+||- ", i);
                        }
                        break;
            //отношение правое
                //операнд
                    case States.L: //проверка на идент или константу любую        D->L, E->M, G->N(операция отношиения)
                        {
                            if (s[i] == ' ') { i++; }
                            else if ((s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.L1;
                                i++;
                            }
                            else if ((s[i] >= '0' && s[i] <= '9') || s[i] == '+' || s[i] == '-')
                            {
                                states = States.M;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '+', '-', '_', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;
                   
                    case States.L1:
                        {
                            if ((s[i] >= '0' && s[i] <= '9') || (s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.L1;
                                i++;
                            }
                            else if (s[i] == '[')
                            {
                                states = States.L2;
                                i++;
                            }
                            else if ((s[i] == ' ') || (s[i] == '<') || (s[i] == '>') || (s[i] == '=') || (s[i] == ')'))
                            {
                                states = States.N; //выход из операнда
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '[', '_', '<', '>', '=', ')', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;
                    case States.L2: //после [ проверка на идент или константу любую
                        {
                            if (s[i] == ' ') { i++; }
                            else if ((s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.L3;
                                i++;
                            }
                            else if ((s[i] >= '0' && s[i] <= '9') || s[i] == '+' || s[i] == '-')
                            {
                                states = States.L4;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '+', '-', '_', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;
                    //идентификатор
                    case States.L3:
                        {
                            if ((s[i] >= '0' && s[i] <= '9') || (s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.L3;
                                i++;
                            }
                            else if (s[i] == ' ')
                            {
                                states = States.L7;
                                i++;
                            }
                            else if (s[i] == ']')
                            {
                                states = States.N;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, ']', '_', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;
                    //проверка константы целой
                    case States.L4:
                        {
                            if (s[i] >= '1' && s[i] <= '9')
                            {
                                states = States.L6;
                                i++;
                            }
                            else if (s[i] == '0')
                            {
                                states = States.L7;
                                i++;
                            }
                            else if (s[i] == '+' || s[i] == '-')
                            {
                                states = States.L5;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '+', '-' или цифры от 0 до 9", i);
                        }
                        break;
                    case States.L5:
                        {
                            if (s[i] >= '1' && s[i] <= '9')
                            {
                                states = States.L6;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались цифры от 1 до 9", i);
                        }
                        break;
                    case States.L6:
                        {
                            if (s[i] >= '0' && s[i] <= '9')
                            {
                                states = States.L6;
                                i++;
                            }
                            else if (s[i] == ' ')
                            {
                                states = States.L7;
                                i++;
                            }
                            else if (s[i] == ']')
                            {
                                states = States.N;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, ']' или цифры от 0 до 9", i);
                        }
                        break;
                    case States.L7:
                        {
                            if (s[i] == ' ') { i++; }
                            else if (s[i] == ']')
                            {
                                states = States.N;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел или ']'", i);
                        }
                        break;
                    //проверка константы любой
                    case States.M:
                        {
                            if (s[i] == '+' || s[i] == '-')
                            {
                                states = States.M1;
                                i++;
                            }
                            else if (s[i] >= '1' && s[i] <= '9')
                            {
                                states = States.M2;
                                i++;
                            }
                            else if (s[i] == '0')
                            {
                                states = States.M5;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '+', '-' или цифры от 0 до 9", i);
                        }
                        break;
                    case States.M1:
                        {
                            if (s[i] >= '1' && s[i] <= '9')
                            {
                                states = States.M2;
                                i++;
                            }
                            else if (s[i] == '0')
                            {
                                states = States.M4;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались цифры от 0 до 9", i);
                        }
                        break;
                    case States.M2:
                        {
                            if (s[i] >= '0' && s[i] <= '9')
                            {
                                states = States.M2;
                                i++;
                            }
                            else if (s[i] == '.')
                            {
                                states = States.M3;
                                i++;
                            }
                            else if ((s[i] == ' ') || (s[i] == '<') || (s[i] == '>') || (s[i] == '=') || (s[i] == ')'))
                            {
                                states = States.N; //выход из операнда
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '.', '<', '>', '=', ')' или цифры от 0 до 9", i);
                        }
                        break;
                    case States.M3:
                        {
                            if (s[i] >= '0' && s[i] <= '9')
                            {
                                states = States.M3;
                                i++;
                            }
                            else if ((s[i] == ' ') || (s[i] == '<') || (s[i] == '>') || (s[i] == '=') || (s[i] == ')'))
                            {
                                states = States.N; //выход из операнда
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '<', '>', '=', ')' или цифры от 0 до 9", i);
                        }
                        break;
                    case States.M4:
                        {
                            if (s[i] == '.')
                            {
                                states = States.M3;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидался символ: .", i);

                        }
                        break;
                    case States.M5:
                        {
                            if (s[i] == '.')
                            {
                                states = States.M3;
                                i++;
                            }
                            else if ((s[i] == ' ') || (s[i] == '<') || (s[i] == '>') || (s[i] == '=') || (s[i] == ')'))
                            {
                                states = States.N; //выход из операнда
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '.', '<', '>', '=' или ')'", i);
                        }
                        break;
                //операция отношения
                    case States.N:
                        {
                            if (s[i] == ' ') { i++; }
                            else if (s[i] == '<')
                            {
                                states = States.N1;
                                i++;
                            }
                            else if (s[i] == '>')
                            {
                                states = States.N2;
                                i++;
                            }
                            else if (s[i] == '=')
                            {
                                states = States.O;
                                i++;
                            }
                            else if (s[i] == ')')
                            {
                                states = States.P;    //выход из отношения
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '<', '>', '=' или ')'", i);
                        }
                        break;
                    case States.N1:
                        {
                            if ((s[i] == '=') || (s[i] == '>'))
                            {
                                states = States.O;
                                i++;
                            }
                            else if ((s[i] == ' ') || (s[i] >= 'a' && s[i] <= 'z') || (s[i] >= '0' && s[i] <= '9') || s[i] == '+' || s[i] == '-')
                            {
                                states = States.O;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '>', '=', '+', '-', '_', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;
                    case States.N2:
                        {
                            if (s[i] == '=')
                            {
                                states = States.O;
                                i++;
                            }
                            else if ((s[i] == ' ') ||(s[i] >= 'a' && s[i] <= 'z') || (s[i] >= '0' && s[i] <= '9') || s[i] == '+' || s[i] == '-')
                            {
                                states = States.O;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел,  '=', '+', '-', '_', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;
                //операнд
                    case States.O: //проверка на идент или константу любую        L->O, M->O10, N->P(операция отношиения)
                        {
                            if (s[i] == ' ') { i++; }
                            else if ((s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.O1;
                                i++;
                            }
                            else if ((s[i] >= '0' && s[i] <= '9') || s[i] == '+' || s[i] == '-')
                            {
                                states = States.O10;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '+', '-', '_', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;
                    
                    case States.O1:
                        {
                            if ((s[i] >= '0' && s[i] <= '9') || (s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.O1;
                                i++;
                            }
                            else if (s[i] == '[')
                            {
                                states = States.O2;
                                i++;
                            }
                            else if (s[i] == ' ')
                            {
                                states = States.O7;
                                i++;
                            }
                            else if (s[i] == ')')
                            {
                                states = States.P; //выход из операнда
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '[', ')', '+', '-', '_', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;
                    case States.O2: //после [ проверка на идент или константу любую
                        {
                            if (s[i] == ' ') { i++; }
                            else if ((s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.O3;
                                i++;
                            }
                            else if ((s[i] >= '0' && s[i] <= '9') || s[i] == '+' || s[i] == '-')
                            {
                                states = States.O4;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '+', '-', '_', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;
                    //идентификатор
                    case States.O3:
                        {
                            if ((s[i] >= '0' && s[i] <= '9') || (s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.O3;
                                i++;
                            }
                            else if (s[i] == ' ')
                            {
                                states = States.O7;
                            }
                            else if (s[i] == ']')
                            {
                                states = States.P;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, ']' или буквы от A до Z", i);
                        }
                        break;
                    //проверка константы целой
                    case States.O4:
                        {
                            if (s[i] >= '1' && s[i] <= '9')
                            {
                                states = States.O6;
                                i++;
                            }
                            else if (s[i] == '0')
                            {
                                states = States.O7;
                                i++;
                            }
                            else if (s[i] == '+' || s[i] == '-')
                            {
                                states = States.O5;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: '+', '-', или цифры от 0 до 9", i);
                        }
                        break;
                    case States.O5:
                        {
                            if (s[i] >= '1' && s[i] <= '9')
                            {
                                states = States.O6;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались цифры от 1 до 9", i);
                        }
                        break;
                    case States.O6:
                        {
                            if (s[i] >= '0' && s[i] <= '9')
                            {
                                states = States.O6;
                                i++;
                            }
                            else if (s[i] == ' ')
                            {
                                states = States.O7;
                                i++;
                            }
                            else if (s[i] == ']')
                            {
                                states = States.P;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, ']', или цифры от 0 до 9", i);
                        }
                        break;
                    case States.O7:
                        {
                            if (s[i] == ' ') { i++; }
                            else if (s[i] == ')')
                            {
                                states = States.P;
                            }
                            else if (s[i] == ']')
                            {
                                states = States.P;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел или ']'", i);
                        }
                        break;
                    //проверка константы любой
                    case States.O10:
                        {
                            if (s[i] == '+' || s[i] == '-')
                            {
                                states = States.O11;
                                i++;
                            }
                            else if (s[i] >= '1' && s[i] <= '9')
                            {
                                states = States.O12;
                                i++;
                            }
                            else if (s[i] == '0')
                            {
                                states = States.O15;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы:'+', '-' или цифры от 0 до 9", i);
                        }
                        break;
                    case States.O11:
                        {
                            if (s[i] >= '1' && s[i] <= '9')
                            {
                                states = States.O12;
                                i++;
                            }
                            else if (s[i] == '0')
                            {
                                states = States.O14;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались цифры от 0 до 9", i);
                        }
                        break;
                    case States.O12:
                        {
                            if (s[i] >= '0' && s[i] <= '9')
                            {
                                states = States.O12;
                                i++;
                            }
                            else if (s[i] == '.')
                            {
                                states = States.O13;
                                i++;
                            }
                            else if (s[i] == ')')
                            {
                                states = States.P; //выход из операнда
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: '.', ')' или цифры от 0 до 9", i);
                        }
                        break;
                    case States.O13:
                        {
                            if (s[i] >= '0' && s[i] <= '9')
                            {
                                states = States.O13;
                                i++;
                            }
                            else if (s[i] == ')')
                            {
                                states = States.P; //выход из операнда
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: ')' или цифры от 0 до 9", i);
                        }
                        break;
                    case States.O14:
                        {
                            if (s[i] == '.')
                            {
                                states = States.O13;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидался символ: .", i);

                        }
                        break;
                    case States.O15:
                        {
                            if (s[i] == '.')
                            {
                                states = States.O13;
                                i++;
                            }
                            else if (s[i] == ')')
                            {
                                states = States.P; //выход из операнда
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: ')' или '.'", i);
                        }
                        break;
            //логическая операция или выход
                    case States.P:
                        {
                            if (s[i] == ' ') { i++; }
                            else if (s[i] == ';')
                            {
                                states = States.F;
                                i++;
                            }
                            else if (s[i] == ')')
                            {
                                states = States.P1;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, ';' или ')'", i);
                        }
                        break;
                    case States.P1:
                        {
                            if (s[i] == ' ') { i++; }
                            else if (s[i] == 'x')
                            {
                                states = States.P2;
                                i++;
                            }
                            else if (s[i] == 'a')
                            {
                                states = States.P4;
                                i++;
                            }
                            else if (s[i] == 'o')
                            {
                                states = States.P3;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, 'x', 'a' или 'o'", i);
                        }
                        break;
                    case States.P2:
                        {
                            if (s[i] == 'o')
                            {
                                states = States.P3;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидался символ: o; ", i);
                        }
                        break;
                    case States.P3:
                        {
                            if (s[i] == 'r')
                            {
                                states = States.P6;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидался символ: r", i);
                        }
                        break;
                    case States.P4:
                        {
                            if (s[i] == 'n')
                            {
                                states = States.P5;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидался символ: n; ", i);
                        }
                        break;
                    case States.P5:
                        {
                            if (s[i] == 'd')
                            {
                                states = States.P6;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидался символ: d", i);
                        }
                        break;
                    case States.P6:
                        {
                            if (s[i] == ' ') { i++; }
                            else if (s[i] == '(')
                            {
                                states = States.Q;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидался символ: (", i);
                        }
                        break;

            //отношение
                //операнд
                    case States.Q: //проверка на идент или константу любую        L->Q, M->Q1, N->T(операция отношиения)
                        {
                            if (s[i] == ' ') { i++; }
                            else if ((s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.Q1;
                                i++;
                            }
                            else if ((s[i] >= '0' && s[i] <= '9') || s[i] == '+' || s[i] == '-')
                            {
                                states = States.Q10;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '+', '-', '_', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;
                    //идентификатор
                    case States.Q1:
                        {
                            if ((s[i] >= '0' && s[i] <= '9') || (s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.Q1;
                                i++;
                            }
                            else if (s[i] == '[')
                            {
                                states = States.Q2;
                                i++;
                            }
                            else if ((s[i] == ')') || (s[i] == ' ') || (s[i] == '<') || (s[i] == '>') || (s[i] == '='))
                            {
                                states = States.SS; //выход из операнда
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '[', ')', '<', '>', '=', '+', '-', '_', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;
                    case States.Q2: //после [ проверка на идент или константу любую
                        {
                            if (s[i] == ' ') { i++; }
                            else if ((s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.Q3;
                                i++;
                            }
                            else if ((s[i] >= '0' && s[i] <= '9') || s[i] == '+' || s[i] == '-')
                            {
                                states = States.Q4;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '+', '-', '_', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;
                    //идентификатор
                    case States.Q3:
                        {
                            if ((s[i] >= '0' && s[i] <= '9') || (s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.Q3;
                                i++;
                            }
                            else if (s[i] == ' ')
                            {
                                states = States.Q7;
                                i++;
                            }
                            else if (s[i] == ']')
                            {
                                states = States.SS;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, ']', '_', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;
                    //проверка константы целой
                    case States.Q4:
                        {
                            if (s[i] >= '1' && s[i] <= '9')
                            {
                                states = States.Q6;
                                i++;
                            }
                            else if (s[i] == '0')
                            {
                                states = States.Q7;
                                i++;
                            }
                            else if (s[i] == '+' || s[i] == '-')
                            {
                                states = States.Q5;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: '+', '-' или цифры от 0 до 9", i);
                        }
                        break;
                    case States.Q5:
                        {
                            if (s[i] >= '1' && s[i] <= '9')
                            {
                                states = States.Q6;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались цифры от 1 до 9", i);
                        }
                        break;
                    case States.Q6:
                        {
                            if (s[i] >= '0' && s[i] <= '9')
                            {
                                states = States.Q6;
                                i++;
                            }
                            else if (s[i] == ' ')
                            {
                                states = States.Q7;
                                i++;
                            }
                            else if (s[i] == ']')
                            {
                                states = States.SS;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, ']' или цифры от 0 до 9", i);
                        }
                        break;
                    case States.Q7:
                        {
                            if (s[i] == ' ') { i++; }
                            else if (s[i] == ']')
                            {
                                states = States.SS;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел или ']'", i);
                        }
                        break;
                    //проверка константы любой
                    case States.Q10:
                        {
                            if (s[i] == '+' || s[i] == '-')
                            {
                                states = States.Q11;
                                i++;
                            }
                            else if (s[i] >= '1' && s[i] <= '9')
                            {
                                states = States.Q12;
                                i++;
                            }
                            else if (s[i] == '0')
                            {
                                states = States.Q15;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: '+', '-' или цифры от 0 до 9", i);
                        }
                        break;
                    case States.Q11:
                        {
                            if (s[i] >= '1' && s[i] <= '9')
                            {
                                states = States.Q12;
                                i++;
                            }
                            else if (s[i] == '0')
                            {
                                states = States.Q14;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались цифры от 0 до 9", i);
                        }
                        break;
                    case States.Q12:
                        {
                            if (s[i] >= '0' && s[i] <= '9')
                            {
                                states = States.Q12;
                                i++;
                            }
                            else if (s[i] == '.')
                            {
                                states = States.Q13;
                                i++;
                            }
                            else if ((s[i] == ' ') || (s[i] == '<') || (s[i] == '>') || (s[i] == '=') || (s[i] == ')'))
                            {
                                states = States.SS; //выход из операнда
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '.', '<', '>', '=', ')' или цифры от 0 до 9", i);
                        }
                        break;
                    case States.Q13:
                        {
                            if (s[i] >= '0' && s[i] <= '9')
                            {
                                states = States.Q13;
                                i++;
                            }
                            else if ((s[i] == ' ') || (s[i] == '<') || (s[i] == '>') || (s[i] == '=') || (s[i] == ')'))
                            {
                                states = States.SS; //выход из операнда
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '<', '>', '=', ')' или цифры от 0 до 9", i);
                        }
                        break;
                    case States.Q14:
                        {
                            if (s[i] == '.')
                            {
                                states = States.Q13;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидался символ: .", i);

                        }
                        break;
                    case States.Q15:
                        {
                            if (s[i] == '.')
                            {
                                states = States.Q13;
                                i++;
                            }
                            else if ((s[i] == ' ') || (s[i] == '<') || (s[i] == '>') || (s[i] == '=') || (s[i] == ')'))
                            {
                                states = States.SS; //выход из операнда
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '<', '>', '=' или ')'", i);
                        }
                        break;
                //операция отношения
                    case States.SS:
                        {
                            if (s[i] == ' ') { i++; }
                            else if (s[i] == '<')
                            {
                                states = States.SS1;
                                i++;
                            }
                            else if (s[i] == '>')
                            {
                                states = States.SS2;
                                i++;
                            }
                            else if (s[i] == '=')
                            {
                                states = States.T;
                                i++;
                            }
                            else if (s[i] == ')')
                            {
                                states = States.X;    //выход из отношения
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '<', '>', '=' или ')", i);
                        }
                        break;
                    case States.SS1:
                        {
                            if ((s[i] == '=') || (s[i] == '>'))
                            {
                                states = States.T;
                                i++;
                            }
                            else if ((s[i] == ' ') || (s[i] >= 'a' && s[i] <= 'z') || (s[i] >= '0' && s[i] <= '9') || s[i] == '+' || s[i] == '-' || (s[i] == '_'))
                            {
                                states = States.T;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '=', '>', '+', '-', '_', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;
                    case States.SS2:
                        {
                            if (s[i] == '=')
                            {
                                states = States.T;
                                i++;
                            }
                            else if ((s[i] == ' ') || (s[i] >= 'a' && s[i] <= 'z') || (s[i] >= '0' && s[i] <= '9') || s[i] == '+' || s[i] == '-' || (s[i] == '_'))
                            {
                                states = States.T;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '=', '+', '-', '_', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;
                //операнд
                    case States.T: //проверка на идент или константу любую        O->T, O1->T10, P->U(операция отношиения)
                        {
                            if (s[i] == ' ') { i++; }
                            else if ((s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.T1;
                                i++;
                            }
                            else if ((s[i] >= '0' && s[i] <= '9') || s[i] == '+' || s[i] == '-')
                            {
                                states = States.T10;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы 0...9||A...Z||_||пробел||+||- ", i);
                        }
                        break;
                    //идентификатор
                    case States.T1:
                        {
                            if ((s[i] >= '0' && s[i] <= '9') || (s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.T1;
                                i++;
                            }
                            else if (s[i] == '[')
                            {
                                states = States.T2;
                                i++;
                            }
                            else if ((s[i] == ' ') || (s[i] == ')'))
                            {
                                states = States.X; //выход из операнда
                            }
                            else if (s[i] == ';')
                            {
                                states = States.F;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы 0...9||A...Z||_||пробел||d||m||/||*||+||- ", i);
                        }
                        break;
                    case States.T2: //после [ проверка на идент или константу любую
                        {
                            if (s[i] == ' ') { i++; }
                            else if ((s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.T3;
                                i++;
                            }
                            else if ((s[i] >= '0' && s[i] <= '9') || s[i] == '+' || s[i] == '-')
                            {
                                states = States.T4;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы 0...9||A...Z||_||пробел||+||- ", i);
                        }
                        break;
                    //идентификатор
                    case States.T3:
                        {
                            if ((s[i] >= '0' && s[i] <= '9') || (s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.T3;
                                i++;
                            }
                            else if(s[i] == ' ')
                            {
                                states = States.T7;
                                i++;
                            }
                            else if (s[i] == ']')
                            {
                                states = States.X;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы 0...9||A...Z||_||пробел||] ", i);
                        }
                        break;
                    //проверка константы целой
                    case States.T4:
                        {
                            if (s[i] >= '1' && s[i] <= '9')
                            {
                                states = States.T6;
                                i++;
                            }
                            else if (s[i] == '0')
                            {
                                states = States.T7;
                                i++;
                            }
                            else if (s[i] == '+' || s[i] == '-')
                            {
                                states = States.T5;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы 0...9||+||-|| ", i);
                        }
                        break;
                    case States.T5:
                        {
                            if (s[i] >= '1' && s[i] <= '9')
                            {
                                states = States.T6;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы 1...9 ", i);
                        }
                        break;
                    case States.T6:
                        {
                            if (s[i] >= '0' && s[i] <= '9')
                            {
                                states = States.T6;
                                i++;
                            }
                            else if (s[i] == ' ')
                            {
                                states = States.T7;
                                i++;
                            }
                            else if (s[i] == ']')
                            {
                                states = States.X;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы 0...9||] ", i);
                        }
                        break;
                    case States.T7:
                        {
                            if (s[i] == ' ') { i++; }
                            else if (s[i] == ']')
                            {
                                states = States.X;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы ]||пробел", i);
                        }
                        break;
                    //проверка константы любой
                    case States.T10:
                        {
                            if (s[i] == '+' || s[i] == '-')
                            {
                                states = States.T11;
                                i++;
                            }
                            else if (s[i] >= '1' && s[i] <= '9')
                            {
                                states = States.T12;
                                i++;
                            }
                            else if (s[i] == '0')
                            {
                                states = States.T15;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы 0...9||+||-", i);
                        }
                        break;
                    case States.T11:
                        {
                            if (s[i] >= '1' && s[i] <= '9')
                            {
                                states = States.T12;
                                i++;
                            }
                            else if (s[i] == '0')
                            {
                                states = States.T14;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы 0...9", i);
                        }
                        break;
                    case States.T12:
                        {
                            if (s[i] >= '0' && s[i] <= '9')
                            {
                                states = States.T12;
                                i++;
                            }
                            else if (s[i] == '.')
                            {
                                states = States.T13;
                                i++;
                            }
                            else if ((s[i] == ' ') || (s[i] == ')'))
                            {
                                states = States.X; //выход из операнда
                            }
                            else throw new ExceptionWithPosition("Ожидались символы 0...9||d||>||<||= ", i);
                        }
                        break;
                    case States.T13:
                        {
                            if (s[i] >= '0' && s[i] <= '9')
                            {
                                states = States.T13;
                                i++;
                            }
                            else if ((s[i] == ' ') || (s[i] == ')'))
                            {
                                states = States.X; //выход из операнда
                            }
                            else throw new ExceptionWithPosition("Ожидались символы 0...9||<||>||=", i);
                        }
                        break;
                    case States.T14:
                        {
                            if (s[i] == '.')
                            {
                                states = States.T13;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидался символ .", i);

                        }
                        break;
                    case States.T15:
                        {
                            if (s[i] == '.')
                            {
                                states = States.T13;
                                i++;
                            }
                            else if (s[i] == ')')
                            {
                                states = States.X; //выход из операнда
                            }
                            else throw new ExceptionWithPosition("Ожидались символы .||d||m||/||*||+||- ", i);
                        }
                        break;


            //отношение левое
                //операнд
                    case States.U: //проверка на идент или константу любую        Q->U, Q1->U1, T->V(операция отношиения)
                        {
                            /*if (s[i] == ';')
                            {
                                states = States.F;
                                i++;
                            }
                            else if (s[i] == ' ')
                            {
                                states = States.U;
                                i++;
                            }*/
                            if ((s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.U1;
                                i++;
                            }
                            else if ((s[i] >= '0' && s[i] <= '9') || s[i] == '+' || s[i] == '-')
                            {
                                states = States.U10;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '+', '-', '_', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;
                    //идентификатор
                    case States.U1:
                        {
                            if ((s[i] >= '0' && s[i] <= '9') || (s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.U1;
                                i++;
                            }
                            else if (s[i] == '[')
                            {
                                states = States.U2;
                                i++;
                            }
                            else if ((s[i] == ' ') || (s[i] == '<') || (s[i] == '>') || (s[i] == '='))
                            {
                                states = States.V; //выход из операнда
                            }
                            else if (s[i] == ';')
                            {
                                states = States.Y;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '<', '>', '=', ';', '+', '-', '_', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;
                    case States.U2: //после [ проверка на идент или константу любую
                        {
                            if (s[i] == ' ') { i++; }
                            else if ((s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.U3;
                                i++;
                            }
                            else if ((s[i] >= '0' && s[i] <= '9') || s[i] == '+' || s[i] == '-')
                            {
                                states = States.U4;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '+', '-', '_', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;
                    //идентификатор
                    case States.U3:
                        {
                            if ((s[i] >= '0' && s[i] <= '9') || (s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.U3;
                                i++;
                            }
                            else if (s[i] == ' ')
                            {
                                states = States.U7;
                                i++;
                            }
                            else if (s[i] == ']')
                            {
                                states = States.V;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, ']', '_', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;
                    //проверка константы целой
                    case States.U4:
                        {
                            if (s[i] >= '1' && s[i] <= '9')
                            {
                                states = States.U6;
                                i++;
                            }
                            else if (s[i] == '0')
                            {
                                states = States.U7;
                                i++;
                            }
                            else if (s[i] == '+' || s[i] == '-')
                            {
                                states = States.U5;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: '+', '-' или цифры от 0 до 9", i);
                        }
                        break;
                    case States.U5:
                        {
                            if (s[i] >= '1' && s[i] <= '9')
                            {
                                states = States.U6;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались цифры от 1 до 9", i);
                        }
                        break;
                    case States.U6:
                        {
                            if (s[i] >= '0' && s[i] <= '9')
                            {
                                states = States.U6;
                                i++;
                            }
                            else if (s[i] == ' ')
                            {
                                states = States.U7;
                                i++;
                            }
                            else if (s[i] == ']')
                            {
                                states = States.V;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, ']' или цифры от 0 до 9", i);
                        }
                        break;
                    case States.U7:
                        {
                            if (s[i] == ' ') { i++; }
                            else if (s[i] == ']')
                            {
                                states = States.V;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел или ']'", i);
                        }
                        break;
                    //проверка константы любой
                    case States.U10:
                        {
                            if (s[i] == '+' || s[i] == '-')
                            {
                                states = States.U11;
                                i++;
                            }
                            else if (s[i] >= '1' && s[i] <= '9')
                            {
                                states = States.U12;
                                i++;
                            }
                            else if (s[i] == '0')
                            {
                                states = States.U15;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: '+', '-' или цифры от 0 до 9", i);
                        }
                        break;
                    case States.U11:
                        {
                            if (s[i] >= '1' && s[i] <= '9')
                            {
                                states = States.U12;
                                i++;
                            }
                            else if (s[i] == '0')
                            {
                                states = States.U14;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались цифры от 0 до 9", i);
                        }
                        break;
                    case States.U12:
                        {
                            if (s[i] >= '0' && s[i] <= '9')
                            {
                                states = States.U12;
                                i++;
                            }
                            else if (s[i] == '.')
                            {
                                states = States.U13;
                                i++;
                            }
                            else if ((s[i] == ' ') || (s[i] == '<') || (s[i] == '>') || (s[i] == '='))
                            {
                                states = States.V; //выход из операнда
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '.', '<', '>', '=' или цифры от 0 до 9", i);
                        }
                        break;
                    case States.U13:
                        {
                            if (s[i] >= '0' && s[i] <= '9')
                            {
                                states = States.U13;
                                i++;
                            }
                            else if ((s[i] == ' ') || (s[i] == '<') || (s[i] == '>') || (s[i] == '='))
                            {
                                states = States.V; //выход из операнда
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '<', '>', '=', или цифры от 0 до 9", i);
                        }
                        break;
                    case States.U14:
                        {
                            if (s[i] == '.')
                            {
                                states = States.U13;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидался символ: .", i);

                        }
                        break;
                    case States.U15:
                        {
                            if (s[i] == '.')
                            {
                                states = States.U13;
                                i++;
                            }
                            else if ((s[i] == ' ') || (s[i] == '<') || (s[i] == '>') || (s[i] == '=') )
                            {
                                states = States.V; //выход из операнда
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '.', '<', '>', '=',", i);
                        }
                        break;
                //операция отношения
                    case States.V:
                        {
                            if (s[i] == ' ') { i++; }
                            else if (s[i] == '<')
                            {
                                states = States.V1;
                                i++;
                            }
                            else if (s[i] == '>')
                            {
                                states = States.V2;
                                i++;
                            }
                            else if (s[i] == '=')
                            {
                                states = States.W;
                                i++;
                            }
                            else if (s[i] == ']')
                            {
                                states = States.Y;    //выход из отношения
                                i++;
                            }
                            else if ((s[i - 1] == ' ') || (s[i] == ';'))
                            {
                                states = States.F;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '<', '>', '=' или ']'", i);
                        }
                        break;
                    case States.V1:
                        {
                            if ((s[i] == '=') || (s[i] == '>'))
                            {
                                states = States.W;
                                i++;
                            }
                            else if ((s[i] == ' ') || (s[i] >= 'a' && s[i] <= 'z') || (s[i] >= '0' && s[i] <= '9') || s[i] == '+' || s[i] == '-' || (s[i] == '_'))
                            {
                                states = States.W;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: '=', '>', пробел, '+', '-', '_', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;
                    case States.V2:
                        {
                            if (s[i] == '=')
                            {
                                states = States.W;
                                i++;
                            }
                            else if ((s[i] == ' ') || (s[i] >= 'a' && s[i] <= 'z') || (s[i] >= '0' && s[i] <= '9') || s[i] == '+' || s[i] == '-' || (s[i] == '_'))
                            {
                                states = States.W;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '=', '+', '-', '_', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;
                //операнд
                    case States.W: //проверка на идент или константу любую        T->W, T1->W10, U->Z(операция отношиения)
                        {
                            if (s[i] == ' ') { i++; }
                            else if ((s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.W1;
                                i++;
                            }
                            else if ((s[i] >= '0' && s[i] <= '9') || s[i] == '+' || s[i] == '-')
                            {
                                states = States.W10;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '+', '-', '_', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;
                    //идентификатор
                    case States.W1:
                        {
                            if ((s[i] >= '0' && s[i] <= '9') || (s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.W1;
                                i++;
                            }
                            else if (s[i] == '[')
                            {
                                states = States.W2;
                                i++;
                            }
                            else if ((s[i] == ' ') || (s[i] == ';'))
                            {
                                states = States.Y; //выход из операнда
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '[', ';', '_', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;
                    case States.W2: //после [ проверка на идент или константу любую
                        {
                            if (s[i] == ' ') { i++; }
                            else if ((s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.W3;
                                i++;
                            }
                            else if ((s[i] >= '0' && s[i] <= '9') || s[i] == '+' || s[i] == '-')
                            {
                                states = States.W4;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '+', '-', '_', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;
                    //идентификатор
                    case States.W3:
                        {
                            if ((s[i] >= '0' && s[i] <= '9') || (s[i] >= 'a' && s[i] <= 'z') || (s[i] == '_'))
                            {
                                states = States.W3;
                                i++;
                            }
                            else if (s[i] == ' ')
                            {
                                states = States.W7;
                                i++;
                            }
                            else if (s[i] == ']')
                            {
                                states = States.Y;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, ']', '_', буквы от A до Z или цифры от 0 до 9", i);
                        }
                        break;
                    //проверка константы целой
                    case States.W4:
                        {
                            if (s[i] >= '1' && s[i] <= '9')
                            {
                                states = States.W6;
                                i++;
                            }
                            else if (s[i] == '0')
                            {
                                states = States.W7;
                                i++;
                            }
                            else if (s[i] == '+' || s[i] == '-')
                            {
                                states = States.W5;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: '+', '-' или цифры от 0 до 9", i);
                        }
                        break;
                    case States.W5:
                        {
                            if (s[i] >= '1' && s[i] <= '9')
                            {
                                states = States.W6;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались цифры от 1 до 9", i);
                        }
                        break;
                    case States.W6:
                        {
                            if (s[i] >= '0' && s[i] <= '9')
                            {
                                states = States.W6;
                                i++;
                            }
                            else if (s[i] == ' ')
                            {
                                states = States.W7;
                                i++;
                            }
                            else if (s[i] == ']')
                            {
                                states = States.Y;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, ']' или цифры от 0 до 9", i);
                        }
                        break;
                    case States.W7:
                        {
                            if (s[i] == ' ') { i++; }
                            else if (s[i] == ']')
                            {
                                states = States.Y;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел или ']'", i);
                        }
                        break;
                    //проверка константы любой
                    case States.W10:
                        {
                            if (s[i] == '+' || s[i] == '-')
                            {
                                states = States.W11;
                                i++;
                            }
                            else if (s[i] >= '1' && s[i] <= '9')
                            {
                                states = States.W12;
                                i++;
                            }
                            else if (s[i] == '0')
                            {
                                states = States.W15;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '+', '-' или цифры от 0 до 9", i);
                        }
                        break;
                    case States.W11:
                        {
                            if (s[i] >= '1' && s[i] <= '9')
                            {
                                states = States.W12;
                                i++;
                            }
                            else if (s[i] == '0')
                            {
                                states = States.W14;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались цифры от 0 до 9", i);
                        }
                        break;
                    case States.W12:
                        {
                            if (s[i] >= '0' && s[i] <= '9')
                            {
                                states = States.W12;
                                i++;
                            }
                            else if (s[i] == '.')
                            {
                                states = States.W13;
                                i++;
                            }
                            else if ((s[i] == ' ') || (s[i] == ';'))
                            {
                                states = States.Y; //выход из операнда
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '.', ';' или цифры от 0 до 9", i);
                        }
                        break;
                    case States.W13:
                        {
                            if (s[i] >= '0' && s[i] <= '9')
                            {
                                states = States.W13;
                                i++;
                            }
                            else if ((s[i] == ' ') || (s[i] == ';'))
                            {
                                states = States.Y; //выход из операнда
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, ';' или цифры от 0 до 9", i);
                        }
                        break;
                    case States.W14:
                        {
                            if (s[i] == '.')
                            {
                                states = States.W13;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидался символ: .", i);

                        }
                        break;
                    case States.W15:
                        {
                            if (s[i] == '.')
                            {
                                states = States.W13;
                                i++;
                            }
                            else if ((s[i] == ' ') || (s[i] == ';'))
                            {
                                states = States.Y; //выход из операнда
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел, '.' или ';'", i);
                        }
                        break;

                    case States.X:
                        {
                            if (s[i] == ' ') { i++; }
                            else if (s[i] == ')')
                            {
                                states = States.Y;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел или ')'", i);
                        }
                        break;
                //;
                    case States.Y:
                        {
                            if (s[i] == ' ') { i++; }
                            else if (s[i] == ';')
                            {
                                states = States.F;
                                i++;
                            }
                            else throw new ExceptionWithPosition("Ожидались символы: пробел или ';'", i);
                        }
                        break;
                    case States.F:
                        {
                            if (i != s.Length) 
                            {
                                throw new ExceptionWithPosition("Ожидался конец строки", i);
                            }
                        }
                        break;
                }
            }
            if (states != States.F)
            {
                throw new ExceptionWithPosition("Ожидался символ: ;", i);
            }
            string result = "Строка правильная!";
            return result;
        }
    }
}
