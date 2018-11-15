using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Andrew_s_MahJong //pairs show up twice seem good, 3 layers up seem good
{
    public partial class MahJong : Form
    {
        private Random rand = new Random();

        private int[] selected = new int[2]; //click two selected
        private int[] layer = new int[2]; //click 3D layer position
        private string map; //Grid3D designs: Cube, Fence, Pool
        
        Grid3D mainGrid3D;

        public MahJong()
        {
            InitializeComponent();
            ResetSelectedLayer();
            RandomizeMap();
        }

        private void RandomizeMap() //randomizes the map
        {
            int randNum = rand.Next(0, 3);

            switch (randNum)
            {
                case 0:
                    map = "Cube";
                    break;
                case 1:
                    map = "Fence";
                    break;
                case 2:
                    map = "Pool";
                    break;
            }
        }

        //Click Tiles
        private void Mouse_Down(object sender, MouseEventArgs e)
        {
            if (mainGrid3D != null)
            {
                int[] clicked = mainGrid3D.Click(e.X, e.Y); //gets the layer and array position of a clicked tile 

                if (selected[0] == -1)
                {
                    for (int i = 0; i < clicked.Length; i++) //set selected 0
                    {
                        if (clicked[i] != -1)
                        {
                            layer[0] = i;
                            selected[0] = clicked[i];
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < clicked.Length; i++) //set selected 1
                    {
                        if (clicked[i] != -1)
                        {
                            layer[1] = i;
                            selected[1] = clicked[i];
                        }
                    }

                    if (selected[1] != -1)
                    {
                        if (mainGrid3D.Grids[layer[0]].Tiles[selected[0]].Text == mainGrid3D.Grids[layer[1]].Tiles[selected[1]].Text) //compare texts
                        {
                            if (mainGrid3D.Grids[layer[0]].Tiles[selected[0]] != mainGrid3D.Grids[layer[1]].Tiles[selected[1]]) //not the same tile
                            {
                                mainGrid3D.Grids[layer[0]].Tiles[selected[0]].Text = "-1";
                                mainGrid3D.Grids[layer[1]].Tiles[selected[1]].Text = "-1";

                                ResetSelectedLayer();
                            }
                            else //set selected 0 equal to selected 1
                            {
                                layer[0] = layer[1];
                                selected[0] = selected[1];

                                layer[1] = -1;
                                selected[1] = -1;
                            }
                        }
                        else //set selected 0 equal to selected 1
                        {
                            layer[0] = layer[1];
                            selected[0] = selected[1];

                            layer[1] = -1;
                            selected[1] = -1;
                        }
                    }
                    else
                    {
                        ResetSelectedLayer(); //reset
                    }
                }

                this.Invalidate();
            }
        }
        private void ResetSelectedLayer()
        {
            selected[0] = -1;
            selected[1] = -1;
            layer[0] = -1;
            layer[1] = -1;
        }


        //Menu Events
        private void Click_NewGame(object sender, EventArgs e)
        {
            mainGrid3D = null;
            mainGrid3D = new Grid3D(map, 0, 25);
            this.Invalidate();
        }

        private void Click_Random(object sender, EventArgs e)
        {
            RandomizeMap();
        }
        private void Click_Cube(object sender, EventArgs e)
        {
            map = "Cube";
        }
        private void Click_Fence(object sender, EventArgs e)
        {
            map = "Fence";
        }
        private void Click_Pool(object sender, EventArgs e)
        {
            map = "Pool";
        }

        //paint events
        private void Paint_Everything(object sender, PaintEventArgs e)
        {
            if (mainGrid3D != null)
            {
                mainGrid3D.Paint(e);
            }
        }
    }
}
