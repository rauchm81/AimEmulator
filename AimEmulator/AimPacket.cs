using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace TurboDisplay.source.common.aim
{
    enum AimType
    {
        RPM,
        WheelSpeed,
        OilPressure,
        OilTemp,
        WaterTemp,
        FuelPressure,
        BatteryVoltage,
        ThrottleAngle,
        ManifoldPress,
        AirChargeTemp,
        ExhausTemp,
        LambdaSensor,
        FuelTemp,
        Gear,
        MAX
    };

    class AimPacket
    {
        private byte[] m_rawData;
        private AimType m_type;

        public AimPacket(byte[] rawData)
        {
            m_rawData = rawData;
            setType();
        }

        public AimPacket(char[] rawData)
        {
            m_rawData = new byte[5];
            for (int i = 0; i < 5; i++)
                m_rawData[i] = (byte)rawData[i];
            setType();
        }

        private void setType()
        {
            switch (getChannel())
            {
                case 1: m_type = AimType.RPM; break;
                case 5: m_type = AimType.WheelSpeed; break;
                case 9: m_type = AimType.OilPressure; break;
                case 13: m_type = AimType.OilTemp; break;
                case 17: m_type = AimType.WaterTemp; break;
                case 21: m_type = AimType.FuelPressure; break;
                case 33: m_type = AimType.BatteryVoltage; break;
                case 45: m_type = AimType.ThrottleAngle; break;
                case 69: m_type = AimType.ManifoldPress; break;
                case 97: m_type = AimType.AirChargeTemp; break;
                case 101: m_type = AimType.ExhausTemp; break;
                case 105: m_type = AimType.LambdaSensor; break;
                case 109: m_type = AimType.FuelTemp; break;
                case 113: m_type = AimType.Gear; break;
                
                default:
                    {
                        break;
                    }
            }
        }

        public AimType getType()
        {
            return m_type;
        }

        public byte getChannel()
        {
            return m_rawData[0];
        }

        public byte getConstant()
        {
            return m_rawData[1]; // should always be 0xA3;
        }

        public int getValue()
        {
            int value = m_rawData[2] << 8 | m_rawData[3];
            return value;
        }

        public double getConvertedValue()
        {
            int value = m_rawData[2] << 8 | m_rawData[3];
            double converted = AimConversion.convert(value, getChannel());
            return converted;
        }

        public byte getCheckSum()
        {
            return m_rawData[4];
        }

        public string toString()
        {
            string s = getConvertedValue() + " ";

            switch (getChannel())
            {
                case 1: s += "RPM"; break;
                case 5: s += "Km/h"; break;
                case 9:
                case 21:
                    {
                        s += "Bar"; break;
                    }

                case 13:
                case 17:
                case 97:
                case 101:
                case 109:
                    {
                        s += "°C"; break;
                    }

                case 33: s += "Volt"; break;
                case 69: s += "mBar"; break;
                case 105: s += "Lambda"; break;

                default: break;
                    
            }

            return s;

        }

    }
}
