using Core.Domain.Abstract;
using System.Reflection;

namespace LRMS.Generator.App
{
    public partial class Main : Form
    {

        public static List<Type> AllTypes = new();

        public Main()
        {
            InitializeComponent();

            Main.AllTypes.AddRange(GetIEntities("Core.Domain"));
            Main.AllTypes.AddRange(GetIEntities("Domain"));
        }

        private void List_Click(object sender, EventArgs e)
        {
            List list = new();
            this.Hide();
            list.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        static IList<Type> GetIEntities(string loadPack)
        {
            Assembly assembly = Assembly.Load(loadPack);

            return assembly.GetTypes()
                 .Where(x => typeof(IEntity).IsAssignableFrom(x) && x.IsClass)
                 .ToList();
        }

        private void buttonGenerateAll_Click(object sender, EventArgs e)
        {
            GenerateAll generateAll = new();
            this.Hide();
            generateAll.Show();
        }
    }
}
