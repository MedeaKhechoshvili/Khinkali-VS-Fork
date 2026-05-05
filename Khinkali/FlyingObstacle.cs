using System.Windows.Forms;

namespace Khinkali
{
    // Represents an obstacle that appears in the air
    // Flying obstacles are used for forks and knives that the player ducks under
    public class FlyingObstacle : Obstacle
    {
        public FlyingObstacle(PictureBox pictureBox, int speed, int topPosition)
            : base(pictureBox, speed, topPosition)
        {
            // The parent Obstacle constructor handles the setup
        }

        public override void ResetPosition(int newLeft)
        {
            // Uses the parent reset logic to set position and reset counted status
            base.ResetPosition(newLeft);

            // Makes the flying obstacle visible again after it resets
            pictureBox.Visible = true;
        }
    }
}