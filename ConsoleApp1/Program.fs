open System
open System.Threading
open System.Collections.Generic

printfn "Simple banking system"
Console.WriteLine("")
Console.WriteLine("Task 1")
Console.WriteLine("")
//Task 1
type Account = {AccountNumber:string; 
                mutable Balance:float;} 
                member this.Withdraw x = 
                    Console.WriteLine("|| " + x.ToString() + " has been taken out of -> Account number : " + this.AccountNumber + " || Balance : " + this.Balance.ToString() + " ||")
                    this.Balance <- this.Balance - x
                member this.Deposit x = 
                    Console.WriteLine("|| " + x.ToString() + " has been added in to -> Account number : " + this.AccountNumber + " || Balance : " + this.Balance.ToString() + " ||")
                    this.Balance <- this.Balance + x 
                member this.Print =
                    Console.WriteLine("|| Account number : " + this.AccountNumber + " || Balance : " + this.Balance.ToString() + " ||") 

let account = {AccountNumber = "0000"; Balance = 50.0}
account.Print
account.Deposit 50.0
account.Print
account.Withdraw 19.1
account.Print
account.Deposit 3.6
account.Print
account.Withdraw 100.0
account.Print

//Task 2

Console.WriteLine("")
Console.WriteLine("Task 2")
Console.WriteLine("")

let AccountCopy account = 
    match account with
    |_ when account.Balance < 10.0 -> 
        Console.WriteLine("Balance is low")
    |_ when account.Balance >= 10.0 && account.Balance<=100 -> 
        Console.WriteLine("Balance is ok")
    |_ when account.Balance > 100.0 -> 
        Console.WriteLine("Balance is high")
    |_ -> 
        Console.WriteLine("Balance is not recorded")

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

//Task 3

Console.WriteLine("")
Console.WriteLine("Task 3")
Console.WriteLine("")

let accountList  = [
    account1;
    account2;
    account3;
    account4;
    account5;
    account6;
]
let lowSequence = seq{
        for i in accountList do
            if i.Balance >= 0 then
                if i.Balance < 50 then
                    i
}

let highSequence = seq{
    for i in accountList do
        if i.Balance >50 then
            i
}

Console.WriteLine("List of accounts whose balance falls between 0 and 50")
for i in lowSequence do
    i.Print

Console.WriteLine("List of accounts whose balance exceeds 50")
for i in highSequence do
    i.Print

//Task 4

Console.WriteLine("Ticket System")
Console.WriteLine("")
Console.WriteLine("Task 4")
Console.WriteLine("")

type Ticket = {
        seat:int; customer:string}
                member this.Print = 
                    Console.WriteLine("Seat : " + (this.seat).ToString() + " || Customer : " + this.customer)
    

let mutable tickets = new List<Ticket>()

for n in 1..10 do 

    let tempTicket:Ticket = {Ticket.seat = n; Ticket.customer = ""}
    tickets.Add(tempTicket)

let DisplayTicket ticket = 
    for i in tickets do
        i.Print
        
let lockobj = new Object()

let returnValue ticket = 
    ticket

let BookSeat (customer:String) (seatNumber:int) = 
    async{
        lock lockobj (fun()->
            //let mutable ticket= List.map returnValue tickets
            let mutable ticket= new List<Ticket>()
            let mutable g = 0
            for i in tickets do
                if i.seat = seatNumber then
                    if i.customer = "" then
                        let tempTicket:Ticket = {Ticket.seat = seatNumber; Ticket.customer = customer}
                        ticket.Add(tempTicket)
                        Console.WriteLine("Seat " + i.seat.ToString() + " has been bought by " + customer)
                    else    
                        ticket.Add(tickets.Item(g))
                        Console.WriteLine("Seat unavailable")
                else 
                    ticket.Add(tickets.Item(g))
                g <- g + 1
            

            tickets <- ticket
            //ignore
        )
    }

DisplayTicket tickets

let thread1 = BookSeat "Thread 11" 3
Async.RunSynchronously thread1
let thread2 = BookSeat "Thread 13" 3
Async.RunSynchronously thread2

DisplayTicket tickets


for i in 1..10 do
    let thread = BookSeat "Admin" i
    Async.RunSynchronously thread

DisplayTicket tickets