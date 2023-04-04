namespace mis_221_pa_5_clmiller16
{
    public class ListingReport
    {
        Listing[] listings;
        public ListingReport(Listing[] listings){
            this.listings = listings;
        }
        public void PrintAllListings(){
            for (int i = 0; i < Listing.GetCount(); i++){
                System.Console.WriteLine(listings[i].ToStringFormatted());
            }
        }

        public void IDByName(){
            string curr = listings[0].GetName();
            int count = listings[0].GetID();
            for (int i = 1; i < Listing.GetCount(); i++){
                if (listings[i].GetName() == curr){
                    count += listings[i].GetID();
                } else{
                    ProcessBreak(ref curr, ref count, listings[i]);
                }
            }
            ProcessBreak(curr, count);
        }

        public void ProcessBreak(ref string curr, ref int count, Listing newListing){
            System.Console.WriteLine($"{curr} \t{count}");
            curr = newListing.GetName();
            count = newListing.GetID();
        }

        public void ProcessBreak(string curr, int count){
            System.Console.WriteLine($"{curr} \t{count}");
        }
    }
}