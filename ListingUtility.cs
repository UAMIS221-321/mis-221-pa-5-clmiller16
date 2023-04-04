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
            Trainer.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split('#');
                //*** wordCount+=temp.Length();
                listings[Listing.GetCount()] = new Listing(int.Parse(temp[0]), temp[1], temp[2], temp[3], temp[4], temp[5]);
                Listing.IncCount();
                line = inFile.ReadLine();
            }


            //close
            inFile.Close();
        }

        public void AddListing()
        {
            System.Console.WriteLine("Please enter the ID");
            Listing myListing = new Listing();
            myListing.SetID(int.Parse(Console.ReadLine()));
            System.Console.WriteLine("Please enter the name");
            myListing.SetName(Console.ReadLine());
            System.Console.WriteLine("Please enter the date");
            myListing.SetDate(Console.ReadLine());
            System.Console.WriteLine("Please enter the time");
            myListing.SetTime(Console.ReadLine());
            System.Console.WriteLine("Please enter the cost");
            myListing.SetCost(Console.ReadLine());
            System.Console.WriteLine("Please enter if it has been taken");
            myListing.SetTaken(Console.ReadLine());
           
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

        public void UpdateTrainer()
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
                System.Console.WriteLine("Trainer not found");
            }   
        }
    }
}
