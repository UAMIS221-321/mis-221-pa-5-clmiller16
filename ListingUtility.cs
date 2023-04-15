namespace mis_221_pa_5_clmiller16
{
    public class ListingUtility
    {
        private Listing[] listings;   

        public ListingUtility(Listing[] listings){
            this.listings = listings;
        }     



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
                listings[Listing.GetCount()] = new Listing(int.Parse(temp[0]), temp[1], temp[2], temp[3], temp[4], temp[5], bool.Parse(temp[6]));
                Listing.IncCount();
                line = inFile.ReadLine();
            }


            //close
            inFile.Close();
        }

        public void AddListing(int max)
        {
            // System.Console.WriteLine("Please enter the ID");
            Listing myListing = new Listing();

            myListing.SetID(max);
            System.Console.WriteLine("Please enter the name");
            myListing.SetName(Console.ReadLine());
            System.Console.WriteLine("Please enter the date");
            myListing.SetDate(Console.ReadLine());
            System.Console.WriteLine("Please enter the time");
            myListing.SetTime(Console.ReadLine());
            System.Console.WriteLine("Please enter the cost");
            myListing.SetCost(Console.ReadLine());
            // System.Console.WriteLine("Please enter if it has been taken");
            myListing.SetTaken("available");

            myListing.SetDeleted(false);
           
            listings[Listing.GetCount()] = myListing;
            Listing.IncCount();
        }

        public void Save()
        {
            StreamWriter outFile = new StreamWriter("listings.txt");

            for(int i = 0; i < Listing.GetCount(); i++)
            {
                outFile.WriteLine(listings[i].ToFile());
            }

            outFile.Close();

        }

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

        public void UpdateListing()
        {
            System.Console.WriteLine("What is the ID of the listing you want to update");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);
            if(foundIndex != -1)
            {
                System.Console.WriteLine("Please enter the ID");
                listings[foundIndex].SetID(int.Parse(Console.ReadLine()));
                System.Console.WriteLine("Please enter the name");
                listings[foundIndex].SetName(Console.ReadLine());
                System.Console.WriteLine("Please enter the date");
                listings[foundIndex].SetDate(Console.ReadLine());
                System.Console.WriteLine("Please enter the time");
                listings[foundIndex].SetTime(Console.ReadLine());
                System.Console.WriteLine("Please enter the cost");
                listings[foundIndex].SetCost(Console.ReadLine());
                System.Console.WriteLine("Please enter whether the listing has been taken");
                listings[foundIndex].SetTaken(Console.ReadLine());

                Save();
            }
            else
            {
                System.Console.WriteLine("Listing not found");
            }   
        }

        public void DeleteListing(){
            System.Console.WriteLine("What is the ID of the listing you want to delete?");
            int deleteID = int.Parse(Console.ReadLine());

            listings[deleteID - 1].SetDeleted(true);
        }

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
