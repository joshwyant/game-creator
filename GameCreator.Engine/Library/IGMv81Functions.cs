using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

/*

Functions:
message_text_charset(type, charset)	8.1
string_byte_at(str, index)	8.1
string_byte_length(str)	8.1
ansi_char(val)	8.1
point_distance_3d(x1, y1, z1, x2, y2, z2)	8.1
dot_product_3d(x1, y1, z1, x2, y2, z2)	8.1
dot_product(x1, y1, x2, y2)	8.1
d3d_light_define_ambient(color)	8.1
draw_self()	8.1

*/

public interface IGMv81Functions
{
    [Gml("message_text_charset", v81)]
    void MessageTextCharset(int type, int charset);

    [Gml("string_byte_at", v81)]
    int StringByteAt(string str, int index);

    [Gml("string_byte_length", v81)]
    int StringByteLength(string str);

    [Gml("ansi_char", v81)]
    string AnsiChar(int val);

    [Gml("point_distance_3d", v81)]
    double PointDistance3d(double x1, double y1, double z1, double x2, double y2, double z2);

    [Gml("dot_product_3d", v81)]
    double DotProduct3d(double x1, double y1, double z1, double x2, double y2, double z2);

    [Gml("dot_product", v81)]
    double DotProduct(double x1, double y1, double x2, double y2);

    [Gml("d3d_light_define_ambient", v81)]
    void D3dLightDefineAmbient(int color);

    [Gml("draw_self", v81)]
    void DrawSelf();
}
