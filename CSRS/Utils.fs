namespace Utils

open System
open System.IO

module TicketOperations =
    let DateAandtTime () = 
        let now = System.DateTime.Now
        now.ToString("yyyy-MM-dd HH:mm:ss")
   
    let addticket (id: int) (username: string) (date: string) (seat: int) (filePath: string) =
        let newLine = sprintf "%d,%s,%s,%d" id username date seat
        try
            File.AppendAllText(filePath, newLine + Environment.NewLine)
            id=id+1
            printfn "Successfully added: %s" newLine
        with
             | :? IOException as ex ->
                printfn "An error occurred while writing to the file: %s" ex.Message


    let readticket filePath =
        try
            let lines = File.ReadLines(filePath)
            let mutable linesList = []
            for line in lines do
                linesList <- line::linesList
            linesList
        with
            | :? IOException as ex ->
                printfn "An error occurred while writing to the file: %s" ex.Message
                []