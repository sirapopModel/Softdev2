using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System.CodeDom.Compiler;
using System.Data.Common;
using System.Runtime.ExceptionServices;
using System.Windows.Forms;

namespace Dynamic_UI_gen_demo
{
    public partial class Dynamic_UI_gen : Form
    {
        public Dynamic_UI_gen() // a Method name "Form1" this one will be run once a program is launch.
        {
            InitializeComponent();
        }

        int k = 0;
        int num_move_Count = 0 ;
        bool checker = false;
        List<Button> Button_list = new List<Button>();
        string[][] button_array;
        string[] checked_array_X;
        string[] checked_array_O;
        bool Fist_checked = true;
        int limiter;
        void button_click(object sender, EventArgs e) // check winner
        {
            Button temp = (Button)sender;
            string[] index = temp.Name.Split(",");
            int btn_row = Int32.Parse(index[0]);
            int btn_col = Int32.Parse(index[1]);
            if (temp.Text == "")
            {
                if (checker == false)
                {
                    temp.Text = "X";
                    button_array[btn_row][btn_col] = "X";
                    Turn_temp.Text = "O";
                    checker = true;
                    
                }
                else
                {
                    temp.Text = "O";
                    button_array[btn_row][btn_col] = "O";
                    Turn_temp.Text = "X";
                    checker = false;
                }
                num_move_Count++;
                num_Move.Text = num_move_Count.ToString();
                //string bt_name = temp.Name ;

                check_score(btn_row, btn_col);
            }

        }

        void check_score(int bt_row, int bt_col)
        {

            //horizontal
            for (int Row = 0; Row < k; Row++)
            {
                if (button_array[Row].SequenceEqual(checked_array_X))
                {
                    MessageBox.Show("X is winner (horizontal line)", "Congratulation", MessageBoxButtons.OK);
                    jaxed_array_clear(button_array);
                    return;
                }
                else if (button_array[Row].SequenceEqual(checked_array_O))
                {
                    MessageBox.Show("O is winner (horizontal line)", "Congratulation", MessageBoxButtons.OK);
                    jaxed_array_clear(button_array);
                    return;

                }
            }

            //vertical
            for (int Column = 0; Column < k; Column++)
            {
                if (button_array[0][Column] == button_array[1][Column])
                {
                    for (int Row = 1; Row < k; Row++)
                    {
                        if (button_array[Row][Column] != button_array[0][Column] || button_array[Row][Column] == "")
                        {
                            break;
                        }
                        else if (Row == k - 1)
                        {

                            MessageBox.Show(button_array[0][Column] + " is winner (vertical line)", "Congratulation", MessageBoxButtons.OK);
                            jaxed_array_clear(button_array);
                            return;
                        }

                    }
                }

            }
            // 2 diagonal line  

            for (int i = 0; i < k; i++)
            {
                if (button_array[0][0] != button_array[i][i] || button_array[i][i] == "")
                {
                    break;
                }
                else if (i == (k - 1))
                {
                    MessageBox.Show(button_array[0][0] + " is winner (diagonal line)", "Congratulation", MessageBoxButtons.OK);
                    jaxed_array_clear(button_array);
                    return;
                }

            }
            // slope + diagonal line
            for (int i = 0; i < k; i++)
            {
                if (button_array[k - 1][0] != button_array[k - 1 - i][i] || button_array[k - 1 - i][i] == "")
                {
                    break;
                }
                else if (i == (k - 1))
                {
                    MessageBox.Show(button_array[k - 1][0] + " is winner (diagonal line)", "Congratulation", MessageBoxButtons.OK);
                    jaxed_array_clear(button_array);
                    return;
                }
            }

            if (num_move_Count == (k*k))
            {
                MessageBox.Show("Draw!!","Alert!!",MessageBoxButtons.OK);
            }

        }
        void jaxed_array_clear(string[][] temp)
        {
            for (int i = 0; i < temp.Length; i++)
            {
                Array.Clear(temp[i]);
            }
        }



        void Generate_Fuction()
        {
            num_Move.Text = "0";
            num_move_Count = 0;
            try
            {
                k = Int32.Parse(NumGen_Box.Text);
            }
            catch
            {
                MessageBox.Show("Interger Only", "Alert", MessageBoxButtons.OK);
                return;
            }
            button_array = new string[k][];
            checked_array_X = new string[k];
            checked_array_O = new string[k];

            for (int i = 0; i < k; i++)
            {
                button_array[i] = new string[k];
                checked_array_X[i] = "X";
                checked_array_O[i] = "O";
            }

            if (Fist_checked == false)
            {
                for (int i = 1; i <= limiter; i++)
                {
                    this.Controls.Remove(this.Button_list[i - 1]);
                }

                if (Button_list.Count != 0)
                {
                    Button_list.RemoveRange(0, limiter); // (Start index , Amount of removed element ) 
                }
            }
            else
            {
                Fist_checked = false;
            }
            limiter = k * k;

            int square_button_size = (800 / k);
            for (int Row = 0; Row < k; Row++)
            {
                for (int Column = 0; Column < k; Column++)
                {
                    Button temp = new Button();
                    temp.Name = (Row.ToString() + "," + Column.ToString());
                    temp.Text = "";
                    temp.BackColor = Color.DarkGray;
                    temp.Margin = new Padding(3, 3, 3, 3);
                    temp.Size = new Size(square_button_size, square_button_size);
                    temp.Location = new Point(100 + square_button_size * (Column), 100 + square_button_size * (Row));
                    temp.AutoSize = true;
                    Button_list.Add(temp);
                    this.Controls.Add(temp);
                    temp.Click += new System.EventHandler(this.button_click); //Add event of button (this one is Click)
                    temp.ForeColor = Color.White;
                    button_array[Row][Column] = temp.Name;
                    temp.Font = new Font("Areial", 100 / k);
                }

            }
        }
        private void Generate_Click(object sender, EventArgs e) // Widget Method Call 
        {
            Generate_Fuction();
        }

        

        private void Save_Button_Click(object sender, EventArgs e)
        {
            DialogResult Ans = MessageBox.Show("Do you want to save this game?","Alert!",MessageBoxButtons.YesNo);
            if (Ans == DialogResult.Yes)
            {
                SaveFileDialog win = new SaveFileDialog();
                win.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                win.InitialDirectory = "C:\\Users\\sirapophuangwilai\\Desktop\\My_Dotnet\\Dynamic_UI_gen_demo\\SAVE";
                //"C:\\Users\\sirapophuangwilai\\Desktop\\My_Dotnet\\Dynamic_UI_gen_demo\\SAVE"
                win.FilterIndex = 1;
                win.RestoreDirectory = true;
                if (win.ShowDialog() == DialogResult.OK)
                {
                    Stream fileStream = win.OpenFile();
                    StreamWriter streamWriter = new StreamWriter(fileStream);
                    
                    streamWriter.WriteLine(k.ToString());//
                    streamWriter.WriteLine(archive_boardOrder(Button_list));
                    streamWriter.WriteLine(Turn_temp.Text);
                    streamWriter.WriteLine(num_Move.Text);

                    streamWriter.Close();
                                                            
                }
            }
            
        }
        public string archive_boardOrder(List<Button> button_list)
        {
            string Sequence = "" ;
            foreach (Button button in button_list)
            {
                switch (button.Text)
                {
                    case "X": // ' ' represent a UTF 16 char , the upperlevel X is not UTF 16
                        Sequence = Sequence + 'x' ;
                        break;
                    case "O":
                        Sequence = Sequence + 'o';
                        break;
                    default:
                        Sequence = Sequence + 'n';
                        break;
                }
            }
            return Sequence;
        }

        private void NumGen_Box_TextChanged(object sender, EventArgs e)

        {

        }

        private void LOAD_Click(object sender, EventArgs e)
        {
            OpenFileDialog win = new OpenFileDialog();
            win.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            win.InitialDirectory = "C:\\Users\\sirapophuangwilai\\Desktop\\My_Dotnet\\Dynamic_UI_gen_demo\\SAVE";
            win.FilterIndex = 2;
            win.RestoreDirectory = true;
            if (win.ShowDialog() == DialogResult.OK)
            {
                Stream fileStream = win.OpenFile() ;
                StreamReader reader = new StreamReader(fileStream);
                try
                {
                    
                    string[] temp = new string[4] ;
                    int counter = 0;
                    while (reader.Peek() >= 0)
                    {
                        temp[counter] = reader.ReadLine() ;
                        counter++;
                    }
                    // 0 for field size
                    NumGen_Box.Text = temp[0];
                    Generate_Fuction();
                    // 1 for X O sequence
                    assigned_OX(temp[1],Button_list);
                    //List_Count.Text = temp[1];
                    Turn_temp.Text = temp[2].ToUpper();
                    checker = (temp[2]=="o") ? true : false ;
                    num_move_Count = Int32.Parse(temp[3]);
                    num_Move.Text = temp[3];

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Wrong format save file", "Error",MessageBoxButtons.OK);
                }

            } 

        }
        void assigned_OX(string Sequence , List<Button> button_list)
        {
            int idx_sequence = 0;
            Button temp;
            for (int Row = 0; Row < k; Row++)
            {
                for (int Coloumn = 0; Coloumn < k; Coloumn++)
                {
                    switch(Sequence[idx_sequence])
                    
                    {
                        case 'x':
                            temp = button_list[idx_sequence];
                            temp.Text = "X";
                            button_array[Row][Coloumn] = "X";
                            break;
                        case 'o':
                            temp = button_list[idx_sequence];
                            temp.Text = "O";
                            button_array[Row][Coloumn] = "O";
                            break;

                        default:
                            temp = button_list[idx_sequence];
                            temp.Text = "";
                            button_array[Row][Coloumn] = Row.ToString()+","+Coloumn.ToString();
                            break;
                    }
                    
                    idx_sequence++;
                }
            }
        }


    }// end program class
}