namespace FINAL_PROJECT_HEALTHCARESCHEDULER
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void NEXT_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void lbl_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
