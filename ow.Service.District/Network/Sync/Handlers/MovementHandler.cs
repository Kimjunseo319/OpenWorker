﻿using ow.Framework.IO.Network.Sync.Attributes;
using ow.Framework.IO.Network.Sync.Opcodes;
using ow.Framework.IO.Network.Sync.Permissions;
using ow.Framework.IO.Network.Sync.Requests;
using ow.Framework.IO.Network.Sync.Responses;

namespace ow.Service.District.Network.Sync.Handlers
{
    internal static class MovementHandler
    {
        [Handler(ServerOpcode.MovementJump, HandlerPermission.Authorized)]
        public static void Jump(Session session, MovementJumpRequest request)
        {
            session.Character.Place.Position = request.Position;
            session.Character.Place.Rotation = request.Rotation;

            session.Dimension!.BroadcastAsync(request);
        }

        [Handler(ServerOpcode.MovementLoopMotionEnd, HandlerPermission.Authorized)]
        public static void LoopMotionEndBroadcast(Session session) =>
            session.Dimension!.BroadcastAsync(new CharacterLoopMotionEndResponse() { Character = session.Character.Id });

        [Handler(ServerOpcode.MovementMove, HandlerPermission.Authorized)]
        public static void Move(Session session, MovementMoveRequest request)
        {
            session.Character.Place.Position = request.Position;
            session.Character.Place.Rotation = request.Rotation;

            session.Dimension!.BroadcastAsync(request);
        }

        [Handler(ServerOpcode.MovementStopBt, HandlerPermission.Authorized)]
        public static void Stop(Session session, MovementStopRequest request)
        {
            session.Character.Place.Position = request.Position;
            session.Character.Place.Rotation = request.Rotation;

            session.Dimension!.BroadcastAsync(request);
        }
    }
}