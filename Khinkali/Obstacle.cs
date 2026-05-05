using System.Drawing;
using System.Windows.Forms;

namespace Khinkali
{
    // Base class for all obstacle objects in the game
    // Adds obstacle-specific behavior to the shared GameObject structure
    public abstract class Obstacle : GameObject
    {
        // Stores how fast the obstacle moves to the left
        protected int speed;

        // Stores the vertical position where the obstacle appears
        // Ground and flying obstacles use different top positions
        protected int topPosition;

        // Stores whether this obstacle has already been counted for score
        protected bool counted;

        public bool Counted
        {
            get { return counted; }
            set { counted = value; }
        }

        public Obstacle(PictureBox pictureBox, int speed, int topPosition)
            : base(pictureBox)
        {
            // Stores the movement speed for this obstacle
            this.speed = speed;

            // Stores the vertical position used when the obstacle resets
            this.topPosition = topPosition;

            // Marks the obstacle as not counted when it is first created
            this.counted = false;
        }

        public void SetSpeed(int speed)
        {
            // Updates the obstacle speed when the game speed changes
            this.speed = speed;
        }

        public override void Update()
        {
            // Moves the obstacle left during each timer tick
            pictureBox.Left -= speed;
        }

        public Rectangle GetHitBox()
        {
            // Returns a smaller rectangle for fairer collision detection
            return new Rectangle(
                pictureBox.Left + 5,
                pictureBox.Top + 5,
                pictureBox.Width - 10,
                pictureBox.Height - 10
            );
        }

        public virtual void ResetPosition(int newLeft)
        {
            // Moves the obstacle back to the right side of the screen
            pictureBox.Left = newLeft;

            // Restores the obstacle to its correct vertical position
            pictureBox.Top = topPosition;

            // Allows the obstacle to be counted again after it resets
            counted = false;
        }
    }
}