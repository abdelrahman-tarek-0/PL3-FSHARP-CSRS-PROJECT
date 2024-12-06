namespace CSRS

open System.IO
open System.Diagnostics

module TicketFile =

    let tp: string = "Tickets.txt"
    let lastIdFile: string = "LastId.txt" 

    let getLastId() =
        if File.Exists(lastIdFile) then
            let lastId = File.ReadAllText(lastIdFile)
            try
                int lastId 
            with
                | :? System.FormatException -> 0 
        else
            0

    let incrementId() =
        let newId = getLastId() + 1
        File.WriteAllText(lastIdFile, newId.ToString()) 
        newId

    let SaveTicket(seat: int, username: string) =
        if not (File.Exists(tp)) then
            File.WriteAllText(tp, "Tickets\n")
        let id = incrementId() 
        let date = TicketOperations.DateAandtTime()
        TicketOperations.addticket (string id) username date seat tp
        tp

    let openFileInDefaultProgram (filePath: string) =
        let psi = new ProcessStartInfo(filePath)
        psi.UseShellExecute <- true 
        Process.Start(psi) |> ignore

    let delete() =
        if File.Exists(tp) then
            File.Delete(tp)
