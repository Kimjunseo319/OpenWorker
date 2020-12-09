﻿using ow.Framework.Game.Extensions;
using System.Xml;

namespace ow.Framework.Game.Datas.World.Table.EventBox
{
    public sealed class VPortalExitBox : VEntity
    {
        /// <summary>
        /// PortalBox ID of connected
        /// </summary>
        public uint ParentPortal { get; }

        internal VPortalExitBox(XmlNode xml) : base(xml) =>
            ParentPortal = xml.GetUInt32("m_iParentPortalBoxID");
    }
}