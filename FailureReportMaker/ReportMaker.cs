using System;
using System.Collections.Generic;

namespace Incapsulation.Failures
{
    public enum FailureType
    {
        unexpected_shutdown,
        short_non_responding,
        hardware_failures,
        connection_problems
    }

    public class Device
    {
        public Device(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public int ID;
        public string Name;
    }

    public class Failure
    {
        public Failure(FailureType type, Device device, DateTime date)
        {
            Type = type;
            Device = device;
            Date = date;
        }

        public FailureType Type;
        public Device Device;
        public DateTime Date;
    }

    public class ReportMaker
    {
        /// <summary>
        /// </summary>
        /// <param name="day"></param>
        /// <param name="failureTypes">
        /// 0 for unexpected shutdown, 
        /// 1 for short non-responding, 
        /// 2 for hardware failures, 
        /// 3 for connection problems
        /// </param>
        /// <param name="deviceId"></param>
        /// <param name="times"></param>
        /// <param name="devices"></param>
        /// <returns></returns>
        public static List<string> FindDevicesFailedBeforeDateObsolete(
            int day,
            int month,
            int year,
            int[] failureTypes, 
            int[] deviceId, 
            object[][] times,
            List<Dictionary<string, object>> devices)
        {
            var problematicDevices = new HashSet<int>();

            var failures = new List<Failure>();

            for (int i = 0; i < failureTypes.Length; i++)
            {
                int vYear = (int)times[i][2];
                int vMonth = (int)times[i][1];
                int vDay = (int)times[i][0];

                failures.Add(new Failure
                    ((FailureType)failureTypes[i],
                    new Device(deviceId[i], devices[deviceId[i]]["Name"] as string),
                    new DateTime(vYear, vMonth, vDay))
                    );
            }

            DateTime date = new DateTime(year, month, day);
            return FindDevicesFailedBeforeDate(date, failures);
        }


        public static List<string> FindDevicesFailedBeforeDate(DateTime Date,
            List<Failure> failures)
        {
            var result = new List<string>();

            foreach (var failure in failures)
            {
                if ((int)failure.Type % 2 == 0 && failure.Date < Date)
                    result.Add(failure.Device.Name);
            }

            return result;
        }

    }
}
