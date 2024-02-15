using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

/*

Functions:
set_application_title(title)	8.0
background_replace_background(ind, fname)	8.0
background_add_background(fname)	8.0
sprite_replace_sprite(ind, fname)	8.0
sprite_add_sprite(fname)	8.0
timeline_clear(ind)	8.0
background_create_from_surface(id, x, y, w, h, removeback, smooth)	8.0
background_create_from_screen(x, y, w, h, removeback, smooth)	8.0
background_replace(ind, fname, removeback, smooth)	8.0
background_add(fname, removeback, smooth)	8.0
sprite_collision_mask(sepmasks, bboxmode, bbleft, bbright, bbtop, bbbottom, kind, tolerance)	8.0
sprite_add_from_surface(ind, id, x, y, w, h, removeback, smooth)	8.0
sprite_create_from_surface(id, x, y, w, h, removeback, smooth, xorig, yorig)	8.0
sprite_add_from_screen(ind, x, y, w, h, removeback, smooth)	8.0
sprite_create_from_screen(x, y, w, h, removeback, smooth, xorig, yorig)	8.0
sprite_replace(ind, fname, imgnumb, removeback, smooth, xorig, yorig)	8.0
sprite_add(fname, imgnumb, removeback, smooth, xorig, yorig)	8.0
sprite_save_strip(ind, fname)	8.0
splash_set_close_button(show)	8.0
splash_set_position(x, y)	8.0
disk_free(drive)	8.0
disk_size(drive)	8.0
file_text_eoln()	8.0
mouse_wheel_down()	8.0
mouse_wheel_up()	8.0
irandom_range(x1, x2)	8.0
irandom(x)	8.0
random_range(x1, x2)	8.0
splash_show_web(url, delay)	8.0

*/

public interface IGMv80Functions
{
    [Gml("set_application_title", v80)]
    void SetApplicationTitle(string title);

    [Gml("background_replace_background", v80)]
    void BackgroundReplaceBackground(int ind, string fname);

    [Gml("background_add_background", v80)]
    void BackgroundAddBackground(string fname);

    [Gml("sprite_replace_sprite", v80)]
    void SpriteReplaceSprite(int ind, string fname);

    [Gml("sprite_add_sprite", v80)]
    void SpriteAddSprite(string fname);

    [Gml("timeline_clear", v80)]
    void TimelineClear(int ind);

    [Gml("background_create_from_surface", v80)]
    void BackgroundCreateFromSurface(int id, double x, double y, double w, double h, bool removeback, bool smooth);

    [Gml("background_create_from_screen", v80)]
    void BackgroundCreateFromScreen(double x, double y, double w, double h, bool removeback, bool smooth);

    [Gml("background_replace", v80)]
    void BackgroundReplace(int ind, string fname, bool removeback, bool smooth);

    [Gml("background_add", v80)]
    void BackgroundAdd(string fname, bool removeback, bool smooth);

    [Gml("sprite_collision_mask", v80)]
    void SpriteCollisionMask(bool sepmasks, int bboxmode, double bbleft, double bbright, double bbtop, double bbbottom, int kind, double tolerance);

    [Gml("sprite_add_from_surface", v80)]
    void SpriteAddFromSurface(int ind, int id, double x, double y, double w, double h, bool removeback, bool smooth);

    [Gml("sprite_create_from_surface", v80)]
    void SpriteCreateFromSurface(int id, double x, double y, double w, double h, bool removeback, bool smooth, double xorig, double yorig);

    [Gml("sprite_add_from_screen", v80)]
    void SpriteAddFromScreen(int ind, double x, double y, double w, double h, bool removeback, bool smooth);

    [Gml("sprite_create_from_screen", v80)]
    void SpriteCreateFromScreen(double x, double y, double w, double h, bool removeback, bool smooth, double xorig, double yorig);

    [Gml("sprite_replace", v80)]
    void SpriteReplace(int ind, string fname, int imgnumb, bool removeback, bool smooth, double xorig, double yorig);

    [Gml("sprite_add", v80)]
    void SpriteAdd(string fname, int imgnumb, bool removeback, bool smooth, double xorig, double yorig);

    [Gml("sprite_save_strip", v80)]
    void SpriteSaveStrip(int ind, string fname);

    [Gml("splash_set_close_button", v80)]
    void SplashSetCloseButton(bool show);

    [Gml("splash_set_position", v80)]
    void SplashSetPosition(double x, double y);

    [Gml("disk_free", v80)]
    double DiskFree(string drive);

    [Gml("disk_size", v80)]
    double DiskSize(string drive);

    [Gml("file_text_eoln", v80)]
    bool FileTextEoln();

    [Gml("mouse_wheel_down", v80)]
    bool MouseWheelDown();

    [Gml("mouse_wheel_up", v80)]
    bool MouseWheelUp();

    [Gml("irandom_range", v80)]
    int IrandomRange(int x1, int x2);

    [Gml("irandom", v80)]
    int Irandom(int x);

    [Gml("random_range", v80)]
    double RandomRange(double x1, double x2);

    [Gml("splash_show_web", v80)]
    void SplashShowWeb(string url, double delay);
}
