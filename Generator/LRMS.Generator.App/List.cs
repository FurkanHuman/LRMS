using Core.Domain.Abstract;
using System.Data;
using System.Reflection;

namespace LRMS.Generator.App
{
    public partial class List : Form
    {
        public List()
        {
            InitializeComponent();
        }

        private void List_Load(object sender, EventArgs e)
        {
            listBox.Items.AddRange(Main.AllTypes.Select(g => g.Name).ToArray());
            label1.Text = Main.AllTypes.Count.ToString();
        }


        private void List_Closed(object sender, EventArgs e)
        {            
            Main main = new();
            this.Hide();
            main.Show();
        }
    }
}
