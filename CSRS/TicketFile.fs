namespace CSRS

open System.IO
open System.Diagnostics

open CSRS

module TicketFile =



    let tp: string =("Tickets.txt")
    let SaveTicket(seat:int , username:string) =
        if not (File.Exists(tp)) then
           File.WriteAllText(tp, "Tickets\n")
        let id =TicketOperations.randomString()
        let date =TicketOperations.DateAandtTime()
        TicketOperations.addticket id  username  date  seat  tp 
        tp

    let openFileInDefaultProgram (filePath: string) =
        let psi = new ProcessStartInfo(filePath)
        psi.UseShellExecute <- true 
        Process.Start(psi) |> ignore


    let delete()=
        if (File.Exists(tp)) then
           File.Delete(tp )