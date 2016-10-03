/*
 * Copyright 2016 Karsten Meyer zu Selhausen
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF
{
    public class AdminConfigEncTSSign : IAdminConfigEncTSSign
    {
        public string getAdminToken()
        {
            string date = DateTime.Now.ToString("dd'/'MM'/'yyyy HH:mm:ss");
            Console.WriteLine(date + ": getAdminToken() called (EncTSSign)");
            return sha256(date);
        }

        public string getServerTime()
        {
            string date = DateTime.Now.ToString("dd'/'MM'/'yyyy HH:mm:ss");
            Console.WriteLine(date + ": getServerTime() called (EncTSSign)");
            return date;
        }

        //Original source: stackoverflow.com/questions/12416249/hashing-a-string-with-sha256
        private static string sha256(string input)
        {
            System.Security.Cryptography.SHA256Managed hashfunction = new System.Security.Cryptography.SHA256Managed();
            byte[] hash_bytes = hashfunction.ComputeHash(Encoding.UTF8.GetBytes(input), 0, Encoding.UTF8.GetByteCount(input));
            System.Text.StringBuilder hash_string = new StringBuilder();
            foreach (byte theByte in hash_bytes)
            {
                hash_string.Append(theByte.ToString("x2"));
            }
            return hash_string.ToString();
        }
    }
}
