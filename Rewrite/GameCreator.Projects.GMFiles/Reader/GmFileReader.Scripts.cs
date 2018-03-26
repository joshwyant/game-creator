namespace GameCreator.Projects.GMFiles
{
    partial class GmFileReader
    {
        void readScripts()
        {
            var version = getInt();

            var count = getInt();

            for (var i = 0; i < count; i++)
            {
                project.Scripts.NextIndex = i;

                if (getInt() != 0)
                {
                    var script = project.Scripts.Create();

                    script.Name = getString();

                    version = getInt();

                    script.Code = getString();
                }
            }
        }
    }
}
