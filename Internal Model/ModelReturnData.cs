using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoboSub.Internal_Model
{
    /// <summary>
    /// Holds the 8 coordinates of an object.
    /// </summary>
    class ModelReturnData
    {
        //instance fields
        private int[] coord1, coord2, coord3, coord4, coord5, coord6, coord7, coord8, specPoint;

        public int[] SpecPoint
        {
            get { return specPoint; }
            set { specPoint = value; }
        }

        public int[] Coord8
        {
            get { return coord8; }
            set { coord8 = value; }
        }

        public int[] Coord7
        {
            get { return coord7; }
            set { coord7 = value; }
        }

        public int[] Coord6
        {
            get { return coord6; }
            set { coord6 = value; }
        }

        public int[] Coord5
        {
            get { return coord5; }
            set { coord5 = value; }
        }

        public int[] Coord4
        {
            get { return coord4; }
            set { coord4 = value; }
        }

        public int[] Coord3
        {
            get { return coord3; }
            set { coord3 = value; }
        }

        public int[] Coord2
        {
            get { return coord2; }
            set { coord2 = value; }
        }

        public int[] Coord1
        {
            get { return coord1; }
            set { coord1 = value; }
        }
        public string name;
        /// <summary>
        /// Holds the 8 coordinates of an object.
        /// </summary>
        public ModelReturnData()
        {
        }
    }
}
