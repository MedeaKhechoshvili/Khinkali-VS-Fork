using System.Drawing;
using System.Windows.Forms;

namespace Khinkali
{
    // Represents a collectible coin in the game.
    // Coin inherits from GameObject, so it uses the same PictureBox structure.
    public class Coin : GameObject
    {
        // Number of points added when the player collects the coin.
        private int value;

        // Speed used to move the coin left.
        private int speed;

        public int Value
        {
            get { return value; }
        }

        // A coin is active when its PictureBox is visible.
        public bool Active
        {
            get { return pictureBox.Visible; }
        }

        public Coin(PictureBox pictureBox, int value, int speed)
            : base(pictureBox)
        {
            this.value = value;
            this.speed = speed;
        }

        // Moves the coin left each timer tick.
        public override void Update()
        {
            pictureBox.Left -= speed;
        }

        // Updates the coin speed when the game speed increases.
        public void SetSpeed(int newSpeed)
        {
            speed = newSpeed;
        }

        // Places the coin in a new position and shows it.
        public void ResetPosition(int newLeft, int newTop)
        {
            pictureBox.Left = newLeft;
            pictureBox.Top = newTop;
            pictureBox.Visible = true;
            pictureBox.BringToFront();
        }

        // Hides the coin after it is collected.
        public void Hide()
        {
            pictureBox.Visible = false;
        }

        // Returns a smaller hitbox so collecting the coin feels fair.
        public Rectangle GetHitBox()
        {
            return new Rectangle(
                pictureBox.Left + 5,
                pictureBox.Top + 5,
                pictureBox.Width - 10,
                pictureBox.Height - 10
            );
        }
    }
}