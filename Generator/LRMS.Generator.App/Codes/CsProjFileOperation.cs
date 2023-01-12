namespace LRMS.Generator.App.Codes;

internal static class CsProjFileOperation
{
    public static (Stream, string) CsProjOpenFileDialog()
    {
        OpenFileDialog fileDialog = new()
        {
            InitialDirectory = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.Personal)).FullName,
            Multiselect = false,
            Filter = "C# Project File |*.csproj"
        };

        MessageBox.Show("Please select the layer \".csproj\" file within your project.", "Warning");
        fileDialog.ShowDialog();

        return (fileDialog.OpenFile(), fileDialog.SafeFileName);
    }
}
