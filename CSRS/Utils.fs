namespace CSRS

open System
open System.IO

module TicketOperations =
    let DateAandtTime () =
        let now = System.DateTime.Now
        now.ToString("yyyy-MM-dd HH:mm:ss")

    let addticket (id: string) (username: string) (date: string) (seat: int) (filePath: string) =
 
        File.AppendAllText(filePath , "Ticket ID: "+ id+" booked for "+ username+" in seat number "+seat.ToString()+" at "+ date+"\n")
     


    let readticket filePath =
        try
            let lines = File.ReadLines(filePath)
            let mutable linesList = []

            for line in lines do
                linesList <- line :: linesList

            linesList
        with :? IOException as ex ->
            printfn "An error occurred while writing to the file: %s" ex.Message
            []
