using System;
using System.Linq;

namespace GameCreator.Engine.Library
{
    public partial class ActionLibrary
    {
        #region Move

        public void Move(GameInstance self, string directions, double speed, bool relative = false)
        {
            var dirs = Library.MoveDirections.NotSet;
            for (var i = 0; i < 9; i++)
            {
                if (directions[i] == '1')
                {
                    dirs |= (MoveDirections) (1 << i);
                }
            }
            Move(self, dirs, speed, relative);
        }

        /// <summary>
        /// Moves in the direction specified by the direction flags. 
        /// ArgumentRelative must be specified.
        /// </summary>
        public void Move(GameInstance self, MoveDirections directions, double speed, bool relative = false)
        {
            var moveList = Enum.GetValues(typeof(MoveDirections))
                .Cast<MoveDirections>()
                .Where(dir => (dir & directions) != 0)
                .ToList();

            if (moveList.Count != 0)
            {
                var dir = moveList[Context.Library.Real.RandomObject.Next(moveList.Count)];

                if (dir == Library.MoveDirections.Stop)
                {
                    self.Speed = 0;
                }
                else
                {
                    self.Speed = relative
                        ? self.Speed + speed
                        : speed;

                    self.Direction = MoveDirections[dir];
                }
            }
        }

        public void SetMotion(GameInstance self, double direction, double speed, bool relative = false)
        {
            if (relative)
            {
                self.AddSpeedVector(speed * Math.Cos(direction * Math.PI / 180),
                    speed * -Math.Sin(direction * Math.PI / 180));
            }
            else
            {
                self.Direction = direction;
                self.Speed = speed;
            }
        }

        public void MoveTowardsPoint(GameInstance self, double x, double y, double speed, bool relative = false)
        {
            self.Direction = Context.Library.Real.PointDirection(
                self.X,
                self.Y,
                relative ? self.X + x : x,
                relative ? self.Y + y : y);

            self.Speed = speed;
        }

        public void SetHSpeed(GameInstance self, double speed, bool relative = false)
        {
            self.HSpeed = relative ? self.HSpeed + speed : speed;
        }

        public void SetVSpeed(GameInstance self, double speed, bool relative = false)
        {
            self.VSpeed = relative ? self.VSpeed + speed : speed;
        }

        public void SetGravity(GameInstance self, double direction, double amount, bool relative = false)
        {
            self.GravityDirection = relative ? self.GravityDirection + direction : direction;
            self.Gravity = relative ? self.Gravity + amount : amount;
        }

        public void ReverseXDirection(GameInstance self)
        {
            self.HSpeed = -self.HSpeed;
        }

        public void ReverseYDirection(GameInstance self)
        {
            self.VSpeed = -self.VSpeed;
        }

        public void SetFriction(GameInstance self, double amount, bool relative = false)
        {
            self.Friction = relative ? self.Friction + amount : amount;
        }

        public void MoveTo(GameInstance self, double x, double y, bool relative = false)
        {
            self.X = relative ? self.X + x : x;
            self.Y = relative ? self.Y + y : y;
        }

        public void MoveToStart(GameInstance self)
        {
            self.X = self.XStart;
            self.Y = self.YStart;
        }

        public void MoveRandom(GameInstance self, int snapx, int snapy)
        {
            throw new NotImplementedException();
        }

        public void Snap(GameInstance self, int snapx, int snapy)
        {
            throw new NotImplementedException();
        }

        /// <param name="direction">0 = horizontal, 1 = vertical, 2 = both directions</param>
        public void Wrap(GameInstance self, int direction)
        {
            throw new NotImplementedException();
        }

        public void MoveContact(GameInstance self, double direction, double maximum = -1, bool allObjects = false)
        {
            throw new NotImplementedException();
        }

        public void Bounce(GameInstance self, bool precise, bool allObjects)
        {
            throw new NotImplementedException();
        }

        /// <param name="atEnd">
        /// 0 = stop, 1 = continue from start,
        /// 2 = continue from here, 3 = reverse
        /// </param>
        /// <param name="absolute">whether absolute or relative</param>
        public void SetPath(GameInstance self, GamePath path, double speed, int atEnd, bool absolute)
        {
            throw new NotImplementedException();
        }

        public void PathEnd(GameInstance self)
        {
            throw new NotImplementedException();
        }

        /// <param name="position">Range is between 0 and 1</param>
        public void PathPosition(GameInstance self, double position, bool relative = false)
        {
            throw new NotImplementedException();
        }

        public void PathSpeed(GameInstance self, double speed, bool relative = false)
        {
            throw new NotImplementedException();
        }

        public void LinearStep(GameInstance self, double x, double y, double speed, bool stopAtAllObjects,
            bool relative = false)
        {
            throw new NotImplementedException();
        }

        public void PotentialStep(GameInstance self, double x, double y, double speed, bool stopAtAllObjects,
            bool relative = false)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}