using System.Windows.Forms;

namespace Khinkali
{
    // Represents an obstacle that appears on the ground
    // Ground obstacles are used for forks, knives, and fork-knife combinations
    public class GroundObstacle : Obstacle
    {
        public GroundObstacle(PictureBox pictureBox, int speed, int topPosition)
            : base(pictureBox, speed, topPosition)
        {
            // The parent Obstacle constructor handles the setup
        }

        public override void ResetPosition(int newLeft)
        {
            // Uses the parent reset logic to set position and reset counted status
            base.ResetPosition(newLeft);

            // Makes the ground obstacle visible again after it resets
            pictureBox.Visible = true;
        }
    }
}