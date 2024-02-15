using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IMplayFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // Introduced in v4.1
    //
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
