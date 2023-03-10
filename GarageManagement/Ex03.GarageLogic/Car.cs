using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eColors
    {
        Red=1,
        Blue,
        White,
        Gray
    }

    public enum eDoors
    {
        Two=1,
        Three,
        Four,
        Five
    }

    internal class Car : Vehicle
    {
        private eColors m_Color;
        private eDoors m_Doors;

        internal Car(string i_LicenseNumber, uint i_NumOfWheels, float io_MaxAirPressure, object i_EngineType):
        base(i_LicenseNumber,i_NumOfWheels,io_MaxAirPressure,i_EngineType)
        {

        }

        internal eColors Color
        {
            get { return m_Color; }
            set
            {
                if (Enum.IsDefined(typeof(eColors), value))
                {
                    m_Color = value;
                }
                else
                {
                    Exception ex = new Exception("The color is invalid!");
                    throw new ValueOutOfRangeException(ex, (float)Enum.GetValues(typeof(eColors)).Length, 1f);
                }
            }
        }

        internal eDoors Doors
        {
            get { return m_Doors; }
            set
            {
                if (Enum.IsDefined(typeof(eDoors), value))
                {
                    m_Doors = value;
                }
                else
                {
                    Exception ex = new Exception("Number of doors is invalid!");
                    throw new ValueOutOfRangeException(ex, (float)Enum.GetValues(typeof(eDoors)).Length, 1f);
                }
            }
        }

        internal static string ShowDoorsOptions()
        {
            StringBuilder doors = new StringBuilder();

            foreach (eDoors door in Enum.GetValues(typeof(eDoors)))
            {
                doors.Append(string.Format("{0}. {1}{2}", (int)door, door.ToString(), Environment.NewLine));
            }

            return doors.ToString();
        }

        internal static string ShowColorsOptions()
        {
            StringBuilder colors = new StringBuilder();

            foreach (eColors color in Enum.GetValues(typeof(eColors)))
            {
                colors.Append(string.Format("{0}. {1}{2}", (int)color, color.ToString(), Environment.NewLine));
            }

            return colors.ToString();
        }

        public override string ToString()
        {
            string carInfo = string.Format(
                "{0}The color of the car is {1} and it has {2} doors{3}",
                base.ToString(),
                Color.ToString(),
                Doors.ToString(),
                Environment.NewLine);

            return carInfo;
        }
    }
}
