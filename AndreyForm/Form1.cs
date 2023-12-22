using System.Windows.Forms;

namespace AndreyForm
{
    public partial class Form1 : Form
    {

        /*
         Заменить в третьем столбце матрицы A (5×7) все нули на единицы, а в пятом столбце матрицы  B
         
         */



        
        public List<TextBox> FindTextBoxes(Control.ControlCollection controls)
        {
            
            
            List<TextBox> textBoxes = new List<TextBox>();
            foreach (Control control in controls)
            {
        
                if (control is TextBox)
                {
                    textBoxes.Add((TextBox)control);
                }
                
                if (control.HasChildren)
                {
                    textBoxes.AddRange(FindTextBoxes(control.Controls));
                }
            }
            return textBoxes;
        }
        
        List<string> flagList_row1_a = new List<string>() { "textBox1", "textBox2", "textBox3", "textBox4", "textBox5", };
        List<string> flagList_row5_b = new List<string>() { "textBox55", "textBox54", "textBox53", "textBox52", "textBox51", "textBox50", "textBox49", };



        List<TextBox> getListTextBoxes(List<string> flagNames) => 
            FindTextBoxes(this.Controls)
            .Where(elem => flagNames.Contains(elem.Name))
            .ToList();
        
        void changeNumbers(List<TextBox> textBoxes, int treatNumber, int changeNumber) => textBoxes
            .ForEach(element => element.Text=int.Parse(element.Text) == treatNumber ? changeNumber.ToString() : element.Text);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            changeNumbers(getListTextBoxes(flagList_row1_a),0,1);
            changeNumbers(getListTextBoxes(flagList_row5_b), 1, 0);
            MessageBox.Show("Выполнено");
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
    }
}
