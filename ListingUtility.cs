namespace mis_221_pa_5_clmiller16
{
    public class ListingUtility
    {
        private Listing[] listings;   

        public ListingUtility(Listing[] listings){
            this.listings = listings;
        }     


        // gets all the listings
        public void GetAllListingsFromFile()
        {
            //open
            StreamReader inFile = new StreamReader("listings.txt");

            //*** int wordCount = 0;


            //process
            Listing.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split('#');
                //*** wordCount+=temp.Length();
                listings[Listing.GetCount()] = new Listing(int.Parse(temp[0]), temp[1], DateOnly.Parse(temp[2]), temp[3], int.Parse(temp[4]), temp[5], bool.Parse(temp[6]), int.Parse(temp[7]));
                Listing.IncCount();
                line = inFile.ReadLine();
            }


            //close
            inFile.Close();
        }

        // adds a listing with (the max id + 1) ID
        public void AddListing(int max)
        {
            // System.Console.WriteLine("Please enter the ID");
            Listing myListing = new Listing();

            myListing.SetID(max);
            System.Console.WriteLine("Please enter the name");
            myListing.SetName(Console.ReadLine());
            System.Console.WriteLine("Please enter the date");
            myListing.SetDate(DateOnly.Parse(Console.ReadLine()));
            System.Console.WriteLine("Please enter the time");
            myListing.SetTime(Console.ReadLine());
            System.Console.WriteLine("Please enter the cost");
            myListing.SetCost(int.Parse(Console.ReadLine()));
            // System.Console.WriteLine("Please enter if it has been taken");
            myListing.SetTaken("available");
            System.Console.WriteLine("Please enter the ID of the trainer");
            myListing.SetTrainerID(int.Parse(Console.ReadLine()));

            myListing.SetDeleted(false);
           
            listings[Listing.GetCount()] = myListing;
            Listing.IncCount();
        }

        // saves to listings.txt

        public void Save()
        {
            StreamWriter outFile = new StreamWriter("listings.txt");

            for(int i = 0; i < Listing.GetCount(); i++)
            {
                outFile.WriteLine(listings[i].ToFile());
            }

            outFile.Close();

        }

        // finds the index where the listing is found
        private int Find(int searchVal)
        {
            for(int i = 0; i < Listing.GetCount(); i++)
            {
                if(listings[i].GetID() == searchVal)
                {
                    return i;
                }
            }
            return -1;
        }


        // finds the index of the listing based on the ID you input, then updates the content
        public void UpdateListing()
        {
            System.Console.WriteLine("What is the ID of the listing you want to update");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);
            if(foundIndex != -1)
            {
                // System.Console.WriteLine("Please enter the ID");
                // listings[foundIndex].SetID(searchVal);
                System.Console.WriteLine("Please enter the new name");
                listings[foundIndex].SetName(Console.ReadLine());
                System.Console.WriteLine("Please enter the new date");
                listings[foundIndex].SetDate(DateOnly.Parse(Console.ReadLine()));
                System.Console.WriteLine("Please enter the new time");
                listings[foundIndex].SetTime(Console.ReadLine());
                System.Console.WriteLine("Please enter the new cost");
                listings[foundIndex].SetCost(int.Parse(Console.ReadLine()));
                System.Console.WriteLine("Please enter whether the listing has been taken");
                string userInput = Console.ReadLine();
                string correctInput = ValidInputTaken(userInput);
                listings[foundIndex].SetTaken(correctInput);
                System.Console.WriteLine("Plese enter the ID of the trainer");
                listings[foundIndex].SetTrainerID(int.Parse(Console.ReadLine()));

                Save();
            }
            else
            {
                System.Console.WriteLine("Listing not found");
            }   
        }

        // checks if someone entered "available" or "talen" --> so the data isn't messed up
        static string ValidInputTaken(string userInput){
            while (userInput != "available" && userInput != "taken"){
                System.Console.WriteLine("(Please enter available or taken)");
                userInput = Console.ReadLine();
            }

            return userInput;
        }

        // soft delete--> sets deleted to true        
        public void DeleteListing(){
            System.Console.WriteLine("What is the ID of the listing you want to delete?");
            int deleteID = int.Parse(Console.ReadLine());

            listings[deleteID - 1].SetDeleted(true);
        }

        // When you delet a trainer, it deletes all the listings for that trainer-->
        // it doesn't make sense to have listings for a trainer that doesn't exist
        public void DeleteListingsForTrainer(string trainerName){
            for (int i = 0; i < Listing.GetCount(); i++){
                if (listings[i].GetName() == trainerName){
                    listings[i].SetDeleted(true);
                }
            }
            
        }

        
        // when you book a session, this sets the listing from available to taken
        public void SetListingTaken(string stringUserInput){
            int userInput = int.Parse(stringUserInput);

            // StreamWriter outFile = new StreamWriter("listings.txt");


            // outFile.Close();
            int foundIndex = Find(userInput);
            if (foundIndex != -1){
                listings[foundIndex].SetTaken("taken");
                Save();
            } else System.Console.WriteLine("Listing unable to be updated");

        }
    }
}
