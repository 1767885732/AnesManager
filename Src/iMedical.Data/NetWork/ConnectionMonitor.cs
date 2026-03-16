using System;
using System.Collections.Generic;
using System.Text;
using System.Net.NetworkInformation;

namespace Wis.Anes.Data
{
    public class ConnectionMonitor
    {
        //单例
        private static ConnectionMonitor networkMonitor = null ;
        private NetworkInterface adapter;
        public static ConnectionMonitor GetCurrentMonitor()
        {
            if (networkMonitor == null)
            {
                networkMonitor = new ConnectionMonitor();
            }

            return networkMonitor;
        }

  
        private ConnectionMonitor()
        {

            RegisterNetEvent();
            adapter = DetectConnectedAdapter();
        }

        public void RegisterNetEvent()
        {

            NetworkChange.NetworkAddressChanged += NetworkChange_NetworkAddressChanged;
            NetworkChange.NetworkAvailabilityChanged += NetworkChange_NetworkAvailabilityChanged;
        }


        public void UnRegisterNetEvent()
        {
            NetworkChange.NetworkAvailabilityChanged -= NetworkChange_NetworkAvailabilityChanged;
            NetworkChange.NetworkAddressChanged -= NetworkChange_NetworkAddressChanged;

        }
        void NetworkChange_NetworkAddressChanged(object sender, EventArgs e)
        {
            NotifyNetworkAddressChange();
            //   DisplayNetworkInfo();
        }

        void NetworkChange_NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            NotifyNetworkAvailabilityChange();
            //  DisplayNetworkInfo();
        }

        private void NotifyNetworkAvailabilityChange()
        {
            adapter = DetectConnectedAdapter();

            if (adapter != null && IsConnected)
            {

            }

            else
            {

            }
        }

        private void NotifyNetworkAddressChange()
        {
            adapter = DetectConnectedAdapter();

            if (adapter != null && IsConnected)
            {

            }

            else
            {

            }
        }
      
        
        private void DisplayNetworkInfo()
        {/*
            adapter = DetectConnectedAdapter();

            if (adapter != null && IsConnected)
            {
                
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("网络适配器: {0}\n", adapter.Name);
                sb.AppendLine(adapter.Description);
                sb.AppendLine(String.Empty.PadLeft(adapter.Description.Length, '='));
                sb.AppendFormat("接口类型 ................................. : {0}\n", adapter.NetworkInterfaceType);
                sb.AppendFormat("网络连接操作状态 ............................. : {0}\n", adapter.OperationalStatus);
                sb.AppendFormat("网络接口速度 ............................. : {0}\n", adapter.Speed);
                sb.AppendFormat("MAC地址 ............................. : {0}\n", adapter.GetPhysicalAddress());

                string versions = String.Empty;
                if (adapter.Supports(NetworkInterfaceComponent.IPv4))
                {
                    versions = "IPv4";
                }
                if (adapter.Supports(NetworkInterfaceComponent.IPv6))
                {
                    if (versions.Length > 0)
                    {
                        versions += " ";
                    }
                    versions += "IPv6";
                }
                sb.AppendFormat("IP 版本 ..................................... : {0}\n", versions);

                IPAddressCollection dnsServers = adapter.GetIPProperties().DnsAddresses;
                if (dnsServers != null)
                {
                    foreach (IPAddress dns in dnsServers)
                    {
                        sb.AppendFormat("DNS 服务器 ............................. : {0}\n",
                                        dns.ToString()
                            );
                    }
                }


                UpdateTextBox(sb.ToString());
               

            }
            else
            {
           
                
                UpdateTextBox("网络无连接");
                
            }*/

        }

        protected virtual NetworkInterface DetectConnectedAdapter()
        {
            foreach (NetworkInterface theAdapter in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (theAdapter.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                    theAdapter.OperationalStatus == OperationalStatus.Up)
                {
                    return theAdapter;
                }
            }
            return null;
        }

        public bool IsConnected
        {
            get { return true ; }
        }








    }

}
