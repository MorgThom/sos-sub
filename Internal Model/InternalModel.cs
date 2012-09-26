using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoboSub.Exceptions;

namespace RoboSub.Internal_Model {
    /// <summary>
    /// Instances a 3d byte array which stores locations of objects,
    /// the byte values of which can be looked up in the sorted dictionary.
    /// </summary>
    class InternalModel {
        //instance variables
        private int xGridSize, yGridSize, zGridSize;
        private int[] offset = new int[3];
        private byte[, ,] modelGrid; //each grid location represents a 1 decimeter cube.
        private Dictionary<byte, string> modelNameCodes;
        private Dictionary<byte, int[]> objectSpecPoints;
        /// <summary>
        /// Instantiates an internal model
        /// </summary>
        /// <param name="xGridSize">The size of the grid in the x direction</param>
        /// <param name="yGridSize">The size of the grid in the y direction</param>
        /// <param name="zGridSize">The size of the grid in the z direction</param>       
        public InternalModel(int xGridSize, int yGridSize, int zGridSize, int[] offset) {
            try {
                this.xGridSize = xGridSize;
                this.yGridSize = yGridSize;
                this.zGridSize = zGridSize;
                if (offset.Length != 3)
                    throw new InvalidInputException("Invalid offset array length.");
                this.offset = offset;
                modelGrid = new byte[xGridSize, yGridSize, zGridSize];
                for (int i = 0; i < xGridSize; i++) {
                    for (int j = 0; j < yGridSize; j++) {
                        for (int k = 0; k < zGridSize; k++) {
                            modelGrid[i, j, k] = 0;
                        }
                    }
                }
                modelNameCodes.Add(0, "empty");
            } catch (InvalidInputException) {
                //code for error handling here.
            }
        }
        /// <summary>
        /// Adds an object to the model. Coordinates must be opposite corners of the object.
        /// Coordinates are input as a length 3 array of ints, with index 0 being x, 1 being y, and 2 being z.
        /// </summary>
        /// <param name="name">The name of the object</param>
        /// <param name="coord1">The coordinate of one of the objects corners.</param>
        /// <param name="coord2">The coordinate of the opposite corner.</param>
        /// <param name="specPoint">The special point for the object.</param>
        public void AddObject(String name, int[] coord1, int[] coord2, int[] specPoint) {
            try {
                if (coord1.Length != 3 || coord2.Length != 3 || specPoint.Length != 3)
                    throw new InvalidInputException("Incorrect number of elements in a coordinate array");
                byte thisByteCode = FindEmptyKey(); //byte key for this object.
                modelNameCodes.Add(thisByteCode, name); //adds this object to the object dictionary.
                objectSpecPoints.Add(thisByteCode, specPoint); //adds the special point to the list of special points.
                int xLower = int.MaxValue, xUpper = int.MinValue, yLower = int.MaxValue,
                    yUpper = int.MinValue, zLower = int.MaxValue, zUpper = int.MinValue;
                //finds the upper and lower limits of each variable.
                //find lowest values
                if (coord1[0] < xLower) {
                    xLower = coord1[0];
                }
                if (coord2[0] < xLower) {
                    xLower = coord2[0];
                }
                if (coord1[1] < yLower) {
                    yLower = coord1[1];
                }
                if (coord2[1] < yLower) {
                    yLower = coord2[1];
                }
                if (coord1[2] < zLower) {
                    zLower = coord1[2];
                }
                if (coord2[2] < zLower) {
                    zLower = coord2[2];
                }
                //find upper limits
                if (coord1[0] > xUpper) {
                    xUpper = coord1[0];
                }
                if (coord2[0] > xUpper) {
                    xUpper = coord2[0];
                }
                if (coord1[1] > yUpper) {
                    yUpper = coord1[1];
                }
                if (coord2[1] > yUpper) {
                    yUpper = coord2[1];
                }
                if (coord1[2] > zUpper) {
                    zUpper = coord1[2];
                }
                if (coord2[2] > zUpper) {
                    zUpper = coord2[2];
                }
                //adjust by offset.
                xUpper += offset[0];
                xLower += offset[0];
                yUpper += offset[1];
                yLower += offset[1];
                zUpper += offset[2];
                zLower += offset[2];
                //fills the specified area with the byte key.
                for (int i = xLower; i <= xUpper; i++) {
                    for (int j = yLower; j <= yUpper; j++) {
                        for (int k = zLower; k <= zUpper; k++) {
                            modelGrid[i, j, k] = thisByteCode;
                        }
                    }
                }
            } catch (InvalidInputException) {
                //Code for error handling here.
            }
        }
        /// <summary>
        /// Finds an empty key in the dictionary.
        /// </summary>
        /// <returns>An empty byte key.</returns>
        public byte FindEmptyKey() {
            for (byte i = 1; i <= 255; i++) {
                if (!modelNameCodes.ContainsKey(i)) {
                    return i;
                }
            }
            return 0;
        }
        /// <summary>
        /// Searches for an object by name.
        /// Returns a ModelReturnData object containing the location of an object.
        /// </summary>
        /// <param name="name">The name of the object to search for.</param>
        /// <returns>ModelReturnData containing all 8 corners.</returns>
        public ModelReturnData FindObjectLocationByName(string name) {
            try {
                byte byteCodeSearch = 0;
                foreach (KeyValuePair<byte, string> pair in modelNameCodes) {
                    if (name.Equals(pair.Value)) {
                        byteCodeSearch = pair.Key;
                    }
                }
                if (byteCodeSearch == 0)
                    throw new ModuleNotFoundException();
                int xLower = int.MaxValue, xUpper = int.MinValue, yLower = int.MaxValue,
                    yUpper = int.MinValue, zLower = int.MaxValue, zUpper = int.MinValue;
                for (int i = 0; i < xGridSize; i++) {
                    for (int j = 0; j < yGridSize; j++) {
                        for (int k = 0; k < zGridSize; k++) {
                            if (modelGrid[i, j, k] == byteCodeSearch) {
                                if (i < xLower)
                                    xLower = i;
                                if (i > xUpper)
                                    xUpper = i;
                                if (j < yLower)
                                    yLower = j;
                                if (j > yUpper)
                                    yUpper = j;
                                if (k < zLower)
                                    zLower = k;
                                if (k > zUpper)
                                    zUpper = k;
                            }
                        }
                    }
                }
                //adjust by offset
                xUpper -= offset[0];
                xLower -= offset[0];
                yUpper -= offset[1];
                yLower -= offset[1];
                zUpper -= offset[2];
                zLower -= offset[2];
                //construct return object
                ModelReturnData objectReturn = new ModelReturnData();
                objectReturn.name = name;
                objectReturn.Coord1[0] = xLower;
                objectReturn.Coord1[1] = yLower;
                objectReturn.Coord1[2] = zLower;

                objectReturn.Coord2[0] = xUpper;
                objectReturn.Coord2[1] = yLower;
                objectReturn.Coord2[2] = zLower;

                objectReturn.Coord3[0] = xLower;
                objectReturn.Coord3[1] = yUpper;
                objectReturn.Coord3[2] = zLower;

                objectReturn.Coord4[0] = xUpper;
                objectReturn.Coord4[1] = yUpper;
                objectReturn.Coord4[2] = zLower;

                objectReturn.Coord5[0] = xLower;
                objectReturn.Coord5[1] = yLower;
                objectReturn.Coord5[2] = zUpper;

                objectReturn.Coord6[0] = xUpper;
                objectReturn.Coord6[1] = yLower;
                objectReturn.Coord6[2] = zUpper;

                objectReturn.Coord7[0] = xLower;
                objectReturn.Coord7[1] = yUpper;
                objectReturn.Coord7[2] = zUpper;

                objectReturn.Coord8[0] = xUpper;
                objectReturn.Coord8[1] = yUpper;
                objectReturn.Coord8[2] = zUpper;

                objectReturn.SpecPoint[0] = objectSpecPoints[byteCodeSearch][0];
                objectReturn.SpecPoint[1] = objectSpecPoints[byteCodeSearch][1];
                objectReturn.SpecPoint[2] = objectSpecPoints[byteCodeSearch][2];

                return objectReturn;
            } catch (ModuleNotFoundException) {
                //code for error handling here.
                return new ModelReturnData();
            }
        }

        /// <summary>
        /// Searches for an object given one of its corners.
        /// </summary>
        /// <param name="coordIn">A length three int representing a coordinate.</param>
        /// <returns>ModelReturnData containing all 8 corners.</returns>
        public ModelReturnData FindObjectLocationByCoord(int[] coordIn) {
            byte byteCodeSearch = modelGrid[coordIn[0], coordIn[1], coordIn[2]];
            int xLower = int.MaxValue, xUpper = int.MinValue, yLower = int.MaxValue,
                yUpper = int.MinValue, zLower = int.MaxValue, zUpper = int.MinValue;
            for (int i = 0; i < xGridSize; i++) {
                for (int j = 0; j < yGridSize; j++) {
                    for (int k = 0; k < zGridSize; k++) {
                        if (modelGrid[i, j, k] == byteCodeSearch) {
                            if (i < xLower)
                                xLower = i;
                            if (i > xUpper)
                                xUpper = i;
                            if (j < yLower)
                                yLower = j;
                            if (j > yUpper)
                                yUpper = j;
                            if (k < zLower)
                                zLower = k;
                            if (k > zUpper)
                                zUpper = k;
                        }
                    }
                }
            }
            //adjust by offset
            xUpper -= offset[0];
            xLower -= offset[0];
            yUpper -= offset[1];
            yLower -= offset[1];
            zUpper -= offset[2];
            zLower -= offset[2];
            //construct return object
            ModelReturnData objectReturn = new ModelReturnData();
            objectReturn.name = modelNameCodes[byteCodeSearch];
            objectReturn.Coord1[0] = xLower;
            objectReturn.Coord1[1] = yLower;
            objectReturn.Coord1[2] = zLower;

            objectReturn.Coord2[0] = xUpper;
            objectReturn.Coord2[1] = yLower;
            objectReturn.Coord2[2] = zLower;

            objectReturn.Coord3[0] = xLower;
            objectReturn.Coord3[1] = yUpper;
            objectReturn.Coord3[2] = zLower;

            objectReturn.Coord4[0] = xUpper;
            objectReturn.Coord4[1] = yUpper;
            objectReturn.Coord4[2] = zLower;

            objectReturn.Coord5[0] = xLower;
            objectReturn.Coord5[1] = yLower;
            objectReturn.Coord5[2] = zUpper;

            objectReturn.Coord6[0] = xUpper;
            objectReturn.Coord6[1] = yLower;
            objectReturn.Coord6[2] = zUpper;

            objectReturn.Coord7[0] = xLower;
            objectReturn.Coord7[1] = yUpper;
            objectReturn.Coord7[2] = zUpper;

            objectReturn.Coord8[0] = xUpper;
            objectReturn.Coord8[1] = yUpper;
            objectReturn.Coord8[2] = zUpper;

            objectReturn.SpecPoint[0] = objectSpecPoints[byteCodeSearch][0];
            objectReturn.SpecPoint[1] = objectSpecPoints[byteCodeSearch][1];
            objectReturn.SpecPoint[2] = objectSpecPoints[byteCodeSearch][2];

            return objectReturn;
        }

        /// <summary>
        /// Removes an object from the grid by name.
        /// </summary>
        /// <param name="name">The name of the object to be removed.</param>
        public void RemoveObjectByName(string name) {
            byte byteCodeSearch = 0;
            foreach (KeyValuePair<byte, string> pair in modelNameCodes) {
                if (name.Equals(pair.Value)) {
                    byteCodeSearch = pair.Key;
                }
            }
            for (int i = 0; i < xGridSize; i++) {
                for (int j = 0; j < yGridSize; j++) {
                    for (int k = 0; k < zGridSize; k++) {
                        if (modelGrid[i, j, k] == byteCodeSearch) {
                            modelGrid[i, j, k] = 0;
                        }
                    }
                }
            }
            modelNameCodes.Remove(byteCodeSearch);
            objectSpecPoints.Remove(byteCodeSearch);
        }
    }
}
