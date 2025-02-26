﻿using Lidgren.Network;
using RoomEnum;

namespace NetworkThread.Multiplayer.Packets
{
    public class RoomPacket
    {
        public int Id { get; set; }
        public string Name {  set; get; }
        public RoomMode roomMode { get; set; }
        public RoomStatus roomStatus { get; set; }
        public RoomType roomType { get; set;}

        public void Serialize(NetOutgoingMessage message)
        {
            message.Write(Id);
            message.Write(Name);
            message.Write((byte)roomMode);
            message.Write((byte)roomStatus);
            message.Write((byte)roomType);
        }

        public static RoomPacket Deserialize(NetIncomingMessage message)
        {
            return new RoomPacket
            {
                Id = message.ReadInt32(),
                Name = message.ReadString(),
                roomMode = (RoomMode)message.ReadByte(),
                roomStatus = (RoomStatus)message.ReadByte(),
                roomType = (RoomType)message.ReadByte(),
            };
        }
    }
}