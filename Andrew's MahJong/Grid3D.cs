using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Andrew_s_MahJong
{
    public class Grid3D
    {
        private static int numElementsX = 8; //designed only for these numbers
        private static int numElementsY = 6;

        private Random rand = new Random();

        private Grid[] grids;
        public Grid[] Grids
        {
            get { return grids; }
            set { grids = value; }
        }

        public Grid3D(string design, int offSetX, int offSetY) //designs: Cube, Fence, pool
        {
            switch (design)
            {
                case "Cube":
                    Cube(offSetX, offSetY);
                    break;
                case "Fence":
                    Fence(offSetX, offSetY);
                    break;
                case "Pool":
                    Pool(offSetX, offSetY);
                    break;
            }
        }

        public int[] Click(int mouseX, int mouseY)
        {
            int[] selected = new int[] { -1, -1, -1 };

            selected[2] = grids[2].Click(mouseX, mouseY);

            if (selected[2] == -1)
            {
                selected[1] = grids[1].Click(mouseX, mouseY);

                if (selected[1] == -1)
                {
                    selected[0] = grids[0].Click(mouseX, mouseY);
                }
                else
                {
                    selected[0] = grids[0].Click(-1, -1); //deselect
                }
            }
            else
            {
                selected[1] = grids[1].Click(-1, -1); //deselect
                selected[0] = grids[0].Click(-1, -1); //deselect
            }

            return selected;
        }

        private void Cube(int offSetX, int offSetY)
        {
            char[] letters = RandomChars(numElementsX * numElementsY * 3 / 4); //must be divisible by 4
            letters = DuplicateChars(letters);

            for (int i = 0; i < 8; i++) //randomizes the letters a few times
            {
                letters = RandomizeChars(letters);
            }

            grids = new Grid[3];
            
            for (int i = 0; i < grids.Length; i++)
            {
                grids[i] = new Grid("Square", numElementsX, numElementsY, offSetX + (i * Tile.OffSet), offSetY + (i * Tile.OffSet), oneThirdChars(letters, i));
            }
        }
        private void Fence(int offSetX, int offSetY)
        {
            char[] letters = RandomChars(((numElementsX + numElementsY) * 2 - 4) * 3 / 4); //must be divisible by 4
            letters = DuplicateChars(letters);

            for (int i = 0; i < 8; i++) //randomizes the letters a few times
            {
                letters = RandomizeChars(letters);
            }

            grids = new Grid[3];

            for (int i = 0; i < grids.Length; i++)
            {
                grids[i] = new Grid("Fence", numElementsX, numElementsY, offSetX + (i * Tile.OffSet), offSetY + (i * Tile.OffSet), oneThirdChars(letters, i));
            }
        }
        private void Pool(int offSetX, int offSetY)
        {
            //48 + 48 = 96, 96 / 4 = 24
            int amount = ((numElementsX + numElementsY) * 2 - 4) * 2; //top two layers
            char[] letters = RandomChars((amount + numElementsX * numElementsY) / 4); //must be divisible by 4
            letters = DuplicateChars(letters);

            for (int i = 0; i < 8; i++) //randomizes the letters a few times
            {
                letters = RandomizeChars(letters);
            }

            grids = new Grid[3]; //half, fourth, fourth
            int count = 0;
            char[] newLetters = new char[letters.Length / 2];

            for (int i = 0; i < newLetters.Length; i++)
            {
                newLetters[i] = letters[count];
                count++;
            }

            grids[0] = new Grid("Square", numElementsX, numElementsY, offSetX + (0 * Tile.OffSet), offSetY + (0 * Tile.OffSet), newLetters);
            //new layer
            newLetters = new char[letters.Length / 4];

            for (int i = 0; i < newLetters.Length; i++)
            {
                newLetters[i] = letters[count];
                count++;
            }

            grids[1] = new Grid("Fence", numElementsX, numElementsY, offSetX + (1 * Tile.OffSet), offSetY + (1 * Tile.OffSet), newLetters);
            //new layer
            newLetters = new char[letters.Length / 4];

            for (int i = 0; i < newLetters.Length; i++)
            {
                newLetters[i] = letters[count];
                count++;
            }

            grids[2] = new Grid("Fence", numElementsX, numElementsY, offSetX + (2 * Tile.OffSet), offSetY + (2 * Tile.OffSet), newLetters);
        }

        private char[] RandomChars(int amount) //uses random chars
        {
            char[] possible = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] used = new char[amount];
            char current = ' ';

            for (int i = 0; i < used.Length; i++) //default all used
            {
                used[i] = '-';
            }

            for (int i = 0; i < amount; i++)
            {
                do
                {
                    current = possible[rand.Next(0, possible.Length)];
                } while (used.Contains(current));

                used[i] = current;
            }

            return used;
        }
        private char[] DuplicateChars(char[] letters) //creates an array with 4 of each letter
        {
            char[] newLetters = new char[letters.Length * 4];
            int counter = 0;

            for (int i = 0; i < newLetters.Length; i += 4)
            {
                newLetters[i] = letters[counter];
                newLetters[i + 1] = letters[counter];
                newLetters[i + 2] = letters[counter];
                newLetters[i + 3] = letters[counter];

                counter++;
            }

            return newLetters; 
        }
        private char[] RandomizeChars(char[] letters) //randomizes all chars
        {
            int randNum;
            char temp;

            for (int i = 0; i < letters.Length; i++)
            {
                randNum = rand.Next(0, letters.Length);
                temp = letters[i];
                letters[i] = letters[randNum];
                letters[randNum] = temp;
            }

            return letters;
        }
        private char[] oneThirdChars(char[] letters, int section) //uses one third of the chars, section 0, 1, or 2
        {
            char[] portion = new char[(letters.Length) / 3];

            for (int i = 0; i < portion.Length; i++)
            {
                portion[i] = letters[i + (section * portion.Length)]; 
            }

            return portion;
        }

        public void Paint(PaintEventArgs e)
        {
            for (int i = 0; i < grids.Length; i++)
            {
                grids[i].Paint(e);
            }
        }
    }
}
