using AventStack.ExtentReports.Model;
using minesWeeper.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minesWeeper
{
    public partial class Form1 : Form
    {
        Panel panel1 = new Panel();
        int h = 10, w = 10, mC;
        int cellWidth = 25;
        int cellHeight = 25;
        int depth = 3;
        int[,] numbers;
        int say = 0;
        int[] emptyCellCoordinates;
        int counter = 0;
        int flagCount;
        int flaggedMineCount = 0;
        int[] emptyCellCoordinatesX;
        int[] emptyCellCoordinatesY;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void heightTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void deneme_Click(object sender, EventArgs e)
        {
            Bitmap  bitmap = DrawControlToBitmap(panel1);
            bitmap.Save("mine.bmp");
            System.Diagnostics.Process.Start("mine.bmp");
        }

        private static Bitmap DrawControlToBitmap(Control control)
        {
            Bitmap bitmap = new Bitmap(control.Width, control.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            Rectangle rect = control.RectangleToScreen(control.ClientRectangle);
            graphics.CopyFromScreen(rect.Location, Point.Empty, control.Size);
            return bitmap;
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            
            flaggedMineCountLabel.Text = flaggedMineCount.ToString();
            int x = Convert.ToInt32(heightTextBox.Text);
            int y = Convert.ToInt32(weightTextBox.Text);
            int mineCount = Convert.ToInt32(mineCountTextBox.Text);
            
            mineArea mA1 = new mineArea(x, y, mineCount);
            h = mA1.X + 2;
            w = mA1.Y + 2;
            mC = mA1.MineCount;
            flagCount = mC;
            flagCountLabel.Text = flagCount.ToString();

            //--------reset bölgesi
            this.Controls.Remove(panel1);
            panel1.Controls.Clear();
            emptyCellCoordinatesX = new int[0];
            emptyCellCoordinatesY = new int[0];
            counter = 0;
            control = true;
            GameStatusLabel.Text = "";
            flaggedMineCount = 0;
            flagCount = mC;

            this.Controls.Add(panel1);
            
            panel1.Location = new Point(15, 75);
            panel1.Size = new Size(h * cellHeight, w * cellWidth);
            panel1.Visible = true;

            Random r = new Random();
            int[] mineArrayXY = new int[mC + 1];
            int[] mineArrayY = new int[w + 1];
            
            for (int i = 1; i <= mC; i++)
            {
            A:
                int mineX = r.Next(1, mA1.X + 1);
                int mineY = r.Next(1, mA1.Y + 1);
                for (int k = 1; k < i; k++)
                {
                    if (mineArrayXY[k] == mineX * 100 + mineY)  // oluşturulan mayınların üst üste gelmesini engelledik.
                    {
                        goto A;
                    }

                }

                mineArrayXY[i] = mineX * 100 + mineY;

            }
            mineArrayXY[0] = 0;
            mineArrayY[0] = 0;
            mineArrayY[w] = 0;

            numbers = new int[h + 1, w + 1];

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {

                    if (i > 0 && j > 0)
                    {
                        foreach (int number in mineArrayXY)
                        {
                            if (number == ((i * 100) + j))
                            {
                                if (numbers[i - 1, j] != number) // matrise, etrafındaki mayın sayısı kadar rakam belirten işlem
                                    numbers[i - 1, j] += 1;
                                if (numbers[i + 1, j] != number)
                                    numbers[i + 1, j] += 1;
                                if (numbers[i, j - 1] != number)
                                    numbers[i, j - 1] += 1;
                                if (numbers[i, j + 1] != number)
                                    numbers[i, j + 1] += 1;
                                if (numbers[i - 1, j - 1] != number)
                                    numbers[i - 1, j - 1] += 1;
                                if (numbers[i + 1, j + 1] != number)
                                    numbers[i + 1, j + 1] += 1;
                                if (numbers[i + 1, j - 1] != number)
                                    numbers[i + 1, j - 1] += 1;
                                if (numbers[i - 1, j + 1] != number)
                                    numbers[i - 1, j + 1] += 1;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < h; i++)             // ilk ve son satır ve stunları boş bırakmak için sıfırlıyoruz
            {
                for (int j = 0; j < w; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        numbers[i, j] = 0;
                    }
                    if (i == h - 1 || j == w - 1)
                    {
                        numbers[i, j] = 0;
                    }
                }
            }


            int btnNo = 0;
            for (int i = 0; i < h; i++)             //buttonlar ile tarlayı oluşturuyoruz
            {
                for (int j = 0; j < w; j++)
                {
                    
                    Button cell = new Button();
                 
                    cell.Location = new Point(j * cellWidth, i * cellHeight);
                    cell.Size = new Size(cellWidth, cellHeight);
                    cell.Click += button_click;
                    cell.MouseDown += Flag;
                    cell.FlatStyle = FlatStyle.Flat;
                    cell.Margin.All.Equals(0);
                    cell.BackColor = Color.White;
                    cell.ForeColor = Color.Gray;
                    cell.BackgroundImageLayout = ImageLayout.Stretch;
                    cell.BackgroundImage = Resources.top;
                    


                    cell.Tag = numbers[i, j];               //buttonlar default olarak 0 ile tanımlanıyor
                    if (i == 0 || j == 0)        //burada da ilk ve son satır ve stunlar invisible oluyor
                    {
                        cell.Visible = false;
                    }
                    if (i == h - 1 || j == w - 1)
                    {
                        cell.Visible = false;
                    }



                    if (i >= 1 && j >= 1)         // Tarlaya mayın ekleme işlemi
                    {

                        foreach (int a in mineArrayXY)
                        {
                            if (a == ((i * 100) + j))
                            {
                                say++;
                                cell.Tag = 9;

                            }

                        }
                    }



                    
                    panel1.Controls.Add(cell);  // hücreyi, buttonu panele ekliyoruz
                }
            }
            emptyCellCoordinatesX = new int[h * w];
            emptyCellCoordinatesY = new int[h * w];

        }
        bool control = true; // mayına basıldıktan sonra oyuna devam etmememizi sağlıyor.
        
        private void button_click(object sender, EventArgs e)
        {
            Button thisButton = ((Button)sender);   // üzerine basılan button ve gönderilen özellikleri

            int xIndex = thisButton.Location.X / cellWidth;     //x eksenini alıyoruz
            int yIndex = thisButton.Location.Y / cellHeight;    //y eksenini alıyoruz



            if (thisButton.Tag.ToString() == "0" && control == true && thisButton.Text != ".")
            {
                if (!EmptyControl(yIndex, xIndex))
                {
                    CellControl(yIndex, xIndex);
                    EmptyCellCoordinateAdd(xIndex, yIndex);
                    thisButton.Tag = "10";
                }
                    
            }
            if (thisButton.Tag.ToString() == "9" && thisButton.Text != ".")
            {
                GameOver();
                control = false;
            }
            if (thisButton.Tag.ToString() == "1" && control == true && thisButton.Text!=".")
            {
                if (!EmptyControl(yIndex, xIndex))                              //değerlerin EmptyCellCoordinateAdd dizisinde olup olmadığını kontrol ettiriyoruz
                {
                    EmptyCellCoordinateAdd(xIndex, yIndex);                     //Coordinatları kontrol amaçlı bir diziye eklemek için gönderiyoruz
                    thisButton.BackgroundImageLayout = ImageLayout.Stretch;
                    thisButton.BackgroundImage = Resources.one;
                    thisButton.Tag = "10";                                      //Açılan button'ın artık bir işlevi kalmaadığından ve flag kontrolü için Tag'i 10 a eşitledim.
                }
            }
            if (thisButton.Tag.ToString() == "2" && control == true && thisButton.Text != ".")
            {
                if (!EmptyControl(yIndex, xIndex))
                {
                    EmptyCellCoordinateAdd(xIndex, yIndex);
                    thisButton.BackgroundImageLayout = ImageLayout.Stretch;
                    thisButton.BackgroundImage = Resources.two;
                    thisButton.Tag = "10";
                }
            }
            if (thisButton.Tag.ToString() == "3" && control == true && thisButton.Text != ".")
            {
                if (!EmptyControl(yIndex, xIndex))
                {
                    EmptyCellCoordinateAdd(xIndex, yIndex);
                    thisButton.BackgroundImageLayout = ImageLayout.Stretch;
                    thisButton.BackgroundImage = Resources.three;
                    thisButton.Tag = "10";
                }
            }
            if (thisButton.Tag.ToString() == "4" && control == true && thisButton.Text != ".")
            {
                if (!EmptyControl(yIndex, xIndex))
                {
                    EmptyCellCoordinateAdd(xIndex, yIndex);
                    thisButton.BackgroundImageLayout = ImageLayout.Stretch;
                    thisButton.BackgroundImage = Resources.four;
                    thisButton.Tag = "10";
                }
            }
            if (thisButton.Tag.ToString() == "5" && control == true && thisButton.Text != ".")
            {
                if (!EmptyControl(yIndex, xIndex))
                {
                    EmptyCellCoordinateAdd(xIndex, yIndex);
                    thisButton.BackgroundImageLayout = ImageLayout.Stretch;
                    thisButton.BackgroundImage = Resources.five;
                    thisButton.Tag = "10";
                }
            }
            if (thisButton.Tag.ToString() == "6" && control == true && thisButton.Text != ".")
            {
                if (!EmptyControl(yIndex, xIndex))
                {
                    EmptyCellCoordinateAdd(xIndex, yIndex);
                    thisButton.BackgroundImageLayout = ImageLayout.Stretch;
                    thisButton.BackgroundImage = Resources.six;
                    thisButton.Tag = "10";
                }
            }
            if (thisButton.Tag.ToString() == "7" && control == true && thisButton.Text != ".")
            {
                if (!EmptyControl(yIndex, xIndex))
                {
                    EmptyCellCoordinateAdd(xIndex, yIndex);
                    thisButton.BackgroundImageLayout = ImageLayout.Stretch;
                    thisButton.BackgroundImage = Resources.seven;
                    thisButton.Tag = "10";
                }
            }
            if (thisButton.Tag.ToString() == "8" && control == true && thisButton.Text != ".")
            {
                if (!EmptyControl(yIndex, xIndex))
                {
                    EmptyCellCoordinateAdd(xIndex, yIndex);
                    thisButton.BackgroundImageLayout = ImageLayout.Stretch;
                    thisButton.BackgroundImage = Resources.eight;
                    thisButton.Tag = "10";
                }   
            }
        }


        private void GameOver()     //mayına basıldığında tüm mayınlar açılır.
        {
          
            foreach (Control cell in panel1.Controls)
            {
                if (cell.Tag.ToString() == "9")
                {
                    cell.BackgroundImageLayout = ImageLayout.Stretch;
                    cell.BackgroundImage = Resources.mine;
                }
            }
            GameStatusLabel.Text = "You Lost This Game";
        }
        
        void Flag(object sender, MouseEventArgs e)
        {
            Button thisButton = ((Button)sender);


            if (e.Button == MouseButtons.Right)
            {
                
                if(thisButton.Text == "" && flagCount>0 && control == true && thisButton.Tag.ToString() != "10") 
                {
                    thisButton.BackgroundImageLayout = ImageLayout.Stretch;
                    thisButton.BackgroundImage = Resources.flag;
                    
                    thisButton.Text = ".";
                    
                    flagCount--;

                    if(thisButton.Tag.ToString() == "9")
                    {
                        flaggedMineCount++;
                        flaggedMineCountLabel.Text = flaggedMineCount.ToString();
                        WonGame();
                    }
                    
                }
                else
                {
                    
                    if (thisButton.Text=="." && flagCount<mC && control == true && thisButton.Tag.ToString() != "10")
                    {
                        flagCount++;    
                    }

                    else if (flagCount != 0 && control == true && thisButton.Tag.ToString() != "10")
                    {
                        flagCount++;
                    }
                        
                    if (control == true && thisButton.Tag.ToString() != "10")
                    {
                        thisButton.BackgroundImageLayout = ImageLayout.Stretch;
                        thisButton.BackgroundImage = Resources.top;
                        thisButton.Text = "";
                    }
                    if(thisButton.Tag.ToString() == "9" && flagCount!=0)
                    {
                        flaggedMineCount--;
                        flaggedMineCountLabel.Text = flaggedMineCount.ToString();
                    }
                
                    

                }
                flagCountLabel.Text = flagCount.ToString();

            }
        }

        
        

        bool onur = true;
        void CellControl(int x, int y)
        {
            onur = true;
            if (onur)
            {
                onur = false;
                if ((x <= 0 || y <= 0) || (x >= h - 1 || y >= w - 1))
                {

                    return;
                }

                if (EmptyControl(x, y))
                {
                    return;
                }
               
                for (int i = 0; i < panel1.Controls.Count; i++)
                {
                    int yIndex = panel1.Controls[i].Location.X / cellWidth;
                    int xIndex = panel1.Controls[i].Location.Y / cellHeight;
                    

                    if (xIndex == x && yIndex == y)
                    {
                        if (panel1.Controls[i].Text == ".")
                        {
                            return;
                        }

                        else if (panel1.Controls[i].Tag.ToString() == "0")
                        {
                            
                            panel1.Controls[i].BackgroundImageLayout = ImageLayout.Stretch;
                            panel1.Controls[i].BackgroundImage = Resources.empty;
                            
                            EmptyCellCoordinateAdd(x, y);
                            panel1.Controls[i].Tag = "10";
                            //-----------------
                            for (int j = -1; j <= 1; j++)
                            {
                                for (int k = -1; k <= 1; k++)
                                {
                                    CellControl(x + j, y + k);

                                }
                            }
                        }
                        else if (int.Parse(panel1.Controls[i].Tag.ToString()) <= 8 && int.Parse(panel1.Controls[i].Tag.ToString()) >= 1)
                        {
                            panel1.Controls[i].BackgroundImageLayout = ImageLayout.Stretch;
                            panel1.Controls[i].BackgroundImage = SetPictures(int.Parse(panel1.Controls[i].Tag.ToString()));
                            EmptyCellCoordinateAdd(x, y);
                            panel1.Controls[i].Tag = "10";
                        }
                        
                        
                    }
                }
            }
            onur = true;
        }

        bool EmptyControl(int x, int y)
        {
            for (int i = 0; i < emptyCellCoordinatesX.Length; i++)
            {
                if (emptyCellCoordinatesX[i] == x && emptyCellCoordinatesY[i] == y)
                {
                    return true;
                }
            }
            return false;
        }

        void EmptyCellCoordinateAdd(int x, int y)
        {
            emptyCellCoordinatesX[counter] = x;
            emptyCellCoordinatesY[counter] = y;
            counter++;
        }

        Image SetPictures(int pictureNumb)
        {
            if (pictureNumb == 1)
            {

                return Resources.one;
            }
            else if (pictureNumb == 2)
            {
                return Resources.two;
            }
            else if (pictureNumb == 3)
            {
                return Resources.three;
            }
            else if (pictureNumb == 4)
            {
                return Resources.four;
            }
            else if (pictureNumb == 5)
            {
                return Resources.five;
            }
            else if (pictureNumb == 6)
            {
                return Resources.six;
            }
            else if (pictureNumb == 7)
            {
                return Resources.seven;
            }
            else
            {
                return Resources.eight;
            }
        }

        void WonGame()
        {
            if(flaggedMineCount == mC)
            {
                control = false;
                GameStatusLabel.Text = "You Won This Game";
            }
        }









    }
}
