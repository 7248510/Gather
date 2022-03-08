package com.gather.com.gather.maven.eclipse;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.net.URL;
import org.apache.commons.io.FileUtils;
import java.util.Scanner;  


/*
 * Gather written in Java instead of C#
 */


public class App 
{
	public static final String currentDir = System.getProperty("user.dir");
	
    public static void main( String[] args ) throws InterruptedException
    {
        System.out.println( "Hello from Maven" );
        /*
        String url = "http://10.0.1.4/DataSet.zip";
        String file = "C:\\Users\\Caleb\\Desktop\\dataset.zip";
        */
        try {
            //FileUtils.copyURLToFile(new URL(url), new File(file), 10000, 10000);
			FileInputStream currentURL = new FileInputStream(currentDir + "\\data.txt");		
			setup();
			int numberCount = 0;
			Scanner urlList = new Scanner(currentURL);
				while(urlList.hasNextLine())  
				{  
					String currentLink = urlList.nextLine();
					downloadFile(currentLink, numberCount);
					++numberCount;
				}  
				urlList.close(); //Close the file once operations are complete
				System.out.println("Files have been downloaded.");
         }catch (IOException error) {
            error.printStackTrace();
         }
    }
    
    
    
    public static void setup() {
    	File projectRoot = new File(currentDir + "\\Images");
		boolean status = projectRoot.mkdir();
		
		if (status) {
			System.out.println("Directory created");
		}
		//Would prefer a more verbose method.
		else {
			System.out.println("Directory not created\nAlready exists");
		}
    }
    
    
    public static void downloadFile(String URL, int numberIndex) throws InterruptedException  {
    	System.out.println("URL INDEX: " + URL + "Number Index: "+ numberIndex);
    	String destination = currentDir + "\\dataset\\" + numberIndex + ".jpg";
    	try {
    		Thread.sleep(1000);
			FileUtils.copyURLToFile(new URL(URL), new File(destination), 10000, 10000);
		} catch (IOException error) {
			// TODO Auto-generated catch block
			error.printStackTrace();
		}
    }
}
