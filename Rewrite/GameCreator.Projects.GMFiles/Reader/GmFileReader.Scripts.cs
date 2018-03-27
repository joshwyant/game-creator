namespace GameCreator.Projects.GMFiles
{
    internal partial class GmFileReader
    {
        private void ReadScripts()
        {
            var version = ReadInt();

            var count = ReadInt();

            for (var i = 0; i < count; i++)
            {
                Project.Scripts.NextIndex = i;

                if (ReadInt() != 0)
                {
                    var script = Project.Scripts.Create();

                    script.Name = ReadString();

                    version = ReadInt();

                    script.Code = ReadString();
                }
            }
        }
    }
}
