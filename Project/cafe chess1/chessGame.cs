using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace cafe_chess1
{
    public class chessGame
    {
        public static int button_number;
        public static string[] c;
        public static int[] indxed;
        Player Players;
        public chessGame()
        {
            c = new string[65];
            indxed = new int[65];
            c[1] = c[8] = c[57] = c[64] = "Rook";
            c[2] = c[7] = c[58] = c[63] = "Knight";
            c[3] = c[6] = c[59] = c[62] = "Bishop";
            c[4] = c[60] = "Queen";
            c[5] = c[61] = "King";
            for (int i = 9; i <= 16; i++)
                c[i] = "Pawn";
            for (int i = 49; i <= 56; i++)
                c[i] = "Pawn";
            for (int i = 17; i <= 48; i++)
                c[i] = null;
            for (int i = 1; i <= 16; i++)
                indxed[i] = 2;
            for (int i = 49; i <= 64; i++)
                indxed[i] = 1;
            for (int i = 17; i <= 48; i++)
                indxed[i] = 0;
        }
        public chessGame(Player p1)
        {
            this.Players = p1;
        }
       public int all_possible_move(int button_number, int[] arr)
        {
           return this.Players.all_possible_move(button_number, arr);
        }
        public int all_possible_move_for_king(int button_number, int[] arr)
        {
            return this.Players.all_possible_move_for_king(button_number, arr);
        }
        public bool move_OR_kill(int button_number1, int button_number2, int x, int[] arr) 
        {
            return this.Players.move_OR_kill(button_number1, button_number2, x, arr);
        }
    }
    public interface Player
    {
       int all_possible_move(int button_number, int[] arr);
        int all_possible_move_for_king(int button_number, int[] arr);
        bool move_OR_kill(int button_number1, int button_number2, int x, int[] arr);
    }
    public class Pawn : Player
    {
        public bool[] array_of_postion1;
        public bool[] array_of_postion;
        public Pawn()
        {
            array_of_postion = new bool[65];
            array_of_postion1 = new bool[65];
            for (int i = 9; i <= 16; i++)
                array_of_postion[i] = true;
            for (int i = 49; i <= 57; i++)
                array_of_postion1[i] = true;
        }
        public bool check_piece(int index)
        {
            if (chessGame.c[index] == "Pawn")
                return true;
            return false;
        }
        public int all_possible_move(int button_number, int[] arr)
        {
            
            int i = 0;
            if (check_piece(button_number))
            {
                if (chessGame.indxed[button_number] == 2)
                {
                    if (button_number + 8 <= 64 && chessGame.c[button_number + 8] == null)
                    {
                        arr[i] = (button_number + 8);
                        i++;
                        if (button_number + 16 <= 64 && chessGame.c[button_number + 16] == null && array_of_postion[button_number])
                        {
                            arr[i] = (button_number + 16); i++;
                        }

                    }
                    if (button_number + 9 <= 64 && chessGame.c[button_number + 9] != null && button_number % 8 != 0 && chessGame.indxed[button_number + 9] != 2)
                    {
                        arr[i] = (button_number + 9);
                        i++;
                    }
                    if (button_number + 7 <= 64 && chessGame.c[button_number + 7] != null && (button_number - 1) % 8 != 0 && chessGame.indxed[button_number + 7] != 2)
                    {
                        arr[i] = (button_number + 7);
                        i++;
                    }
                }
                else
                {
                    if (button_number - 8 >= 1 && chessGame.c[button_number - 8] == null)
                    {
                        arr[i] = (button_number - 8);
                        i++;
                        if (button_number - 16 >= 1 && chessGame.c[button_number - 16] == null && array_of_postion1[button_number])
                        {
                            arr[i] = (button_number - 16); i++;
                        }
                    }
                    if (button_number - 9 >= 1 && chessGame.c[button_number - 9] != null && (button_number - 1) % 8 != 0 && chessGame.indxed[button_number - 9] != 1)
                    {
                        arr[i] = (button_number - 9);
                        i++;
                    }
                    if (button_number - 7 >= 1 && chessGame.c[button_number - 7] != null && button_number % 8 != 0 && chessGame.indxed[button_number - 7] != 1)
                    {
                        arr[i] = (button_number - 7);
                        i++;
                    }
                }
            }
            return i;
        }
        public bool move_OR_kill(int button_number1, int button_number2, int x, int[] arr)
        {
            for (int i = 0; i < x; i++)
            {
                if (button_number2 == arr[i])
                {

                    chessGame.c[button_number2] = chessGame.c[button_number1];
                    chessGame.c[button_number1] = null;
                    chessGame.indxed[button_number2] = chessGame.indxed[button_number1];
                    chessGame.indxed[button_number1] = 0;
                    return true;
                }
            }
            return false;
            // hena bat4k 3la en elzorar ely ana dost 3le mn demn elamakn ely elmafrod yemshy 3leh
        }
        public int all_possible_move_for_king(int button_number, int[] arr)
        {
            int i = 0;
            if (check_piece(button_number))
            {
                if (chessGame.indxed[button_number] == 2)
                {
                    if (button_number + 8 <= 64 && chessGame.c[button_number + 8] == null)
                    {
                        arr[i] = (button_number + 8);
                        i++;
                        if (button_number + 16 <= 64 && chessGame.c[button_number + 16] == null && array_of_postion[button_number])
                        {
                            arr[i] = (button_number + 16); i++;
                        }

                    }
                    if (button_number + 9 <= 64 && chessGame.c[button_number + 9] != null && button_number % 8 != 0 && chessGame.indxed[button_number + 9] != 2)
                    {
                        arr[i] = (button_number + 9);
                        i++;
                    }
                    if (button_number + 7 <= 64 && chessGame.c[button_number + 7] != null && (button_number - 1) % 8 != 0 && chessGame.indxed[button_number + 7] != 2)
                    {
                        arr[i] = (button_number + 7);
                        i++;
                    }
                }
                else
                {
                    if (button_number - 8 >= 1 && chessGame.c[button_number - 8] == null)
                    {
                        arr[i] = (button_number - 8);
                        i++;
                        if (button_number - 16 >= 1 && chessGame.c[button_number - 16] == null && array_of_postion1[button_number])
                        {
                            arr[i] = (button_number - 16); i++;
                        }
                    }
                    if (button_number - 9 >= 1 && chessGame.c[button_number - 9] != null && (button_number - 1) % 8 != 0 && chessGame.indxed[button_number - 9] != 1)
                    {
                        arr[i] = (button_number - 9);
                        i++;
                    }
                    if (button_number - 7 >= 1 && chessGame.c[button_number - 7] != null && button_number % 8 != 0 && chessGame.indxed[button_number - 7] != 1)
                    {
                        arr[i] = (button_number - 7);
                        i++;
                    }
                }
            }
            return i;
        }
    }
    public class Knight : Player
    {
        public bool check_piece(int index)
        {
            if (chessGame.c[index] == "Knight")
                return true;
            return false;
        }
        public int all_possible_move(int button_number, int[] arr)
        {
            int i = 0;
            if (check_piece(button_number))
            {
                // 8 postions maximum for knight
                int row1 = button_number / 8;
                if (button_number % 8 != 0)
                    row1++;
                if (button_number + 10 <= 64 && ((chessGame.c[button_number + 10] == null) || (chessGame.indxed[button_number + 10] != chessGame.indxed[button_number])))
                {
                    int row2 = (button_number + 10) / 8;
                    if ((button_number + 10) % 8 != 0)
                        row2++;
                    if (row2 - row1 == 1)
                    {
                        arr[i] = (button_number + 10);
                        i++;
                    }
                }
                if (button_number + 6 <= 64 && ((chessGame.c[button_number + 6] == null) || (chessGame.indxed[button_number + 6] != chessGame.indxed[button_number])))
                {
                    int row2 = (button_number + 6) / 8;
                    if ((button_number + 6) % 8 != 0)
                        row2++;
                    if (row2 - row1 == 1)
                    {
                        arr[i] = (button_number + 6);
                        i++;
                    }
                }
                if (button_number + 17 <= 64 && ((chessGame.c[button_number + 17] == null) || (chessGame.indxed[button_number + 17] != chessGame.indxed[button_number])))
                {
                    int row2 = (button_number + 17) / 8;
                    if ((button_number + 17) % 8 != 0)
                        row2++;
                    if (row2 - row1 == 2)
                    {
                        arr[i] = (button_number + 17);
                        i++;
                    }
                }
                if (button_number + 15 <= 64 && ((chessGame.c[button_number + 15] == null) || (chessGame.indxed[button_number + 15] != chessGame.indxed[button_number])))
                {
                    int row2 = (button_number + 15) / 8;
                    if ((button_number + 15) % 8 != 0)
                        row2++;
                    if (row2 - row1 == 2)
                    {
                        arr[i] = (button_number + 15);
                        i++;
                    }
                }
                if (button_number - 10 >= 1 && ((chessGame.c[button_number - 10] == null) || (chessGame.indxed[button_number - 10] != chessGame.indxed[button_number])))
                {
                    int row2 = (button_number - 10) / 8;
                    if ((button_number - 10) % 8 != 0)
                        row2++;
                    if (row1 - row2 == 1)
                    {
                        arr[i] = (button_number - 10);
                        i++;
                    }
                }
                if (button_number - 6 >= 1 && ((chessGame.c[button_number - 6] == null) || (chessGame.indxed[button_number - 6] != chessGame.indxed[button_number])))
                {
                    int row2 = (button_number - 6) / 8;
                    if ((button_number - 6) % 8 != 0)
                        row2++;
                    if (row1 - row2 == 1)
                    {
                        arr[i] = (button_number - 6);
                        i++;
                    }
                }
                if (button_number - 17 >= 1 && ((chessGame.c[button_number - 17] == null) || (chessGame.indxed[button_number - 17] != chessGame.indxed[button_number])))
                {
                    int row2 = (button_number - 17) / 8;
                    if ((button_number - 17) % 8 != 0)
                        row2++;
                    if (row1 - row2 == 2)
                    {
                        arr[i] = (button_number - 17);
                        i++;
                    }
                }
                if (button_number - 15 >= 1 && ((chessGame.c[button_number - 15] == null) || (chessGame.indxed[button_number - 15] != chessGame.indxed[button_number])))
                {
                    int row2 = (button_number - 15) / 8;
                    if ((button_number - 15) % 8 != 0)
                        row2++;
                    if (row1 - row2 == 2)
                    {
                        arr[i] = (button_number - 15);
                        i++;
                    }
                }
            }
            return i;
        }
        public int all_possible_move_for_king(int button_number, int[] arr)
        {
            int i = 0;
            if (check_piece(button_number))
            {
                // 8 postions maximum for knight
                int row1 = button_number / 8;
                if (button_number % 8 != 0)
                    row1++;
                if (button_number + 10 <= 64 && ((chessGame.c[button_number + 10] == null) || (chessGame.indxed[button_number + 10] == chessGame.indxed[button_number])))
                {
                    int row2 = (button_number + 10) / 8;
                    if ((button_number + 10) % 8 != 0)
                        row2++;
                    if (row2 - row1 == 1)
                    {
                        arr[i] = (button_number + 10);
                        i++;
                    }
                }
                if (button_number + 6 <= 64 && ((chessGame.c[button_number + 6] == null) || (chessGame.indxed[button_number + 6] == chessGame.indxed[button_number])))
                {
                    int row2 = (button_number + 6) / 8;
                    if ((button_number + 6) % 8 != 0)
                        row2++;
                    if (row2 - row1 == 1)
                    {
                        arr[i] = (button_number + 6);
                        i++;
                    }
                }
                if (button_number + 17 <= 64 && ((chessGame.c[button_number + 17] == null) || (chessGame.indxed[button_number + 17] == chessGame.indxed[button_number])))
                {
                    int row2 = (button_number + 17) / 8;
                    if ((button_number + 17) % 8 != 0)
                        row2++;
                    if (row2 - row1 == 2)
                    {
                        arr[i] = (button_number + 17);
                        i++;
                    }
                }
                if (button_number + 15 <= 64 && ((chessGame.c[button_number + 15] == null) || (chessGame.indxed[button_number + 15] == chessGame.indxed[button_number])))
                {
                    int row2 = (button_number + 15) / 8;
                    if ((button_number + 15) % 8 != 0)
                        row2++;
                    if (row2 - row1 == 2)
                    {
                        arr[i] = (button_number + 15);
                        i++;
                    }
                }
                if (button_number - 10 >= 1 && ((chessGame.c[button_number - 10] == null) || (chessGame.indxed[button_number - 10] == chessGame.indxed[button_number])))
                {
                    int row2 = (button_number - 10) / 8;
                    if ((button_number - 10) % 8 != 0)
                        row2++;
                    if (row1 - row2 == 1)
                    {
                        arr[i] = (button_number - 10);
                        i++;
                    }
                }
                if (button_number - 6 >= 1 && ((chessGame.c[button_number - 6] == null) || (chessGame.indxed[button_number - 6] == chessGame.indxed[button_number])))
                {
                    int row2 = (button_number - 6) / 8;
                    if ((button_number - 6) % 8 != 0)
                        row2++;
                    if (row1 - row2 == 1)
                    {
                        arr[i] = (button_number - 6);
                        i++;
                    }
                }
                if (button_number - 17 >= 1 && ((chessGame.c[button_number - 17] == null) || (chessGame.indxed[button_number - 17] == chessGame.indxed[button_number])))
                {
                    int row2 = (button_number - 17) / 8;
                    if ((button_number - 17) % 8 != 0)
                        row2++;
                    if (row1 - row2 == 2)
                    {
                        arr[i] = (button_number - 17);
                        i++;
                    }
                }
                if (button_number - 15 >= 1 && ((chessGame.c[button_number - 15] == null) || (chessGame.indxed[button_number - 15] == chessGame.indxed[button_number])))
                {
                    int row2 = (button_number - 15) / 8;
                    if ((button_number - 15) % 8 != 0)
                        row2++;
                    if (row1 - row2 == 2)
                    {
                        arr[i] = (button_number - 15);
                        i++;
                    }
                }
            }
            return i;
        }
        public bool move_OR_kill(int button_number1, int button_number2, int x, int[] arr)
        {
            for (int i = 0; i < x; i++)
            {
                if (button_number2 == arr[i])
                {
                    chessGame.c[button_number2] =chessGame.c[button_number1];
                    chessGame.c[button_number1] = null;
                    chessGame.indxed[button_number2] = chessGame.indxed[button_number1];
                    chessGame.indxed[button_number1] = 0;
                    return true;
                }
            }
            return false;
            // hena bat4k 3la en elzorar ely ana dost 3le mn demn elamakn ely elmafrod yemshy 3leh
        }

    }
    public class Bishop : Player
    {
        public bool check_piece(int index)
        {
            if (chessGame.c[index] == "Bishop" || chessGame.c[index] == "Queen")
                return true;
            return false;
        }
        public int all_possible_move(int button_number, int[] arr)
        {
            int i = 0;
            int x = button_number;
            if (check_piece(button_number))
            {
                while ((x + 9) % 8 != 1 && x + 9 <= 64 && (chessGame.c[x + 9] == null || chessGame.indxed[x + 9] != chessGame.indxed[button_number]))
                {
                    arr[i] = x + 9;
                    i++;
                    if (chessGame.c[x + 9] != null)
                        break;
                    x += 9;
                }
                x = button_number;
                while ((x - 9) % 8 != 0 && x - 9 > 0 && (chessGame.c[x - 9] == null || chessGame.indxed[x - 9] != chessGame.indxed[button_number]))
                {
                    arr[i] = x - 9;
                    i++;
                    if (chessGame.c[x - 9] != null)
                        break;
                    x -= 9;
                }

                x = button_number;
                while ((x + 7) % 8 != 0 && x + 7 <= 64 && (chessGame.c[x + 7] == null || chessGame.indxed[x + 7] != chessGame.indxed[button_number]))
                {
                    arr[i] = x + 7;
                    i++;
                    if (chessGame.c[x + 7] != null)
                        break;
                    x += 7;

                }
                x = button_number;
                while ((x - 7) % 8 != 1 && x - 7 > 0 && (chessGame.c[x - 7] == null || chessGame.indxed[x - 7] != chessGame.indxed[button_number]))
                {
                    arr[i] = x - 7;
                    i++;
                    if (chessGame.c[x - 7] != null)
                        break;
                    x -= 7;
                }
            }
            return i;
        }
        public int all_possible_move_for_king(int button_number, int[] arr)
        {
            int i = 0;
            int x = button_number;
            if (check_piece(button_number))
            {
                while ((x + 9) % 8 != 1 && x + 9 <= 64)
                {
                    arr[i] = x + 9;
                    i++;
                    if (chessGame.c[x + 9] != null)
                    {
                        x += 9;
                        if ((x + 9) % 8 != 1 && x + 9 <= 64 && chessGame.c[x] == "King" && chessGame.indxed[button_number] != chessGame.indxed[x])
                        {

                            arr[i] = x + 9;
                            i++;
                        }
                        break;
                    }
                    x += 9;
                }
                x = button_number;
                while ((x - 9) % 8 != 0 && x - 9 > 0)
                {
                    arr[i] = x - 9;
                    i++;
                    if (chessGame.c[x - 9] != null)
                    {
                        x -= 9;
                        if ((x - 9) % 8 != 0 && x - 9 > 0 && chessGame.c[x] == "King" && chessGame.indxed[button_number] != chessGame.indxed[x])
                        {
                            arr[i] = x - 9;
                            i++;
                        }
                        break;
                    }
                    x -= 9;
                }
                x = button_number;
                while ((x + 7) % 8 != 0 && x + 7 <= 64)
                {
                    arr[i] = x + 7;
                    i++;
                    if (chessGame.c[x + 7] != null)
                    {
                        x += 7;
                        if ((x + 7) % 8 != 0 && x + 7 <= 64 && chessGame.c[x] == "King" && chessGame.indxed[button_number] != chessGame.indxed[x])
                        {
                            arr[i] = x + 7;
                            i++;
                        }
                        break;
                    }
                    x += 7;
                }
                x = button_number;
                while ((x - 7) % 8 != 1 && x - 7 > 0)
                {
                    arr[i] = x - 7;
                    i++;
                    if (chessGame.c[x - 7] != null)
                    {
                        x -= 7;
                        if ((x - 7) % 8 != 1 && x - 7 > 0 && chessGame.c[x] == "King" && chessGame.indxed[button_number] != chessGame.indxed[x])
                        {
                            arr[i] = x - 7;
                            i++;
                        }
                        break;
                    }
                    x -= 7;
                }
            }
            return i;
        }
        public bool move_OR_kill(int button_number1, int button_number2, int x, int[] arr)
        {
            for (int i = 0; i < x; i++)
            {
                if (button_number2 == arr[i])
                {
                    chessGame.c[button_number2] = chessGame.c[button_number1];
                    chessGame.c[button_number1] = null;
                    chessGame.indxed[button_number2] = chessGame.indxed[button_number1];
                    chessGame.indxed[button_number1] = 0;
                    return true;
                }
            }
            return false;
            // hena bat4k 3la en elzorar ely ana dost 3le mn demn elamakn ely elmafrod yemshy 3leh
        }
    }
    public class Rook : Player
    {
        public bool check_piece(int index)
        {
            if (chessGame.c[index] == "Rook" || chessGame.c[index] == "Queen")
                return true;
            return false;
        }
        public int all_possible_move(int button_number, int[] arr)
        {
            int i = 0;
            int but = button_number;
            if (check_piece(button_number))
            {
                if (but % 8 != 0) // Move right
                {
                    while (but % 8 != 0)
                    {
                        but++;
                        if (chessGame.c[but] == null || chessGame.indxed[button_number] != chessGame.indxed[but])
                        {
                            arr[i] = but;
                            i++;
                        }
                        if (chessGame.c[but] != null)
                            break;
                    }
                }
                but = button_number;
                if (but % 8 != 1) // Move left
                {
                    while (but % 8 != 1)
                    {
                        but--;
                        if (chessGame.c[but] == null || chessGame.indxed[button_number] != chessGame.indxed[but])
                        {
                            arr[i] = but;
                            i++;
                        }
                        if (chessGame.c[but] != null)
                            break;
                    }
                }
                but = button_number;
                while (but + 8 <= 64) // move down 
                {
                    but += 8;
                    if (chessGame.c[but] == null || chessGame.indxed[button_number] != chessGame.indxed[but])
                    {
                        arr[i] = but;
                        i++;
                    }
                    if (chessGame.c[but] != null)
                        break;
                }
                but = button_number;
                while (but - 8 >= 1) // move up
                {
                    but -= 8;
                    if (chessGame.c[but] == null || chessGame.indxed[button_number] != chessGame.indxed[but])
                    {
                        arr[i] = but;
                        i++;
                    }
                    if (chessGame.c[but] != null)
                        break;
                }
            }
            return i;
        }
        public int all_possible_move_for_king(int button_number, int[] arr)
        {
            int i = 0;
            int but = button_number;
            if (check_piece(button_number))
            {
                if (but % 8 != 0) // Move right
                {
                    while (but % 8 != 0)
                    {
                        but++;
                        arr[i] = but;
                        i++;
                        if (chessGame.c[but] != null)
                        {
                            but++;
                            if (but % 8 != 1 && but <= 64 && chessGame.c[but - 1] == "King" && chessGame.indxed[button_number] != chessGame.indxed[but - 1])
                            {
                                arr[i] = but;
                                i++;
                            }
                            break;
                        }
                    }
                }
                but = button_number;
                if (but % 8 != 1) // Move left
                {
                    while (but % 8 != 1)
                    {
                        but--;
                        arr[i] = but;
                        i++;
                        if (chessGame.c[but] != null)
                        {
                            but--;
                            if (but % 8 != 0 && but > 0 && chessGame.c[but + 1] == "King" && chessGame.indxed[button_number] != chessGame.indxed[but + 1])
                            {
                                arr[i] = but;
                                i++;
                            }
                            break;
                        }
                    }
                }
                but = button_number;
                while (but + 8 <= 64) // move down 
                {
                    but += 8;
                    arr[i] = but;
                    i++;
                    if (chessGame.c[but] != null)
                    {
                        but += 8;
                        if (but <= 64 && chessGame.c[but - 8] == "King" && chessGame.indxed[button_number] != chessGame.indxed[but - 8])
                        {
                            arr[i] = but;
                            i++;
                        }
                        break;
                    }
                }
                but = button_number;
                while (but - 8 >= 1) // move up
                {
                    but -= 8;
                    arr[i] = but;
                    i++;
                    if (chessGame.c[but] != null)
                    {
                        but -= 8;
                        if (but > 0 && chessGame.c[but + 8] == "King" && chessGame.indxed[button_number] != chessGame.indxed[but + 8])
                        {
                            arr[i] = but;
                            i++;
                        }
                        break;
                    }
                }
            }
            return i;
        }
        public bool move_OR_kill(int button_number1, int button_number2, int x, int[] arr)
        {
            for (int i = 0; i < x; i++)
            {
                if (button_number2 == arr[i])
                {
                    chessGame.c[button_number2] = chessGame.c[button_number1];
                    chessGame.c[button_number1] = null;
                    chessGame.indxed[button_number2] = chessGame.indxed[button_number1];
                    chessGame.indxed[button_number1] = 0;
                    return true;
                }
            }
            return false;
            // hena bat4k 3la en elzorar ely ana dost 3le mn demn elamakn ely elmafrod yemshy 3leh
        }
    }
    public class Queen : Player
    {
        Rook r = new Rook();
        Bishop b = new Bishop();
        public bool check_piece(int index)
        {
            if (chessGame.c[index] == "Queen")
                return true;
            return false;
        }
        public int all_possible_move(int button_number, int[] arr)
        {
            int[] arr2 = new int[65];
            int x = r.all_possible_move(button_number, arr2);
            for (int j = 0; j < x; j++)
                arr[j] = arr2[j];
            int i = x;
            x = b.all_possible_move(button_number, arr2);
            for (int j = 0; j < x; j++)
            {
                arr[i] = arr2[j];
                i++;
            }
            return i;
        }
        public int all_possible_move_for_king(int button_number, int[] arr)
        {
            int[] arr2 = new int[65];
            int x = r.all_possible_move_for_king(button_number, arr2);
            for (int j = 0; j < x; j++)
                arr[j] = arr2[j];
            int i = x;
            x = b.all_possible_move_for_king(button_number, arr2);
            for (int j = 0; j < x; j++)
            {
                arr[i] = arr2[j];
                i++;
            }
            return i;
        }
        public bool move_OR_kill(int button_number1, int button_number2, int x, int[] arr)
        {
            for (int i = 0; i < x; i++)
            {
                if (button_number2 == arr[i])
                {
                    chessGame.c[button_number2] = chessGame.c[button_number1];
                    chessGame.c[button_number1] = null;
                    chessGame.indxed[button_number2] = chessGame.indxed[button_number1];
                    chessGame.indxed[button_number1] = 0;
                    return true;
                }
            }
            return false;
            // hena bat4k 3la en elzorar ely ana dost 3le mn demn elamakn ely elmafrod yemshy 3leh
        }
    }
    public class King : Player
    {
        public int[] arr;
        public int[] enemy;
        public static int king1;
        public static int king2;
        public int var;
        int button_numberx;
        Pawn p1 = new Pawn();
        Bishop p2 = new Bishop();
        Knight p3 = new Knight();
        Rook p4 = new Rook();
        Queen p5 = new Queen();
        public King()
        {
            arr = new int[90];
            enemy = new int[90];
        }
        public bool check_piece(int index)
        {
            if (chessGame.c[index] == "King")
                return true;
            return false;
        }
        public int all_possible_move_for_king(int button_number, int[] arr)
        {
            return 1;
        }
        public int all_possible_move(int button_number, int[] arr)
        {
            int i = 0;
             enemy_move(button_number, enemy, 0, -1); // -1 or -55415454524524
             if (button_number + 8 <= 64 && enemy[button_number + 8] == 0 && ((chessGame.c[button_number + 8] == null) || (chessGame.indxed[button_number] != chessGame.indxed[button_number + 8])))
            {
                arr[i] = button_number + 8;
                i++;
            }
             if (button_number - 8 >= 1 && enemy[button_number - 8] == 0 && ((chessGame.c[button_number - 8] == null) || (chessGame.indxed[button_number] != chessGame.indxed[button_number - 8])))
            {
                arr[i] = button_number - 8;
                i++;
            }
             if (button_number + 1 <= 64 && button_number % 8 != 0 && enemy[button_number + 1] == 0 && (chessGame.c[button_number + 1] == null || chessGame.indxed[button_number] != chessGame.indxed[button_number + 1]))
            {
                arr[i] = button_number + 1;
                i++;
            }
             if (button_number - 1 >= 1 && button_number % 8 != 1 && enemy[button_number - 1] == 0 && (chessGame.c[button_number - 1] == null || chessGame.indxed[button_number] != chessGame.indxed[button_number - 1]))
            {
                arr[i] = button_number - 1;
                i++;
            }
            ///////////////////////////////////////////////////////////////////////////////////////
             if (button_number + 9 <= 64 && button_number % 8 != 0 && enemy[button_number + 9] == 0 && (chessGame.c[button_number + 9] == null || chessGame.indxed[button_number] != chessGame.indxed[button_number + 9]))
            {
                arr[i] = button_number + 9;
                i++;
            }
             if (button_number + 7 <= 64 && button_number % 8 != 1 && enemy[button_number + 7] == 0 && (chessGame.c[button_number + 7] == null || chessGame.indxed[button_number] != chessGame.indxed[button_number + 7]))
            {
                arr[i] = button_number + 7;
                i++;
            }
             if (button_number - 9 >= 1 && button_number % 8 != 1 && enemy[button_number - 9] == 0 && (chessGame.c[button_number - 9] == null || chessGame.indxed[button_number] != chessGame.indxed[button_number - 9]))
            {
                arr[i] = button_number - 9;
                i++;
            }
             if (button_number - 7 >= 1 && button_number % 8 != 0 && enemy[button_number - 7] == 0 && (chessGame.c[button_number - 7] == null || chessGame.indxed[button_number] != chessGame.indxed[button_number - 7]))
            {
                arr[i] = button_number - 7;
                i++;
            }
            return i;
        }
        public void enemy_move(int button_number, int[] enemy, int a, int cc)
        {
            int[] arr = new int[70];
            int x;
            for (int i = 1; i <= 75; i++)
                enemy[i] = 0; // =D :)
            if (chessGame.indxed[button_number] == 1 || cc == 1)
            {
                for (int i = 1; i <= 64; i++)
                {
                    if (chessGame.indxed[i] == 2)
                    {
                        if (chessGame.c[i] == "Pawn")
                        {
                            if (i % 8 != 1 && i + 9 <= 64)
                                enemy[i + 9] = 1;
                            if (i % 8 != 0 && i + 7 >= 1)
                                enemy[i + 7] = 1;
                        }
                        else if (chessGame.c[i] == "Bishop")
                        {
                            if (a == 1)
                                x = p2.all_possible_move(i, arr);
                            else
                                x = p2.all_possible_move_for_king(i, arr);
                            for (int j = 0; j < x; j++)
                                enemy[arr[j]] = 1;
                        }
                        else if (chessGame.c[i] == "Knight")
                        {
                            if(a==1)
                                x = p3.all_possible_move(i, arr);
                            else
                                x = p3.all_possible_move_for_king(i, arr);
                            for (int j = 0; j < x; j++)
                                enemy[arr[j]] = 1;
                        }
                        else if (chessGame.c[i] == "Rook")
                        {
                            if (a == 1)
                                x = p4.all_possible_move(i, arr);
                            else
                                x = p4.all_possible_move_for_king(i, arr);
                            for (int j = 0; j < x; j++)
                                enemy[arr[j]] = 1;
                        }
                        else if (chessGame.c[i] == "Queen")
                        {
                            if (a == 1)
                                x = p5.all_possible_move(i, arr);
                            else
                                x = p5.all_possible_move_for_king(i, arr);
                            for (int j = 0; j < x; j++)
                                enemy[arr[j]] = 1;
                        }
                        else if (chessGame.c[i] == "King")
                        {
                            enemy[i + 8] = 1;
                            enemy[i + 9] = 1;
                            enemy[i + 7] = 1;
                            enemy[i + 1] = 1;
                              if(i-7 >= 1)
                                  enemy[i - 7] = 1;
                              if (i - 1 >= 1)
                                  enemy[i - 1] = 1;
                              if (i - 9 >= 1)
                                  enemy[i - 9] = 1;
                              if (i - 8 >= 1)
                                  enemy[i - 8] = 1;
                        }
                    }
                }
            }
            else if (chessGame.indxed[button_number] == 2 || cc == 2)
            {
                for (int i = 1; i <= 64; i++)
                {
                    if (chessGame.indxed[i] == 1)
                    {
                        if (chessGame.c[i] == "Pawn")
                        {
                            x = p1.all_possible_move(i, arr);
                            if (i % 8 != 1 && i - 9 >= 1)
                                enemy[i - 9] = 1;
                            if (i % 8 != 0 && i - 7 >= 1)
                                enemy[i - 7] = 1;
                        }
                        else if (chessGame.c[i] == "Bishop")
                        {
                            if (a == 1)
                                x = p2.all_possible_move(i, arr);
                            else
                                x = p2.all_possible_move_for_king(i, arr);
                            for (int j = 0; j < x; j++)
                                enemy[arr[j]] = 1;
                        }
                        else if (chessGame.c[i] == "Knight")
                        {
                            if (a == 1)
                                x = p3.all_possible_move(i, arr);
                            else
                                x = p3.all_possible_move_for_king(i, arr);
                            for (int j = 0; j < x; j++)
                                enemy[arr[j]] = 1;
                        }
                        else if (chessGame.c[i] == "Rook")
                        {
                            if (a == 1)
                                x = p4.all_possible_move(i, arr);
                            else
                                x = p4.all_possible_move_for_king(i, arr);
                            for (int j = 0; j < x; j++)
                                enemy[arr[j]] = 1;
                        }
                        else if (chessGame.c[i] == "Queen")
                        {
                            if (a == 1)
                                x = p5.all_possible_move(i, arr);
                            else
                                x = p5.all_possible_move_for_king(i, arr);
                            for (int j = 0; j < x; j++)
                                enemy[arr[j]] = 1;
                        }
                        else if (chessGame.c[i] == "King")
                        {
                            enemy[i + 8] = 1;
                            enemy[i + 9] = 1;
                            enemy[i + 7] = 1;
                            enemy[i + 1] = 1;
                            if (i - 7 >= 1)
                                enemy[i - 7] = 1;
                            if (i - 1 >= 1)
                                enemy[i - 1] = 1;
                            if (i - 9 >= 1)
                                enemy[i - 9] = 1;
                            if (i - 8 >= 1)
                                enemy[i - 8] = 1;
                        }
                    }
                }
            }
        }
        public bool Special_Move(int button_number, int[] arr)// دي فانكشن عشان التبيت او التحصين للملك
        {
            int i = 0;
            enemy_move(button_number, enemy, 1, -54554);
            // 4 cases
            if (button_number == 61 && chessGame.indxed[button_number] == 1 && chessGame.indxed[button_number + 1] == 0 && chessGame.indxed[button_number + 2] == 0 && chessGame.indxed[button_number + 3] == 1 && chessGame.c[button_number + 3] == "Rook" && enemy[button_number + 2] == 0 && King.king1 == 0 && enemy[button_number] == 0)
            {
                arr[i] = button_number + 2;
                i++;
            }
            if (button_number == 61 && chessGame.indxed[button_number] == 1 && chessGame.indxed[button_number - 1] == 0 && chessGame.indxed[button_number - 2] == 0 && chessGame.indxed[button_number - 3] == 0 && chessGame.indxed[button_number - 4] == 1 && chessGame.c[button_number - 4] == "Rook" && enemy[button_number - 2] == 0 && King.king1 == 0 && enemy[button_number] == 0)
            {
                arr[i] = button_number - 2;
                i++;
            }
            if (button_number == 5 && chessGame.indxed[button_number] == 2 && chessGame.indxed[button_number + 1] == 0 && chessGame.indxed[button_number + 2] == 0 && chessGame.indxed[button_number + 3] == 2 && chessGame.c[button_number + 3] == "Rook" && enemy[button_number + 2] == 0 && King.king2 == 0 && enemy[button_number] == 0)
            {
                arr[i] = button_number + 2;
                i++;
            }
            if (button_number == 5 && chessGame.indxed[button_number] == 2 && chessGame.indxed[button_number - 1] == 0 && chessGame.indxed[button_number - 2] == 0 && chessGame.indxed[button_number - 3] == 0 && chessGame.indxed[button_number - 4] == 2 && chessGame.c[button_number - 4] == "Rook" && enemy[button_number - 2] == 0 && King.king2 == 0 && enemy[button_number] == 0)
            {
                arr[i] = button_number - 2;
                i++;
            }
            if (i != 0)
                return true;
            return false;
        }
        public bool move_OR_kill(int button_number1, int button_number2, int x, int[] arr)
        {
            for (int i = 0; i < x; i++)
            {
                if (button_number2 == arr[i])
                {
                    if (chessGame.indxed[button_number1] == 1 && King.king1 == 0)
                        King.king1++;
                    else if (chessGame.indxed[button_number1] == 2 && King.king2 == 0)
                        King.king2++;
                    chessGame.c[button_number2] = chessGame.c[button_number1];
                    chessGame.c[button_number1] = null;
                    chessGame.indxed[button_number2] = chessGame.indxed[button_number1];
                    chessGame.indxed[button_number1] = 0;
                    return true;
                }
            }
            return false;
            // hena bat4k 3la en elzorar ely ana dost 3le mn demn elamakn ely elmafrod yemshy 3leh
        }
        public bool test(int button_number)
        {
            for (int i = 1; i <= 64; i++)
                if (chessGame.c[i] == "King" && chessGame.indxed[button_number] == chessGame.indxed[i])
                    button_numberx = i;
            enemy_move(button_number, enemy, 1, var);
            if (enemy[button_numberx] == 1)
                return false;
            return true;
        }
    }
}