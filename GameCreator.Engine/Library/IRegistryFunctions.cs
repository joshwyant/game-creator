using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IRegistryFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // Introduced in v4.0
    //

    [Gml("registry_write_string", v40)]
    void RegistryWriteString(string name, string str);

    [Gml("registry_write_real", v40)]
    void RegistryWriteReal(string name, double x);

    [Gml("registry_read_string", v40)]
    string RegistryReadString(string name);

    [Gml("registry_read_real", v40)]
    double RegistryReadReal(string name);

    [Gml("registry_exists", v40)]
    double RegistryExists(string name);

    [Gml("registry_read_string_ext", v40)]
    string RegistryReadStringExt(string key, string name);

    [Gml("registry_read_real_ext", v40)]
    double RegistryReadRealExt(string key, string name);

    [Gml("registry_exists_ext", v40)]
    double RegistryExistsExt(string key, string name);

}
