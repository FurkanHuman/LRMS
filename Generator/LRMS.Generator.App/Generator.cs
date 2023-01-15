using System.Linq.Dynamic.Core;
using LRMS.Generator.App.Codes;
using LRMS.Generator.App.Codes.CreatorCodes;

namespace LRMS.Generator.App;

public partial class Generator : Form
{

    private readonly PacketLoader PacketLoader = new();
    private static List<Type> AllEntityTypes = new();
    private static List<Type> AllDbContextTypes = new();

    CsFileOperationConfig Config = new();

    private static string _AppPath;

    public Generator()
    {
        InitializeComponent();
    }

    private void Generator_Load(object sender, EventArgs e)
    {
        LoadDbContext();
        SimpleRepoRadioButton.Checked = true;
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

    private void LayerConfigSetButton_Click(object sender, EventArgs e)
    {
        (string Path, string FileName) csName = CsProjFileOperation.CsProjOpenFileDialog();
        SetLogicLayerLabel.Text = csName.FileName + " Selected";
        ConfigLayerLabel.Text = csName.FileName + " Selected";
        _AppPath = csName.Path;
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

    private async void GenerateButton_Click(object sender, EventArgs e)
    {
        List<Type> SelectedEntityTypes = new();

        foreach (object item in EntityListBox.CheckedItems)
            SelectedEntityTypes.Add((Type)item);

        CsFile[] csFiles = CsFileOperation.CsFilesEngine(SelectedEntityTypes, Config);

        CodeGeneratorHelpers.WriteCsFiles(csFiles, _AppPath);
    }

    private void DbContextListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        Config.SetDbContextForType((Type)DbContextListBox.SelectedItem);
    }

    private void SyncRepoRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        Config.SelectedRepo = 1;
    }

    private void AsyncRepoRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        Config.SelectedRepo = 2;
    }

    private void SyncAndAsyncRepoRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        Config.SelectedRepo = 3;
    }

    private void SimpleRepoRadioButton_CheckedChanged(object sender, EventArgs e)
    {
        Config.SelectedRepo = 0;
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
}
