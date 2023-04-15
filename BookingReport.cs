namespace mis_221_pa_5_clmiller16
{
    public class BookingReport
    {
        Booking[] bookings;

        public BookingReport(Booking[] bookings){
            this.bookings = bookings;
        }

        public void PrintAllBookings(){
            System.Console.WriteLine();
            for (int i = 0; i < Booking.GetCount(); i++){
                System.Console.WriteLine(bookings[i].ToStringFormatted());
            }
        }

        public void SessionsForCustomer(){

            System.Console.WriteLine("What was your email?");
            string email = Console.ReadLine();

            // string curr = bookings[0].GetCustomerEmail();

            for (int i = 1; i < Booking.GetCount(); i++){
                if (bookings[i].GetCustomerEmail() == email){
                    System.Console.WriteLine(bookings[i].ToStringFormatted());
                }
            }
        }


    }
}