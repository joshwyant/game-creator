using GameCreator.Engine.Api;
using GameCreator.Runtime.Api;
using static GameCreator.Engine.Api.GmlBindingOption;

namespace GameCreator.Engine.Library
{
    public interface IActionLibrary
    {
        #region Move

        /// <summary>
        /// Moves the instance in the direction specified by the string.
        /// ArgumentRelative must be specified.
        /// </summary>
        /// <param name="directions">
        /// Corresponds to the move buttons, left to right, bottom to top.
        /// 1 means the button is pressed, and 0 means it's not.
        /// </param>
        [Gml("action_move")]
        void Move([GmlBinding(CurrentInstance)] GameInstance self, string directions, double speed,
            [GmlBinding(Relative)] bool relative = false);

        [Gml("action_set_motion")]
        void SetMotion([GmlBinding(CurrentInstance)] GameInstance self, double direction, double speed,
            [GmlBinding(Relative)] bool relative = false);

        [Gml("action_move_point")]
        void MoveTowardsPoint([GmlBinding(CurrentInstance)] GameInstance self, double x, double y,
            double speed, [GmlBinding(Relative)] bool relative = false);

        [Gml("action_set_hspeed")]
        void SetHSpeed([GmlBinding(CurrentInstance)] GameInstance self, double speed,
            [GmlBinding(Relative)] bool relative);

        [Gml("action_set_vspeed")]
        void SetVSpeed([GmlBinding(CurrentInstance)] GameInstance self, double speed,
            [GmlBinding(Relative)] bool relative);

        [Gml("action_set_gravity")]
        void SetGravity([GmlBinding(CurrentInstance)] GameInstance self, double direction,
            double amount, [GmlBinding(Relative)] bool relative);

        [Gml("action_reverse_xdir")]
        void ReverseXDirection([GmlBinding(CurrentInstance)] GameInstance self);

        [Gml("action_reverse_ydir")]
        void ReverseYDirection([GmlBinding(CurrentInstance)] GameInstance self);

        [Gml("action_set_friction")]
        void SetFriction([GmlBinding(CurrentInstance)] GameInstance self, double amount,
            [GmlBinding(Relative)] bool relative = false);

        [Gml("action_move_to")]
        void MoveTo([GmlBinding(CurrentInstance)] GameInstance self, double x, double y,
            [GmlBinding(Relative)] bool relative = false);

        [Gml("action_move_start")]
        void MoveToStart([GmlBinding(CurrentInstance)] GameInstance self);

        [Gml("action_move_random")]
        void MoveRandom([GmlBinding(CurrentInstance)] GameInstance self, int snapx, int snapy);

        [Gml("action_snap")]
        void Snap([GmlBinding(CurrentInstance)] GameInstance self, int snapx, int snapy);

        /// <param name="direction">0 = horizontal, 1 = vertical, 2 = both directions</param>
        [Gml("action_wrap")]
        void Wrap([GmlBinding(CurrentInstance)] GameInstance self, int direction);

        [Gml("action_move_contact")]
        void MoveContact([GmlBinding(CurrentInstance)] GameInstance self, double direction, double maximum = -1,
            bool allObjects = false);

        [Gml("action_bounce")]
        void Bounce([GmlBinding(CurrentInstance)] GameInstance self, bool precise, bool allObjects);

        /// <param name="atEnd">
        /// 0 = stop, 1 = continue from start,
        /// 2 = continue from here, 3 = reverse
        /// </param>
        /// <param name="absolute">whether absolute or relative</param>
        [Gml("action_path")]
        void SetPath([GmlBinding(CurrentInstance)] GameInstance self, GamePath path, double speed, int atEnd,
            bool absolute);

        [Gml("action_path_end")]
        void PathEnd([GmlBinding(CurrentInstance)] GameInstance self);

        /// <param name="position">Range is between 0 and 1</param>
        [Gml("action_path_position")]
        void PathPosition([GmlBinding(CurrentInstance)] GameInstance self, double position,
            [GmlBinding(Relative)] bool relative = false);

        [Gml("action_path_speed")]
        void PathSpeed([GmlBinding(CurrentInstance)] GameInstance self, double speed,
            [GmlBinding(Relative)] bool relative = false);

        [Gml("action_linear_step")]
        void LinearStep([GmlBinding(CurrentInstance)] GameInstance self, double x, double y, double speed,
            bool stopAtAllObjects, [GmlBinding(Relative)] bool relative = false);

        [Gml("action_potential_step")]
        void PotentialStep([GmlBinding(CurrentInstance)] GameInstance self, double x, double y, double speed,
            bool stopAtAllObjects, [GmlBinding(Relative)] bool relative = false);

        #endregion

        #region Main 1

        [Gml("action_create_object")]
        void CreateObject([GmlBinding(CurrentInstance)] GameInstance self, GameObject obj, double x, double y,
            [GmlBinding(Relative)] bool relative = false);

        [Gml("action_create_object_motion")]
        void CreateObjectMotion([GmlBinding(CurrentInstance)] GameInstance self, GameObject obj, double x, double y,
            double speed,
            double direction, [GmlBinding(Relative)] bool relative = false);

        [Gml("action_create_object_random")]
        void CreateObjectRandom([GmlBinding(CurrentInstance)] GameInstance self, GameObject obj1, GameObject obj2,
            GameObject obj3, GameObject obj4, double x, double y, [GmlBinding(Relative)] bool relative = false);

        [Gml("action_change_object")]
        void ChangeObject([GmlBinding(CurrentInstance)] GameInstance self, GameObject obj, bool performEvents);

        [Gml("action_kill_object")]
        void KillObject([GmlBinding(CurrentInstance)] GameInstance self);

        [Gml("action_kill_position")]
        void KillPosition([GmlBinding(CurrentInstance)] GameInstance self, double x, double y,
            [GmlBinding(Relative)] bool relative = false);

        [Gml("action_sprite_set")]
        void SetSprite([GmlBinding(CurrentInstance)] GameInstance self, GameSprite sprite, int subimage, double speed);

        [Gml("action_set_sprite")]
        void SetSprite([GmlBinding(CurrentInstance)] GameInstance self, GameSprite sprite, double scaleFactor);

        /// <param name="mirroring">
        /// 0 = no mirroring
        /// 1 = mirror horizontally
        /// 2 = flip vertically
        /// 3 = mirror and flip
        /// </param>
        [Gml("action_sprite_transform")]
        void TransformSprite([GmlBinding(CurrentInstance)] GameInstance self, double xscale, double yscale,
            double angle, int mirroring);

        [Gml("action_sprite_color")]
        void SpriteSetColor([GmlBinding(CurrentInstance)] GameInstance self, int color, double alpha);

        [Gml("action_sound")]
        void PlaySound(GameSound sound, bool loop);

        [Gml("action_end_sound")]
        void StopSound(GameSound sound);

        [Gml("action_if_sound")]
        bool IfSound(GameSound sound);

        [Gml("action_previous_room")]
        void GoToPreviousRoom(RoomTransitionKind transitionKind);

        [Gml("action_next_room")]
        void GoToNextRoom(RoomTransitionKind transitionKind);

        [Gml("action_current_room")]
        void RestartCurrentRoom(RoomTransitionKind transitionKind);

        [Gml("action_another_room")]
        void GoToRoom(GameRoom room, RoomTransitionKind transitionKind);

        [Gml("action_if_previous_room")]
        bool IfPreviousRoom();

        [Gml("action_if_next_room")]
        bool IfNextRoom();

        #endregion

        #region Main 2

        [Gml("action_set_alarm")]
        void SetAlarm([GmlBinding(CurrentInstance)] GameInstance self, int steps, int alarmNo,
            [GmlBinding(Relative)] bool relative = false);

        [Gml("action_sleep")]
        void Sleep(int milliseconds, bool redraw);

        [Gml("action_set_timeline")]
        void SetTimeline([GmlBinding(CurrentInstance)] GameInstance self, GameTimeline timeline, int position);

        [Gml("action_timeline_set")]
        void SetTimeline([GmlBinding(CurrentInstance)] GameInstance self, GameTimeline timeline, int position,
            bool dontStartImmediately, bool loop);

        [Gml("action_set_timeline_position")]
        void SetTimelinePosition([GmlBinding(CurrentInstance)] GameInstance self, int position,
            [GmlBinding(Relative)] bool relative = false);

        [Gml("action_set_timeline_speed")]
        void SetTimelineSpeed([GmlBinding(CurrentInstance)] GameInstance self, double speed,
            [GmlBinding(Relative)] bool relative = false);

        [Gml("action_timeline_start")]
        void StartTimeline([GmlBinding(CurrentInstance)] GameInstance self);

        [Gml("action_timeline_pause")]
        void PauseTimeline([GmlBinding(CurrentInstance)] GameInstance self);

        [Gml("action_timeline_stop")]
        void StopTimeline([GmlBinding(CurrentInstance)] GameInstance self);

        [Gml("action_message")]
        void ShowMessage(string message);

        [Gml("action_show_info")]
        void ShowInfo();

        [Gml("action_show_video")]
        void ShowVideo(string filename, bool fullScreen, bool loop);

        [Gml("action_splash_text")]
        void ShowSplashText(string filename);

        [Gml("action_splash_image")]
        void ShowSplashImage(string filename);

        [Gml("action_splash_web")]
        void ShowSplashWeb(string url, bool showInBrowser);

        [Gml("action_splash_video")]
        void ShowSplashVideo(string filename, bool loop);

        /// <param name="openIn">
        /// 0 = game window,
        /// 1 = normal window,
        /// 2 = full screen
        /// </param>
        [Gml("action_splash_settings")]
        void SplashSettings(string caption, int openIn, bool dontShowCloseButton, bool dontCloseOnEscape,
            bool dontCloseOnClick);

        [Gml("action_restart_game")]
        void RestartGame();

        [Gml("action_end_game")]
        void EndGame();

        [Gml("action_save_game")]
        void SaveGame(string filename);

        [Gml("action_load_game")]
        void LoadGame(string filename);

        [Gml("action_replace_sprite")]
        void ReplaceSprite(GameSprite sprite, string filename, int images);

        [Gml("action_replace_sound")]
        void ReplaceSound(GameSound sound, string filename);

        [Gml("action_replace_background")]
        void ReplaceBackground(GameBackground background, string filename);

        #endregion

        #region Control

        [Gml("action_if_empty")]
        bool IfEmpty([GmlBinding(CurrentInstance)] GameInstance self, double x, double y, bool allObjects,
            [GmlBinding(Relative)] bool relative = false);

        [Gml("action_if_collision")]
        bool IfCollision([GmlBinding(CurrentInstance)] GameInstance self, double x, double y, bool allObjects,
            [GmlBinding(Relative)] bool relative = false);

        [Gml("action_if_object")]
        bool IfObject([GmlBinding(CurrentInstance)] GameInstance self, GameObject obj, double x, double y,
            [GmlBinding(Relative)] bool relative = false);

        /// <param name="operation">
        /// 0 = equal to,
        /// 1 = smaller than,
        /// 2 = larger than
        /// </param>
        [Gml("action_if_number")]
        bool IfNumber(GameObject obj, int number, int operation);

        [Gml("action_if_dice")]
        bool IfDice(int sides);

        [Gml("action_if_question")]
        bool IfQuestion(string question);

        [Gml("action_if")]
        bool If(Variant expression);

        /// <param name="button">
        /// 0 = no button,
        /// 1 = left,
        /// 2 = right,
        /// 3 = middle
        /// </param>
        [Gml("action_if_mouse")]
        bool IfMouse(int button);

        [Gml("action_if_aligned")]
        bool IfAligned([GmlBinding(CurrentInstance)] GameInstance self, int snapx, int snapy);

        /// <summary>
        /// TODO: This requires context for the current event and object,
        /// which requires support from the game engine, at the least.
        /// </summary>
        [Gml("action_inherited")]
        void CallInheritedEvent();

        [Gml("action_execute_script")]
        void ExecuteScript([GmlBinding(CurrentInstance)] GameInstance self, GameScript script, Variant arg0,
            Variant arg1, Variant arg2, Variant arg3, Variant arg4);

        /// <param name="operation">
        /// 0 = equal to,
        /// 1 = less than,
        /// 2 = greater than
        /// </param>
        [Gml("action_if_variable")]
        bool IfVariable([GmlBinding(CurrentInstance)] GameInstance self, Variant result, Variant value, int operation);

        [Gml("action_draw_variable")]
        void DrawVariable([GmlBinding(CurrentInstance)] GameInstance self, Variant result, double x, double y,
            [GmlBinding(Relative)] bool relative = false);

        #endregion

        #region Score

        [Gml("action_set_score")]
        void SetScore(double score, [GmlBinding(Relative)] bool relative = false);

        /// <param name="operation">
        /// 0 = equal to,
        /// 1 = less than,
        /// 2 = greater than
        /// </param>
        [Gml("action_if_score")]
        bool IfScore(double value, int operation);

        [Gml("action_draw_score")]
        void DrawScore([GmlBinding(CurrentInstance)] GameInstance self, double x, double y, string caption,
            [GmlBinding(Relative)] bool relative = false);

        [Gml("action_highscore_show")]
        void ShowHighscore([GmlBinding(CurrentInstance)] GameBackground background, bool showBorder, int newColor,
            int otherColor, string fontString);

        [Gml("action_highscore_clear")]
        void ClearHighscore();

        [Gml("action_set_life")]
        void SetLives(double lives, [GmlBinding(Relative)] bool relative = false);

        /// <param name="operation">
        /// 0 = equal to,
        /// 1 = less than,
        /// 2 = greater than
        /// </param>
        [Gml("action_if_life")]
        bool IfLives(double value, int operation);

        [Gml("action_draw_life")]
        void DrawLives([GmlBinding(CurrentInstance)] GameInstance self, double x, double y, string caption,
            [GmlBinding(Relative)] bool relative = false);

        [Gml("action_draw_life_images")]
        void DrawLifeImages([GmlBinding(CurrentInstance)] GameInstance self, double x, double y, GameSprite sprite,
            [GmlBinding(Relative)] bool relative = false);

        [Gml("action_set_health")]
        void SetHealth(double health, [GmlBinding(Relative)] bool relative = false);

        /// <param name="operation">
        /// 0 = equal to,
        /// 1 = less than,
        /// 2 = greater than
        /// </param>
        [Gml("action_if_health")]
        bool IfHealth(double value, int operation);

        /// <param name="backColor">
        /// One of:
        /// none|black|gray|silver|white|maroon|green|olive|navy|purple|teal|red|lime|yellow|blue|fuchsia|aqua
        /// </param>
        /// <param name="barColor">
        /// One of:
        /// green to red|white to black|black|gray|silver|white|maroon|green|olive|navy|purple|teal|red|lime|yellow|blue|fuchsia|aqua
        /// </param>
        [Gml("action_draw_health")]
        void DrawHealth([GmlBinding(CurrentInstance)] GameInstance self, double x1, double y1, double x2, double y2,
            int backColor, int barColor, [GmlBinding(Relative)] bool relative = false);

        [Gml("action_set_caption")]
        void SetCaption(bool showScore, string scoreCaption, bool showLives, string livesCaption,
            bool showHealth, string healthCaption);

        #endregion

        #region Extra

        [Gml("action_partsyst_create")]
        void ParticleSystemCreate(double depth);

        [Gml("action_partsyst_destroy")]
        void ParticleSystemDestroy();

        [Gml("action_partsyst_clear")]
        void ParticleSystemClear();

        /// <param name="typeId">
        /// 0-15
        /// </param>
        /// <param name="shapeId">
        /// pixel|disk|square|line|star|circle|ring|sphere|flare|spark|explosion|cloud|smoke
        /// </param>
        [Gml("action_parttype_create_old")]
        void ParticleTypeCreate(int typeId, int shapeId, double minSize, double maxSize, int startColor,
            int endColor);

        /// <param name="typeId">0-15</param>
        /// <param name="shapeId">
        /// pixel|disk|square|line|star|circle|ring|sphere|flare|spark|explosion|cloud|smoke|snow
        /// </param>
        [Gml("action_parttype_create")]
        void ParticleTypeCreate(int typeId, int shapeId, GameSprite sprite, double minSize, double maxSize,
            double sizeIncrement);

        /// <param name="typeId">0-15</param>
        /// <param name="shapeChanging">mixed|changing</param>
        [Gml("action_parttype_color")]
        void ParticleTypeColor(int typeId, bool shapeChanging, int color1, int color2, double startAlpha,
            double endAlpha);

        /// <param name="typeId">0-15</param>
        [Gml("action_parttype_life")]
        void ParticleTypeLife(int typeId, double minLife, double maxLife);

        /// <param name="typeId">0-15</param>
        [Gml("action_parttype_speed")]
        void ParticleTypeSpeed(int typeId, double minSpeed, double maxSpeed, double minDir, double maxDir,
            double friction);

        /// <param name="typeId">0-15</param>
        [Gml("action_parttype_gravity")]
        void ParticleTypeGravity(int typeId, double amount, double direction);

        /// <param name="typeId">0-15</param>
        /// <param name="stepTypeId">0-15</param>
        /// <param name="deathTypeId">0-15</param>
        [Gml("action_parttype_secondary")]
        void ParticleTypeSecondary(int typeId, int stepTypeId, int stepCount, int deathTypeId, int deathCount);

        /// <param name="emitterId">0-7</param>
        /// <param name="shape">rectangle|ellipse|diamond|line</param>
        [Gml("action_partemit_create")]
        void ParticleEmitterCreate(int emitterId, int shape, double xmin, double xmax, double ymin, double ymax);

        /// <param name="emitterId">0-7</param>
        [Gml("action_partemit_destroy")]
        void ParticleEmitterDestroy(int emitterId);

        /// <param name="emitterId">0-7</param>
        /// <param name="typeId">0-15</param>
        [Gml("action_partemit_burst")]
        void ParticleEmitterBurst(int emitterId, int typeId, int number);

        /// <param name="emitterId">0-7</param>
        /// <param name="typeId">0-15</param>
        [Gml("action_partemit_stream")]
        void ParticleEmitterStream(int emitterId, int typeId, int number);

        [Gml("action_cd_play")]
        void PlayCd(int startTrack, int finalTrack);

        [Gml("action_cd_stop")]
        void StopCd();

        [Gml("action_cd_pause")]
        void PauseCd();

        [Gml("action_cd_resume")]
        void ResumeCd();

        [Gml("action_cd_present")]
        bool IfCdExists();

        [Gml("action_cd_playing")]
        bool IfCdPlaying();

        [Gml("action_set_cursor")]
        void SetCursor(GameSprite sprite, bool showNativeCursor);

        [Gml("action_webpage")]
        void OpenWebpage(string url);

        #endregion

        #region Draw

        [Gml("action_draw_sprite")]
        void DrawSprite([GmlBinding(CurrentInstance)] GameInstance self, GameSprite sprite, double x, double y,
            int subimage, [GmlBinding(Relative)] bool relative = false);

        [Gml("action_draw_background")]
        void DrawBackground([GmlBinding(CurrentInstance)] GameInstance self, GameBackground background, double x,
            double y, bool tiled, [GmlBinding(Relative)] bool relative = false);

        [Gml("action_draw_text")]
        void DrawText([GmlBinding(CurrentInstance)] GameInstance self, string text, double x, double y,
            [GmlBinding(Relative)] bool relative = false);

        [Gml("action_draw_text_transformed")]
        void DrawTextScaled([GmlBinding(CurrentInstance)] GameInstance self, string text, double x, double y,
            double xscale, double yscale, double angle, [GmlBinding(Relative)] bool relative = false);

        [Gml("action_draw_rectangle")]
        void DrawRectangle([GmlBinding(CurrentInstance)] GameInstance self, double x1, double y1, double x2,
            double y2, bool outlineOnly, [GmlBinding(Relative)] bool relative = false);

        [Gml("action_draw_gradient_hor")]
        void DrawGradientHorizontal([GmlBinding(CurrentInstance)] GameInstance self, double x1, double y1,
            double x2, double y2, int color1, int color2, [GmlBinding(Relative)] bool relative = false);

        [Gml("action_draw_gradient_vert")]
        void DrawGradientVertical([GmlBinding(CurrentInstance)] GameInstance self, double x1, double y1, double x2,
            double y2, int color1, int color2, [GmlBinding(Relative)] bool relative = false);

        [Gml("action_draw_ellipse")]
        void DrawEllipse([GmlBinding(CurrentInstance)] GameInstance self, double x1, double y1, double x2, double y2,
            bool outlineOnly, [GmlBinding(Relative)] bool relative = false);

        [Gml("action_draw_ellipse_gradient")]
        void DrawEllipseGradient([GmlBinding(CurrentInstance)] GameInstance self, double x1, double y1, double x2,
            double y2, int color1, int color2, [GmlBinding(Relative)] bool relative = false);

        [Gml("action_draw_line")]
        void DrawLine([GmlBinding(CurrentInstance)] GameInstance self, double x1, double y1, double x2, double y2,
            [GmlBinding(Relative)] bool relative = false);

        [Gml("action_draw_arrow")]
        void DrawArrow([GmlBinding(CurrentInstance)] GameInstance self, double x1, double y1, double x2, double y2,
            double tipSize, [GmlBinding(Relative)] bool relative = false);

        [Gml("action_color")]
        void SetColor(int color);

        /// <param name="align">
        /// 0 = left,
        /// 1 = center,
        /// 2 = right
        /// </param>
        [Gml("action_font")]
        void SetFont(GameFont font, int align);

        /// <param name="action">
        /// 0 = switch,
        /// 1 = window,
        /// 2 = fullscreen
        /// </param>
        [Gml("action_fullscreen")]
        void SetFullscreen(int action);

        [Gml("action_snapshot")]
        void Snapshot(string filename);

        /// <param name="type">
        /// One of:
        /// explosion|ring|ellipse|firework|smoke|smoke up|star|spark|flare|cloud|rain|snow
        /// </param>
        /// <param name="size">
        /// One of:
        /// small|medium|large
        /// </param>
        /// <param name="location">
        /// One of:
        /// below objects|above objects
        /// </param>
        [Gml("action_effect")]
        void CreateEffect([GmlBinding(CurrentInstance)] GameInstance self, int type, double x, double y, int size,
            int color, int location, [GmlBinding(Relative)] bool relative = false);

        #endregion
    }
}