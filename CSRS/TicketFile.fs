namespace CSRS

open System.IO
open System.Diagnostics

open CSRS

module TicketFile =



    let tp: string =("Tickets.txt")
    let SaveTicket(seat:int , user:string) =
        if not (File.Exists(tp)) then
           File.WriteAllText(tp, "Tickets\n")
        let y =TicketOperations.randomString()
        File.AppendAllText(tp , "Ticket number "+ y+" booked for "+ user+" in seat number "+seat.ToString()+" at "+ TicketOperations.DateAandtTime()+"\n")
        //TicketOperations.addticket(y , user , TicketOperations.DateAandtTime() , seat , tp )
        tp

    let openFileInDefaultProgram (filePath: string) =
        let psi = new ProcessStartInfo(filePath)
        psi.UseShellExecute <- true 
        Process.Start(psi) |> ignore


    let delete()=
        if (File.Exists(tp)) then
           File.Delete(tp )