using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyfitLibrary
{
    public class Device
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string GetDeviceId()
        {
            Hardware hardware = new Hardware();
            var DeviceId = hardware.DeviceId;
            if (!string.IsNullOrWhiteSpace(DeviceId) && (DeviceId != "unknown"))
                this.Id = DeviceId;
            else
                this.Id = "01234567890";
            return Id;

        }
    }
}
