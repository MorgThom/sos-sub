using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoboSub.Exceptions;

namespace RoboSub.RSMath
{
    static class CoordinateMath
    {
        /// <summary>
        /// Gets the distance in the horizontal plane to a point.
        /// </summary>
        /// <param name="curX">The current X location</param>
        /// <param name="curY">The current Y location</param>
        /// <param name="destX">The destination X location</param>
        /// <param name="destY">The destination Y location</param>
        /// <returns>The horizontal plane distance.</returns>
        public static double getHorizontalPlaneDistanceToPoint(double curX, double curY, double destX, double destY)
        {
            return Math.Sqrt(Math.Pow((destX - curX), 2) + Math.Pow((destY - curY), 2));
        }
        /// <summary>
        /// Gets the adjusted heading to a point in radians.
        /// (How far to turn to be facing it)
        /// </summary>
        /// <param name="curX">The current X location</param>
        /// <param name="curY">The current Y location</param>
        /// <param name="destX">The destination X location</param>
        /// <param name="destY">The destination Y location</param>
        /// <param name="curHeading">The sub's current heading in polar, radians (between -Pi and Pi)</param>
        /// <returns>The adjusted heading to a point.</returns>
        public static double getHeadingToPoint(double curX, double curY, double destX, double destY, double curHeading)
        {
            double unAdjHeading;
            if ((destX - curX) != 0)
                unAdjHeading = Math.Atan2(destY - curY, destX - curX);
            else if (destY - curY > 0)
                unAdjHeading = Math.PI / 2;
            else if (destY - curY < 0)
                unAdjHeading = -Math.PI / 2;
            else
                unAdjHeading = 0;
            return curHeading - unAdjHeading;
        }
        /// <summary>
        /// Gets the change in depth/altitude to a point.
        /// </summary>
        /// <param name="curZ">Current z location</param>
        /// <param name="destZ">Destination z location</param>
        /// <returns>Necessary depth change.</returns>
        public static double getDepthChange(double curZ, double destZ)
        {
            return destZ - curZ;
        }

        /// <summary>
        /// Gets the angle of elevation from the current horizontal plane to a point.
        /// </summary>
        /// <param name="curX">Current x location</param>
        /// <param name="destX">Destination x location</param>
        /// <param name="curY">Current y location</param>
        /// <param name="destY">Destination y location</param>
        /// <param name="curZ">Current z location</param>
        /// <param name="destZ">Destination z location.</param>
        /// <returns>elevation angle.</returns>
        public static double getElevationAngleToPoint(double curX, double destX, double curY,
                                                      double destY, double curZ, double destZ)
        {
            double hPDistance = getHorizontalPlaneDistanceToPoint(curX, curY, destX, destY); //horizontal plane distance.
            double zDiff = getDepthChange(curZ, destZ); //Difference in z's. Why did I make a method for that?
            double elevationAngle = Math.Atan2(zDiff, hPDistance); //Elevation angle. Explanation available upon request.
            //check if more than 90 up or down. Again, explanation of how this works available upon request.
            if (elevationAngle > Math.PI / 2)
            {
                elevationAngle = Math.PI - elevationAngle;
            }
            if (elevationAngle < -Math.PI / 2)
            {
                elevationAngle = -Math.PI - elevationAngle;
            }
            return elevationAngle;
        }

        /// <summary>
        /// Tells which octant a point is in.
        /// </summary>
        /// <param name="point">a point. 0 is x, 1 is y, 2 is z.</param>
        /// <returns>1-8, representing which octant.</returns>
        public static int getOctant(int[] point)
        {
            try
            {
                bool xPos = false;
                bool yPos = false;
                bool zPos = false;
                int octant = 0;
                if (point.Length != 3)
                    throw new InvalidInputException("Incorrect number of elements in input array.");
                //check if x y and z are positive.
                if (point[0] >= 0)
                    xPos = true;
                if (point[1] >= 0)
                    yPos = true;
                if (point[2] >= 0)
                    zPos = true;
                //decide which octant.
                if (zPos)
                {
                    if (xPos)
                    {
                        if (yPos)
                        {
                            octant = 1;
                        }
                        else
                        {
                            octant = 4;
                        }
                    }
                    else
                    {
                        if (yPos)
                        {
                            octant = 2;
                        }
                        else
                        {
                            octant = 3;
                        }
                    }
                }
                else
                {
                    if (xPos)
                    {
                        if (yPos)
                        {
                            octant = 5;
                        }
                        else
                        {
                            octant = 8;
                        }
                    }
                    else
                    {
                        if (yPos)
                        {
                            octant = 6;
                        }
                        else
                        {
                            octant = 7;
                        }
                    }
                }
                //return octant.
                return octant;

            }
            catch (InvalidInputException)
            {
                //error handling code here.
                return 0;
            }
        }
    }
}
