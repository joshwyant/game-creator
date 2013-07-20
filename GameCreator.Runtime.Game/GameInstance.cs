using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCreator.Framework;

namespace GameCreator.Runtime.Game
{
    public class GameInstance : RuntimeInstance
    {
        #region Constructors
        public GameInstance(ResourceContext context, int object_index, int id)
            : base(context, object_index, id) { }

        public GameInstance(ResourceContext context)
            : base(context, 0, 0) { }
        #endregion

        #region Instance variables and access methods
        public int[] alarm = new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
        double m_direction, m_hspeed, m_vspeed, m_speed;
        public double direction { get { return m_direction; } set { m_direction = value; sethspeedvspeed(); } }
        public double speed { get { return m_speed; } set { m_speed = value; sethspeedvspeed(); } }
        public double hspeed { get { return m_hspeed; } set { m_hspeed = value; setspeeddirection(true); } }
        public double vspeed { get { return m_vspeed; } set { m_vspeed = value; setspeeddirection(true); } }
        public int sprite_index = 0, image_blend = 16777215 /* which I believe to be an int, I have no way to test it now. */;
        public double x = 0, y = 0, gravity = 0, gravity_direction = 270, friction = 0, depth = 0, image_speed = 1, image_single = -1, image_index = 0,
            image_xscale = 1, image_yscale = 1, image_angle = 0, image_alpha = 1, xstart = 0, ystart = 0, xprevious = 0, yprevious = 0;
        public bool visible = true, solid = true, persistent = false;
        #endregion

        #region Private Methods
        // used after setting vspeed or hspeed to set speed and direction variables.
        // resetdir indicates whether direction should be set to 0 by default if speed is 0.
        void setspeeddirection(bool resetdir)
        {
            m_speed = Math.Sqrt(hspeed * hspeed + vspeed * vspeed);
            if (speed == 0.0)
            {
                if (resetdir) m_direction = 0.0;
            }
            else
            {
                m_direction = Math.Atan2(-vspeed / speed, hspeed / speed) / Math.PI * 180.0;
                if (direction < 0.0)
                    m_direction += 360.0;
            }
        }
        // used after setting speed or direction to set vspeed and hspeed variables.
        void sethspeedvspeed()
        {
            m_hspeed = Math.Cos(direction * Math.PI / 180.0) * speed;
            m_vspeed = -Math.Sin(direction * Math.PI / 180.0) * speed;
        }
        #endregion

        #region Public Methods
        public void SetSpeedVector(double hspeed, double vspeed)
        {
            m_hspeed = hspeed;
            m_vspeed = vspeed;
            setspeeddirection(false);
        }
        public void AddSpeedVector(double hspeed, double vspeed)
        {
            m_hspeed += hspeed;
            m_vspeed += vspeed;
            setspeeddirection(false);
        }
        public void SetMotion(double direction, double speed)
        {
            m_direction = direction;
            m_speed = speed;
            sethspeedvspeed();
        }
        #endregion
    }
}
