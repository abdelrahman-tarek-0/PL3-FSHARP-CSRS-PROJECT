namespace CSRS

open System
open System.IO

module TicketOperations =
    let DateAandtTime () =
        let now = System.DateTime.Now
        now.ToString("yyyy-MM-dd HH:mm:ss")

    let randomString () =
        let random = new Random()
        let chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        let stringChars = Array.zeroCreate<char> 8

        for i = 0 to 7 do
            stringChars.[i] <- chars.[random.Next(chars.Length)]

        new string (stringChars)

    let addticket (id: int) (username: string) (date: string) (seat: int) (filePath: string) =
        let newLine = sprintf "%d\n%s\n%s\n%d" id username date seat

        try
            File.AppendAllText(filePath, newLine)
            1
        with :? IOException as ex ->
            printfn "An error occurred while writing to the file: %s" ex.Message
            0


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
