using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TurboDisplay.source.common.aim;

namespace AimEmulator
{
    class AimData
    {

        AimPacket[] packets_ = new AimPacket[(int)AimType.MAX];

        public AimData()
        {
            byte[] emptyBytes = new byte[5]; ;
            for (int i = 0; i < (int)AimType.MAX; i++)
                packets_[i] = new AimPacket(emptyBytes);
        }

        public string getString(AimType t)
        {
            return packets_[(int)t].toString();
        }

        public int getData(AimType t)
        {
            return packets_[(int)t].getValue();
        }

        public void setPacket(AimType t, AimPacket packet)
        {
            packets_[(int)t] = packet;
        }

        public double getConvertedData(AimType t)
        {
            return packets_[(int)t].getConvertedValue();
        }
        
    }
}
