﻿#region File Description
//-----------------------------------------------------------------------------
// TiledMapObject
//
// Copyright © 2014 Wave Corporation
// Use is subject to license terms.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace WaveEngine.TiledMap
{
    public class TiledMapObject
    {
        #region Properties
        /// <summary>
        /// Gets the object name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the object type
        /// </summary>
        public TiledMapObjectType ObjectType { get; private set; }

        /// <summary>
        /// Gets the object type property
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Gets the X position
        /// </summary>
        public float X { get; private set; }

        /// <summary>
        /// Gets the Y position
        /// </summary>
        public float Y { get; private set; }

        /// <summary>
        /// Gets the With size
        /// </summary>
        public float Width { get; private set; }

        /// <summary>
        /// Gets the Height size
        /// </summary>
        public float Height { get; private set; }

        /// <summary>
        /// Gets the rotation
        /// </summary>
        public double Rotation { get; private set; }

        /// <summary>
        /// Gets the asociated tile
        /// </summary>
        public LayerTile Tile { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this object is visible
        /// </summary>
        public bool Visible { get; private set; }

        /// <summary>
        /// Gets the point list 
        /// </summary>
        public List<Tuple<int, int>> Points { get; private set; }

        /// <summary>
        /// Gets the object property list
        /// </summary>
        public Dictionary<string, string> Properties { get; private set; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="TiledMapObject" /> class.
        /// </summary>
        /// <param name="tmxObject">The TMX parsed object</param>
        public TiledMapObject(TiledSharp.TmxObjectGroup.TmxObject tmxObject)
        {
            this.Name = tmxObject.Name;
            this.ObjectType = (TiledMapObjectType)((int)tmxObject.ObjectType);
            this.Type = tmxObject.Type;
            this.X = tmxObject.X;
            this.Y = tmxObject.Y;
            this.Width = tmxObject.Width;
            this.Height = tmxObject.Height;
            this.Rotation = tmxObject.Rotation;
            this.Visible = tmxObject.Visible;

            this.Properties = new Dictionary<string, string>(tmxObject.Properties);
            if (tmxObject.Points != null)
            {
                this.Points = new List<Tuple<int, int>>(tmxObject.Points);
            }
        }
        #endregion
    }
}
