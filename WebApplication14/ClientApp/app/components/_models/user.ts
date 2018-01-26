export class User{

    LoginModel(Email:string,Password:string){
        this.Email = Email;
        this.Password =  Password;
    }
    RegistrationModel(First_name:string, Last_name:string,Email:string,Password:string,ConfirmPassword:string,PlaceOfBirth:string, Year:Date){

        this.First_name = First_name;
        this.Last_name = Last_name;
        this.Email = Email; 
        this.Password = Password;
        this.ConfirmPassword = ConfirmPassword;
        this.PlaceOfBirth = PlaceOfBirth;
        this.Year = Year;
    }
    First_name:string;
    Last_name:string;
    Email:string; 
    Password:string;
    ConfirmPassword:string;
    PlaceOfBirth:string;
    Year: Date;

}