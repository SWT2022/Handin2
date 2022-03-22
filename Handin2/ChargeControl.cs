﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsbSimulator;

namespace Handin2
{

    internal class ChargeControl
    {
        private double _current;
        private IUsbCharger _usbCharger;
        private Display _display;

        public ChargeControl(IUsbCharger usbCharger, Display display)
        {
            _display = display;
            _usbCharger = usbCharger;
            _usbCharger.CurrentValueEvent += HandleCurrentValueEvent;
        }

        private void HandleCurrentValueEvent(object s, CurrentEventArgs e)
        {
            _current = e.Current;
            if (_current > 0 && _current <= 5)
            {
                StopCharge();
                _display.DisplayFullyCharged();
            }
            else if (_current > 5 && _current <= 500)
            {
                _display.DisplayCharging();
            }
            else if (_current > 500)
            {
                StopCharge();
                _display.DisplayChargingError();
            }


        }

        public bool isConnected()
        {
            if (_usbCharger.Connected == true)
            {
                _usbCharger.StartCharge();
            }
            
            return _usbCharger.Connected;

        }

        public void StartCharge()
        {
            Console.WriteLine("Phone Charging started");
            _usbCharger.StartCharge();
        }

        public void StopCharge()
        {
            Console.WriteLine("Phone Charging stopped");
            _usbCharger.StopCharge();
        }

    }
}