using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Andrew_s_MahJong
{
    public class Grid
    {
        private Tile[] tiles;
        public Tile[] Tiles
        {
            get { return tiles; }
            set { tiles = value; }
        }

        public Grid(string design, int numElementsX, int numElementsY, int offSetX, int offSetY, char[] letters) //designs: Square
        {
            switch(design)
            {
                case "Square":
                    Square(numElementsX, numElementsY, offSetX, offSetY, letters);
                    break;
                case "Fence":
                    Fence(numElementsX, numElementsY, offSetX, offSetY, letters);
                    break;

            }
        }

        public int Click(int mouseX, int mouseY)
        {
            int clicked = -1;

            for (int i = 0; i < tiles.Length; i++)
            {
                if (tiles[i].Click(mouseX, mouseY))
                {
                    clicked = i;
                }
            }

            return clicked;
        }

        private void Square(int numElementsX, int numElementsY, int offSetX, int offSetY, char[] letters)
        {
            int count = 0;
            tiles = new Tile[numElementsX * numElementsY];

            for (int y = numElementsY; y > 0; y--)
            {
                for (int x = numElementsX; x > 0; x--)
                {
                    tiles[count] = new Tile(offSetX + x * Tile.Width, offSetY + y * Tile.Height, letters[count]);
                    count++;
                }
            }
        }
        private void Fence(int numElementsX, int numElementsY, int offSetX, int offSetY, char[] letters)
        {
            int count = 0;
            tiles = new Tile[(numElementsX + numElementsY) * 2 - 4];

            for (int x = numElementsX; x > 0; x--) //bottom row
            {
                tiles[count] = new Tile(offSetX + x * Tile.Width, offSetY + numElementsY * Tile.Height, letters[count]);
                count++;
            }

            for (int y = numElementsY - 1; y > 1; y--) //middles
            {
                tiles[count] = new Tile(offSetX + 1 * Tile.Width, offSetY + y * Tile.Height, letters[count]);
                count++;
                tiles[count] = new Tile(offSetX + numElementsX * Tile.Width, offSetY + y * Tile.Height, letters[count]);
                count++;
            }

            for (int x = numElementsX; x > 0; x--) //top row
            {
                tiles[count] = new Tile(offSetX + x * Tile.Width, offSetY + 1 * Tile.Height, letters[count]);
                count++;
            }
        }

        public void Paint(PaintEventArgs e)
        {
            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i].Paint(e);
            }
        }
    }
}
