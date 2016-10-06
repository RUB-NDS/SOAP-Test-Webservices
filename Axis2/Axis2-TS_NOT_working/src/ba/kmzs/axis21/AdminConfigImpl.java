/**
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
package ba.kmzs.axis21;

import java.io.UnsupportedEncodingException;
import java.util.Date;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.util.logging.Level;
import java.util.logging.Logger;

import javax.jws.WebService;

@WebService(endpointInterface = "ba.kmzs.axis21.AdminConfig")
public class AdminConfigImpl implements AdminConfig {
    public String getServerTime() {
        Date current_date = new Date();
        DateFormat df = new SimpleDateFormat("dd/MM/yyyy HH:mm:ss");
        System.out.println(df.format(current_date) + ": getServerTime() called");
	return df.format(current_date);
    }
	
	public String getAdminToken() {
            String output = "ERROR";
        try {
            Date current_date = new Date();
            DateFormat df = new SimpleDateFormat("dd/MM/yyyy HH:mm:ss");
            System.out.println(df.format(current_date) + ": getAdminToken() called");
            
            MessageDigest md = MessageDigest.getInstance("SHA-256");
            md.update(df.format(current_date).getBytes("UTF-8"));
            byte[] digest = md.digest();         
            output = String.format("%064x", new java.math.BigInteger(1, digest));
        } catch (NoSuchAlgorithmException ex) {
            System.out.println("Error: NoSuchAlgorithmException");
            Logger.getLogger(AdminConfigImpl.class.getName()).log(Level.SEVERE, null, ex);
        } catch (UnsupportedEncodingException ex) {
            System.out.println("Error: UnsupportedEncodingException");
            Logger.getLogger(AdminConfigImpl.class.getName()).log(Level.SEVERE, null, ex);
        }
        return output;
	}
}