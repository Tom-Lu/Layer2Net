using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using PcapDotNet.Base;
using PcapDotNet.Packets.Ethernet;
using PcapDotNet.Packets.IpV4;
using System.Collections;

namespace Layer2Net
{
    public static class UtilityLib
    {
        public static MacAddress BroadcastMac = new MacAddress("FF:FF:FF:FF:FF:FF");

        public static byte[] ToBytes(this IpV4Address address)
        {
            uint address_value = address.ToValue();
            return new byte[] 
            { 
                (byte)(address_value >> 24 & 0xFF),
                (byte)(address_value >> 16 & 0xFF),
                (byte)(address_value >> 8 & 0xFF),
                (byte)(address_value & 0xFF),
            };
        }

        public static IpV4Address ToIpV4Address(this byte[] array)
        {
            uint address_value = 0;

            address_value = array[3];
            address_value = (address_value << 8) + array[2];
            address_value = (address_value << 8) + array[1];
            address_value = (address_value << 8) + array[0];

            return new IpV4Address(address_value);
        }

        public static byte[] ToBytes(this MacAddress address)
        {
            ulong address_value = (ulong)address.ToValue();
            return new byte[] 
            { 
                (byte)(address_value >> 40 & 0xFF),
                (byte)(address_value >> 32 & 0xFF),
                (byte)(address_value >> 24 & 0xFF),
                (byte)(address_value >> 16 & 0xFF),
                (byte)(address_value >> 8 & 0xFF),
                (byte)(address_value & 0xFF),
            };
        }

        public static MacAddress ToMacAddress(this byte[] array)
        {
            ulong mac_address_value = 0;

            mac_address_value = array[0];
            mac_address_value = (mac_address_value << 8) + array[1];
            mac_address_value = (mac_address_value << 8) + array[2];
            mac_address_value = (mac_address_value << 8) + array[3];
            mac_address_value = (mac_address_value << 8) + array[4];
            mac_address_value = (mac_address_value << 8) + array[5];

            return new MacAddress((UInt48)mac_address_value);
        }

        public static uint GetVirtualAdapterHashCode(string MAC, string IP, ushort VLAN)
        {
            return Hash(UtilityLib.ByteArrayJoin(UtilityLib.ByteArrayJoin(new MacAddress(MAC).ToBytes(), new IpV4Address(IP).ToBytes()), BitConverter.GetBytes(VLAN)));
        }

        public static uint GetVirtualAdapterHashCode(MacAddress MAC, IpV4Address IP, ushort VLAN)
        {
            return Hash(UtilityLib.ByteArrayJoin(UtilityLib.ByteArrayJoin(MAC.ToBytes(), IP.ToBytes()), BitConverter.GetBytes(VLAN)));
        }

        public static uint GetTcpSessionHashCode(IpV4Address LocalIP, ushort LocalPort, IpV4Address RemoteIP, ushort RemotePort)
        {
            byte[] LocalAdress = UtilityLib.ByteArrayJoin(LocalIP.ToBytes(), BitConverter.GetBytes(LocalPort));
            byte[] RemoteAdress = UtilityLib.ByteArrayJoin(RemoteIP.ToBytes(), BitConverter.GetBytes(RemotePort));
            return Hash(UtilityLib.ByteArrayJoin(LocalAdress, RemoteAdress));
        }

        public static byte[] ByteArrayJoin(byte[] array1, byte[] array2)
        {
            byte[] result_array = new byte[array1.Length + array2.Length];
            Array.Copy(array1, result_array, array1.Length);
            Array.Copy(array2, 0, result_array, array1.Length, array2.Length);
            return result_array;
        }

        public static T[] ToArray<T>(this ICollection collection)
        {
            T[] array = new T[collection.Count];
            collection.CopyTo(array, 0);
            return array;
        }

        public static UInt32 Hash(Byte[] dataToHash)
        {
            Int32 dataLength = dataToHash.Length;
            if (dataLength == 0)
                return 0;
            UInt32 hash = (UInt32)dataLength;
            Int32 remainingBytes = dataLength & 3; // mod 4
            Int32 numberOfLoops = dataLength >> 2; // div 4
            Int32 currentIndex = 0;
            while (numberOfLoops > 0)
            {
                hash += (UInt16)(dataToHash[currentIndex++] | dataToHash[currentIndex++] << 8);
                UInt32 tmp = (UInt32)((UInt32)(dataToHash[currentIndex++] | dataToHash[currentIndex++] << 8) << 11) ^ hash;
                hash = (hash << 16) ^ tmp;
                hash += hash >> 11;
                numberOfLoops--;
            }

            switch (remainingBytes)
            {
                case 3:
                    hash += (UInt16)(dataToHash[currentIndex++] | dataToHash[currentIndex++] << 8);
                    hash ^= hash << 16;
                    hash ^= ((UInt32)dataToHash[currentIndex]) << 18;
                    hash += hash >> 11;
                    break;
                case 2:
                    hash += (UInt16)(dataToHash[currentIndex++] | dataToHash[currentIndex] << 8);
                    hash ^= hash << 11;
                    hash += hash >> 17;
                    break;
                case 1:
                    hash += dataToHash[currentIndex];
                    hash ^= hash << 10;
                    hash += hash >> 1;
                    break;
                default:
                    break;
            }

            /* Force "avalanching" of final 127 bits */
            hash ^= hash << 3;
            hash += hash >> 5;
            hash ^= hash << 4;
            hash += hash >> 17;
            hash ^= hash << 25;
            hash += hash >> 6;

            return hash;
        }
    }
}
