using System;

namespace Forum.App.Models
{
    public struct Position
    {
        private int left;
        private int top;

        public Position(int left, int top)
        {
            this.Left = left;
            this.Top = top;
        }
	    
	public int Left
        {
            get { return this.left; }
            set { this.left = value; }
        }

        public int Top
        {
            get { return this.top; }
            set { this.top = value; }
        }

        public static Position ConsoleCenter()
        {
            int centerTop = Console.WindowHeight / 2;
            int centerLeft = Console.WindowWidth / 2;
            Position center = new Position(centerLeft, centerTop);
	
            return center;
        }
    }
}
