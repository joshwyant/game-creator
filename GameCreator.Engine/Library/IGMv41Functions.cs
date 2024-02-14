using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

/*

Functions:
sprite_add(fname, imgnumb, precise, transparent, videomem, loadonuse, xorig, yorig)	4.1	7.0
sprite_replace(ind, fname, imgnumb, precise, transparent, videomem, loadonuse, xorig, yorig)	4.1	7.0
background_add(fname, transparent, videomem, loadonuse)	4.1	7.0
background_replace(ind, fname, transparent, videomem, loadonuse)	4.1	7.0
is_real(val)	4.1	
is_string(val)	4.1	
draw_getpixel(x, y)	4.1	
execute_string(str)	4.1	
event_inherited()	4.1	
sprite_delete(ind)	4.1	
background_delete(ind)	4.1	
sound_add(fname, buffers, effects, loadonuse)	4.1	
sound_replace(index, fname, buffers, effects, loadonuse)	4.1	
sound_delete(index)	4.1	
mplay_init_ipx()	4.1	
mplay_init_tcpip(addr)	4.1	
mplay_init_modem(initstr, phonenr)	4.1	
mplay_init_serial(portno, baudrate, stopbits, parity, flow)	4.1	
mplay_connect_status()	4.1	
mplay_end()	4.1	
mplay_session_create(sesname, playnumb, playername)	4.1	
mplay_session_find()	4.1	
mplay_session_name(numb)	4.1	
mplay_session_join(numb, playername)	4.1	
mplay_session_mode(move)	4.1	
mplay_session_status()	4.1	
mplay_session_end()	4.1	
mplay_layer_find()	4.1	
mplay_player_id(numb)	4.1	
mplay_data_write(ind, val)	4.1	
mplay_data_read(ind)	4.1	
mplay_data_mode(guar)	4.1	
mplay_message_send(player, id, val)	4.1	
mplay_message_send_guaranteed(player, id, val)	4.1	
mplay_message_receive(player)	4.1	
mplay_message_id()	4.1	
mplay_message_value()	4.1	
mplay_message_player()	4.1	
mplay_message_name()	4.1	
mplay_message_count(player)	4.1	
mplay_message_clear(player)	4.1	

Deprecated functions:
object_name(ind)	4.1	4.2a
sprite_name(ind)	4.1	4.2a
background_name(ind)	4.1	4.2a
sound_name(ind)	4.1	4.2a
script_name(ind)	4.1	4.2a
external_define3(dll, name, arg1type, arg2type, arg3type, restype)	4.1	4.3
external_define4(dll, name, arg1type, arg2type, arg3type, arg4type, restype)	4.1	4.3
external_call3(id, arg1, arg2, arg3)	4.1	4.3
external_call4(id, arg1, arg2, arg3, arg4)	4.1	4.3

*/

public interface IGMv41Functions
{
    #region Deprecated functions
    [Gml("sprite_add", v41, v70)]
    int SpriteAdd(string fname, int imgnumb, bool precise, bool transparent, bool videomem, bool loadonuse, int xorig, int yorig);

    [Gml("sprite_replace", v41, v70)]
    void SpriteReplace(int ind, string fname, int imgnumb, bool precise, bool transparent, bool videomem, bool loadonuse, int xorig, int yorig);

    [Gml("background_add", v41, v70)]
    int BackgroundAdd(string fname, bool transparent, bool videomem, bool loadonuse);

    [Gml("background_replace", v41, v70)]
    void BackgroundReplace(int ind, string fname, bool transparent, bool videomem, bool loadonuse);
    #endregion

    [Gml("is_real", v41)]
    bool IsReal(double val);

    [Gml("is_string", v41)]
    bool IsString(string val);

    [Gml("draw_getpixel", v41)]
    int DrawGetpixel(int x, int y);

    [Gml("execute_string", v41)]
    void ExecuteString(string str);

    [Gml("event_inherited", v41)]
    void EventInherited();

    [Gml("sprite_delete", v41)]
    void SpriteDelete(int ind);

    [Gml("background_delete", v41)]
    void BackgroundDelete(int ind);

    [Gml("sound_add", v41)]
    int SoundAdd(string fname, int buffers, bool effects, bool loadonuse);

    [Gml("sound_replace", v41)]
    void SoundReplace(int index, string fname, int buffers, bool effects, bool loadonuse);

    [Gml("sound_delete", v41)]
    void SoundDelete(int index);

    [Gml("mplay_init_ipx", v41)]
    void MplayInitIpx();

    [Gml("mplay_init_tcpip", v41)]
    void MplayInitTcpip(string addr);

    [Gml("mplay_init_modem", v41)]
    void MplayInitModem(string initstr, string phonenr);

    [Gml("mplay_init_serial", v41)]
    void MplayInitSerial(int portno, int baudrate, int stopbits, int parity, int flow);

    [Gml("mplay_connect_status", v41)]
    void MplayConnectStatus();

    [Gml("mplay_end", v41)]
    void MplayEnd();

    [Gml("mplay_session_create", v41)]
    void MplaySessionCreate(string sesname, int playnumb, string playername);

    [Gml("mplay_session_find", v41)]
    void MplaySessionFind();

    // Here are the rest:

    [Gml("mplay_init_modem", v41)]
    void MplayInitModem(string initstr, string phonenr);

    [Gml("mplay_init_serial", v41)]
    void MplayInitSerial(int portno, int baudrate, int stopbits, int parity, int flow);

    [Gml("mplay_connect_status", v41)]
    void MplayConnectStatus();

    [Gml("mplay_end", v41)]
    void MplayEnd();

    [Gml("mplay_session_create", v41)]
    void MplaySessionCreate(string sesname, int playnumb, string playername);

    [Gml("mplay_session_find", v41)]
    void MplaySessionFind();

    [Gml("mplay_session_name", v41)]
    void MplaySessionName(int numb);

    [Gml("mplay_session_join", v41)]
    void MplaySessionJoin(int numb, string playername);

    [Gml("mplay_session_mode", v41)]
    void MplaySessionMode(int move);

    [Gml("mplay_session_status", v41)]
    void MplaySessionStatus();

    [Gml("mplay_session_end", v41)]
    void MplaySessionEnd();

    [Gml("mplay_layer_find", v41)]
    void MplayLayerFind();

    [Gml("mplay_player_id", v41)]
    void MplayPlayerId(int numb);

    [Gml("mplay_data_write", v41)]
    void MplayDataWrite(int ind, int val);

    [Gml("mplay_data_read", v41)]
    void MplayDataRead(int ind);

    [Gml("mplay_data_mode", v41)]
    void MplayDataMode(int guar);

    [Gml("mplay_message_send", v41)]
    void MplayMessageSend(int player, int id, int val);

    [Gml("mplay_message_send_guaranteed", v41)]
    void MplayMessageSendGuaranteed(int player, int id, int val);

    [Gml("mplay_message_receive", v41)]
    void MplayMessageReceive(int player);

    [Gml("mplay_message_id", v41)]
    void MplayMessageId();

    [Gml("mplay_message_value", v41)]
    void MplayMessageValue();

    [Gml("mplay_message_player", v41)]
    void MplayMessagePlayer();

    [Gml("mplay_message_name", v41)]
    void MplayMessageName();

    [Gml("mplay_message_count", v41)]
    void MplayMessageCount(int player);

    [Gml("mplay_message_clear", v41)]
    void MplayMessageClear(int player);
}
