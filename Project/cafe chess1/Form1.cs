using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
namespace cafe_chess1
{
    public partial class Form1 : Form
    {
        public bool Check;
        public bool false_vis = false;
        public string variable;
        public int x;
        public int flag;
        public int Start;
        public int number_of_moves = 1;
        public static int postion;
        public int[] arr = new int[100];
        public int[] LIGHT = new int[100];
        public int l = 0;
        public int varr1;
        public int varr2;
        public string ss;
        public int  king_posi;
        int[] arr2 = new int[3]; // for king // عشان التبيت
        public int[] check = new int[65];
        public int CHESS = 0;
        public int BUTTON;
        public static Button[] my_button1 = new Button[65];
        public static Button[] promotion_buttons = new Button[9];
        public chessGame Games,Games1;
        public King p6 = new King();
        public void GAME(int button)
        {
            if (Start == 0)
                return;
            if (CHESS == 0 && my_button1[button].BackgroundImage != null)
            {
                CHESS = 1;
                l = 0;
                flag = 0;
                BUTTON = button;
                Check = false;
                 if (chessGame.c[button] == "King")
                    {
                        Games = new chessGame(new King());
                        x = Games.all_possible_move(button, arr);
                        if (p6.Special_Move(button, arr2) == true)
                        {
                            arr[x] = arr2[0];
                            x++;
                            if (arr2[1] != 0)
                            {
                                arr[x] = arr2[1];
                                x++;
                                flag++;
                            }
                            flag++;
                        }
                        for (int i = 0; i < x; i++)
                            LIGHT[i] = arr[i];
                        l = x;
                        light(LIGHT, l);
                        Check = true;
                    }
                    else if (chessGame.c[button] == "Pawn")
                    {
                        variable = "Pawn";
                        Games=new chessGame(new Pawn());
                        
                    }
                    else if (chessGame.c[button] == "Knight")
                    {
                        variable= "Knight";
                        Games=new chessGame(new Knight());

                    }
                    else if (chessGame.c[button] == "Bishop")
                    {
                        variable= "Bishop";
                        Games=new chessGame(new Bishop());
                    }
                    else if (chessGame.c[button] == "Rook")
                    {
                       variable="Rook";
                       Games=new chessGame(new Rook());
                    }
                    else if (chessGame.c[button] == "Queen")
                    {
                       variable="Queen";
                       Games=new chessGame(new Queen());
                    }
                    if (!Check)
                    {
                        x = Games.all_possible_move(button, arr);
                        Try(button, variable);
                        light(LIGHT, l);
                    }
                   
            }
            else if (CHESS == 1 && (my_button1[button] == null || chessGame.indxed[button] != chessGame.indxed[BUTTON]))
            {
                if (chessGame.c[BUTTON] == "King")
                {
                    if (Games.move_OR_kill(BUTTON, button, l, LIGHT))
                    {
                        my_button1[button].BackgroundImage = my_button1[BUTTON].BackgroundImage;
                        my_button1[BUTTON].BackgroundImage = null;
                        number_of_moves++;
                        // السطور دي كلها عشان التحصين او التبيت
                        if ((arr2[0] == button || arr2[1] == button) && (King.king1 == 1 || King.king2 == 1))
                        {
                            if ((button == 7 && BUTTON == 5) || (button == 63 && BUTTON == 61))
                            {
                                my_button1[BUTTON + 1].BackgroundImage = my_button1[BUTTON + 3].BackgroundImage;
                                my_button1[BUTTON + 3].BackgroundImage = null;
                                chessGame.c[BUTTON + 3] = null;
                                chessGame.c[BUTTON + 1] = "Rook";
                                chessGame.indxed[BUTTON + 3] = 0;
                                if (BUTTON == 5)
                                    chessGame.indxed[BUTTON + 1] = 2;
                                else
                                    chessGame.indxed[BUTTON + 1] = 1;
                            }
                            else if ((button == 3 && BUTTON == 5) || (button == 59 && BUTTON == 61))
                            {
                                my_button1[BUTTON - 1].BackgroundImage = my_button1[BUTTON - 4].BackgroundImage;
                                my_button1[BUTTON - 4].BackgroundImage = null;
                                chessGame.c[BUTTON - 4] = null;
                                chessGame.c[BUTTON - 1] = "Rook";
                                chessGame.indxed[BUTTON - 4] = 0;
                                if (BUTTON == 5)
                                    chessGame.indxed[BUTTON - 1] = 2;
                                else
                                    chessGame.indxed[BUTTON - 1] = 1;
                            }
                        }
                    }
                   BackColor_HandlePlayer(LIGHT, l);
                }
                else
                {
                    int warn_red = 0;
                    if (Games.move_OR_kill(BUTTON, button, l, LIGHT))
                    {
  
                            warn_red = 1;
                        my_button1[button].BackgroundImage = my_button1[BUTTON].BackgroundImage;
                        my_button1[BUTTON].BackgroundImage = null;
                        number_of_moves++;
                        postion = button; 

                    }
                    if (warn_red == 1)
                    {
                       BackColor_HandlePlayer(LIGHT, l);
                        convert(button, BUTTON);
                        warn_red = 0;
                    }
                    else
                       BackColor_HandlePlayer(LIGHT,l);
                }
                if (number_of_moves % 2 == 1)
                    End_game(1);
                else if (number_of_moves % 2 == 0)
                    End_game(2);
                Draw();
                BUTTON = button;
                CHESS = 0;
            }
            else if (CHESS == 1)
            {
               BackColor_HandlePlayer(LIGHT, l);
                BUTTON = button;
                CHESS = 0;
            }
        }
        public void Function_Button()
        {
            my_button1[1] = button1;
            my_button1[2] = button2;
            my_button1[3] = button3;
            my_button1[4] = button4;
            my_button1[5] = button5;
            my_button1[6] = button6;
            my_button1[7] = button7;
            my_button1[8] = button8;
            my_button1[9] = button9;
            my_button1[10] = button10;
            my_button1[11] = button11;
            my_button1[12] = button12;
            my_button1[13] = button13;
            my_button1[14] = button14;
            my_button1[15] = button15;
            my_button1[16] = button16;
            my_button1[17] = button17;
            my_button1[18] = button18;
            my_button1[19] = button19;
            my_button1[20] = button20;
            my_button1[21] = button21;
            my_button1[22] = button22;
            my_button1[23] = button23;
            my_button1[24] = button24;
            my_button1[25] = button25;
            my_button1[26] = button26;
            my_button1[27] = button27;
            my_button1[28] = button28;
            my_button1[29] = button29;
            my_button1[30] = button30;
            my_button1[31] = button31;
            my_button1[32] = button32;
            my_button1[33] = button33;
            my_button1[34] = button34;
            my_button1[35] = button35;
            my_button1[36] = button36;
            my_button1[37] = button37;
            my_button1[38] = button38;
            my_button1[39] = button39;
            my_button1[40] = button40;
            my_button1[41] = button41;
            my_button1[42] = button42;
            my_button1[43] = button43;
            my_button1[44] = button44;
            my_button1[45] = button45;
            my_button1[46] = button46;
            my_button1[47] = button47;
            my_button1[48] = button48;
            my_button1[49] = button49;
            my_button1[50] = button50;
            my_button1[51] = button51;
            my_button1[52] = button52;
            my_button1[53] = button53;
            my_button1[54] = button54;
            my_button1[55] = button55;
            my_button1[56] = button56;
            my_button1[57] = button57;
            my_button1[58] = button58;
            my_button1[59] = button59;
            my_button1[60] = button60;
            my_button1[61] = button61;
            my_button1[62] = button62;
            my_button1[63] = button63;
            my_button1[64] = button64;
            promotion_buttons[1] = button71;
            promotion_buttons[2] = button72;
            promotion_buttons[3] = button73;
            promotion_buttons[4] = button74;
            promotion_buttons[5] = button75;
            promotion_buttons[6] = button76;
            promotion_buttons[7] = button77;
            promotion_buttons[8] = button78;
        }
        public void Set(int[] arr)//Set, Set Check Back peieces Color White,Color Black.
        {
            int j = 1, counter = 1;
            for (int i = 1; i <= 64; i++)
            {
                if (counter + 8 == i)
                {
                    counter += 8;
                    j++;
                }
                arr[i] = j;
            }
        }
        public Form1()
        {
            InitializeComponent();
            Function_Button();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           //SoundPlayer game_music = new SoundPlayer("D:\\Music.wav");
           //game_music.Play();
            for (int i = 1; i <= 64; i++)
                my_button1[i].Visible = false;
            for (int i = 1; i <= 8; i++)
                promotion_buttons[i].Visible = false;
            button65.Visible = false;
            button66.Visible = false;
            button67.Visible = true;
            button68.Visible = true;
            button69.Visible = true;
            button70.Visible = false;
            button79.Visible = false;
            button80.Visible = false;
            button81.Visible = false;
            button82.Visible = false;
            button83.Visible = false;
            chessGame c = new chessGame();
        } 
        public void light(int[] arr1, int size)
        {
            for (int i = 0; i < size; i++)
            {
                // if & else if ----> عشان مربع تحصين الملك يلون بلون مختلف عن الطبيعي لانها حركة خاصة للملك
                if ((flag == 1 && i == size - 1) || (flag == 2 && (i == size - 1 || i == size - 2)))
                {
                    my_button1[arr1[i]].FlatAppearance.BorderSize = 10;
                    my_button1[arr1[i]].FlatAppearance.BorderColor = Color.GreenYellow;
                }
                else
                {
                    my_button1[arr1[i]].FlatAppearance.BorderSize = 10;
                    my_button1[arr1[i]].FlatAppearance.BorderColor = Color.Yellow;
                }
            }
        }
        public void BackColor_HandlePlayer(int[] arr1, int size) //Function Set Work back Color peieces.
        {
            
       
            if (number_of_moves % 2 == 1)
            {
                button79.FlatAppearance.BorderSize = 7;
                button80.FlatAppearance.BorderSize = 0;
                button79.FlatAppearance.BorderColor = Color.YellowGreen;
            }
            if (number_of_moves % 2 == 0)
            {
                button80.FlatAppearance.BorderSize = 7;
                button79.FlatAppearance.BorderSize = 0;
                button80.FlatAppearance.BorderColor = Color.YellowGreen;
            }

            Set(check); // CaLL Function Set array of int check.
            for (int i = 0; i < size; i++)
            {
                if (check[arr1[i]] % 2 == 0)     //if check[arr1[i]] is even ,if arr1[i] is even Color_Back,else arr1[i] is odd Color_White : else check[arr1[i]] is odd ,if arr1[i] is even Color_White,else Color_black
                {
                    if (arr1[i] % 2 == 0)
                    {
                        my_button1[arr1[i]].FlatAppearance.BorderSize = 0;
                        my_button1[arr1[i]].FlatAppearance.BorderColor = Color.Peru;
                    }
                    else
                    {
                        my_button1[arr1[i]].FlatAppearance.BorderSize = 0;
                        my_button1[arr1[i]].FlatAppearance.BorderColor = Color.SaddleBrown;
                    }
                }
                else
                {
                    if (arr1[i] % 2 != 0)
                    {
                        my_button1[arr1[i]].FlatAppearance.BorderSize = 0;
                        my_button1[arr1[i]].FlatAppearance.BorderColor = Color.Peru;

                    }
                    else
                    {
                        my_button1[arr1[i]].FlatAppearance.BorderSize = 0;
                        my_button1[arr1[i]].FlatAppearance.BorderColor = Color.SaddleBrown;
                    }
                }
            }
        }
        public void Try(int button,string sssss)
        {
            l = 0;
            varr1 = chessGame.indxed[button];
            chessGame.indxed[button] = 0;
            chessGame.c[button] = null;
            for (int cc = 0; cc < x; cc++)
            {

                ss = chessGame.c[arr[cc]];
                varr2 = chessGame.indxed[arr[cc]];
                chessGame.indxed[arr[cc]] = varr1;
                chessGame.c[arr[cc]] = sssss;
                if (p6.test(arr[cc]) == true)
                {
                    LIGHT[l] = arr[cc];
                    l++;
                }
                chessGame.c[arr[cc]] = ss;
                chessGame.indxed[arr[cc]] = varr2;
            }
            chessGame.indxed[button] = varr1;
            chessGame.c[button] = sssss;
        }
      
        public void Draw()
        {
            // التعادل 3 حالات تقريبا 
            // اول حالة لو الجيم وصل لملك قدام ملك يبقي تعادل 
            int x = 0;
            int y = 0;
            for (int i = 1; i <= 64; i++)
                if (chessGame.c[i] == null)
                    x++;
            if (x == 62) // هنا معناها ان كل المربعات مفهاش قطع كلها ماتت واتبقي طبعا الملكين
            {
                button81.Visible = true;
                for (int i = 1; i <= 64; i++)
                    my_button1[i].Visible = false;
                
            }
            //////////////////////////
            // تاني حالة لو اتبقي ملك قدام ملك وفيل يبقي تعادل 
            // او برضه لو اتبقي ملك قدام ملك وحصان يبقي تعادل
            x = 0;
            for (int i = 1; i <= 64; i++)
                if (chessGame.c[i] == "Bishop" || chessGame.c[i] == "Knight")
                    x++;
                else if (chessGame.c[i] == null)
                    y++;
            if (x == 1 && y == 61)
            {
                button81.Visible = true;
                for (int i = 1; i <= 64; i++)
                    my_button1[i].Visible = false;
                
            }
            //////////////////
            // تالت حالة في التعادل وهي اهم حالة 
            // لو الملك مش في وضع الكش ومفيش اي حركة للملك ولا اي قطعة من قطع الفريق يبقي تعادل
            // الحالة دي في فانكشن نهاية الجيم لانه نفس الكود تقريبا
        }
        public void End_game(int player)
        {
             int  lll = 0;
            for(int i=1;i<=64;i++)
                if (chessGame.indxed[i] == player)
                {
                    if (chessGame.c[i] == "King" && chessGame.indxed[i] == player)
                    {
                        Games1 = new chessGame(new King());
                        lll += Games1.all_possible_move(i, arr);
                        king_posi = i;
                        continue;
                    }
                    else if (chessGame.c[i] == "Pawn" && chessGame.indxed[i] == player)
                    {
                        Games1=new chessGame(new Pawn());
                        variable = "Pawn";
                    }
                    else if (chessGame.c[i] == "Bishop" && chessGame.indxed[i] == player)
                    {
                        Games1=new chessGame(new Bishop());
                        variable = "Bishop";
                    }
                    else if (chessGame.c[i] == "Knight" && chessGame.indxed[i] == player)
                    {
                        Games1=new chessGame(new Knight());
                        variable = "Knight";
                   }
                    else if (chessGame.c[i] == "Rook" && chessGame.indxed[i] == player)
                    {
                        Games1=new chessGame(new Rook());
                        variable = "Rook";
                    }
                    else if (chessGame.c[i] == "Queen" && chessGame.indxed[i] == player)
                    {
                        Games1=new chessGame(new Queen());
                        variable = "Queen";
                    }
                    x = Games1.all_possible_move(i, arr);
                    Try(i, variable);
                    lll += l;
                }
            if (lll == 0) // so there is no possible move for any piece 
            {

                if (p6.enemy[king_posi] == 0)
                {
                    button81.Visible = true; 
                    for (int i = 1; i <= 64; i++)
                        my_button1[i].Visible = false;
                }
                else if (player == 1)
                {
                    button82.Visible = true;
                    for (int i = 1; i <= 64; i++)
                        my_button1[i].Visible = false;
                    
                    button79.BackColor = Color.Green;
                    button80.BackColor = Color.Red;
                }
                else
                {
                    button83.Visible = true;
                    for (int i = 1; i <= 64; i++)
                        my_button1[i].Visible = false;
                    button80.BackColor = Color.Green;
                    button79.BackColor = Color.Red;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (number_of_moves % 2 == 1 && (chessGame.indxed[1] == 1 || CHESS == 1))
                GAME(1);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[1] == 2 || CHESS == 1))
                GAME(1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
           
            if (number_of_moves % 2 == 1 && (chessGame.indxed[2] == 1 || CHESS == 1))
                GAME(2);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[2] == 2 || CHESS == 1))
                GAME(2);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            
            if (number_of_moves % 2 == 1 && (chessGame.indxed[3] == 1 || CHESS == 1))
                GAME(3);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[3] == 2 || CHESS == 1))
                GAME(3);
        }
        private void button4_Click(object sender, EventArgs e)
        {
           
            if (number_of_moves % 2 == 1 && (chessGame.indxed[4] == 1 || CHESS == 1))
                GAME(4);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[4] == 2 || CHESS == 1))
                GAME(4);
        }
        private void button5_Click(object sender, EventArgs e)
        {
           
            if (number_of_moves % 2 == 1 && (chessGame.indxed[5] == 1 || CHESS == 1))
                GAME(5);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[5] == 2 || CHESS == 1))
                GAME(5);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            
            if (number_of_moves % 2 == 1 && (chessGame.indxed[6] == 1 || CHESS == 1))
                GAME(6);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[6] == 2 || CHESS == 1))
                GAME(6);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            
            if (number_of_moves % 2 == 1 && (chessGame.indxed[7] == 1 || CHESS == 1))
                GAME(7);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[7] == 2 || CHESS == 1))
                GAME(7);
        }
        private void button8_Click(object sender, EventArgs e)
        {
           
            if (number_of_moves % 2 == 1 && (chessGame.indxed[8] == 1 || CHESS == 1))
                GAME(8);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[8] == 2 || CHESS == 1))
                GAME(8);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            
            if (number_of_moves % 2 == 1 && (chessGame.indxed[9] == 1 || CHESS == 1))
                GAME(9);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[9] == 2 || CHESS == 1))
                GAME(9);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            
            if (number_of_moves % 2 == 1 && (chessGame.indxed[10] == 1 || CHESS == 1))
                GAME(10);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[10] == 2 || CHESS == 1))
                GAME(10);
        }
        private void button11_Click(object sender, EventArgs e)
        {
            
            if (number_of_moves % 2 == 1 && (chessGame.indxed[11] == 1 || CHESS == 1))
                GAME(11);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[11] == 2 || CHESS == 1))
                GAME(11);
        }
        private void button12_Click(object sender, EventArgs e)
        {
            
            if (number_of_moves % 2 == 1 && (chessGame.indxed[12] == 1 || CHESS == 1))
                GAME(12);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[12] == 2 || CHESS == 1))
                GAME(12);
        }
        private void button13_Click(object sender, EventArgs e)
        {
           
            if (number_of_moves % 2 == 1 && (chessGame.indxed[13] == 1 || CHESS == 1))
                GAME(13);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[13] == 2 || CHESS == 1))
                GAME(13);
        }
        private void button14_Click(object sender, EventArgs e)
        {
           
            if (number_of_moves % 2 == 1 && (chessGame.indxed[14] == 1 || CHESS == 1))
                GAME(14);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[14] == 2 || CHESS == 1))
                GAME(14);
        }
        private void button15_Click(object sender, EventArgs e)
        {
            
            if (number_of_moves % 2 == 1 && (chessGame.indxed[15] == 1 || CHESS == 1))
                GAME(15);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[15] == 2 || CHESS == 1))
                GAME(15);
        }
        private void button16_Click(object sender, EventArgs e)
        {
           
            if (number_of_moves % 2 == 1 && (chessGame.indxed[16] == 1 || CHESS == 1))
                GAME(16);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[16] == 2 || CHESS == 1))
                GAME(16);
        }
        private void button17_Click(object sender, EventArgs e)
        {
            
            if (number_of_moves % 2 == 1 && (chessGame.indxed[17] == 1 || CHESS == 1))
                GAME(17);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[17] == 2 || CHESS == 1))
                GAME(17);
        }
        private void button18_Click(object sender, EventArgs e)
        {
            
            if (number_of_moves % 2 == 1 && (chessGame.indxed[18] == 1 || CHESS == 1))
                GAME(18);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[18] == 2 || CHESS == 1))
                GAME(18);
        }
        private void button19_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[19] == 1 || CHESS == 1))
                GAME(19);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[19] == 2 || CHESS == 1))
                GAME(19);
        }
        private void button20_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[20] == 1 || CHESS == 1))
                GAME(20);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[20] == 2 || CHESS == 1))
                GAME(20);
        }
        private void button21_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[21] == 1 || CHESS == 1))
                GAME(21);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[21] == 2 || CHESS == 1))
                GAME(21);
        }
        private void button22_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[22] == 1 || CHESS == 1))
                GAME(22);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[22] == 2 || CHESS == 1))
                GAME(22);
        }
        private void button23_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[23] == 1 || CHESS == 1))
                GAME(23);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[23] == 2 || CHESS == 1))
                GAME(23);
        }
        private void button24_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[24] == 1 || CHESS == 1))
                GAME(24);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[24] == 2 || CHESS == 1))
                GAME(24);
        }
        private void button25_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[25] == 1 || CHESS == 1))
                GAME(25);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[25] == 2 || CHESS == 1))
                GAME(25);
        }
        private void button26_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[26] == 1 || CHESS == 1))
                GAME(26);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[26] == 2 || CHESS == 1))
                GAME(26);
        }
        private void button27_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[27] == 1 || CHESS == 1))
                GAME(27);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[27] == 2 || CHESS == 1))
                GAME(27);
        }
        private void button28_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[28] == 1 || CHESS == 1))
                GAME(28);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[28] == 2 || CHESS == 1))
                GAME(28);
        }
        private void button29_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[29] == 1 || CHESS == 1))
                GAME(29);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[29] == 2 || CHESS == 1))
                GAME(29);
        }
        private void button30_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[30] == 1 || CHESS == 1))
                GAME(30);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[30] == 2 || CHESS == 1))
                GAME(30);
        }
        private void button31_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[31] == 1 || CHESS == 1))
                GAME(31);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[31] == 2 || CHESS == 1))
                GAME(31);
        }
        private void button32_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[32] == 1 || CHESS == 1))
                GAME(32);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[32] == 2 || CHESS == 1))
                GAME(32);
        }
        private void button33_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[33] == 1 || CHESS == 1))
                GAME(33);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[33] == 2 || CHESS == 1))
                GAME(33);
        }
        private void button34_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[34] == 1 || CHESS == 1))
                GAME(34);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[34] == 2 || CHESS == 1))
                GAME(34);
        }
        private void button35_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[35] == 1 || CHESS == 1))
                GAME(35);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[35] == 2 || CHESS == 1))
                GAME(35);
        }
        private void button36_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[36] == 1 || CHESS == 1))
                GAME(36);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[36] == 2 || CHESS == 1))
                GAME(36);
        }
        private void button37_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[37] == 1 || CHESS == 1))
                GAME(37);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[37] == 2 || CHESS == 1))
                GAME(37);
        }
        private void button38_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[38] == 1 || CHESS == 1))
                GAME(38);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[38] == 2 || CHESS == 1))
                GAME(38);
        }
        private void button39_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[39] == 1 || CHESS == 1))
                GAME(39);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[39] == 2 || CHESS == 1))
                GAME(39);
        }
        private void button40_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[40] == 1 || CHESS == 1))
                GAME(40);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[40] == 2 || CHESS == 1))
                GAME(40);
        }
        private void button41_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[41] == 1 || CHESS == 1))
                GAME(41);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[41] == 2 || CHESS == 1))
                GAME(41);
        }
        private void button42_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[42] == 1 || CHESS == 1))
                GAME(42);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[42] == 2 || CHESS == 1))
                GAME(42);
        }
        private void button43_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[43] == 1 || CHESS == 1))
                GAME(43);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[43] == 2 || CHESS == 1))
                GAME(43);
        }
        private void button44_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[44] == 1 || CHESS == 1))
                GAME(44);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[44] == 2 || CHESS == 1))
                GAME(44);
        }
        private void button45_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[45] == 1 || CHESS == 1))
                GAME(45);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[45] == 2 || CHESS == 1))
                GAME(45);
        }
        private void button46_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[46] == 1 || CHESS == 1))
                GAME(46);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[46] == 2 || CHESS == 1))
                GAME(46);
        }
        private void button47_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[47] == 1 || CHESS == 1))
                GAME(47);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[47] == 2 || CHESS == 1))
                GAME(47);
        }
        private void button48_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[48] == 1 || CHESS == 1))
                GAME(48);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[48] == 2 || CHESS == 1))
                GAME(48);
        }
        private void button49_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[49] == 1 || CHESS == 1))
                GAME(49);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[49] == 2 || CHESS == 1))
                GAME(49);
        }
        private void button50_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[50] == 1 || CHESS == 1))
                GAME(50);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[50] == 2 || CHESS == 1))
                GAME(50);
        }
        private void button51_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[51] == 1 || CHESS == 1))
                GAME(51);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[51] == 2 || CHESS == 1))
                GAME(51);
        }
        private void button52_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[52] == 1 || CHESS == 1))
                GAME(52);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[52] == 2 || CHESS == 1))
                GAME(52);
        }
        private void button53_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[53] == 1 || CHESS == 1))
                GAME(53);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[53] == 2 || CHESS == 1))
                GAME(53);
        }
        private void button54_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[54] == 1 || CHESS == 1))
                GAME(54);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[54] == 2 || CHESS == 1))
                GAME(54);
        }
        private void button55_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[55] == 1 || CHESS == 1))
                GAME(55);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[55] == 2 || CHESS == 1))
                GAME(55);
        }
        private void button56_Click(object sender, EventArgs e)
        {
            
            if (number_of_moves % 2 == 1 && (chessGame.indxed[56] == 1 || CHESS == 1))
                GAME(56);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[56] == 2 || CHESS == 1))
                GAME(56);
        }
        private void button57_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[57] == 1 || CHESS == 1))
                GAME(57);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[57] == 2 || CHESS == 1))
                GAME(57);
        }
        private void button58_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[58] == 1 || CHESS == 1))
                GAME(58);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[58] == 2 || CHESS == 1))
                GAME(58);
        }
        private void button59_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[59] == 1 || CHESS == 1))
                GAME(59);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[59] == 2 || CHESS == 1))
                GAME(59);
        }
        private void button60_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[60] == 1 || CHESS == 1))
                GAME(60);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[60] == 2 || CHESS == 1))
                GAME(60);
        }
        private void button61_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[61] == 1 || CHESS == 1))
                GAME(61);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[61] == 2 || CHESS == 1))
                GAME(61);
        }
        private void button62_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[62] == 1 || CHESS == 1))
                GAME(62);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[62] == 2 || CHESS == 1))
                GAME(62);
        }
        private void button63_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[63] == 1 || CHESS == 1))
                GAME(63);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[63] == 2 || CHESS == 1))
                GAME(63);
        }
        private void button64_Click(object sender, EventArgs e)
        {
            if (number_of_moves % 2 == 1 && (chessGame.indxed[64] == 1 || CHESS == 1))
                GAME(64);
            else if (number_of_moves % 2 == 0 && (chessGame.indxed[64] == 2 || CHESS == 1))
                GAME(64);
        }
        private void button65_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private void button66_Click(object sender, EventArgs e)
        {
            
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button67_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == " ")
            {
                textBox1.Text = "1st Player";
                textBox2.Text = "2nd Player";
            }
            button79.FlatAppearance.BorderSize = 4;
            button80.FlatAppearance.BorderSize = 0;
            button79.FlatAppearance.BorderColor = Color.YellowGreen;
            button79.Text = textBox1.Text;
            button80.Text = textBox2.Text;
            if (Start == 0)
            {
                Start = 1;
                for (int i = 1; i <= 64; i++)
                    my_button1[i].Visible = true;
                button65.Visible = true;
                button66.Visible = true;
                button67.Visible = false;
                button68.Visible = false;
                button69.Visible = false;
                button70.Visible = true;
                button79.Visible = true;
                button80.Visible = true;
                textBox1.Visible = false;
                textBox2.Visible = false;
                label1.Visible = false;
            }
        }

        private void button68_Click(object sender, EventArgs e)
        {

        }
        private void button69_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button70_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button71_Click(object sender, EventArgs e)
        {
            chessGame.c[Form1.postion] = "Queen";
            Form1.my_button1[Form1.postion].BackgroundImage = button71.BackgroundImage;
            chessGame.indxed[Form1.postion] = 1;
            buttons_reset();

        }
        private void button72_Click(object sender, EventArgs e)
        {
            chessGame.c[Form1.postion] = "Rook";
            Form1.my_button1[Form1.postion].BackgroundImage = button72.BackgroundImage;
            chessGame.indxed[Form1.postion] = 1;
            buttons_reset();
        }
        private void button73_Click(object sender, EventArgs e)
        {
            chessGame.c[Form1.postion] = "Bishop";
            Form1.my_button1[Form1.postion].BackgroundImage = button73.BackgroundImage;
            chessGame.indxed[Form1.postion] = 1;
            buttons_reset();
        }

        private void button74_Click(object sender, EventArgs e)
        {
            chessGame.c[Form1.postion] = "Knight";
            Form1.my_button1[Form1.postion].BackgroundImage = button74.BackgroundImage;
            chessGame.indxed[Form1.postion] = 1;
            buttons_reset();
        }

        private void button75_Click(object sender, EventArgs e)
        {
            chessGame.c[Form1.postion] = "Queen";
            Form1.my_button1[Form1.postion].BackgroundImage = button75.BackgroundImage;
            chessGame.indxed[Form1.postion] = 2;
            buttons_reset();
        }

        private void button76_Click(object sender, EventArgs e)
        {
            chessGame.c[Form1.postion] = "Rook";
            Form1.my_button1[Form1.postion].BackgroundImage = button76.BackgroundImage;
            chessGame.indxed[Form1.postion] = 2;
            buttons_reset();
        }

        private void button77_Click(object sender, EventArgs e)
        {
            chessGame.c[Form1.postion] = "Bishop";
            Form1.my_button1[Form1.postion].BackgroundImage = button77.BackgroundImage;
            chessGame.indxed[Form1.postion] = 2;
            buttons_reset();
        }

        private void button78_Click(object sender, EventArgs e)
        {
            chessGame.c[Form1.postion] = "Knight";
            Form1.my_button1[Form1.postion].BackgroundImage = button78.BackgroundImage;
            chessGame.indxed[Form1.postion] = 2;
            buttons_reset();
        }

        public void convert(int button, int button1)
        {
            if (chessGame.c[button] != "Pawn")
                return;
            if (button >= 1 && button <= 8)
            {
                button71.Visible = true;
                button72.Visible = true;
                button73.Visible = true;
                button74.Visible = true;
                for (int i = 1; i <= 64; i++)
                {
                    my_button1[i].Enabled = false;
                    my_button1[i].FlatAppearance.BorderSize = 10;
                    my_button1[i].FlatAppearance.BorderColor = Color.Red;
                }
            }
            else if (button >= 57 && button <= 64)
            {
                button75.Visible = true;
                button76.Visible = true;
                button77.Visible = true;
                button78.Visible = true;

                for (int i = 1; i <= 64; i++)
                {
                    my_button1[i].Enabled = false;
                    my_button1[i].FlatAppearance.BorderSize = 10;
                    my_button1[i].FlatAppearance.BorderColor = Color.Red;
                }
     
            }
           

        }
         public void buttons_reset()
        {
            for (int i = 1; i <= 8; i++)
                promotion_buttons[i].Visible = false;

            for (int i = 1; i <= 64; i++)
            {
                my_button1[i].Enabled = true;
                my_button1[i].FlatAppearance.BorderSize = 0;

            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button79_Click(object sender, EventArgs e)
        {
            
            
        }
        //public void players_recognizer()
        //{
        //    if (number_of_moves%2==1)
        //    {
        //        button79.FlatAppearance.BorderSize = 4;
        //        button80.FlatAppearance.BorderSize = 0;
        //        button79.FlatAppearance.BorderColor = Color.Orange;
        //    }
        //    if (number_of_moves%2==0)
        //    {
        //        button80.FlatAppearance.BorderSize = 4;
        //        button79.FlatAppearance.BorderSize = 0;
        //        button80.FlatAppearance.BorderColor = Color.Orange;
        //    }
        //}


    }
}