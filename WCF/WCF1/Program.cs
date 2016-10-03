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
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;
using System.ServiceModel.Description;

namespace WCF
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost serviceHost = null;
            ServiceHost tSSignHost = null;
            ServiceHost encTSSignHost = null;
            try
            {
                serviceHost = new ServiceHost(typeof(AdminConfig));
                serviceHost.Open();
                Console.WriteLine("No Security web service is online. WSDL: http://localhost:8081/?wsdl");
                tSSignHost = new ServiceHost(typeof(AdminConfigTSSign));
                tSSignHost.Open();
                Console.WriteLine("TS+Sign web service is online. WSDL: http://localhost:8082/?wsdl");
                encTSSignHost = new ServiceHost(typeof(AdminConfigEncTSSign));
                encTSSignHost.Open();
                Console.WriteLine("Enc+TS+Sign web service is online. WSDL: http://localhost:8083/?wsdl");
                Console.WriteLine("Press ENTER to shutdown the services.");
                Console.ReadLine();
                serviceHost.Close();
                tSSignHost.Close();
                encTSSignHost.Close();
            }
            catch (Exception ex)
            {
                serviceHost = null;
                tSSignHost = null;
                encTSSignHost = null;
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("Press ENTER to shutdown the services.");
                Console.ReadLine();
            }
        }
    }
}