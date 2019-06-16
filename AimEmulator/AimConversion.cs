using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace TurboDisplay.source.common.aim
{
    class AimConversion
    {
        public static double convert(int value, int channel)
        {
            double converted = 0;
            switch (channel)
            {
                case 1:
                case 69:
                case 113:
                    {
                        converted = value;
                        break;
                    }

                case 5:
                case 45:
                    {
                        converted = value / 10.0;
                        break;
                    }

                case 9:
                case 21:
                case 105:
                    {
                        converted = value / 1000.0;
                        break;
                    }

                case 13:
                case 17:
                case 97:
                case 101:
                case 109:
                    {
                        converted = value / 10.0 - 100;
                        break;
                    }

                case 33:
                    {
                        converted = value / 100.0;
                        break;
                    }

                default:
                    {
                        converted = value;
                        break;
                    }
            }
            return converted;
        }
    }
}
