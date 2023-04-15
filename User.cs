namespace mis_221_pa_5_clmiller16
{
    public class User
    {
        private string userType;

        public User(){

        }

        public User(string userType){
            this.userType = userType;
        }

        // public string GetUserType(){
        //     return User.userType;
        // }
        // public void SetUserType(string userType){
        //     User.userType = userType;
        // }

        public string GetUserType(){
            return userType;
        }
        public void SetUserType(string userType){
            this.userType = userType;
        }


    }
}