open System.Drawing
open System.Windows.Forms
open System.IO
open CSRS

[<EntryPoint>]
let main _ =
    Application.EnableVisualStyles()
    
    let form =
        LoginForm.initForm (fun username ->
            MessageBox.Show($"Welcome, {username}!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information)
            |> ignore

            TicketFile.delete()

            let seatsForm =
                SeatsForm.createForm  (fun seat ->
                        MessageBox.Show(
                            $"You have selected seat {seat}.",
                            "Seat Selected",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        )
                        TicketFile.openFileInDefaultProgram (TicketFile.SaveTicket (seat ,username))

                        |> ignore

                        SeatsStore.editSeatStatus seat SeatsStore.SeatStatus.R |> ignore
                    )
            seatsForm.Show()
        )

    Application.Run(form)

    0