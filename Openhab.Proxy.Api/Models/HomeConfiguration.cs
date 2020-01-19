using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Openhab.Proxy.Api.Models
{
    public class HomeConfiguration
    {
        public string Id { get; set; }
        public Guid Uuid { get; set; }
        public string Token { get; set; }
        public IEnumerable<Zone> Zones { get; set; }
    }

    public class Zone
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
    }

    public class Room
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Device> Devices { get; set; }
    }

    public class Device
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Room { get; set; }
        public string Zone { get; set; }
        public string Type { get; set; }
        public string OpenhabType { get; set; }
    }

}
