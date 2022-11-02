namespace LRMS.Generator.App
{
    public partial class GenerateAll : Form
    {
        public GenerateAll()
        {
            InitializeComponent();
        }

        private void GenerateAll_Load(object sender, EventArgs e)
        {
            string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            MessageBox.Show(strExeFilePath);
        }

        private void buttonGenerateAllRepository_Click(object sender, EventArgs e)
        {

        }

        private void buttonPathGenerate_Click(object sender, EventArgs e)
        {
                foreach (var item in Main.AllTypes)
                {
                    listBox1.Items.AddRange(GenerateAllStrings.MakeFeatureDirectory(item));

                }
            
            label1.Text = listBox1.Items.Count.ToString();
            Thread.Sleep(250);
        }
    }
}
