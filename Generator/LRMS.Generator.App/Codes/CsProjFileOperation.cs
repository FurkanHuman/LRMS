using Microsoft.Build.Evaluation;

namespace LRMS.Generator.App.Codes;

internal class CsProjFileOperation
{

    public static (Stream, string) CsProjOpenFileDialog()
    {
        OpenFileDialog fileDialog = new();
        fileDialog.InitialDirectory = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.Personal)).FullName;
        fileDialog.Multiselect = false;
        fileDialog.Filter = "C# Project File |*.csproj";

        MessageBox.Show("Please select the layer \".csproj\" file within your project.", "Warning");
        fileDialog.ShowDialog();

        return (fileDialog.OpenFile(), fileDialog.SafeFileName);
    }

    void Modify()
    {
        ProjectCollection projectCollection = new();
    }

}
