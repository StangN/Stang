using System;
using System.Drawing;
using System.Windows.Forms;



namespace Puzzlegame
{
    
    public partial class Form1 : Form
    {
        

        
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {


        }

        OpenFileDialog openFileDialog = null;
        Image image;
        PictureBox picBoxWhole = null;
        
        private void buttonImageBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog == null)
                openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textboxImagePath.Text = openFileDialog.FileName;
                image = CreateBitmapImage(Image.FromFile(openFileDialog.FileName));
                picBoxWhole = picBoxPuzzle;
                picBoxWhole.Image = image;
            }
        }
        

        
        private void Randomize(ref int[] array)
        {
            Random rand = new Random();
            int n = array.Length;
            while (n > 1)
            {
                int k = rand.Next(n);
                n--;
                int temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
        private void CreateBitmapImage(Image image, Image[] images, int index, int numRow, int numCol, int unitX, int unitY)
        {
            images[index] = new Bitmap(unitX, unitY);
            Graphics objGraphics = Graphics.FromImage(images[index]);
            objGraphics.Clear(Color.White);

            objGraphics.DrawImage(image, new Rectangle(0, 0, unitX, unitY), new Rectangle(unitX * (index % numRow), unitY * (index / numRow), unitX, unitY), GraphicsUnit.Pixel);
            objGraphics.Flush();
        }
        private Bitmap CreateBitmapImage(Image image)
        {
            Bitmap objBmpImage = new Bitmap(groupboxPuzzle.Width, groupboxPuzzle.Height);
            Graphics objGraphics = Graphics.FromImage(objBmpImage);
            objGraphics.Clear(Color.White);
            objGraphics.DrawImage(image, new Rectangle(0, 0, groupboxPuzzle.Width, groupboxPuzzle.Height));
            objGraphics.Flush();
            return objBmpImage;
        }

        PictureBox[] picBoxes = null;
        Image[] images = null;
        private void button2_Click(object sender, EventArgs e)
        {
            Play();
        }
        int puzzleWidth = 0;
        int puzzleHeight = 0;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                puzzleWidth = int.Parse(textBox1.Text);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                puzzleHeight = int.Parse(textBox2.Text);
            }
        }
        
        private void Play()
        {
            int size = (puzzleHeight * puzzleWidth);
            if (picBoxes != null && size > picBoxes.Length)
            {
                picBoxes = null;
                
               
            }
            if (picBoxWhole != null)
            {
                groupboxPuzzle.Controls.Remove(picBoxWhole);
                picBoxWhole.Dispose();
                picBoxWhole = null;
            }
            if (picBoxes == null)
            {
                picBoxes = new PictureBox[size];
                images = new Image[size];
            }
            

            int numRow = puzzleWidth;
            int numCol = puzzleHeight;
            int unitX = groupboxPuzzle.Width / numRow;
            int unitY = groupboxPuzzle.Height / numCol;
            int[] indice = new int[size];
            for (int i = 0; i < (size); i++)
            {
                indice[i] = i;
                if (picBoxes[i] == null)
                {
                    picBoxes[i] = new MyPictureBox();
                    picBoxes[i].Click += new EventHandler(OnPuzzleClick);
                    picBoxes[i].BorderStyle = BorderStyle.FixedSingle;
                }
                picBoxes[i].Width = unitX;
                picBoxes[i].Height = unitY;
                ((MyPictureBox)picBoxes[i]).Index = i;
                CreateBitmapImage(image, images, i, numRow, numCol, unitX, unitY);
               
                    picBoxes[i].Location = new Point(unitX * (i % numRow), unitY * (i / numRow));
                    if (!groupboxPuzzle.Controls.Contains(picBoxes[i]))
                        groupboxPuzzle.Controls.Add(picBoxes[i]);
               
               
                
            }
            Randomize(ref indice);
            for (int i = 0; i < (size); i++)
            {
                picBoxes[i].Image = images[indice[i]];
                ((MyPictureBox)picBoxes[i]).ImageIndex = indice[i];
            }



        }

        MyPictureBox firstBox = null;
        MyPictureBox secondBox = null;
        
        private void Autosolve()
        {
            int size = (puzzleHeight * puzzleWidth);
            bool[] boxPlace = new bool[size];
            Random rand = new Random();

            for (int i = 0;i < (size);i++)
            {
                boxPlace[i] = false;
            }
            while (!(Win()))
                for (int i = 0; i < (size);i++)
                {
                    int rand1 = rand.Next(size);
                    int rand2 = rand.Next(size);
                    int cnt1 = -1;
                    int cnt2 = -1;
                    while (boxPlace[rand1] != false)
                    {
                        cnt1++;
                        if (cnt1 == size)
                            { break; }
                        else rand1 = cnt1;
                    }
                    while (boxPlace[rand2] != false&& rand1 < size)
                    {
                        cnt2++;
                        if (cnt2 == size)
                        { break; }
                        else rand2 = cnt2;
                        
                    }
                    firstBox = (MyPictureBox)picBoxes[rand1];
                    secondBox = (MyPictureBox)picBoxes[rand2];
                    SwitchImages(firstBox, secondBox);
                    
                    if (firstBox.ImageIndex == firstBox.Index)
                    {
                        boxPlace[rand1] = true;
                    }
                    if (secondBox.ImageIndex == secondBox.Index)
                    {
                        boxPlace[rand2] = true;
                    }
                    firstBox = null;
                    secondBox = null;
                }
            Autosolvebtn.Text = "Solved!";
        }
        public void OnPuzzleClick(object sender, EventArgs e)
        {
            if (firstBox == null)
            {
                firstBox = (MyPictureBox)sender;
                firstBox.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (secondBox == null)
            {
                secondBox = (MyPictureBox)sender;
                firstBox.BorderStyle = BorderStyle.FixedSingle;
                secondBox.BorderStyle = BorderStyle.FixedSingle;
                SwitchImages(firstBox, secondBox);
                firstBox = null;
                secondBox = null;
            }

        }
        private void SwitchImages(MyPictureBox box1, MyPictureBox box2)
        {
            int temp1 = box2.ImageIndex;
            box2.Image = images[box1.ImageIndex];
            box2.ImageIndex = box1.ImageIndex;
            box1.Image = images[temp1];
            box1.ImageIndex = temp1;
            if (Win())
            {
                button2.Text = "YOU WON!";
            }
        }
        private bool Win()
        {
            for (int i = 0; i < (puzzleWidth * puzzleHeight); i++)
            {
                if (((MyPictureBox)picBoxes[i]).ImageIndex != ((MyPictureBox)picBoxes[i]).Index)
                    return false;
            }
            return true;
        }

        private void Autosolvebtn_Click(object sender, EventArgs e)
        {
            Autosolve();
        }

        private void Autosolvebtn_Click_1(object sender, EventArgs e)
        {
            Autosolve();
        }

        
    }
   

}