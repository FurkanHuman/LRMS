using System.Linq.Dynamic.Core;
using LRMS.Generator.App.Codes;
using LRMS.Generator.App.Codes.CreatorCodes;
using LRMS.Generator.App.Codes.CreatorCodes.Repository;

namespace LRMS.Generator.App;

public partial class Generator : Form
{

    public static List<Type> SelectedEntityTypes = new();
    private readonly PacketLoader PacketLoader = new();
    private static List<Type> AllEntityTypes = new();
    private static List<Type> AllDbContextTypes = new();

    public Generator()
    {
        InitializeComponent();
    }

    private void Generator_Load(object sender, EventArgs e)
    {

        LoadDbContext();
        CoreEntitiesCheckBox.Checked = true;
        EntitiesCheckBox.Checked = true;

    }

    private async void EntityListBox_SelectedValueChanged(object sender, EventArgs e)
    {
        SelectAllCheckBox.CheckState = CheckState.Indeterminate;

        SelectedItemCounterUpdate();
    }

    private async void Reload_Click(object sender, EventArgs e)
    {
        AllEntityTypes.Clear();
        CoreEntitiesCheckBox_CheckedChanged(sender, e);
        EntitiesCheckBox_CheckedChanged(sender, e);
        SelectAllCheckBox.CheckState = CheckState.Unchecked;
        InverseCheckBox.CheckState = CheckState.Unchecked;

    }

    private async void SaveSelectedEntities_Click(object sender, EventArgs e)
    {
        foreach (object item in EntityListBox.CheckedItems)
            SelectedEntityTypes.Add((Type)item);

        LoadEntitiesPaths();
    }


    private void DbLayerConfigSetButton_Click(object sender, EventArgs e)
    {
        (Stream, string) csName = CsProjFileOperation.CsProjOpenFileDialog();
        SetDbLayerLabel.Text = csName.Item2 + " Selected";
    }

    private void LogicLayerConfigSetButton_Click(object sender, EventArgs e)
    {
        (Stream, string) csName = CsProjFileOperation.CsProjOpenFileDialog();
        SetLogicLayerLabel.Text = csName.Item2 + " Selected";
    }


    private async void CoreEntitiesCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        IList<Type> entitiesForCore = PacketLoader.GetLoadedPacketEntitiesForCore();

        if (CoreEntitiesCheckBox.Checked)
            foreach (Type item in entitiesForCore)
                AllEntityTypes.Add(item);
        else
        {
            foreach (Type item in entitiesForCore)
                AllEntityTypes.Remove(item);
        }

        ListBoxUpdate();
    }

    private async void EntitiesCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        IList<Type> entitiesForNormal = PacketLoader.GetLoadedPacketEntities();


        if (EntitiesCheckBox.Checked)
            foreach (Type item in entitiesForNormal)
                AllEntityTypes.Add(item);
        else
        {
            foreach (Type item in entitiesForNormal)
                AllEntityTypes.Remove(item);
        }

        ListBoxUpdate();

        SelectedItemCounterUpdate();
    }

    private async void SelectAllCheckBox_CheckedChanged(object sender, EventArgs e)
    {

        for (int i = 0; i < EntityListBox.Items.Count; i++)
        {
            if (SelectAllCheckBox.CheckState == CheckState.Checked)
                EntityListBox.SetItemChecked(i, true);

            else if (SelectAllCheckBox.CheckState == CheckState.Unchecked)
                EntityListBox.SetItemChecked(i, false);
        }

        SelectedItemCounterUpdate();
    }

    private async void InverseCheckBox_CheckedChanged(object sender, EventArgs e)
    {

        for (int i = 0; i < EntityListBox.Items.Count; i++)
        {
            EntityListBox.SetItemChecked(i, !EntityListBox.GetItemChecked(i));
        }

        SelectedItemCounterUpdate();
    }

    private async Task ListBoxUpdate()
    {
        this.EntityListBox.DataSource = AllEntityTypes.Distinct().ToArray();
        this.EntityListBox.DisplayMember = "Name";

        EntitiesCounter.Text = EntityListBox.Items.Count.ToString();
        SelectedItemCounterUpdate();
    }

    private async Task SelectedItemCounterUpdate()
    {
        int counter = 0;
        for (int i = 0; i < EntityListBox.CheckedItems.Count; i++)
        {
            counter++;
        }

        SelectedEntitiesCounter.Text = counter.ToString();
    }

    private async Task LoadDbContext()
    {
        AllDbContextTypes.AddRange(PacketLoader.GetLoadedPacketDbContexts());

        this.DbContextListBox.DataSource = AllDbContextTypes;
        this.DbContextListBox.DisplayMember = "Name";
    }

    private async Task LoadEntitiesPaths()
    {
        this.EntitiesPathsListBoxForApplication.DataSource = GenerateEngine.Generator(SelectedEntityTypes).Distinct().ToList();
        PahtsCountLabel.Text = EntitiesPathsListBoxForApplication.Items.Count.ToString();
    }

    private string SelectedDbContextName()
    {
        object obj = DbContextListBox.SelectedItem;
        Type type = (Type)obj;

        return type.Name;
    }

    private void GenerateButton_Click(object sender, EventArgs e)
    {

        CsFile[] result = CsFileOperation.CsFilesEngine(SelectedEntityTypes, SelectedDbContextName());

        CodeGeneratorHelpers.WriteCsFiles(result);
    }
}
