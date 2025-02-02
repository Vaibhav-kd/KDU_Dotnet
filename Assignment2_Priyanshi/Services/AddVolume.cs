﻿using Assignment2_newAttempt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_newAttempt.Services
{
    internal class AddVolume
    {
        public List<Coin> addVolumeInCoinsData(string coinName, long quantity, List<Coin> coinRecords)
        {
            Hash_Function hf = new Hash_Function();
            Thread backgroundThread = new Thread(() =>
            {
                hf.GetBlockHash();
            });
            backgroundThread.IsBackground = true;
            backgroundThread.Start();

            foreach (var i in coinRecords)
            {
                if (i.Name == coinName)
                    i.Circulating_Supply += quantity;
            }
            return coinRecords;
        }
    }
}
