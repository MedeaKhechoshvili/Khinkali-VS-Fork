using System.Drawing;
using System.Windows.Forms;

namespace Khinkali
{
    // Base class for visual objects in the game
    // Shares common PictureBox behavior between objects such as obstacles and coins
    public abstract class GameObject
    {
        // Stores the PictureBox that represents the object on the form
        // Protected allows child classes to use it directly
        protected PictureBox pictureBox;

        public PictureBox PictureBox
        {
            get { return pictureBox; }
        }

        public Rectangle Bounds
        {
            // Returns the rectangular area of the object for collision checks
            get { return pictureBox.Bounds; }
        }

        public int Left
        {
            // Gets or changes the object's left position
            get { return pictureBox.Left; }
            set { pictureBox.Left = value; }
        }

        public int Top
        {
            // Gets or changes the object's top position
            get { return pictureBox.Top; }
            set { pictureBox.Top = value; }
        }

        public int Right
        {
            // Gets the right edge position of the object
            get { return pictureBox.Right; }
        }

        public bool Visible
        {
            // Gets or changes whether the object is visible
            get { return pictureBox.Visible; }
            set { pictureBox.Visible = value; }
        }

        public GameObject(PictureBox pictureBox)
        {
            // Connects this game object to a PictureBox from the form
            this.pictureBox = pictureBox;
        }

        // Forces child classes to define their own update behavior
        public abstract void Update();
    }
}