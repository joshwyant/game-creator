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
}
