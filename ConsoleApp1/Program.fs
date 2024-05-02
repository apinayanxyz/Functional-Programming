open System

printfn "Simple banking system"

//Task 1
type Account = {AccountNumber:string; 
                mutable Balance:float;} 
                member this.Withdraw x = this.Balance - x
                member this.Deposit x = this.Balance + x
                member this.Print =
                    Console.WriteLine("|| Account number : " + this.AccountNumber + " || Balance : " + this.Balance.ToString() + " ||") 

//Task 2

let AccountCopy account = 
    match account with
    |_ when account.Balance < 10.0 -> Console.WriteLine("Balance is low")
    |_ when account.Balance >= 10.0 && account.Balance<=100 -> Console.WriteLine("Balance is ok")
    |_ when account.Balance > 100.0 -> Console.WriteLine("Balance is high")

let account1 = {AccountNumber = "0001"; Balance = 00.0}
account1.Print
AccountCopy account1
let account2 = {AccountNumber = "0002"; Balance = 51.0}
account2.Print
AccountCopy account2
let account3 = {AccountNumber = "0003"; Balance = 5.0}
account3.Print
AccountCopy account3
let account4 = {AccountNumber = "0004"; Balance = 100.0}
account4.Print
AccountCopy account4
let account5 = {AccountNumber = "0005"; Balance = 100.5}
account5.Print
AccountCopy account5
let account6 = {AccountNumber = "0006"; Balance = 00.5}
account6.Print
AccountCopy account6