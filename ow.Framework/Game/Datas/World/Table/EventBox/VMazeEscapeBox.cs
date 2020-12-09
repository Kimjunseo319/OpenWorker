﻿using ow.Framework.Game.Extensions;
using System.Xml;

namespace ow.Framework.Game.Datas.World.Table.EventBox
{
    public sealed class VMazeEscapeBox : VEntity
    {
        /// <summary>
        /// Field ID
        /// </summary>
        public uint Field { get; }

        /// <summary>
        /// ID of Event Object.
        /// </summary>
        public uint EventObject { get; }

        internal VMazeEscapeBox(XmlNode xml) : base(xml)
        {
            Field = xml.GetUInt32("m_iField");
            EventObject = xml.GetUInt32("m_iEventObject");
        }
    }
}