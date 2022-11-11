namespace læseOgSkirveIFil
{

    class program
    {
        static void Main(String[] args)
        {

            // den overwrite hele vores fil og slette alt text der stod før i vores fil 

            if (File.Exists("C:\\Users\\kaspe\\OneDrive\\Skrivebord\\pepsi.txt")) // hvis vi ikke havde denne line code og vores file ikke findes så ville den bare laver en ny 
            {
                string hvad_Vi_skrive_i_vores_file = "det virker"; // hvad vi havde skal står i vores file 

                File.WriteAllText("C:\\Users\\kaspe\\OneDrive\\Skrivebord\\pepsi.txt", hvad_Vi_skrive_i_vores_file); // her skrive i vores fil 
            }



            if (File.Exists("C:\\Users\\kaspe\\OneDrive\\Skrivebord\\pepsi.txt"))
            {
                string pepsi = File.ReadAllText("C:\\Users\\kaspe\\OneDrive\\Skrivebord\\pepsi.txt"); // vi gør at vores file bliv taget som en Data type string 
                Console.WriteLine(pepsi);
            }






        }
    }
}